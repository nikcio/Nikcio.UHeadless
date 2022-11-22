# Disable Banana cake pop UI at /graphql

Version: 3.2.0+ required

```csharp
app.UseUHeadlessGraphQLEndpoint(new UHeadlessEndpointOptions
{
    GraphQLServerOptions = new()
    {
        Tool = {
            Enable = false
        }
    }
});
```

The above example will disable the UI with enabled set to false.