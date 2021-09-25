using Microsoft.AspNetCore.Mvc;
using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages.PageData;
using Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages.PageData;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels.PropertyModels;
using Nikcio.Umbraco.Headless.Core.Services.Headless;
using System;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Web.Common.Attributes;
using Umbraco.Cms.Web.Common.Controllers;

namespace TestProject.Controllers
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

    public class TestComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            PropertyMapper.AddMapping(Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MediaPicker3, x => new NewTestClass(x));
        }
    }

    public class NewTestClass : PropertyModel
    {
        public string CustomValue { get; set; }

        public NewTestClass(ICreatePropertyCommandBase createPropertyCommandBase) : base(createPropertyCommandBase)
        {
            CustomValue = DateTime.Now.ToLongDateString();
        }
    }
}
