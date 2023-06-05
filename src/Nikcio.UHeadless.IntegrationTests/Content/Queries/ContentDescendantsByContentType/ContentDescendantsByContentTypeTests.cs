using Nikcio.UHeadless.IntegrationTests.Extensions;
using Nikcio.UHeadless.IntegrationTests.Shared;
using StrawberryShake;

namespace Nikcio.UHeadless.IntegrationTests.Content.Queries.ContentDescendantsByContentType;

public class ContentDescendantsByContentTypeTests : IntegrationTestBase
{
    private readonly Setup _setup = new();

    [TearDown]
    public void TearDown()
    {
        _setup.Dispose();
    }

    [TestCase(null)]
    [TestCase("en-us")]
    [TestCase("da")]
    public async Task GetGeneralContentDescendantsByContentType_Test(string culture)
    {
        var result = await _setup.UHeadlessClient.GetGeneralContentDescendantsByContentType.ExecuteAsync(culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByContentType, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!, Is.Not.Empty);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Id > 0), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Key != null), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => !string.IsNullOrEmpty(node!.Name)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.CreatorId == -1), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.WriterId == -1), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Properties != null && node.Properties.All(property => property != null && !string.IsNullOrEmpty(property.Alias))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => !string.IsNullOrEmpty(node!.ItemType.ToString())), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Level > 0), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Redirect == null || !string.IsNullOrEmpty(node.Redirect.RedirectUrl)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.SortOrder > -1), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.TemplateId == null || node!.TemplateId > 0), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => !string.IsNullOrEmpty(node!.Url)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => !string.IsNullOrEmpty(node!.UrlSegment)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => !string.IsNullOrEmpty(node!.AbsoluteUrl)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Name))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.CreatorId == -1)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.WriterId == -1)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Properties != null && child.Properties.All(property => !string.IsNullOrEmpty(property!.Alias)))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.ItemType.ToString()))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Level > node.Level)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Parent != null)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Parent!.Name))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Redirect == null || !string.IsNullOrEmpty(child.Redirect.RedirectUrl))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.SortOrder > -1)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.TemplateId == null || child!.TemplateId > 0)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Url))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.UrlSegment))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.AbsoluteUrl))), Is.True);
        });
    }

    [TestCase(null)]
    [TestCase("en-us")]
    [TestCase("da")]
    public async Task GetNodeIdContentDescendantsByContentType_Test(string culture)
    {
        var result = await _setup.UHeadlessClient.GetNodeIdContentDescendantsByContentType.ExecuteAsync(culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByContentType, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!, Is.Not.Empty);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
    }

    [TestCase(0, null)]
    [TestCase(1, null)]
    [TestCase(5, null)]
    [TestCase(10, null)]
    [TestCase(0, "en-us")]
    [TestCase(1, "en-us")]
    [TestCase(10, "en-us")]
    [TestCase(5, "da")]
    public async Task GetFirstNodesContentDescendantsByContentType_Test(int firstCount, string culture)
    {
        var result = await _setup.UHeadlessClient.GetFirstNodesContentDescendantsByContentType.ExecuteAsync(firstCount, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByContentType, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes, Is.Not.Null);
        if (firstCount > 0)
        {
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!, Is.Not.Empty);
        }
        Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.Count == firstCount || !result.Data!.ContentDescendantsByContentType.PageInfo.HasNextPage, Is.True);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
    }

    [TestCase(null)]
    [TestCase("en-us")]
    [TestCase("da")]
    public async Task GetPropertiesContentDescendantsByContentType_Test(string culture)
    {
        var result = await _setup.UHeadlessClient.GetPropertiesContentDescendantsByContentType.ExecuteAsync(culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByContentType, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!, Is.Not.Empty);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Properties != null));
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Properties!.All(property => !string.IsNullOrEmpty(property!.Alias))));
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Properties!.All(property => !string.IsNullOrEmpty(property!.EditorAlias))));
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Properties!.All(property => property!.Value != null)));
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Properties!.All(property => SharedValidation.IsPropertyValueValid(property!.Value!))));
            Assert.That(result.Data!.ContentDescendantsByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Properties != null && child.Properties.All(property => SharedValidation.IsPropertyValueValid(property!.Value!)))));
        });
    }
}