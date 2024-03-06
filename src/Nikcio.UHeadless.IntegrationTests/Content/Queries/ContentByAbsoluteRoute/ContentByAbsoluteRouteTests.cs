using Nikcio.UHeadless.IntegrationTests.Extensions;
using Nikcio.UHeadless.IntegrationTests.Shared;
using StrawberryShake;

namespace Nikcio.UHeadless.IntegrationTests.Content.Queries.ContentByAbsoluteRoute;

public class ContentByAbsoluteRouteTests : IntegrationTestBase
{
    private readonly Setup _setup = new();

    [TearDown]
    public void TearDown()
    {
        _setup.Dispose();
    }

    [TestCase("https://site-1.com", "/", null)]
    [TestCase("https://site-1.com", "/homepage", null)]
    [TestCase("https://site-1.com", "/page-1", null)]
    [TestCase("https://site-1.com", "/page-2", null)]
    [TestCase("https://site-1.com", "/collection-of-pages/block-list-page", null)]
    [TestCase("", "/no-domain-site", null)]
    [TestCase("", "/no-domain-homepage", null)]
    [TestCase("https://site-2.com", "/", null)]
    [TestCase("https://site-2.com", "/page-1", null)]
    [TestCase("https://site-culture.com", "/homepage", "en-us")]
    [TestCase("https://site-culture.dk", "/homepage", "da")]
    public async Task GetGeneralContentByAbsoluteRoute_Test(string baseUrl, string route, string? culture)
    {
        var result = await _setup.UHeadlessClient.GetGeneralContentByAbsoluteRoute.ExecuteAsync(baseUrl, route, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentByAbsoluteRoute, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Id ?? 0, Is.GreaterThan(0));
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Key, Is.Not.Null);
        });
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Key, Is.Not.Empty);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Name, Is.Not.Empty);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.CreatorId, Is.EqualTo(-1));
            Assert.That(result.Data!.ContentByAbsoluteRoute!.WriterId, Is.EqualTo(-1));
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Properties?.All(property => property != null && !string.IsNullOrEmpty(property.Alias)), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.ItemType.ToString(), Is.Not.Empty);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Level, Is.GreaterThan(0));
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Redirect == null || !string.IsNullOrEmpty(result.Data!.ContentByAbsoluteRoute!.Redirect.RedirectUrl), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.SortOrder, Is.GreaterThan(-1));
            Assert.That(result.Data!.ContentByAbsoluteRoute!.TemplateId == null || result.Data!.ContentByAbsoluteRoute!.TemplateId > 0, Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Url, Is.Not.Empty);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.UrlSegment, Is.Not.Empty);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.AbsoluteUrl, Is.Not.Empty);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Children?.All(child => !string.IsNullOrEmpty(child!.Name)), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Children?.All(child => child!.CreatorId == -1), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Children?.All(child => child!.WriterId == -1), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Children?.All(child => child!.Properties != null && child.Properties.All(property => !string.IsNullOrEmpty(property!.Alias))), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Children?.All(child => !string.IsNullOrEmpty(child!.ItemType.ToString())), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Children?.All(child => child!.Level > result.Data!.ContentByAbsoluteRoute!.Level), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Children?.All(child => child!.Parent != null), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Children?.All(child => !string.IsNullOrEmpty(child!.Parent!.Name)), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Children?.All(child => child!.Redirect == null || !string.IsNullOrEmpty(child.Redirect.RedirectUrl)), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Children?.All(child => child!.SortOrder > -1), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Children?.All(child => child!.TemplateId == null || child!.TemplateId > 0), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Children?.All(child => !string.IsNullOrEmpty(child!.Url)), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Children?.All(child => !string.IsNullOrEmpty(child!.UrlSegment)), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Children?.All(child => !string.IsNullOrEmpty(child!.AbsoluteUrl)), Is.True);
        });
    }

    [TestCase("https://site-1.com", "/", null)]
    [TestCase("https://site-1.com", "/homepage", null)]
    [TestCase("https://site-1.com", "/page-1", null)]
    [TestCase("https://site-1.com", "/page-2", null)]
    [TestCase("https://site-1.com", "/collection-of-pages/block-list-page", null)]
    [TestCase("", "/no-domain-site", null)]
    [TestCase("", "/no-domain-homepage", null)]
    [TestCase("https://site-2.com", "/", null)]
    [TestCase("https://site-2.com", "/page-1", null)]
    [TestCase("https://site-culture.com", "/homepage", "en-us")]
    [TestCase("https://site-culture.dk", "/homepage", "da")]
    public async Task GetNodeIdContentByAbsoluteRoute_Test(string baseUrl, string route, string? culture)
    {
        var result = await _setup.UHeadlessClient.GetNodeIdContentByAbsoluteRoute.ExecuteAsync(baseUrl, route, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentByAbsoluteRoute, Is.Not.Null);
        Assert.That(result.Data!.ContentByAbsoluteRoute!.Id, Is.GreaterThan(0));
    }

    [TestCase("https://site-1.com", "/", null)]
    [TestCase("https://site-1.com", "/homepage", null)]
    [TestCase("https://site-1.com", "/page-1", null)]
    [TestCase("https://site-1.com", "/page-2", null)]
    [TestCase("https://site-1.com", "/collection-of-pages/block-list-page", null)]
    [TestCase("", "/no-domain-site", null)]
    [TestCase("", "/no-domain-homepage", null)]
    [TestCase("https://site-2.com", "/", null)]
    [TestCase("https://site-2.com", "/page-1", null)]
    [TestCase("https://site-culture.com", "/homepage", "en-us")]
    [TestCase("https://site-culture.dk", "/homepage", "da")]
    public async Task GetPropertiesContentByAbsoluteRoute_Test(string baseUrl, string route, string? culture)
    {
        var result = await _setup.UHeadlessClient.GetPropertiesContentByAbsoluteRoute.ExecuteAsync(baseUrl, route, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentByAbsoluteRoute, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Properties, Is.Not.Null);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Properties!.All(property => !string.IsNullOrEmpty(property!.Alias)), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Properties!.All(property => !string.IsNullOrEmpty(property!.EditorAlias)), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Properties!.All(property => property!.Value != null), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Properties!.All(property => SharedValidation.IsPropertyValueValid(property!.Value!)), Is.True);
            Assert.That(result.Data!.ContentByAbsoluteRoute!.Children?.All(child => child!.Properties != null && child.Properties.All(property => SharedValidation.IsPropertyValueValid(property!.Value!))), Is.True);
        });
    }
}