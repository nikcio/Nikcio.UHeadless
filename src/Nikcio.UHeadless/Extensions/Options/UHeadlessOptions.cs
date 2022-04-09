﻿using Nikcio.UHeadless.UmbracoContent.Properties.Extensions;

namespace Nikcio.UHeadless.Extensions.Options
{
    /// <summary>
    /// Options for UHeadless
    /// </summary>
    public class UHeadlessOptions
    {
        /// <summary>
        /// Options for the property services
        /// </summary>
        public PropertyServicesOptions PropertyServicesOptions { get; set; } = new();

        /// <summary>
        /// Options for the Apollo tracing
        /// </summary>
        public TracingOptions TracingOptions { get; set; } = new();

        /// <summary>
        /// Options for UHeadless GraphQL
        /// </summary>
        public UHeadlessGraphQLOptions UHeadlessGraphQLOptions { get; set; } = new();
    }
}
