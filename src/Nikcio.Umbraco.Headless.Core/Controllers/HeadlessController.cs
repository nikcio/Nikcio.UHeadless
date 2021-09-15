using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
            var data = headlessService.GetData(route);
            return new OkObjectResult(data);
        }
    }

    public interface IHeadlessService
    {
        IPublishedContent GetContentAtRoute(string route, bool preview = false, string culture = null);
        object GetData(string route);
    }

    public class HeadlessService : IHeadlessService
    {
        private readonly IUmbracoContext _umbracoContext;

        public HeadlessService(IUmbracoContextAccessor umbracoContextAccessor)
        {
            umbracoContextAccessor.TryGetUmbracoContext(out _umbracoContext);
        }

        public virtual IPublishedContent GetContentAtRoute(string route, bool preview = false, string culture = null)
        {
            return _umbracoContext.Content.GetByRoute(preview, route, culture: culture);
        }

        public object GetData(string route)
        {
            var content = GetContentAtRoute(route);
            var list = new List<IPropertyOutputInformation>();

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new BlockContractResolver()
            };
            
            foreach (var prop in content.Properties)
            {
                if(prop.PropertyType.EditorAlias == Constants.PropertyEditors.Aliases.BlockList)
                {
                    var raw = prop.GetValue();
                    list.Add(new PropertyOutputInformation(prop.Alias, JsonConvert.SerializeObject(prop.GetValue(), settings)));
                }
                else
                {
                    list.Add(new PropertyOutputInformation(prop.Alias, prop.GetValue()));
                }
            }

            return list;
        }
    }

    public class BlockContractResolver : DefaultContractResolver
    {
        private readonly List<Type> IgnoredPropertyTypes = new()
        {
            typeof(IPublishedProperty),
            typeof(IPublishedPropertyType)
        };

        protected override IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
        {
            var propertiesList = base.CreateProperties(type, memberSerialization);
            return propertiesList.Where(p => !IgnoredPropertyTypes.Any(ignored => ignored == p.PropertyType)).ToList();
        }
    }

    public class HeadlessComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddScoped<IHeadlessService, HeadlessService>();
        }
    }

    public interface IPropertyOutputInformation
    {
        string Alias { get; set; }
        object Value { get; set; }
    }

    public class PropertyOutputInformation : IPropertyOutputInformation
    {
        public PropertyOutputInformation(string alias, object value)
        {
            Alias = alias;
            Value = value;
        }

        public string Alias { get; set; }
        public object Value { get; set; }
    }
}
