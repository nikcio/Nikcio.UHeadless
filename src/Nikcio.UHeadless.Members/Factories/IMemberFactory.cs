using Nikcio.UHeadless.Base.Elements.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Members.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Members.Factories {
    /// <summary>
    /// A factory for creating members
    /// </summary>
    /// <typeparam name="TMember"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    public interface IMemberFactory<TMember, TProperty> : IElementFactory<TMember, TProperty>
        where TMember : IMember<TProperty>
        where TProperty : IProperty {
        /// <summary>
        /// Creates a member
        /// </summary>
        /// <param name="member"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        TMember? CreateMember(IPublishedContent member, string? culture);
    }
}