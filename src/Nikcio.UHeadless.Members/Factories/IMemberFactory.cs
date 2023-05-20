﻿using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Members.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Members.Factories;

/// <summary>
/// A factory for creating members
/// </summary>
/// <typeparam name="TMember"></typeparam>
/// <typeparam name="TProperty"></typeparam>
public interface IMemberFactory<TMember, TProperty>
    where TMember : IMember<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Creates a member
    /// </summary>
    /// <param name="member"></param>
    /// <returns></returns>
    TMember? CreateMember(Umbraco.Cms.Core.Models.IMember member);
}