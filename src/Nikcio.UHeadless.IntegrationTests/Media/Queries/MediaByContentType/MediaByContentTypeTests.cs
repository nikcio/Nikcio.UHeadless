using Nikcio.UHeadless.IntegrationTests.Extensions;
using Nikcio.UHeadless.IntegrationTests.Shared;
using StrawberryShake;

namespace Nikcio.UHeadless.IntegrationTests.Media.Queries.MediaByContentType;

public class MediaByContentTypeTests : IntegrationTestBase
{
    private readonly Setup _setup = new();

    [TearDown]
    public void TearDown()
    {
        _setup.Dispose();
    }

    [Test]
    public async Task GetGeneralMediaByContentType_Test()
    {
        var result = await _setup.UHeadlessClient.GetGeneralMediaByContentType.ExecuteAsync();

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.MediaByContentType, Is.Not.Null);
        Assert.That(result.Data!.MediaByContentType!.Nodes, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.MediaByContentType!.Nodes!, Is.Not.Empty);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Id > 0), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Key != null), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => !string.IsNullOrEmpty(node!.Name)), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.CreatorId == -1), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.WriterId == -1), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Properties != null && node.Properties.All(property => property != null && !string.IsNullOrEmpty(property.Alias))), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => !string.IsNullOrEmpty(node!.ItemType.ToString())), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Level > 0), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.SortOrder > -1), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Url != null), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.AbsoluteUrl != null), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Name))), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.CreatorId == -1)), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.WriterId == -1)), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Properties != null && child.Properties.All(property => !string.IsNullOrEmpty(property!.Alias)))), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.ItemType.ToString()))), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Level > node.Level)), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Parent != null)), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Parent!.Name))), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.SortOrder > -1)), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Url != null)), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.AbsoluteUrl != null)), Is.True);
        });
    }

    [Test]
    public async Task GetNodeIdMediaByContentType_Test()
    {
        var result = await _setup.UHeadlessClient.GetNodeIdMediaByContentType.ExecuteAsync();

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.MediaByContentType, Is.Not.Null);
        Assert.That(result.Data!.MediaByContentType!.Nodes, Is.Not.Null);
        Assert.That(result.Data!.MediaByContentType!.Nodes!, Is.Not.Empty);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(5)]
    [TestCase(10)]
    public async Task GetFirstNodesMediaByContentType_Test(int firstCount)
    {
        var result = await _setup.UHeadlessClient.GetFirstNodesMediaByContentType.ExecuteAsync(firstCount);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.MediaByContentType, Is.Not.Null);
        Assert.That(result.Data!.MediaByContentType!.Nodes, Is.Not.Null);
        if (firstCount > 0)
        {
            Assert.That(result.Data!.MediaByContentType!.Nodes!, Is.Not.Empty);
        }
        Assert.That(result.Data!.MediaByContentType!.Nodes!.Count == firstCount || !result.Data!.MediaByContentType.PageInfo.HasNextPage, Is.True);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
    }

    [Test]
    public async Task GetPropertiesMediaByContentType_Test()
    {
        var result = await _setup.UHeadlessClient.GetPropertiesMediaByContentType.ExecuteAsync();

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.MediaByContentType, Is.Not.Null);
        Assert.That(result.Data!.MediaByContentType!.Nodes, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.MediaByContentType!.Nodes!, Is.Not.Empty);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Properties != null));
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Properties!.All(property => !string.IsNullOrEmpty(property!.Alias))));
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Properties!.All(property => !string.IsNullOrEmpty(property!.EditorAlias))));
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Properties!.All(property => property!.Value != null)));
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Properties!.All(property => SharedValidation.IsPropertyValueValid(property!.Value!))));
            Assert.That(result.Data!.MediaByContentType!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Properties != null && child.Properties.All(property => SharedValidation.IsPropertyValueValid(property!.Value!)))));
        });
    }
}