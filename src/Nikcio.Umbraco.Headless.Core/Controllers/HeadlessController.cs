using Microsoft.AspNetCore.Mvc;
using Nikcio.Umbraco.Headless.Core.Services;
using Umbraco.Cms.Web.Common.Attributes;
using Umbraco.Cms.Web.Common.Controllers;

namespace Nikcio.Umbraco.Headless.Core.Controllers
{
    [PluginController("headlessapi")]
    public class HeadlessController : UmbracoApiController
    {
        private readonly IHeadlessService headlessService;

        public HeadlessController(IHeadlessService headlessService)
        {
            this.headlessService = headlessService;
        }

        public virtual IActionResult GetData(string route)
        {
            return new OkObjectResult(headlessService.GetData(route));
        }
    }
}
