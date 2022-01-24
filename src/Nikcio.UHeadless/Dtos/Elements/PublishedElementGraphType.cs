using Nikcio.UHeadless.Dtos.ContentTypes;
using System;

namespace Nikcio.UHeadless.Dtos.Elements
{
    public class PublishedElementGraphType : IPublishedElementGraphType
    {
        public PublishedContentTypeGraphType ContentType { get; set; }

        public Guid Key { get; set; }
    }
}
