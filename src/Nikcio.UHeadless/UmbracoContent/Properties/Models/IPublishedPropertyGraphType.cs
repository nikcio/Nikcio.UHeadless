namespace Nikcio.UHeadless.UmbracoContent.Properties.Models
{
    public interface IPublishedPropertyGraphType
    {
        //
        // Summary:
        //     Gets the alias of the property.
        string Alias { get; }

        object Value { get; }
        string EditorAlias { get; set; }
    }

}
