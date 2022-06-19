using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Members.Models;

namespace Nikcio.UHeadless.Members.Queries {
    /// <summary>
    /// The base implementation of the Member queries
    /// </summary>
    /// <typeparam name="TMember"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    public class MemberQuery<TMember, TProperty>
        where TMember : IMember<TProperty>
        where TProperty : IProperty {

    }
}