namespace Nikcio.UHeadless.ContentTypes.Extensions {
    /// <inheritdoc/>
    public static class ContentTypeExtensions {
        /// <summary>
        /// Adds content type services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddContentTypeServices(this IServiceCollection services) {
            services
                .AddFactories();

            return services;
        }
    }
}
