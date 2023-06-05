using Nikcio.UHeadless.IntegrationTests.Extensions;
using Nikcio.UHeadless.IntegrationTests.Shared;
using StrawberryShake;

namespace Nikcio.UHeadless.IntegrationTests.Content.Queries.ContentByGuid;

public class ContentByGuidTests : IntegrationTestBase
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
    public async Task GetGeneralContentByGuid_Test(string baseUrl, string route, string culture)
    {
        var routeResult = await _setup.UHeadlessClient.GetGeneralContentByAbsoluteRoute.ExecuteAsync(baseUrl, route, culture);

        routeResult.Errors.EnsureNoErrors();
        Assert.That(routeResult, Is.Not.Null);
        Assert.That(routeResult.Data, Is.Not.Null);
        Assert.That(routeResult.Data!.ContentByAbsoluteRoute, Is.Not.Null);
        Assert.That(routeResult.Data!.ContentByAbsoluteRoute!.Key, Is.Not.Null);

        var result = await _setup.UHeadlessClient.GetGeneralContentByGuid.ExecuteAsync(routeResult.Data!.ContentByAbsoluteRoute!.Key!.Value, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentByGuid, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentByGuid!.Id ?? 0, Is.GreaterThan(0));
            Assert.That(result.Data!.ContentByGuid!.Key, Is.Not.Null);
        });
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentByGuid!.Key, Is.Not.Empty);
            Assert.That(result.Data!.ContentByGuid!.Name, Is.Not.Empty);
            Assert.That(result.Data!.ContentByGuid!.CreatorId, Is.EqualTo(-1));
            Assert.That(result.Data!.ContentByGuid!.WriterId, Is.EqualTo(-1));
            Assert.That(result.Data!.ContentByGuid!.Properties?.All(property => property != null && !string.IsNullOrEmpty(property.Alias)), Is.True);
            Assert.That(result.Data!.ContentByGuid!.ItemType.ToString(), Is.Not.Empty);
            Assert.That(result.Data!.ContentByGuid!.Level, Is.GreaterThan(0));
            Assert.That(result.Data!.ContentByGuid!.Redirect == null || !string.IsNullOrEmpty(result.Data!.ContentByGuid!.Redirect.RedirectUrl), Is.True);
            Assert.That(result.Data!.ContentByGuid!.SortOrder, Is.GreaterThan(-1));
            Assert.That(result.Data!.ContentByGuid!.TemplateId == null || result.Data!.ContentByGuid!.TemplateId > 0, Is.True);
            Assert.That(result.Data!.ContentByGuid!.Url, Is.Not.Empty);
            Assert.That(result.Data!.ContentByGuid!.UrlSegment, Is.Not.Empty);
            Assert.That(result.Data!.ContentByGuid!.AbsoluteUrl, Is.Not.Empty);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => !string.IsNullOrEmpty(child!.Name)), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => child!.CreatorId == -1), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => child!.WriterId == -1), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => child!.Properties != null && child.Properties.All(property => !string.IsNullOrEmpty(property!.Alias))), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => !string.IsNullOrEmpty(child!.ItemType.ToString())), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => child!.Level > result.Data!.ContentByGuid!.Level), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => child!.Parent != null), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => !string.IsNullOrEmpty(child!.Parent!.Name)), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => child!.Redirect == null || !string.IsNullOrEmpty(child.Redirect.RedirectUrl)), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => child!.SortOrder > -1), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => child!.TemplateId == null || child!.TemplateId > 0), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => !string.IsNullOrEmpty(child!.Url)), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => !string.IsNullOrEmpty(child!.UrlSegment)), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => !string.IsNullOrEmpty(child!.AbsoluteUrl)), Is.True);
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
    public async Task GetNodeIdContentByGuid_Test(string baseUrl, string route, string culture)
    {
        var routeResult = await _setup.UHeadlessClient.GetGeneralContentByAbsoluteRoute.ExecuteAsync(baseUrl, route, culture);

        routeResult.Errors.EnsureNoErrors();
        Assert.That(routeResult, Is.Not.Null);
        Assert.That(routeResult.Data, Is.Not.Null);
        Assert.That(routeResult.Data!.ContentByAbsoluteRoute, Is.Not.Null);
        Assert.That(routeResult.Data!.ContentByAbsoluteRoute!.Key, Is.Not.Null);

        var result = await _setup.UHeadlessClient.GetNodeIdContentByGuid.ExecuteAsync(routeResult.Data!.ContentByAbsoluteRoute!.Key!.Value, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentByGuid, Is.Not.Null);
        Assert.That(result.Data!.ContentByGuid!.Id, Is.GreaterThan(0));
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
    public async Task GetPropertiesContentByGuid_Test(string baseUrl, string route, string culture)
    {
        var routeResult = await _setup.UHeadlessClient.GetGeneralContentByAbsoluteRoute.ExecuteAsync(baseUrl, route, culture);

        routeResult.Errors.EnsureNoErrors();
        Assert.That(routeResult, Is.Not.Null);
        Assert.That(routeResult.Data, Is.Not.Null);
        Assert.That(routeResult.Data!.ContentByAbsoluteRoute, Is.Not.Null);
        Assert.That(routeResult.Data!.ContentByAbsoluteRoute!.Key, Is.Not.Null);

        var result = await _setup.UHeadlessClient.GetPropertiesContentByGuid.ExecuteAsync(routeResult.Data!.ContentByAbsoluteRoute!.Key!.Value, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentByGuid, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentByGuid!.Properties, Is.Not.Null);
            Assert.That(result.Data!.ContentByGuid!.Properties!.All(property => !string.IsNullOrEmpty(property!.Alias)), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Properties!.All(property => !string.IsNullOrEmpty(property!.EditorAlias)), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Properties!.All(property => property!.Value != null), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Properties!.All(property => SharedValidation.IsPropertyValueValid(property!.Value!)), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => child!.Properties != null && child.Properties.All(property => SharedValidation.IsPropertyValueValid(property!.Value!))), Is.True);
        });
    }
}