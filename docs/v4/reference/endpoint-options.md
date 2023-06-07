# Endpoint Options

The `UHeadlessEndpointOptions` class provides configuration options for the UHeadless GraphQL endpoint. These options can be used to customize various aspects of the endpoint's behavior. 

## UHeadlessEndpointOptions Properties

| Property               | Description                                                                                                        |
|------------------------|--------------------------------------------------------------------------------------------------------------------|
| CorsPolicy             | The alternate CORS policy to use for the endpoint. If not defined, the default CORS policy will be used.           |
| GraphQLPath            | The path where the GraphQL endpoint will be placed. By default, the endpoint is available at "/graphql".           |
| GraphQLServerOptions   | The options for configuring the GraphQL endpoint.                                                                  |

## GraphQLServerOptions Properties

| Property                                | Description                                                                                        |
|-----------------------------------------|----------------------------------------------------------------------------------------------------|
| Tool                                    | The options for configuring the GraphQL tool (e.g., Banana Cake Pop).                              |
| Sockets                                 | The options for configuring GraphQL sockets.                                                       |
| AllowedGetOperations                    | Specifies which GraphQL options are allowed on GET requests.                                       |
| EnableGetRequests                       | Specifies whether GraphQL HTTP GET requests are allowed.                                           |
| EnforceGetRequestsPreflightHeader       | Specifies whether to enforce the preflight header for GraphQL HTTP GET requests.                   |
| EnableMultipartRequests                 | Specifies whether GraphQL HTTP multipart requests are allowed.                                     |
| EnforceMultipartRequestsPreflightHeader | Specifies whether to enforce the preflight header for GraphQL HTTP multipart requests.             |
| EnableSchemaRequests                    | Specifies whether the GraphQL schema SDL can be downloaded.                                        |
| EnableBatching                          | Specifies whether request batching is enabled.                                                     |

By using these options, you can customize the behavior of the UHeadless GraphQL endpoint to suit your application's needs. These options allow you to configure CORS policies, set the GraphQL endpoint path, enable/disable various HTTP request types (such as GET and multipart requests), control schema downloads, and more.

To configure the endpoint options, use the `.UseUHeadlessGraphQLEndpoint()` method and provide an instance of `UHeadlessEndpointOptions` with the desired settings.

Example usage:

```csharp
app.UseUHeadlessGraphQLEndpoint(new UHeadlessEndpointOptions
{
    CorsPolicy = null,
    GraphQLPath = "/graphql",
    GraphQLServerOptions = new()
    {
        Tool = {
            Enable = true
        }
    }
});
```