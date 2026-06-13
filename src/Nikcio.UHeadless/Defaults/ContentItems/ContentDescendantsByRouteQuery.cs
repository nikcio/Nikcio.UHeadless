using HotChocolate.Authorization;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.ContentItems;
using Nikcio.UHeadless.Defaults.Authorization;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Defaults.ContentItems;

[ExtendObjectType(typeof(HotChocolateQueryObject))]
public class ContentDescendantsByRouteQuery : ContentDescendantsByRouteQuery<ContentItem>
{
    protected override ContentItem? CreateContentItem(IPublishedContent publishedContent, IContentItemRepository<ContentItem> contentItemRepository, IResolverContext resolverContext)
    {
        ArgumentNullException.ThrowIfNull(contentItemRepository);

        return contentItemRepository.GetContentItem(new ContentItem.CreateCommand()
        {
            PublishedContent = publishedContent,
            ResolverContext = resolverContext,
            Redirect = null,
            StatusCode = StatusCodes.Status200OK
        });
    }
}

/// <summary>
/// Implements the <see cref="ContentDescendantsByRouteAsync" /> query
/// </summary>
public abstract class ContentDescendantsByRouteQuery<TContentItem> : IGraphQLQuery
    where TContentItem : ContentItemBase
{
    public const string PolicyName = "ContentDescendantsByRouteQuery";

    public const string ClaimValue = "content.descendants.by.route.query";

    [GraphQLIgnore]
    public virtual void ApplyConfiguration(UHeadlessOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        options.UmbracoBuilder.Services.AddAuthorizationBuilder().AddPolicy(PolicyName, policy =>
        {
            if (options.DisableAuthorization)
            {
                policy.AddRequirements(new AlwaysAllowAuthoriaztionRequirement());
                return;
            }

            policy.AddAuthenticationSchemes(DefaultAuthenticationSchemes.UHeadless);

            policy.RequireAuthenticatedUser();

            policy.RequireClaim(DefaultClaims.UHeadlessScope, ClaimValue, DefaultClaimValues.GlobalContentRead);
        });

        AvailableClaimValue availableClaimValue = new()
        {
            Name = DefaultClaims.UHeadlessScope,
            Values = [ClaimValue, DefaultClaimValues.GlobalContentRead]
        };
        AuthorizationTokenProvider.AddAvailableClaimValue(ClaimValueGroups.Content, availableClaimValue);
    }

    /// <summary>
    /// Gets content item descendants by an absolute route
    /// </summary>
    [Authorize(Policy = PolicyName)]
    [GraphQLName("contentDescendantsByRoute")]
    [GraphQLDescription("Gets content item descendants by a route.")]
    public virtual async Task<PaginationResult<TContentItem?>> ContentDescendantsByRouteAsync(
        IResolverContext resolverContext,
        [GraphQLDescription("The route to fetch descendants from. Example '/da/frontpage/'.")] string route,
        [GraphQLDescription("Filter descendants by content type alias.")] string? contentType = null,
        [GraphQLDescription("How many items to include in a page. Defaults to 10.")] int pageSize = 10,
        [GraphQLDescription("The page number to fetch. Defaults to 1.")] int page = 1,
        [GraphQLDescription("The context of the request.")] QueryContext? inContext = null)
    {
        ArgumentNullException.ThrowIfNull(resolverContext);
        ArgumentException.ThrowIfNullOrEmpty(route);

        if (contentType != null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(contentType);
        }

        inContext ??= new QueryContext();
        if (!inContext.Initialize(resolverContext))
        {
            throw new InvalidOperationException("The context could not be initialized");
        }

        IContentItemRepository<TContentItem> contentItemRepository = resolverContext.Service<IContentItemRepository<TContentItem>>();
        IEnumerable<IPublishedContent> descendants;

        if (inContext.IncludePreview != true)
        {
            descendants = await GetContentDescendantsFromRouteAsync(resolverContext, route, inContext.BaseUrl, inContext.Culture).ConfigureAwait(false);
        }
        else
        {
            IDocumentUrlService documentUrlService = resolverContext.Service<IDocumentUrlService>();
            IPublishedContentCache? contentCache = contentItemRepository.GetCache();

            if (contentCache == null)
            {
                throw new InvalidOperationException("The content cache is not available");
            }

            Guid? contentKey = documentUrlService.GetDocumentKeyByRoute(route, inContext.Culture, null, inContext.IncludePreview.Value);
            if (contentKey == null)
            {
                descendants = [];
            }
            else
            {
                IPublishedContent? publishedContent = contentCache.GetById(inContext.IncludePreview.Value, contentKey.Value);
                descendants = publishedContent?.Descendants(inContext.Culture) ?? [];
            }
        }

        descendants = FilterDescendantsByContentType(resolverContext, descendants, contentType);

        IEnumerable<TContentItem?> resultItems = descendants.Select(contentItem => CreateContentItem(contentItem, contentItemRepository, resolverContext));

        return new PaginationResult<TContentItem?>(resultItems, page, pageSize);
    }

    protected abstract TContentItem? CreateContentItem(IPublishedContent publishedContent, IContentItemRepository<TContentItem> contentItemRepository, IResolverContext resolverContext);

    protected async Task<IEnumerable<IPublishedContent>> GetContentDescendantsFromRouteAsync(IResolverContext resolverContext, string route, string baseUrl, string? culture)
    {
        ArgumentNullException.ThrowIfNull(resolverContext);

        IPublishedRequest contentRequest = await GetContentRequestAsync(resolverContext, route, baseUrl).ConfigureAwait(false);

        return contentRequest.GetRouteResult() switch
        {
            UmbracoRouteResult.Success => contentRequest.PublishedContent?.Descendants(culture) ?? [],
            UmbracoRouteResult.Redirect => [],
            UmbracoRouteResult.NotFound => [],
            _ => throw new InvalidOperationException("The route result is not valid")
        };
    }

    protected async Task<IPublishedRequest> GetContentRequestAsync(IResolverContext resolverContext, string route, string baseUrl)
    {
        ArgumentNullException.ThrowIfNull(resolverContext);

        IPublishedRouter publishedRouter = resolverContext.Service<IPublishedRouter>();
        IHttpContextAccessor? httpContextAccessor = resolverContext.Service<IHttpContextAccessor>();

        baseUrl = SetBaseUrl(httpContextAccessor, baseUrl);

        var uri = new Uri($"{baseUrl.TrimEnd('/')}{route}");

        IPublishedRequestBuilder builder = await publishedRouter.CreateRequestAsync(uri).ConfigureAwait(false);
        IPublishedRequest request = await publishedRouter.RouteRequestAsync(builder, new RouteRequestOptions(RouteDirection.Inbound)).ConfigureAwait(false);

        return request;
    }

    private static IEnumerable<IPublishedContent> FilterDescendantsByContentType(IResolverContext resolverContext, IEnumerable<IPublishedContent> descendants, string? contentType)
    {
        if (contentType == null)
        {
            return descendants;
        }

        return descendants.Where(content => string.Equals(content.ContentType.Alias, contentType, StringComparison.OrdinalIgnoreCase));
    }

    private static string SetBaseUrl(IHttpContextAccessor httpContextAccessor, string baseUrl)
    {
        if (string.IsNullOrWhiteSpace(baseUrl))
        {
            if (httpContextAccessor == null || httpContextAccessor.HttpContext == null)
            {
                throw new HttpRequestException("HttpContext could not be found");
            }

            baseUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host.Host}";

            if (httpContextAccessor.HttpContext.Request.Host.Port is not 80 and not 443)
            {
                baseUrl += $":{httpContextAccessor.HttpContext.Request.Host.Port}";
            }
        }

        return baseUrl;
    }
}
