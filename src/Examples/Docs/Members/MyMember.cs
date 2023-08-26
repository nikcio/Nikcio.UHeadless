﻿using System.Collections.Generic;
using Examples.Docs.Properties;
using HotChocolate;
using HotChocolate.Data;
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

public class MyMemberFromScratch : Member
{
    public string MyCustomValue { get; set; }

    /// <inheritdoc/>
    [GraphQLDescription("Gets the properties of the element.")]
    [UseFiltering]
    public virtual IEnumerable<BasicProperty?>? Properties => Content != null ? PropertyFactory.CreateProperties(Content, Culture, Segment, Fallback) : default;

    protected virtual IPropertyFactory<BasicProperty> PropertyFactory { get; }

    public MyMemberFromScratch(CreateMember createMember, IPropertyFactory<BasicProperty> propertyFactory) : base(createMember)
    {
        MyCustomValue = "Custom Value";
        PropertyFactory = propertyFactory;
    }
}
