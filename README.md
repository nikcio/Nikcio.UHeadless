# Nikcio.UHeadless

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/c1ad06f4e1824f509e027d2e1fad4f48)](https://app.codacy.com/gh/nikcio/Nikcio.UHeadless?utm_source=github.com&utm_medium=referral&utm_content=nikcio/Nikcio.UHeadless&utm_campaign=Badge_Grade_Settings)

This repository creates an easy setup solution for making Umbraco headless. It comes with a wide range of extensibility options that can be tailored to your needs.

To get started, create a controller where you'll get all your content information.

## Example

```CSharp
using Nikcio.UHeadless.Core.Services.Headless;

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

Find how to customize the output and more in the [Documentation](https://github.com/nikcio/Nikcio.UHeadless/wiki).
