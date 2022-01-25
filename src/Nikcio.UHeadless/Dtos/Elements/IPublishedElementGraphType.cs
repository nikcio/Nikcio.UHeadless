using HotChocolate;
using HotChocolate.Types;
using Nikcio.UHeadless.Dtos.ContentTypes;
using Nikcio.UHeadless.Dtos.Propreties;
using System;
using System.Collections.Generic;

namespace Nikcio.UHeadless.Dtos.Elements
{
    public interface IPublishedElementGraphType
    {
        PublishedContentTypeGraphType ContentType { get; set; }

        Guid Key { get; set; }

        public List<PublishedPropertyGraphType> Properties { get; set; }
    }

}
