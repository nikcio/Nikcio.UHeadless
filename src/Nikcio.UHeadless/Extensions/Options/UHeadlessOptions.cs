namespace Nikcio.UHeadless.Extensions.Options {
    /// <summary>
    /// Options for UHeadless
    /// </summary>
    public class UHeadlessOptions {
        /// <summary>
        /// Options for the property services
        /// </summary>
        public virtual PropertyServicesOptions PropertyServicesOptions { get; set; } = new();

        /// <summary>
        /// Options for the Apollo tracing
        /// </summary>
        public virtual TracingOptions TracingOptions { get; set; } = new();

        /// <summary>
        /// Options for UHeadless GraphQL
        /// </summary>
        public virtual UHeadlessGraphQLOptions UHeadlessGraphQLOptions { get; set; } = new();
    }
}
