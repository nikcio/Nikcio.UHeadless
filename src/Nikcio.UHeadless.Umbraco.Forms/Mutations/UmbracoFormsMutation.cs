using System.Collections.ObjectModel;
using HotChocolate;
using Microsoft.AspNetCore.Http;
using Nikcio.UHeadless.Umbraco.Forms.Models;

namespace Nikcio.UHeadless.Umbraco.Forms.Mutations;

/// <summary>
/// Mutations for Umbraco Forms
/// </summary>
public class UmbracoFormsMutation
{
    /// <summary>
    /// Processes a submission for a form.
    /// </summary>
    /// <param name="httpClientFactory"></param>
    /// <param name="httpContextAccessor"></param>
    /// <param name="id"></param>
    /// <param name="entry"></param>
    /// <returns></returns>
    [GraphQLDescription("Processes a submission for a form.")]
    public async Task<SubmitFormEntryResponse> SubmitFormEntry([Service] IHttpContextAccessor httpContextAccessor, [Service] IHttpClientFactory httpClientFactory, Guid id, global::Umbraco.Forms.Web.Models.Api.FormEntryDto entry)
    {
        if (httpContextAccessor.HttpContext == null)
        {
            return new SubmitFormEntryResponse("Failure", "Failed to get HttpContext");
        }

        var client = new UmbracoFormsClient($"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}", httpClientFactory.CreateClient());

        var convertedEntry = new FormEntryDto()
        {
            Values = entry.Values.ToDictionary(value => value.Key, value => new Collection<string>(value.Value) as ICollection<string>),
            ContentId = entry.ContentId
        };
        await client.EntriesSubmitEntryAsync(id, convertedEntry);

        return new SubmitFormEntryResponse("Success", "Form submitted");
    }
}
