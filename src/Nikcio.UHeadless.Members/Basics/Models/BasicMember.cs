﻿using HotChocolate;
using HotChocolate.Resolvers;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Members.Commands;
using Nikcio.UHeadless.Members.Models;
using Nikcio.UHeadless.Members.TypeModules;

namespace Nikcio.UHeadless.Members.Basics.Models;

/// <summary>
/// Represents a member
/// </summary>
public class BasicMember : BasicMember<BasicProperty>
{
    /// <inheritdoc/>
    public BasicMember(CreateMember createMember, IPropertyFactory<BasicProperty> propertyFactory) : base(createMember, propertyFactory)
    {
    }
}

/// <summary>
/// Represents a member
/// </summary>
public class BasicMember<TProperty> : Member
    where TProperty : IProperty
{
    /// <inheritdoc/>
    public BasicMember(CreateMember createMember, IPropertyFactory<TProperty> propertyFactory) : base(createMember)
    {
        PropertyFactory = propertyFactory;
    }

    /// <summary>
    /// The member id
    /// </summary>
    [GraphQLDescription("The member id")]
    public int? Id => MemberItem?.Id;

    /// <summary>
    /// The member parent id
    /// </summary>
    [GraphQLDescription("The member parent id")]
    public int? ParentId => MemberItem?.Parent?.Id;

    /// <summary>
    /// The member content type id
    /// </summary>
    [GraphQLDescription("The member content type id")]
    public int? ContentTypeId => MemberItem?.ContentType.Id;

    /// <summary>
    /// The member content type alias
    /// </summary>
    [GraphQLDescription("The member content type alias")]
    public string? ContentTypeAlias => MemberItem?.ContentType.Alias;

    /// <summary>
    /// The member create date
    /// </summary>
    [GraphQLDescription("The member create date")]
    public DateTime? CreateDate => MemberItem?.CreateDate;

    /// <summary>
    /// The member creator id
    /// </summary>
    [GraphQLDescription("The member creator id")]
    public int? CreatorId => MemberItem?.CreatorId;

    /// <summary>
    /// The member key
    /// </summary>
    [GraphQLDescription("The member key")]
    public Guid? Key => MemberItem?.Key;

    /// <summary>
    /// The member level
    /// </summary>
    [GraphQLDescription("The member level")]
    public int? Level => MemberItem?.Level;

    /// <summary>
    /// The member name
    /// </summary>
    [GraphQLDescription("The member name")]
    public string? Name => MemberItem?.Name;

    /// <summary>
    /// The members path
    /// </summary>
    [GraphQLDescription("The members path")]
    public string? Path => MemberItem?.Path;

    /// <summary>
    /// The members properties
    /// </summary>
    [GraphQLDescription("The members properties")]
    public virtual IEnumerable<TProperty?>? Properties => MemberItem != null ? PropertyFactory.CreateProperties(MemberItem, Culture, Segment, Fallback) : default;

    /// <summary>
    /// Gets the named properties of the element using the member types in Umbraco
    /// </summary>
    [GraphQLDescription("Gets the named properties of the element using the member types in Umbraco.")]
    public virtual INamedMemberProperties NamedProperties(IResolverContext context)
    {
        context.SetScopedState(MemberTypeModule.ElementScopedStateKey, this);

        return new NamedMemberProperties();
    }

    /// <summary>
    /// The member sort order
    /// </summary>
    [GraphQLDescription("The member sort order")]
    public int? SortOrder => MemberItem?.SortOrder;

    /// <summary>
    /// The member writer id
    /// </summary>
    [GraphQLDescription("The member writer id")]
    public int? WriterId => MemberItem?.WriterId;

    /// <summary>
    /// The property factory
    /// </summary>
    protected virtual IPropertyFactory<TProperty> PropertyFactory { get; }
}
