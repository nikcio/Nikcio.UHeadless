using Nikcio.UHeadless.IntegrationTests.Extensions;
using Nikcio.UHeadless.IntegrationTests.Shared;
using StrawberryShake;

namespace Nikcio.UHeadless.IntegrationTests.Content.Queries;

public class ContentAtRootTests : IntegrationTestBase
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
    public async Task GetGeneralContentAtRoot_Test(string culture)
    {
        var result = await _setup.UHeadlessClient.GetGeneralContentAtRoot.ExecuteAsync(culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentAtRoot, Is.Not.Null);
        Assert.That(result.Data!.ContentAtRoot!.Nodes, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentAtRoot!.Nodes!, Is.Not.Empty);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Id > 0), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Key != null), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => !string.IsNullOrEmpty(node!.Name)), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.CreatorId == -1), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.WriterId == -1), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Properties != null && node.Properties.All(property => property != null && !string.IsNullOrEmpty(property.Alias))), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => !string.IsNullOrEmpty(node!.ItemType.ToString())), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Level > 0), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Parent == null), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Redirect == null || !string.IsNullOrEmpty(node.Redirect.RedirectUrl)), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.SortOrder > -1), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.TemplateId == null || node!.TemplateId > 0), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => !string.IsNullOrEmpty(node!.Url)), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => !string.IsNullOrEmpty(node!.UrlSegment)), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => !string.IsNullOrEmpty(node!.AbsoluteUrl)), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Name))), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.CreatorId == -1)), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.WriterId == -1)), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Properties != null && child.Properties.All(property => !string.IsNullOrEmpty(property!.Alias)))), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.ItemType.ToString()))), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Level > node.Level)), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Parent != null)), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Parent!.Name))), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Redirect == null || !string.IsNullOrEmpty(child.Redirect.RedirectUrl))), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.SortOrder > -1)), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.TemplateId == null || child!.TemplateId > 0)), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Url))), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.UrlSegment))), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.AbsoluteUrl))), Is.True);
        });
    }

    [TestCase(null)]
    [TestCase("en-us")]
    [TestCase("da")]
    public async Task GetNodeIdContentAtRoot_Test(string culture)
    {
        var result = await _setup.UHeadlessClient.GetNodeIdContentAtRoot.ExecuteAsync(culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentAtRoot, Is.Not.Null);
        Assert.That(result.Data!.ContentAtRoot!.Nodes, Is.Not.Null);
        Assert.That(result.Data!.ContentAtRoot!.Nodes!, Is.Not.Empty);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
    }

    [TestCase(null)]
    [TestCase("en-us")]
    [TestCase("da")]
    public async Task GetPreviewNodeIdContentAtRoot_Test(string culture)
    {
        var normalResult = await _setup.UHeadlessClient.GetNodeIdContentAtRoot.ExecuteAsync(culture);

        var previewResult = await _setup.UHeadlessClient.GetPreviewNodeIdContentAtRoot.ExecuteAsync(culture);

        normalResult.Errors.EnsureNoErrors();
        Assert.That(normalResult, Is.Not.Null);
        Assert.That(normalResult.Data, Is.Not.Null);
        Assert.That(normalResult.Data!.ContentAtRoot, Is.Not.Null);
        Assert.That(normalResult.Data!.ContentAtRoot!.Nodes, Is.Not.Null);
        Assert.That(normalResult.Data!.ContentAtRoot!.Nodes!, Is.Not.Empty);
        Assert.Multiple(() =>
        {
            Assert.That(normalResult.Data!.ContentAtRoot!.Nodes!.All(node => node != null), Is.True);
            Assert.That(normalResult.Data!.ContentAtRoot!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
        previewResult.Errors.EnsureNoErrors();
        Assert.That(previewResult, Is.Not.Null);
        Assert.That(previewResult.Data, Is.Not.Null);
        Assert.That(previewResult.Data!.ContentAtRoot, Is.Not.Null);
        Assert.That(previewResult.Data!.ContentAtRoot!.Nodes, Is.Not.Null);
        Assert.That(previewResult.Data!.ContentAtRoot!.Nodes!, Is.Not.Empty);
        Assert.Multiple(() =>
        {
            Assert.That(previewResult.Data!.ContentAtRoot!.Nodes!.All(node => node != null), Is.True);
            Assert.That(previewResult.Data!.ContentAtRoot!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
        Assert.That(previewResult.Data!.ContentAtRoot!.Nodes!, Has.Count.GreaterThan(normalResult.Data!.ContentAtRoot!.Nodes!.Count));
    }

    [TestCase(0, null)]
    [TestCase(1, null)]
    [TestCase(5, null)]
    [TestCase(10, null)]
    [TestCase(0, "en-us")]
    [TestCase(1, "en-us")]
    [TestCase(10, "en-us")]
    [TestCase(5, "da")]
    public async Task GetFirstNodesContentAtRoot_Test(int firstCount, string culture)
    {
        var result = await _setup.UHeadlessClient.GetFirstNodesContentAtRoot.ExecuteAsync(firstCount, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentAtRoot, Is.Not.Null);
        Assert.That(result.Data!.ContentAtRoot!.Nodes, Is.Not.Null);
        if (firstCount > 0)
        {
            Assert.That(result.Data!.ContentAtRoot!.Nodes!, Is.Not.Empty);
        }
        Assert.That(result.Data!.ContentAtRoot!.Nodes!.Count == firstCount || !result.Data!.ContentAtRoot.PageInfo.HasNextPage, Is.True);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
    }

    [TestCase(null)]
    [TestCase("en-us")]
    [TestCase("da")]
    public async Task GetPropertiesContentAtRoot_Test(string culture)
    {
        var result = await _setup.UHeadlessClient.GetPropertiesContentAtRoot.ExecuteAsync(culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentAtRoot, Is.Not.Null);
        Assert.That(result.Data!.ContentAtRoot!.Nodes, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentAtRoot!.Nodes!, Is.Not.Empty);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Properties != null));
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Properties!.All(property => !string.IsNullOrEmpty(property!.Alias))));
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Properties!.All(property => !string.IsNullOrEmpty(property!.EditorAlias))));
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Properties!.All(property => property!.Value != null)));
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Properties!.All(property => SharedValidation.IsPropertyValueValid(property!.Value!))));
            Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Properties != null && child.Properties.All(property => SharedValidation.IsPropertyValueValid(property!.Value!)))));
        });
    }
}