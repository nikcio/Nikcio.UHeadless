# Security Considerations

When using Nikcio.UHeadless, it is important to consider security measures to protect your GraphQL data and ensure that access to sensitive information is properly controlled. This section highlights some key security considerations and provides guidance on implementing security measures.

## Built-in Auth Queries

Nikcio.UHeadless provides built-in Auth queries that can be used to authenticate and authorize access to GraphQL data. This is done by adding the `[Authorize]` attribute to the queries used, thereby you can enforce authentication requirements, ensure that only authorized users can query for data. Do note that you have to implement your own way to authenticate with-in your Asp Net Core application. This could be by using JWT tokens for example. Refer to Microsofts documentation [here to learn more](https://learn.microsoft.com/en-us/aspnet/core/security/authentication) 

## HotChocolate Documentation

Nikcio.UHeadless leverages the [HotChocolate](https://chillicream.com/docs/hotchocolate) NuGet package, which is a powerful GraphQL server implementation for .NET. HotChocolate provides documentation on various security topics, including how to add authentication and authorization to your GraphQL queries and data.

For detailed insights into implementing authentication and authorization with HotChocolate, refer to the official HotChocolate documentation on security at:

[HotChocolate Security Documentation](https://chillicream.com/docs/hotchocolate/v13/security)

This documentation covers different authentication and authorization mechanisms supported by HotChocolate and provides guidelines on securing your GraphQL API effectively.

Note: If you need to use any of the `builder.Services.AddGraphQLServer()` extensions shown in the HotChocolate documentation this can be added via the `UHeadlessGraphQLOptions.GraphQLExtensions` like how you add queries.

## Additional or Alternative Security Measures

In addition to leveraging built-in Auth queries and following the guidelines provided by HotChocolate, there are other ways to enhance the security of your Nikcio.UHeadless GraphQL data.

One approach is to use a reverse proxy or similar technology to route all traffic to and from the `/graphql` endpoint internally. By configuring the reverse proxy to allow access only from trusted sources, you can ensure that your GraphQL data remains inaccessible to the public.

Consult the documentation or resources specific to the reverse proxy or technology you are using for detailed instructions on how to configure it to secure the `/graphql` endpoint.

Implementing these security measures, including leveraging built-in Auth queries, referring to HotChocolate documentation for authentication and authorization, and using a reverse proxy, helps safeguard your Nikcio.UHeadless GraphQL data and protect sensitive information from unauthorized access.

Remember to regularly review and update your security measures to stay up to date with best practices and address any emerging security concerns.