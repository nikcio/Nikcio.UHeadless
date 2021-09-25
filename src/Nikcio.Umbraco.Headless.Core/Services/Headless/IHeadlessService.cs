using Nikcio.Umbraco.Headless.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Services
{
    public interface IHeadlessService
    {
        IUmbracoContentRepository HeadlessRepository { get; }
        object GetData(string route);
    }
}
