using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Maps;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Base.TypeModules;
using Nikcio.UHeadless.Core.Extensions;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;

namespace Nikcio.UHeadless.Content.TypeModules;

/// <summary>
/// A module to create models to fetch properties based on content types
/// </summary>
public class ContentTypeModule : UmbracoTypeModuleBase<IContentType, INamedContentProperties>
{
    private readonly IContentTypeService _contentTypeService;

    /// <inheritdoc/>
    public ContentTypeModule(IContentTypeService contentTypeService, IPropertyMap propertyMap) : base(propertyMap)
    {
        _contentTypeService = contentTypeService;
    }

    /// <inheritdoc/>
    protected override IEnumerable<IContentType> GetContentTypes()
    {
        return _contentTypeService.GetAll();
    }
}