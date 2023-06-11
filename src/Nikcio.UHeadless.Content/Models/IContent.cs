﻿using HotChocolate;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Base.Properties.Models;

namespace Nikcio.UHeadless.Content.Models;

/// <summary>
/// Represents a content item
/// </summary>
[GraphQLDescription("Represents a content item.")]
public interface IContent : IElement
{
    /// <summary>
    /// Redirect information for a content node
    /// </summary>
    [GraphQLDescription("Redirect information for a content node")]
    public object? Redirect { get; set; }
}