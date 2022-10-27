using System.Collections;
using HotChocolate;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core;
using Umbraco.Forms.Core.Models;
using Umbraco.Forms.Core.Services;
using Umbraco.Forms.Web.Controllers.Api;
using Umbraco.Forms.Web.Factories.Api;
using Umbraco.Forms.Web.Models.Api;

namespace Nikcio.UHeadless.Umbraco.Forms.Queries;

/// <summary>
/// Queries for Umbraco Forms
/// </summary>
public class UmbracoFormsQuery
{
    private readonly IFormService _formService;
    private readonly IEntityService _entityService;
    private readonly IPageService _pageService;

    /// <inheritdoc/>
    public UmbracoFormsQuery(IFormService formService, IEntityService entityService, IPageService pageService)
    {
        _formService = formService;
        _entityService = entityService;
        _pageService = pageService;
    }

    /// <summary>
    /// Retrieves a single form by Id.
    /// </summary>
    /// <param name="formDtoFactory"></param>
    /// <param name="id"></param>
    /// <param name="contentId"></param>
    /// <returns></returns>
    [GraphQLDescription("Retrieves a single form by Id.")]
    public FormDto? GetDefintionById([Service] FormDtoFactory formDtoFactory, Guid id, string? contentId = null)
    {
        Form? form = _formService.Get(id);
        if (form == null)
        {
            return null;
        }

        Hashtable contentPageElements = GetContentPageElements(contentId);
        return formDtoFactory.BuildFormDefinitionDto(form, contentPageElements);
    }

    /// <summary>
    /// Gets content page elements
    /// </summary>
    /// <param name="contentId"></param>
    /// <returns></returns>
    protected Hashtable GetContentPageElements(string? contentId)
    {
        if (string.IsNullOrEmpty(contentId))
        {
            return new Hashtable();
        }

        if (int.TryParse(contentId, out var result))
        {
            return _pageService.GetPageElements(result);
        }

        if (Guid.TryParse(contentId, out var result2))
        {
            Attempt<int> id = _entityService.GetId(result2, UmbracoObjectTypes.Document);
            if (id.Success)
            {
                return _pageService.GetPageElements(id.Result);
            }
        }

        return new Hashtable();
    }
}
