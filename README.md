# Nikcio.UHeadless

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/48f9a00a65284a0d8d7d8660783beb47)](https://www.codacy.com/gh/nikcio/Nikcio.UHeadless/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=nikcio/Nikcio.UHeadless&amp;utm_campaign=Badge_Grade)

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
