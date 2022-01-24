using Nikcio.UHeadless.Dtos.ContentTypes;
using System;

namespace Nikcio.UHeadless.Dtos.Elements
{
    public interface IPublishedElementGraphType
    {
        PublishedContentTypeGraphType ContentType { get; set; }

        Guid Key { get; set; }
    }

}
