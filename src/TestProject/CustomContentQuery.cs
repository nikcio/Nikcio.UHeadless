using HotChocolate.Types;
using Nikcio.UHeadless.Queries;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoContent.Content.Queries;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;

namespace TestProject
{
    [ExtendObjectType(typeof(Query))]
    public class CustomContentQuery : ContentQueryBase<CustomContentGraphType<PropertyGraphType>, PropertyGraphType>
    {

    }

    public class CustomContentGraphType<TPropertyGraphType> : ContentGraphType<TPropertyGraphType>
        where TPropertyGraphType : IPropertyGraphTypeBase
    {
        public string MyCustomString => "Custom string";
    }
}