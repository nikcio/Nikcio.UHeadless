namespace Nikcio.UHeadless.UmbracoContent.Content.Commands {
    /// <summary>
    /// A command to create a content redirect
    /// </summary>
    public class CreateContentRedirect {
        /// <summary>
        /// The url to redirect to
        /// </summary>
        public virtual string RedirectUrl { get; set; }

        /// <summary>
        /// Is the redirect permanent
        /// </summary>
        public virtual bool IsPermanent { get; set; }

        /// <inheritdoc/>
        public CreateContentRedirect(string redirectUrl, bool isPermanent) {
            RedirectUrl = redirectUrl;
            IsPermanent = isPermanent;
        }

    }
}
