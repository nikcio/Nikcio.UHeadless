using HotChocolate;
using Microsoft.AspNetCore.Http;
using Umbraco.Forms.Web.Controllers.Api;

namespace Nikcio.UHeadless.Umbraco.Forms.Queries;

/// <summary>
/// Queries for Umbraco Forms
/// </summary>
/// <remarks><see cref="DefinitionsController"/></remarks>
public class UmbracoFormsQuery
{
    /// <summary>
    /// Retrieves a single form by Id.
    /// </summary>
    /// <param name="httpClientFactory"></param>
    /// <param name="httpContextAccessor"></param>
    /// <param name="id"></param>
    /// <param name="contentId"></param>
    /// <returns></returns>
    [GraphQLDescription("Retrieves a single form by Id.")]
    public async Task<FormDto?> GetFormsDefintionById([Service] IHttpContextAccessor httpContextAccessor, [Service] IHttpClientFactory httpClientFactory, Guid id, string? contentId = null)
    {
        if (httpContextAccessor.HttpContext == null)
        {
            throw new InvalidOperationException("Unable to get HttpContext");
        }

        var client = new UmbracoFormsClient($"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}", httpClientFactory.CreateClient());

        return await client.DefinitionsGetByIdAsync(id, contentId);
    }
}
