using Nikcio.UHeadless.IntegrationTests.Extensions;
using Nikcio.UHeadless.IntegrationTests.Shared;
using StrawberryShake;

namespace Nikcio.UHeadless.IntegrationTests.Content.Queries;

public class ContentByIdTests : IntegrationTestBase
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
    public async Task GetGeneralContentById_Test(string baseUrl, string route, string culture)
    {
        var routeResult = await _setup.UHeadlessClient.GetGeneralContentByAbsoluteRoute.ExecuteAsync(baseUrl, route, culture);

        routeResult.Errors.EnsureNoErrors();
        Assert.That(routeResult, Is.Not.Null);
        Assert.That(routeResult.Data, Is.Not.Null);
        Assert.That(routeResult.Data!.ContentByAbsoluteRoute, Is.Not.Null);
        Assert.That(routeResult.Data!.ContentByAbsoluteRoute!.Id, Is.Not.Null);

        var result = await _setup.UHeadlessClient.GetGeneralContentById.ExecuteAsync(routeResult.Data!.ContentByAbsoluteRoute!.Id!.Value, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentById, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentById!.Id ?? 0, Is.GreaterThan(0));
            Assert.That(result.Data!.ContentById!.Key, Is.Not.Null);
        });
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentById!.Key, Is.Not.Empty);
            Assert.That(result.Data!.ContentById!.Name, Is.Not.Empty);
            Assert.That(result.Data!.ContentById!.CreatorId, Is.EqualTo(-1));
            Assert.That(result.Data!.ContentById!.WriterId, Is.EqualTo(-1));
            Assert.That(result.Data!.ContentById!.Properties?.All(property => property != null && !string.IsNullOrEmpty(property.Alias)), Is.True);
            Assert.That(result.Data!.ContentById!.ItemType.ToString(), Is.Not.Empty);
            Assert.That(result.Data!.ContentById!.Level, Is.GreaterThan(0));
            Assert.That(result.Data!.ContentById!.Redirect == null || !string.IsNullOrEmpty(result.Data!.ContentById!.Redirect.RedirectUrl), Is.True);
            Assert.That(result.Data!.ContentById!.SortOrder, Is.GreaterThan(-1));
            Assert.That(result.Data!.ContentById!.TemplateId == null || result.Data!.ContentById!.TemplateId > 0, Is.True);
            Assert.That(result.Data!.ContentById!.Url, Is.Not.Empty);
            Assert.That(result.Data!.ContentById!.UrlSegment, Is.Not.Empty);
            Assert.That(result.Data!.ContentById!.AbsoluteUrl, Is.Not.Empty);
            Assert.That(result.Data!.ContentById!.Children?.All(child => !string.IsNullOrEmpty(child!.Name)), Is.True);
            Assert.That(result.Data!.ContentById!.Children?.All(child => child!.CreatorId == -1), Is.True);
            Assert.That(result.Data!.ContentById!.Children?.All(child => child!.WriterId == -1), Is.True);
            Assert.That(result.Data!.ContentById!.Children?.All(child => child!.Properties != null && child.Properties.All(property => !string.IsNullOrEmpty(property!.Alias))), Is.True);
            Assert.That(result.Data!.ContentById!.Children?.All(child => !string.IsNullOrEmpty(child!.ItemType.ToString())), Is.True);
            Assert.That(result.Data!.ContentById!.Children?.All(child => child!.Level > result.Data!.ContentById!.Level), Is.True);
            Assert.That(result.Data!.ContentById!.Children?.All(child => child!.Parent != null), Is.True);
            Assert.That(result.Data!.ContentById!.Children?.All(child => !string.IsNullOrEmpty(child!.Parent!.Name)), Is.True);
            Assert.That(result.Data!.ContentById!.Children?.All(child => child!.Redirect == null || !string.IsNullOrEmpty(child.Redirect.RedirectUrl)), Is.True);
            Assert.That(result.Data!.ContentById!.Children?.All(child => child!.SortOrder > -1), Is.True);
            Assert.That(result.Data!.ContentById!.Children?.All(child => child!.TemplateId == null || child!.TemplateId > 0), Is.True);
            Assert.That(result.Data!.ContentById!.Children?.All(child => !string.IsNullOrEmpty(child!.Url)), Is.True);
            Assert.That(result.Data!.ContentById!.Children?.All(child => !string.IsNullOrEmpty(child!.UrlSegment)), Is.True);
            Assert.That(result.Data!.ContentById!.Children?.All(child => !string.IsNullOrEmpty(child!.AbsoluteUrl)), Is.True);
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
    public async Task GetNodeIdContentById_Test(string baseUrl, string route, string culture)
    {
        var routeResult = await _setup.UHeadlessClient.GetGeneralContentByAbsoluteRoute.ExecuteAsync(baseUrl, route, culture);

        routeResult.Errors.EnsureNoErrors();
        Assert.That(routeResult, Is.Not.Null);
        Assert.That(routeResult.Data, Is.Not.Null);
        Assert.That(routeResult.Data!.ContentByAbsoluteRoute, Is.Not.Null);
        Assert.That(routeResult.Data!.ContentByAbsoluteRoute!.Id, Is.Not.Null);

        var result = await _setup.UHeadlessClient.GetNodeIdContentById.ExecuteAsync(routeResult.Data!.ContentByAbsoluteRoute!.Id!.Value, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentById, Is.Not.Null);
        Assert.That(result.Data!.ContentById!.Id, Is.GreaterThan(0));
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
    public async Task GetPropertiesContentById_Test(string baseUrl, string route, string culture)
    {
        var routeResult = await _setup.UHeadlessClient.GetGeneralContentByAbsoluteRoute.ExecuteAsync(baseUrl, route, culture);

        routeResult.Errors.EnsureNoErrors();
        Assert.That(routeResult, Is.Not.Null);
        Assert.That(routeResult.Data, Is.Not.Null);
        Assert.That(routeResult.Data!.ContentByAbsoluteRoute, Is.Not.Null);
        Assert.That(routeResult.Data!.ContentByAbsoluteRoute!.Id, Is.Not.Null);

        var result = await _setup.UHeadlessClient.GetPropertiesContentById.ExecuteAsync(routeResult.Data!.ContentByAbsoluteRoute!.Id!.Value, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentById, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentById!.Properties, Is.Not.Null);
            Assert.That(result.Data!.ContentById!.Properties!.All(property => !string.IsNullOrEmpty(property!.Alias)), Is.True);
            Assert.That(result.Data!.ContentById!.Properties!.All(property => !string.IsNullOrEmpty(property!.EditorAlias)), Is.True);
            Assert.That(result.Data!.ContentById!.Properties!.All(property => property!.Value != null), Is.True);
            Assert.That(result.Data!.ContentById!.Properties!.All(property => SharedValidation.IsPropertyValueValid(property!.Value!)), Is.True);
            Assert.That(result.Data!.ContentById!.Children?.All(child => child!.Properties != null && child.Properties.All(property => SharedValidation.IsPropertyValueValid(property!.Value!))), Is.True);
        });
    }
}