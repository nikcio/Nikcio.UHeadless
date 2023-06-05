using Nikcio.UHeadless.IntegrationTests.Extensions;
using Nikcio.UHeadless.IntegrationTests.Shared;
using StrawberryShake;

namespace Nikcio.UHeadless.IntegrationTests.Media.Queries.MediaByGuid;

public class MediaByGuidTests : IntegrationTestBase
{
    private readonly Setup _setup = new();

    [TearDown]
    public void TearDown()
    {
        _setup.Dispose();
    }

    [Test]
    public async Task GetGeneralMediaByGuid_Test()
    {
        var rootResult = await _setup.UHeadlessClient.GetGeneralMediaAtRoot.ExecuteAsync();

        rootResult.Errors.EnsureNoErrors();
        Assert.That(rootResult, Is.Not.Null);
        Assert.That(rootResult.Data, Is.Not.Null);
        Assert.That(rootResult.Data!.MediaAtRoot, Is.Not.Null);
        Assert.That(rootResult.Data!.MediaAtRoot!.Nodes, Is.Not.Empty);
        Assert.That(rootResult.Data!.MediaAtRoot!.Nodes!.All(node => node!.Key != null), Is.True);

        for (int i = 0; i < rootResult.Data!.MediaAtRoot!.Nodes!.Count; i++)
        {
            var result = await _setup.UHeadlessClient.GetGeneralMediaByGuid.ExecuteAsync(rootResult.Data!.MediaAtRoot!.Nodes[i]!.Key!.Value);

            result.Errors.EnsureNoErrors();
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data!.MediaByGuid, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Data!.MediaByGuid!.Id ?? 0, Is.GreaterThan(0));
                Assert.That(result.Data!.MediaByGuid!.Key, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(result.Data!.MediaByGuid!.Key, Is.Not.Empty);
                Assert.That(result.Data!.MediaByGuid!.Name, Is.Not.Empty);
                Assert.That(result.Data!.MediaByGuid!.CreatorId, Is.EqualTo(-1));
                Assert.That(result.Data!.MediaByGuid!.WriterId, Is.EqualTo(-1));
                Assert.That(result.Data!.MediaByGuid!.Properties?.All(property => property != null && !string.IsNullOrEmpty(property.Alias)), Is.True);
                Assert.That(result.Data!.MediaByGuid!.ItemType.ToString(), Is.Not.Empty);
                Assert.That(result.Data!.MediaByGuid!.Level, Is.GreaterThan(0));
                Assert.That(result.Data!.MediaByGuid!.SortOrder, Is.GreaterThan(-1));
                Assert.That(result.Data!.MediaByGuid!.Url, Is.Not.Null);
                Assert.That(result.Data!.MediaByGuid!.AbsoluteUrl, Is.Not.Null);
                Assert.That(result.Data!.MediaByGuid!.Children?.All(child => !string.IsNullOrEmpty(child!.Name)), Is.True);
                Assert.That(result.Data!.MediaByGuid!.Children?.All(child => child!.CreatorId == -1), Is.True);
                Assert.That(result.Data!.MediaByGuid!.Children?.All(child => child!.WriterId == -1), Is.True);
                Assert.That(result.Data!.MediaByGuid!.Children?.All(child => child!.Properties != null && child.Properties.All(property => !string.IsNullOrEmpty(property!.Alias))), Is.True);
                Assert.That(result.Data!.MediaByGuid!.Children?.All(child => !string.IsNullOrEmpty(child!.ItemType.ToString())), Is.True);
                Assert.That(result.Data!.MediaByGuid!.Children?.All(child => child!.Level > result.Data!.MediaByGuid!.Level), Is.True);
                Assert.That(result.Data!.MediaByGuid!.Children?.All(child => child!.Parent != null), Is.True);
                Assert.That(result.Data!.MediaByGuid!.Children?.All(child => !string.IsNullOrEmpty(child!.Parent!.Name)), Is.True);
                Assert.That(result.Data!.MediaByGuid!.Children?.All(child => child!.SortOrder > -1), Is.True);
                Assert.That(result.Data!.MediaByGuid!.Children?.All(child => child!.Url != null), Is.True);
                Assert.That(result.Data!.MediaByGuid!.Children?.All(child => child!.AbsoluteUrl != null), Is.True);
            });
        }
    }

    [Test]
    public async Task GetNodeIdMediaByGuid_Test()
    {
        var rootResult = await _setup.UHeadlessClient.GetGeneralMediaAtRoot.ExecuteAsync();

        rootResult.Errors.EnsureNoErrors();
        Assert.That(rootResult, Is.Not.Null);
        Assert.That(rootResult.Data, Is.Not.Null);
        Assert.That(rootResult.Data!.MediaAtRoot, Is.Not.Null);
        Assert.That(rootResult.Data!.MediaAtRoot!.Nodes, Is.Not.Empty);
        Assert.That(rootResult.Data!.MediaAtRoot!.Nodes!.All(node => node!.Key != null), Is.True);

        for (int i = 0; i < rootResult.Data!.MediaAtRoot!.Nodes!.Count; i++)
        {
            var result = await _setup.UHeadlessClient.GetNodeIdMediaByGuid.ExecuteAsync(rootResult.Data!.MediaAtRoot!.Nodes[i]!.Key!.Value);

            result.Errors.EnsureNoErrors();
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data!.MediaByGuid, Is.Not.Null);
            Assert.That(result.Data!.MediaByGuid!.Id, Is.GreaterThan(0));
        }
    }

    [Test]
    public async Task GetPropertiesMediaByGuid_Test()
    {
        var rootResult = await _setup.UHeadlessClient.GetGeneralMediaAtRoot.ExecuteAsync();

        rootResult.Errors.EnsureNoErrors();
        Assert.That(rootResult, Is.Not.Null);
        Assert.That(rootResult.Data, Is.Not.Null);
        Assert.That(rootResult.Data!.MediaAtRoot, Is.Not.Null);
        Assert.That(rootResult.Data!.MediaAtRoot!.Nodes, Is.Not.Empty);
        Assert.That(rootResult.Data!.MediaAtRoot!.Nodes!.All(node => node!.Key != null), Is.True);

        for (int i = 0; i < rootResult.Data!.MediaAtRoot!.Nodes!.Count; i++)
        {
            var result = await _setup.UHeadlessClient.GetPropertiesMediaByGuid.ExecuteAsync(rootResult.Data!.MediaAtRoot!.Nodes[i]!.Key!.Value);

            result.Errors.EnsureNoErrors();
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data!.MediaByGuid, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Data!.MediaByGuid!.Properties, Is.Not.Null);
                Assert.That(result.Data!.MediaByGuid!.Properties!.All(property => !string.IsNullOrEmpty(property!.Alias)), Is.True);
                Assert.That(result.Data!.MediaByGuid!.Properties!.All(property => !string.IsNullOrEmpty(property!.EditorAlias)), Is.True);
                Assert.That(result.Data!.MediaByGuid!.Properties!.All(property => property!.Value != null), Is.True);
                Assert.That(result.Data!.MediaByGuid!.Properties!.All(property => SharedValidation.IsPropertyValueValid(property!.Value!)), Is.True);
                Assert.That(result.Data!.MediaByGuid!.Children?.All(child => child!.Properties != null && child.Properties.All(property => SharedValidation.IsPropertyValueValid(property!.Value!))), Is.True);
            });
        }
    }
}