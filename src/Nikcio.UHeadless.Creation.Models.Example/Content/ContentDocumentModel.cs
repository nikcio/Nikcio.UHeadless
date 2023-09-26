using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Factories;
using Nikcio.UHeadless.Content.Models;
using Nikcio.UHeadless.Content.Router;
using Nikcio.UHeadless.ContentTypes.Factories;
using Nikcio.UHeadless.Creation.Models.Example.Properties;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Creation.Models.Example.Content;

/// <summary>
/// Represents a content item
/// </summary>
public class ContentDocumentModel : UHeadless.Content.Models.Content, IRedirectableEntity<ContentDocumentRedirectModel>
{
    /// <inheritdoc/>
    public ContentDocumentModel(CreateContent createContent, IPropertyFactory<PropertyModel> propertyFactory, IContentTypeFactory<ContentTypeModel> contentTypeFactory, IContentFactory<ContentDocumentModel> contentFactory, IVariationContextAccessor variationContextAccessor, ILogger<ContentDocumentModel> logger) : base(createContent)
    {
        ContentFactory = contentFactory;
        PropertyFactory = propertyFactory;
        ContentTypeFactory = contentTypeFactory;
        variationContextAccessor.VariationContext = new VariationContext(Culture);
        VariationContextAccessor = variationContextAccessor;

        if (createContent.Content == null)
        {
            throw new ArgumentNullException(nameof(createContent), "Content is null.");
        }

        Id = createContent.Content.Id;
        Url = createContent.Content.Url(Culture, UrlMode.Default);
        AbsoluteUrl = createContent.Content.Url(Culture, UrlMode.Absolute);
        Name = createContent.Content.Name(VariationContextAccessor, Culture);
        ContentType = ContentTypeFactory.CreateContentType(createContent.Content.ContentType);
        Properties = PropertyFactory.CreateProperties(createContent.Content, Culture, Segment, Fallback).Where(property =>
        {
            if (property == null)
            {
                logger.LogWarning("Property is null on content.");
            }
            return property != null;
        }).OfType<PropertyModel>().ToDictionary(x => x.Alias, x => x);
    }

    /// <summary>
    /// Gets the unique identifier of the content item
    /// </summary>
    public virtual int Id { get; }

    /// <summary>
    /// Gets the name of the content item for the current culture
    /// </summary>
    public virtual string Name { get; }

    /// <summary>
    /// Gets the url of the content item
    /// </summary>
    public virtual string Url { get; }

    /// <summary>
    /// Gets the absolute url of the content item
    /// </summary>
    public virtual string AbsoluteUrl { get; }

    /// <summary>
    /// The culture of the content item
    /// </summary>
    public new string? Culture => base.Culture;

    /// <summary>
    /// Redirect information
    /// </summary>
    /// <remarks>
    /// Will be set by the <see cref="IContentRouter{TContent, TContentRedirect}"/> if used.
    /// </remarks>
    public virtual ContentDocumentRedirectModel? Redirect { get; set; }

    /// <inheritdoc/>
    public virtual ContentTypeModel? ContentType { get; }

    /// <inheritdoc/>
    public virtual Dictionary<string, PropertyModel> Properties { get; }

    /// <summary>
    /// The content factory
    /// </summary>
    protected virtual IContentFactory<ContentDocumentModel> ContentFactory { get; }

    /// <summary>
    /// The property factory
    /// </summary>
    protected virtual IPropertyFactory<PropertyModel> PropertyFactory { get; }

    /// <summary>
    /// The content type factory
    /// </summary>
    protected virtual IContentTypeFactory<ContentTypeModel> ContentTypeFactory { get; }

    /// <summary>
    /// The variation context accessor
    /// </summary>
    /// <value></value>
    protected virtual IVariationContextAccessor VariationContextAccessor { get; }
}
