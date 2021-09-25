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
    public class HeadlessService : IHeadlessService
    {
        private readonly IPageDataFactory pageDataFactory;

        public HeadlessService(IUmbracoContentRepository headlessRepository, IPageDataFactory pageDataFactory)
        {
            HeadlessRepository = headlessRepository;
            this.pageDataFactory = pageDataFactory;
        }

        public IUmbracoContentRepository HeadlessRepository { get; }

        public object GetData(string route)
        {
            var content = HeadlessRepository.GetContentAtRoute(route);
            return JsonConvert.SerializeObject(new BaseDataModel() { Content = new BasePageModel(content, null, pageDataFactory) }, new JsonSerializerSettings() { ContractResolver = new DefaultHeadlessResolver()});
        }
    }

}
