# Paging options

In Nikcio.UHeadless, you have the flexibility to change the default paging options to suit your specific needs. By modifying the default paging options, you can customize the maximum page size and other relevant parameters for pagination. This document will guide you through the process of changing the default paging options using code examples.

## Default Paging Options

The default paging options in Nikcio.UHeadless are defined by the HotChocolate GraphQL library, which is utilized by Nikcio.UHeadless for data fetching and pagination. The default values for the paging options can be found in the HotChocolate documentation [here](https://chillicream.com/docs/hotchocolate/v13/fetching-data/pagination#pagingoptions).

To modify these default paging options, you need to configure the `UHeadlessGraphQLOptions` during the setup of Nikcio.UHeadless.

## Changing Default Paging Options

To change the default paging options in Nikcio.UHeadless, you can use the provided code example. This code example demonstrates how to modify the default paging options using the `SetPagingOptions` method provided by the HotChocolate library.

```csharp
.AddUHeadless(new()
{
    UHeadlessGraphQLOptions = new()
    {
        GraphQLExtensions = (IRequestExecutorBuilder builder) =>
        {
            builder.SetPagingOptions(new PagingOptions
            {
                MaxPageSize = 100
            });
            return builder;
        },
    },
})
```

In the code example above, the `SetPagingOptions` method is used to set the maximum page size to 100. You can modify the `MaxPageSize` property according to your specific requirements.

By invoking the `SetPagingOptions` method within the `GraphQLExtensions` delegate, you can customize various paging options. For example, you can change the default page size, adjust the maximum allowed page size, or specify other pagination-related settings as per your application's needs.