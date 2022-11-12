using HotChocolate;
using Microsoft.AspNetCore.Http;
using Nikcio.UHeadless.Umbraco.Forms.Mutations;

namespace Nikcio.UHeadless.Umbraco.Forms.Models;

/// <summary>
/// Represents a <see cref="UmbracoFormsMutation.SubmitFormEntry(IHttpContextAccessor, IHttpClientFactory, Guid, FormEntryDto)"/> response
/// </summary>
[GraphQLDescription("Represents a submit form entry response")]
public class SubmitFormEntryResponse
{
    /// <inheritdoc/>
    public SubmitFormEntryResponse(string type, string message)
    {
        Type = type;
        Message = message;
    }

    /// <summary>
    /// The type of response
    /// </summary>
    /// <remarks>For example "Success", "Failure"</remarks>
    [GraphQLDescription("The type of response")]
    public string Type { get; set; }

    /// <summary>
    /// The message of the response
    /// </summary>
    [GraphQLDescription("The message of the response")]
    public string Message { get; set; }
}
