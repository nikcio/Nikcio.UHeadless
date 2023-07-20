using HotChocolate.Execution.Configuration;
using Nikcio.UHeadless.Content.Basics.Queries;
using Nikcio.UHeadless.Content.Extensions;
using Nikcio.UHeadless.Extensions;
using Nikcio.UHeadless.Media.Basics.Queries;
using Nikcio.UHeadless.Media.Extensions;
using Nikcio.UHeadless.Members.Basics.Queries;
using Nikcio.UHeadless.Members.Extensions;

namespace v12
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="webHostEnvironment">The web hosting environment.</param>
        /// <param name="config">The configuration.</param>
        /// <remarks>
        /// Only a few services are possible to be injected here https://github.com/dotnet/aspnetcore/issues/9337.
        /// </remarks>
        public Startup(IWebHostEnvironment webHostEnvironment, IConfiguration config)
        {
            _env = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940.
        /// </remarks>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddUmbraco(_env, _config)
                .AddBackOffice()
                .AddWebsite()
                .AddDeliveryApi()
                .AddComposers()
                .AddUHeadless(new()
                {
                    PropertyServicesOptions = new()
                    {
                        PropertyMapOptions = new()
                        {
                            PropertyMappings = new()
                            {
                            }
                        },
                    },
                    TracingOptions = new()
                    {
                        TimestampProvider = null,
                        TracingPreference = HotChocolate.Execution.Options.TracingPreference.Never,
                    },
                    UHeadlessGraphQLOptions = new()
                    {
                        GraphQLExtensions = (IRequestExecutorBuilder builder) =>
                        {
                            builder.AddAuthorization();

                            builder.UseContentQueries();
                            builder.AddTypeExtension<BasicContentAllQuery>();
                            builder.AddTypeExtension<BasicContentAtRootQuery>();
                            builder.AddTypeExtension<BasicContentByAbsoluteRouteQuery>();
                            builder.AddTypeExtension<BasicContentByContentTypeQuery>();
                            builder.AddTypeExtension<BasicContentByGuidQuery>();
                            builder.AddTypeExtension<BasicContentByIdQuery>();
                            builder.AddTypeExtension<BasicContentByTagQuery>();
                            builder.AddTypeExtension<BasicContentDescendantsByAbsoluteRouteQuery>();
                            builder.AddTypeExtension<BasicContentDescendantsByContentTypeQuery>();
                            builder.AddTypeExtension<BasicContentDescendantsByGuidQuery>();
                            builder.AddTypeExtension<BasicContentDescendantsByIdQuery>();

                            builder.UseMediaQueries();
                            builder.AddTypeExtension<BasicMediaAtRootQuery>();
                            builder.AddTypeExtension<BasicMediaByContentTypeQuery>();
                            builder.AddTypeExtension<BasicMediaByGuidQuery>();
                            builder.AddTypeExtension<BasicMediaByIdQuery>();

                            builder.UseMemberQueries();
                            builder.AddTypeExtension<BasicMembersAllQuery>();
                            builder.AddTypeExtension<BasicFindMembersByDisplayNameQuery>();
                            builder.AddTypeExtension<BasicFindMembersByEmailQuery>();
                            builder.AddTypeExtension<BasicFindMembersByRoleQuery>();
                            builder.AddTypeExtension<BasicFindMembersByUsernameQuery>();
                            builder.AddTypeExtension<BasicMemberByEmailQuery>();
                            builder.AddTypeExtension<BasicMemberByIdQuery>();
                            builder.AddTypeExtension<BasicMemberByKeyQuery>();
                            builder.AddTypeExtension<BasicMemberByUsernameQuery>();
                            builder.AddTypeExtension<BasicMembersByIdQuery>();
                            return builder;
                        },
                    },
                })
                .Build();
        }

        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The web hosting environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseUHeadlessGraphQLEndpoint(new()
            {
                CorsPolicy = null,
                GraphQLPath = "/graphql",
                GraphQLServerOptions = new()
                {
                    Tool =
                    {
                        Enable = true
                    }
                }
            });

            app.UseUmbraco()
                .WithMiddleware(u =>
                {
                    u.UseBackOffice();
                    u.UseWebsite();
                })
                .WithEndpoints(u =>
                {
                    u.UseInstallerEndpoints();
                    u.UseBackOfficeEndpoints();
                    u.UseWebsiteEndpoints();
                });
        }
    }
}
