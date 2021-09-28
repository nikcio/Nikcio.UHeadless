using System;

namespace Nikcio.Umbraco.Headless.Core.Mappers.Sites
{
    public interface ISiteMapper
    {
        /// <summary>
        /// Adds a mapping of a content page and the corresponding model
        /// </summary>
        /// <param name="contentAlias">The alias of the content page</param>
        /// <param name="type">The type to be used with the alias</param>
        /// <remarks>The <see cref="Constants.Constants.Factories.DefaultKey"/> key is the default used when no key is matched</remarks>
        void AddMapping(string contentAlias, Type type);

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
        Type GetValue(string key);
    }
}