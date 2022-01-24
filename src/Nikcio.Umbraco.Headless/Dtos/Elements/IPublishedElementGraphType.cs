using Nikcio.Umbraco.Headless.Dtos.ContentTypes;
using System;

namespace Nikcio.Umbraco.Headless.Dtos.Elements
{
    public interface IPublishedElementGraphType
    {
        PublishedContentTypeGraphType ContentType { get; set; }

        Guid Key { get; set; }
    }

}
