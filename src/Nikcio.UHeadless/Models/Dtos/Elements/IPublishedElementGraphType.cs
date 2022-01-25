using Nikcio.UHeadless.Models.Dtos.ContentTypes;
using Nikcio.UHeadless.Models.Dtos.Propreties;
using System;
using System.Collections.Generic;

namespace Nikcio.UHeadless.Models.Dtos.Elements
{
    public interface IPublishedElementGraphType
    {
        PublishedContentTypeGraphType ContentType { get; set; }

        Guid Key { get; set; }

        public List<PublishedPropertyGraphType> Properties { get; set; }
    }

}
