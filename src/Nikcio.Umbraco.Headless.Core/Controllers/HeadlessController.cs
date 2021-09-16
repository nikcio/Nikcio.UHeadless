using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nikcio.Umbraco.Headless.Core.Json;
using Nikcio.Umbraco.Headless.Core.Models;
using Nikcio.Umbraco.Headless.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Attributes;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.UmbracoContext;

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
