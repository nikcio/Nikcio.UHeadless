using Nikcio.UHeadless.IntegrationTests.Extensions;
using StrawberryShake;

namespace Nikcio.UHeadless.IntegrationTests.Content.Queries;

[TestFixture]
public class ContentFromRootTests : IntegrationTestBase
{
   
    [Test]
    public async Task GeneralGetContentFromRoot_Test()
    {
        var setup = new Setup();

        var result = await setup.UHeadlessClient.GeneralGetContentFromRoot.ExecuteAsync();

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentAtRoot, Is.Not.Null);
        Assert.That(result.Data!.ContentAtRoot!.Nodes, Is.Not.Null);
        Assert.That(result.Data!.ContentAtRoot!.Nodes!.Count(), Is.GreaterThan(0));
        Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node != null), Is.True);
        Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => !string.IsNullOrEmpty(node!.Name)), Is.True);
        Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.CreatorId == -1), Is.True);
        Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.WriterId == -1), Is.True);
        Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Properties == null || node.Properties.All(property => property != null && !string.IsNullOrEmpty(property.Alias))), Is.True);
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
        Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Properties == null || child.Properties.All(property => !string.IsNullOrEmpty(property!.Alias)))), Is.True);
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
    }

    [Test]
    public async Task GetNodeIdGetContentFromRoot_Test()
    {
        var setup = new Setup();

        var result = await setup.UHeadlessClient.GetNodeIdGetContentFromRoot.ExecuteAsync();

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentAtRoot, Is.Not.Null);
        Assert.That(result.Data!.ContentAtRoot!.Nodes, Is.Not.Null);
        Assert.That(result.Data!.ContentAtRoot!.Nodes!.Count(), Is.GreaterThan(0));
        Assert.That(result.Data!.ContentAtRoot!.Nodes!.All(node => node != null && node.Id > 0), Is.True);
    }
}