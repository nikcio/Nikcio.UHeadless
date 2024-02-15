using Nikcio.UHeadless.IntegrationTests.Extensions;
using Nikcio.UHeadless.IntegrationTests.Shared;
using StrawberryShake;

namespace Nikcio.UHeadless.IntegrationTests.Media.Queries.MediaAtRoot;

public class MediaAtRootTests : IntegrationTestBase
{
    private Setup _setup = new();

    [SetUp]
    public async Task Setup()
    {
        _setup = new();
        await _setup.Prepare();
    }

    [Test]
    public async Task GetGeneralMediaAtRoot_Test()
    {
        var result = await _setup.UHeadlessClient.GetGeneralMediaAtRoot.ExecuteAsync();

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.MediaAtRoot, Is.Not.Null);
        Assert.That(result.Data!.MediaAtRoot!.Nodes, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.MediaAtRoot!.Nodes!, Is.Not.Empty);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Id > 0), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Key != null), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => !string.IsNullOrEmpty(node!.Name)), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.CreatorId == -1), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.WriterId == -1), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Properties != null && node.Properties.All(property => property != null && !string.IsNullOrEmpty(property.Alias))), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => !string.IsNullOrEmpty(node!.ItemType.ToString())), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Level > 0), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Parent == null), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.SortOrder > -1), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Url != null), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.AbsoluteUrl != null), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Name))), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.CreatorId == -1)), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.WriterId == -1)), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Properties != null && child.Properties.All(property => !string.IsNullOrEmpty(property!.Alias)))), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.ItemType.ToString()))), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Level > node.Level)), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Parent != null)), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Parent!.Name))), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.SortOrder > -1)), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Url != null)), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.AbsoluteUrl != null)), Is.True);
        });
    }

    [Test]
    public async Task GetNodeIdMediaAtRoot_Test()
    {
        var result = await _setup.UHeadlessClient.GetNodeIdMediaAtRoot.ExecuteAsync();

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.MediaAtRoot, Is.Not.Null);
        Assert.That(result.Data!.MediaAtRoot!.Nodes, Is.Not.Null);
        Assert.That(result.Data!.MediaAtRoot!.Nodes!, Is.Not.Empty);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(5)]
    [TestCase(10)]
    public async Task GetFirstNodesMediaAtRoot_Test(int firstCount)
    {
        var result = await _setup.UHeadlessClient.GetFirstNodesMediaAtRoot.ExecuteAsync(firstCount);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.MediaAtRoot, Is.Not.Null);
        Assert.That(result.Data!.MediaAtRoot!.Nodes, Is.Not.Null);
        if (firstCount > 0)
        {
            Assert.That(result.Data!.MediaAtRoot!.Nodes!, Is.Not.Empty);
        }
        Assert.That(result.Data!.MediaAtRoot!.Nodes!.Count == firstCount || !result.Data!.MediaAtRoot.PageInfo.HasNextPage, Is.True);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
    }

    [Test]
    public async Task GetPropertiesMediaAtRoot_Test()
    {
        var result = await _setup.UHeadlessClient.GetPropertiesMediaAtRoot.ExecuteAsync();

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.MediaAtRoot, Is.Not.Null);
        Assert.That(result.Data!.MediaAtRoot!.Nodes, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.MediaAtRoot!.Nodes!, Is.Not.Empty);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Properties != null));
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Properties!.All(property => !string.IsNullOrEmpty(property!.Alias))));
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Properties!.All(property => !string.IsNullOrEmpty(property!.EditorAlias))));
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Properties!.All(property => property!.Value != null)));
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Properties!.All(property => SharedValidation.IsPropertyValueValid(property!.Value!))));
            Assert.That(result.Data!.MediaAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Properties != null && child.Properties.All(property => SharedValidation.IsPropertyValueValid(property!.Value!)))));
        });
    }
}