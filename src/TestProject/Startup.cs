using System;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nikcio.ApiAuthentication.Extensions;
using Nikcio.ApiAuthentication.Extensions.Models;
using Nikcio.UHeadless.Extensions;
using Nikcio.UHeadless.Extensions.Options;
using Nikcio.UHeadless.Queries;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoContent.Content.Queries;
using Nikcio.UHeadless.UmbracoContent.Content.Repositories;
using Nikcio.UHeadless.UmbracoElements.ContentTypes.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Queries;
using Nikcio.UHeadless.UmbracoMedia.Media.Queries;
using TestProject.Docs;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Extensions;

namespace TestProject {
    public class Startup {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="webHostEnvironment">The web hosting environment.</param>
        /// <param name="config">The configuration.</param>
        /// <remarks>
        /// Only a few services are possible to be injected here https://github.com/dotnet/aspnetcore/issues/9337
        /// </remarks>
        public Startup(IWebHostEnvironment webHostEnvironment, IConfiguration config) {
            _env = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </remarks>
        public void ConfigureServices(IServiceCollection services) {
            static IRequestExecutorBuilder graphQLExtentions(IRequestExecutorBuilder builder) =>
                builder
                    .AddTypeExtension<CustomContentQuery>()
                    .AddTypeExtension<BasicPropertyQuery>()
                        .AddTypeExtension<BasicMediaQuery>();

            services.AddUmbraco(_env, _config)
                .AddBackOffice()
                .AddWebsite()
                .AddComposers()
                .AddUHeadless(new() {
                    UHeadlessGraphQLOptions = new() {
                        GraphQLExtensions = graphQLExtentions
                    }
                })
                .Build();

            services.AddNikcioApiAuthentication(_config, new ApiAuthenticationConfigurationSettings {
                ConnectionStringKey = "umbracoDbDSN",
                ConfigurationSection = "Nikcio:ApiAuthentication",
                DataAccessConfigurationSection = "Nikcio:DataAccess"
            });
        }

        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The web hosting environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseUHeadlessGraphQLEndpoint(new UHeadlessEndpointOptions {
                CorsPolicy = null,
                UseSecurity = true,
                GraphQLPath = "/graphql"
            });

            app.UseUmbraco()
                .WithMiddleware(u => {
                    u.UseBackOffice();
                })
                .WithEndpoints(u => {
                    u.UseInstallerEndpoints();
                    u.UseBackOfficeEndpoints();
                });
        }
    }

    [ExtendObjectType(typeof(Query))]
    public class CustomContentQuery : ContentQuery<BasicContent<BasicProperty, BasicContentType>, BasicProperty> {
        [Authorize]
        public override IEnumerable<BasicContent<BasicProperty, BasicContentType>> GetContentAtRoot([Service(ServiceKind.Default)] IContentRepository<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentRepository, [GraphQLDescription("The culture.")] string culture = null, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return base.GetContentAtRoot(contentRepository, culture, preview);
        }

        [Authorize]
        public override BasicContent<BasicProperty, BasicContentType> GetContentByGuid([Service(ServiceKind.Default)] IContentRepository<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentRepository, [GraphQLDescription("The id to fetch.")] Guid id, [GraphQLDescription("The culture to fetch.")] string culture = null, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return base.GetContentByGuid(contentRepository, id, culture, preview);
        }

        [Authorize]
        public override BasicContent<BasicProperty, BasicContentType> GetContentById([Service(ServiceKind.Default)] IContentRepository<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentRepository, [GraphQLDescription("The id to fetch.")] int id, [GraphQLDescription("The culture to fetch.")] string culture = null, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return base.GetContentById(contentRepository, id, culture, preview);
        }

        [Authorize]
        public override BasicContent<BasicProperty, BasicContentType> GetContentByRoute([Service(ServiceKind.Default)] IContentRepository<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentRepository, [GraphQLDescription("The route to fetch.")] string route, [GraphQLDescription("The culture.")] string culture = null, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return base.GetContentByRoute(contentRepository, route, culture, preview);
        }
    }
}
