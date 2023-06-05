using Nikcio.UHeadless.IntegrationTests.Extensions;
using Nikcio.UHeadless.IntegrationTests.Shared;
using StrawberryShake;

namespace Nikcio.UHeadless.IntegrationTests.Content.Queries;

public class ContentDescendantsByAbsoluteRouteTests : IntegrationTestBase
{
    private readonly Setup _setup = new();

    [TearDown]
    public void TearDown()
    {
        _setup.Dispose();
    }

    [TestCase("https://site-1.com", "/", null)]
    [TestCase("https://site-1.com", "/collection-of-pages", null)]
    [TestCase("", "/no-domain-site", null)]
    [TestCase("https://site-2.com", "/", null)]
    [TestCase("https://site-culture.com", "/", "en-us")]
    [TestCase("https://site-culture.dk", "/", "da")]
    public async Task GetGeneralContentDescendantsByAbsoluteRoute_Test(string baseUrl, string route, string culture)
    {
        var result = await _setup.UHeadlessClient.GetGeneralContentDescendantsByAbsoluteRoute.ExecuteAsync(baseUrl, route, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!, Is.Not.Empty);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Id > 0), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Key != null), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => !string.IsNullOrEmpty(node!.Name)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.CreatorId == -1), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.WriterId == -1), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Properties != null && node.Properties.All(property => property != null && !string.IsNullOrEmpty(property.Alias))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => !string.IsNullOrEmpty(node!.ItemType.ToString())), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Level > 0), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Redirect == null || !string.IsNullOrEmpty(node.Redirect.RedirectUrl)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.SortOrder > -1), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.TemplateId == null || node!.TemplateId > 0), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => !string.IsNullOrEmpty(node!.Url)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => !string.IsNullOrEmpty(node!.UrlSegment)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => !string.IsNullOrEmpty(node!.AbsoluteUrl)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Name))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.CreatorId == -1)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.WriterId == -1)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Properties != null && child.Properties.All(property => !string.IsNullOrEmpty(property!.Alias)))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.ItemType.ToString()))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Level > node.Level)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Parent != null)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Parent!.Name))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Redirect == null || !string.IsNullOrEmpty(child.Redirect.RedirectUrl))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.SortOrder > -1)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.TemplateId == null || child!.TemplateId > 0)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Url))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.UrlSegment))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.AbsoluteUrl))), Is.True);
        });
    }

    [TestCase("https://site-1.com", "/", null)]
    [TestCase("https://site-1.com", "/collection-of-pages", null)]
    [TestCase("", "/no-domain-site", null)]
    [TestCase("https://site-2.com", "/", null)]
    [TestCase("https://site-culture.com", "/", "en-us")]
    [TestCase("https://site-culture.dk", "/", "da")]
    public async Task GetNodeIdContentDescendantsByAbsoluteRoute_Test(string baseUrl, string route, string culture)
    {
        var result = await _setup.UHeadlessClient.GetNodeIdContentDescendantsByAbsoluteRoute.ExecuteAsync(baseUrl, route, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!, Is.Not.Empty);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
    }

    [TestCase("https://site-1.com/", "/", 0, null)]
    [TestCase("https://site-1.com/", "/", 1, null)]
    [TestCase("https://site-1.com/", "/", 2, null)]
    [TestCase("https://site-1.com/", "/", 5, null)]
    [TestCase("https://site-1.com/", "/", 10, null)]
    [TestCase("https://site-culture.com/", "/", 0, "en-us")]
    [TestCase("https://site-culture.com/", "/", 1, "en-us")]
    [TestCase("https://site-culture.com/", "/", 10, "en-us")]
    public async Task GetFirstNodesContentDescendantsByAbsoluteRoute_Test(string baseUrl, string route, int firstCount, string culture)
    {
        var result = await _setup.UHeadlessClient.GetFirstNodesContentDescendantsByAbsoluteRoute.ExecuteAsync(baseUrl, route, firstCount, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes, Is.Not.Null);
        if (firstCount > 0)
        {
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!, Is.Not.Empty);
        }
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.Count == firstCount || !result.Data!.ContentDescendantsByAbsoluteRoute.PageInfo.HasNextPage, Is.True);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
    }

    [TestCase("https://site-1.com", "/", null)]
    [TestCase("https://site-1.com", "/collection-of-pages", null)]
    [TestCase("", "/no-domain-site", null)]
    [TestCase("https://site-2.com", "/", null)]
    [TestCase("https://site-culture.com", "/", "en-us")]
    [TestCase("https://site-culture.dk", "/", "da")]
    public async Task GetPropertiesContentDescendantsByAbsoluteRoute_Test(string baseUrl, string route, string culture)
    {
        var result = await _setup.UHeadlessClient.GetPropertiesContentDescendantsByAbsoluteRoute.ExecuteAsync(baseUrl, route, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!, Is.Not.Empty);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Properties != null));
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Properties!.All(property => !string.IsNullOrEmpty(property!.Alias))));
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Properties!.All(property => !string.IsNullOrEmpty(property!.EditorAlias))));
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Properties!.All(property => property!.Value != null)));
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Properties!.All(property => SharedValidation.IsPropertyValueValid(property!.Value!))));
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Properties != null && child.Properties.All(property => SharedValidation.IsPropertyValueValid(property!.Value!)))));
        });
    }
}