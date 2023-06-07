using System.Collections.Generic;
using Examples.Docs.Properties;
using HotChocolate.Data;
using HotChocolate;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Members.Basics.Models;
using Nikcio.UHeadless.Members.Commands;
using Nikcio.UHeadless.Members.Models;

namespace Examples.Docs.Members;

public class MyMember : BasicMember
{
    public string MyCustomValue { get; set; }

    public MyMember(CreateMember createMember, IPropertyFactory<BasicProperty> propertyFactory) : base(createMember, propertyFactory)
    {
        MyCustomValue = "Custom Value";
    }
}

public class MyMemberWithMyProperty : BasicMember<MyProperty>
{
    public string MyCustomValue { get; set; }

    public MyMemberWithMyProperty(CreateMember createMember, IPropertyFactory<MyProperty> propertyFactory) : base(createMember, propertyFactory)
    {
        MyCustomValue = "Custom Value";
    }
}

public class MyMemberFromScratch : Member<BasicProperty>
{
    public string MyCustomValue { get; set; }

    /// <inheritdoc/>
    [GraphQLDescription("Gets the properties of the element.")]
    [UseFiltering]
    public virtual IEnumerable<BasicProperty?>? Properties => Content != null ? PropertyFactory.CreateProperties(Content, Culture, Segment, Fallback) : default;

    public MyMemberFromScratch(CreateMember createMember, IPropertyFactory<BasicProperty> propertyFactory) : base(createMember, propertyFactory)
    {
        MyCustomValue = "Custom Value";
    }
}
