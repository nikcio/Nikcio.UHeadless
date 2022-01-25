using System;
using System.Collections.Generic;
using Nikcio.UHeadless.Models.Dtos.Propreties;
using Nikcio.UHeadless.Models.Dtos.ContentTypes;

namespace Nikcio.UHeadless.Models.Dtos.Elements
{
    public class PublishedElementGraphType : IPublishedElementGraphType
    {
        public PublishedContentTypeGraphType ContentType { get; set; }

        public Guid Key { get; set; }

        public List<PublishedPropertyGraphType> Properties { get; set; }
    }
}
