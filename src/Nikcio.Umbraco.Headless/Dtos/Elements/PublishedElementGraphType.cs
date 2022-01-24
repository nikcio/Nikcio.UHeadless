using Nikcio.Umbraco.Headless.Dtos.ContentTypes;
using System;

namespace Nikcio.Umbraco.Headless.Dtos.Elements
{
    public class PublishedElementGraphType : IPublishedElementGraphType
    {
        public PublishedContentTypeGraphType ContentType { get; set; }

        public Guid Key { get; set; }
    }
}
