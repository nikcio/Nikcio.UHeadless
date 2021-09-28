using Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels;

namespace Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages
{
    public interface IPageMapper
    {
        /// <summary>
        /// Adds a mapping of a content page and the corresponding model
        /// </summary>
        /// <param name="contentAlias">The alias of the content page</param>
        /// <typeparam name="TType">The type to be used with the alias</typeparam>
        /// <remarks>The <see cref="Constants.Constants.Factories.DefaultKey"/> key is the default used when no key is matched</remarks>
        void AddMapping<TType>(string contentAlias) where TType : class, IPageModelBase;

        /// <summary>
        /// Checks if a key is present in the map
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool ContainsKey(string key);

        /// <summary>
        /// Gets a value for a key in the dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetValue(string key);
    }
}