using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Nikcio.Umbraco.Headless.Core.Controllers;
using Nikcio.Umbraco.Headless.Core.Factories;
using Nikcio.Umbraco.Headless.Core.Json;
using Nikcio.Umbraco.Headless.Core.Models;
using Nikcio.Umbraco.Headless.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace Nikcio.Umbraco.Headless.Core.Services
{
    public class HeadlessComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddScoped<IHeadlessService, HeadlessService>();
        }
    }

    public class HeadlessService : IHeadlessService
    {
        private readonly IPageDataFactory pageDataFactory;

        public HeadlessService(IHeadlessRepository headlessRepository, IPageDataFactory pageDataFactory)
        {
            HeadlessRepository = headlessRepository;
            this.pageDataFactory = pageDataFactory;
        }

        public IHeadlessRepository HeadlessRepository { get; }

        public object GetData(string route)
        {
            var content = HeadlessRepository.GetContentAtRoute(route);
            return JsonConvert.SerializeObject(new BaseDataModel() { Content = new BasePageModel(content, null, pageDataFactory) }, new JsonSerializerSettings() { ContractResolver = new DefaultHeadlessResolver(), ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            //var list = new List<IPropertyOutputInformation>();

            //var settings = new JsonSerializerSettings()
            //{
            //    ContractResolver = new DefaultHeadlessResolver()
            //};

            //foreach (var prop in content.Properties)
            //{
            //    if(prop.PropertyType.EditorAlias == Constants.PropertyEditors.Aliases.BlockList)
            //    {
            //        var raw = prop.GetValue();
            //        list.Add(new PropertyOutputInformation(prop.Alias, JsonConvert.SerializeObject(prop.GetValue(), settings)));
            //    }
            //    else
            //    {
            //        list.Add(new PropertyOutputInformation(prop.Alias, prop.GetValue()));
            //    }
            //}

            //return list;
        }
    }

}
