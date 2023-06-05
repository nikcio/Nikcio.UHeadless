using Nikcio.UHeadless.IntegrationTests.Extensions;
using Nikcio.UHeadless.IntegrationTests.Shared;
using StrawberryShake;

namespace Nikcio.UHeadless.IntegrationTests.Media.Queries.MediaById;

public class MediaByIdTests : IntegrationTestBase
{
    private readonly Setup _setup = new();

    [TearDown]
    public void TearDown()
    {
        _setup.Dispose();
    }

    [Test]
    public async Task GetGeneralMediaById_Test()
    {
        var rootResult = await _setup.UHeadlessClient.GetGeneralMediaAtRoot.ExecuteAsync();

        rootResult.Errors.EnsureNoErrors();
        Assert.That(rootResult, Is.Not.Null);
        Assert.That(rootResult.Data, Is.Not.Null);
        Assert.That(rootResult.Data!.MediaAtRoot, Is.Not.Null);
        Assert.That(rootResult.Data!.MediaAtRoot!.Nodes, Is.Not.Empty);
        Assert.That(rootResult.Data!.MediaAtRoot!.Nodes!.All(node => node!.Id != null), Is.True);

        for (int i = 0; i < rootResult.Data!.MediaAtRoot!.Nodes!.Count; i++)
        {
            var result = await _setup.UHeadlessClient.GetGeneralMediaById.ExecuteAsync(rootResult.Data!.MediaAtRoot!.Nodes[i]!.Id!.Value);

            result.Errors.EnsureNoErrors();
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data!.MediaById, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Data!.MediaById!.Id ?? 0, Is.GreaterThan(0));
                Assert.That(result.Data!.MediaById!.Key, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(result.Data!.MediaById!.Key, Is.Not.Empty);
                Assert.That(result.Data!.MediaById!.Name, Is.Not.Empty);
                Assert.That(result.Data!.MediaById!.CreatorId, Is.EqualTo(-1));
                Assert.That(result.Data!.MediaById!.WriterId, Is.EqualTo(-1));
                Assert.That(result.Data!.MediaById!.Properties?.All(property => property != null && !string.IsNullOrEmpty(property.Alias)), Is.True);
                Assert.That(result.Data!.MediaById!.ItemType.ToString(), Is.Not.Empty);
                Assert.That(result.Data!.MediaById!.Level, Is.GreaterThan(0));
                Assert.That(result.Data!.MediaById!.SortOrder, Is.GreaterThan(-1));
                Assert.That(result.Data!.MediaById!.Url, Is.Not.Null);
                Assert.That(result.Data!.MediaById!.AbsoluteUrl, Is.Not.Null);
                Assert.That(result.Data!.MediaById!.Children?.All(child => !string.IsNullOrEmpty(child!.Name)), Is.True);
                Assert.That(result.Data!.MediaById!.Children?.All(child => child!.CreatorId == -1), Is.True);
                Assert.That(result.Data!.MediaById!.Children?.All(child => child!.WriterId == -1), Is.True);
                Assert.That(result.Data!.MediaById!.Children?.All(child => child!.Properties != null && child.Properties.All(property => !string.IsNullOrEmpty(property!.Alias))), Is.True);
                Assert.That(result.Data!.MediaById!.Children?.All(child => !string.IsNullOrEmpty(child!.ItemType.ToString())), Is.True);
                Assert.That(result.Data!.MediaById!.Children?.All(child => child!.Level > result.Data!.MediaById!.Level), Is.True);
                Assert.That(result.Data!.MediaById!.Children?.All(child => child!.Parent != null), Is.True);
                Assert.That(result.Data!.MediaById!.Children?.All(child => !string.IsNullOrEmpty(child!.Parent!.Name)), Is.True);
                Assert.That(result.Data!.MediaById!.Children?.All(child => child!.SortOrder > -1), Is.True);
                Assert.That(result.Data!.MediaById!.Children?.All(child => child!.Url != null), Is.True);
                Assert.That(result.Data!.MediaById!.Children?.All(child => child!.AbsoluteUrl != null), Is.True);
            });
        }
    }

    [Test]
    public async Task GetNodeIdMediaById_Test()
    {
        var rootResult = await _setup.UHeadlessClient.GetGeneralMediaAtRoot.ExecuteAsync();

        rootResult.Errors.EnsureNoErrors();
        Assert.That(rootResult, Is.Not.Null);
        Assert.That(rootResult.Data, Is.Not.Null);
        Assert.That(rootResult.Data!.MediaAtRoot, Is.Not.Null);
        Assert.That(rootResult.Data!.MediaAtRoot!.Nodes, Is.Not.Empty);
        Assert.That(rootResult.Data!.MediaAtRoot!.Nodes!.All(node => node!.Id != null), Is.True);

        for (int i = 0; i < rootResult.Data!.MediaAtRoot!.Nodes!.Count; i++)
        {
            var result = await _setup.UHeadlessClient.GetNodeIdMediaById.ExecuteAsync(rootResult.Data!.MediaAtRoot!.Nodes[i]!.Id!.Value);

            result.Errors.EnsureNoErrors();
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data!.MediaById, Is.Not.Null);
            Assert.That(result.Data!.MediaById!.Id, Is.GreaterThan(0));
        }
    }

    [Test]
    public async Task GetPropertiesMediaById_Test()
    {
        var rootResult = await _setup.UHeadlessClient.GetGeneralMediaAtRoot.ExecuteAsync();

        rootResult.Errors.EnsureNoErrors();
        Assert.That(rootResult, Is.Not.Null);
        Assert.That(rootResult.Data, Is.Not.Null);
        Assert.That(rootResult.Data!.MediaAtRoot, Is.Not.Null);
        Assert.That(rootResult.Data!.MediaAtRoot!.Nodes, Is.Not.Empty);
        Assert.That(rootResult.Data!.MediaAtRoot!.Nodes!.All(node => node!.Id != null), Is.True);

        for (int i = 0; i < rootResult.Data!.MediaAtRoot!.Nodes!.Count; i++)
        {
            var result = await _setup.UHeadlessClient.GetPropertiesMediaById.ExecuteAsync(rootResult.Data!.MediaAtRoot!.Nodes[i]!.Id!.Value);

            result.Errors.EnsureNoErrors();
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data!.MediaById, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Data!.MediaById!.Properties, Is.Not.Null);
                Assert.That(result.Data!.MediaById!.Properties!.All(property => !string.IsNullOrEmpty(property!.Alias)), Is.True);
                Assert.That(result.Data!.MediaById!.Properties!.All(property => !string.IsNullOrEmpty(property!.EditorAlias)), Is.True);
                Assert.That(result.Data!.MediaById!.Properties!.All(property => property!.Value != null), Is.True);
                Assert.That(result.Data!.MediaById!.Properties!.All(property => SharedValidation.IsPropertyValueValid(property!.Value!)), Is.True);
                Assert.That(result.Data!.MediaById!.Children?.All(child => child!.Properties != null && child.Properties.All(property => SharedValidation.IsPropertyValueValid(property!.Value!))), Is.True);
            });
        }
    }
}