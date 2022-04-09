﻿namespace Nikcio.UHeadless.Extensions.Options
{
    /// <summary>
    /// Options for the UHeadless Endpoint configuration
    /// </summary>
    public class UHeadlessEndpointOptions
    {
        /// <summary>
        /// Alternate cors policy to use. If not defined it will call the UseCors()
        /// </summary>
        public string? CorsPolicy { get; set; } = null;

        /// <summary>
        /// The path where the graphql endpoint will be placed
        /// </summary>
        public string GraphQLPath { get; set; } = "/graphql";

        /// <summary>
        /// 
        /// </summary>
        public bool UseSecurity { get; set; } = false;
    }
}
