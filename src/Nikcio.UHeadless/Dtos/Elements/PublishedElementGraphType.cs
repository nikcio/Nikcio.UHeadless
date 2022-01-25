using HotChocolate.Types;
using HotChocolate;
using Nikcio.UHeadless.Dtos.ContentTypes;
using Nikcio.UHeadless.Dtos.Propreties;
using System;
using System.Collections.Generic;

namespace Nikcio.UHeadless.Dtos.Elements
{
    public class PublishedElementGraphType : IPublishedElementGraphType
    {
        public PublishedContentTypeGraphType ContentType { get; set; }

        public Guid Key { get; set; }

        public List<PublishedPropertyGraphType> Properties { get; set; }
    }
}
