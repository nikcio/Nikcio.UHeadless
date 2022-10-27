using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChocolate;
using Umbraco.Forms.Web.Controllers.Api;
using Umbraco.Forms.Web.Models.Api;

namespace Nikcio.UHeadless.Umbraco.Forms.Mutations;

/// <summary>
/// Mutations for Umbraco Forms
/// </summary>
public class UmbracoFormsMutation
{
    /// <summary>
    /// Processes a submission for a form.
    /// </summary>
    /// <param name="entriesController"></param>
    /// <param name="id"></param>
    /// <param name="entry"></param>
    /// <returns></returns>
    [GraphQLDescription("Processes a submission for a form.")]
    public async Task<bool> SubmitEntry([Service] EntriesController entriesController, Guid id, FormEntryDto entry)
    {
        await entriesController.SubmitEntry(id, entry);
        return true;
    }
}
