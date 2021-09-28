using Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels.PropertyModels;
using UmbracoConstants = Umbraco.Cms.Core.Constants;

namespace Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages.PageData
{
    public interface IPropertyMapper
    {
        /// <summary>
        /// Adds a mapping of a property editor and the corresponding model
        /// </summary>
        /// <param name="contentTypeAlias">The name of the editor. For example: <see cref="UmbracoConstants.PropertyEditors.Aliases.BlockList"/></param>
        /// <typeparam name="TType">The type to be used with the alias</typeparam>
        /// <remarks>The <see cref="Constants.Constants.Factories.DefaultKey"/> key is the default used when no key is matched</remarks>
        void AddAliasMapping<TType>(string contentTypeAlias, string propertyTypeAlias) where TType : class, IPropertyModelBase;

        /// <summary>
        /// Adds a mapping of a property editor and the corresponding model
        /// </summary>
        /// <param name="editorName">The name of the editor. For example: <see cref="UmbracoConstants.PropertyEditors.Aliases.BlockList"/></param>
        /// <typeparam name="TType">The type to be used with the editor name</typeparam>
        /// <remarks>The <see cref="Constants.Constants.Factories.DefaultKey"/> key is the default used when no key is matched</remarks>
        void AddEditorMapping<TType>(string editorName) where TType : class, IPropertyModelBase;

        /// <summary>
        /// Checks if a key is present in the dictionary
        /// </summary>
        /// <param name="editorName"></param>
        /// <returns></returns>
        bool ContainsAlias(string contentTypeAlias, string propertyTypeAlias);

        /// <summary>
        /// Checks if a key is present in the dictionary
        /// </summary>
        /// <param name="editorName"></param>
        /// <returns></returns>
        bool ContainsEditor(string editorName);

        /// <summary>
        /// Gets a value for a key in the editor dictionary
        /// </summary>
        /// <param name="contentTypeAlias"></param>
        /// <returns></returns>
        string GetAliasValue(string contentTypeAlias, string propertyAlias);

        /// <summary>
        /// Gets a value for a key in the editor dictionary
        /// </summary>
        /// <param name="editorAlias"></param>
        /// <returns></returns>
        string GetEditorValue(string editorAlias);
    }
}