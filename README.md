# Nikcio.Umbraco.Headless

This repository creates an easy setup solution for making Umbraco headless. It comes with a wide range of extensibility options that can be tailored to your needs.

To get started, create a controller where you'll get all your content information.

### Example:

```CSharp
using Nikcio.Umbraco.Headless.Core.Services.Headless;

public class HeadlessController : UmbracoApiController
{
    private readonly IHeadlessService headlessService;

    public HeadlessController(IHeadlessService headlessService)
    {
        this.headlessService = headlessService;
    }

    public IActionResult GetData(string route)
    {
        return new OkObjectResult(headlessService.GetData(route));
    }
}
```
Now your content will be avalible at `/umbraco/api/headless/getdata?route=/`
The route parameter is the same as if you would render the content normally i.e the url path to your content node.

Find how to customize the output and more in the [Documentation](https://github.com/Nikcio-Packages/Nikcio.Umbraco.Headless/wiki)
