using Nikcio.UHeadless.IntegrationTests.Extensions;
using StrawberryShake;

namespace Nikcio.UHeadless.IntegrationTests.Content.Queries;

public class ContentDescendantsByAbsoluteRouteTests : IntegrationTestBase
{
    [TestCase("https://site-1.com", "/", null)]
    [TestCase("https://site-1.com", "/collection-of-pages", null)]
    [TestCase("", "/no-domain-site", null)]
    [TestCase("https://site-2.com", "/", null)]
    [TestCase("https://site-culture.com", "/", "en-us")]
    [TestCase("https://site-culture.com", "/homepage", "en-us")]
    [TestCase("https://site-culture.com", "/", null)]
    [TestCase("https://site-culture.com", "/homepage", null)]
    [TestCase("https://site-culture.dk", "/", "da")]
    [TestCase("https://site-culture.dk", "/homepage", "da")]
    public async Task GetGeneralContentDescendantsByAbsoluteRoute_Test(string baseUrl, string route, string culture)
    {
        var setup = new Setup();

        var result = await setup.UHeadlessClient.GetGeneralContentDescendantsByAbsoluteRoute.ExecuteAsync(baseUrl, route, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!, Is.Not.Empty);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Id > 0), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Key != null), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => !string.IsNullOrEmpty(node!.Name)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.CreatorId == -1), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.WriterId == -1), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Properties != null && node.Properties.All(property => property != null && !string.IsNullOrEmpty(property.Alias))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => !string.IsNullOrEmpty(node!.ItemType.ToString())), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Level > 0), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Redirect == null || !string.IsNullOrEmpty(node.Redirect.RedirectUrl)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.SortOrder > -1), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.TemplateId == null || node!.TemplateId > 0), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => !string.IsNullOrEmpty(node!.Url)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => !string.IsNullOrEmpty(node!.UrlSegment)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => !string.IsNullOrEmpty(node!.AbsoluteUrl)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Name))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.CreatorId == -1)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.WriterId == -1)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Properties != null && child.Properties.All(property => !string.IsNullOrEmpty(property!.Alias)))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.ItemType.ToString()))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Level > node.Level)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Parent != null)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Parent!.Name))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Redirect == null || !string.IsNullOrEmpty(child.Redirect.RedirectUrl))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.SortOrder > -1)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.TemplateId == null || child!.TemplateId > 0)), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Url))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.UrlSegment))), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.AbsoluteUrl))), Is.True);
        });
    }

    [TestCase("https://site-1.com", "/", null)]
    [TestCase("https://site-1.com", "/collection-of-pages", null)]
    [TestCase("", "/no-domain-site", null)]
    [TestCase("https://site-2.com", "/", null)]
    [TestCase("https://site-culture.com", "/", "en-us")]
    [TestCase("https://site-culture.com", "/homepage", "en-us")]
    [TestCase("https://site-culture.com", "/", null)]
    [TestCase("https://site-culture.com", "/homepage", null)]
    [TestCase("https://site-culture.dk", "/", "da")]
    [TestCase("https://site-culture.dk", "/homepage", "da")]
    public async Task GetNodeIdContentDescendantsByAbsoluteRoute_Test(string baseUrl, string route, string culture)
    {
        var setup = new Setup();

        var result = await setup.UHeadlessClient.GetNodeIdContentDescendantsByAbsoluteRoute.ExecuteAsync(baseUrl, route, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!, Is.Not.Empty);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
    }

    [TestCase("https://site-1.com/", "/", 0, null)]
    [TestCase("https://site-1.com/", "/", 1, null)]
    [TestCase("https://site-1.com/", "/", 2, null)]
    [TestCase("https://site-1.com/", "/", 5, null)]
    [TestCase("https://site-1.com/", "/", 10, null)]
    [TestCase("https://site-culture.com/", "/", 0, null)]
    [TestCase("https://site-culture.com/", "/", 1, null)]
    [TestCase("https://site-culture.com/", "/", 2, null)]
    [TestCase("https://site-culture.com/", "/", 5, null)]
    [TestCase("https://site-culture.com/", "/", 10, null)]
    [TestCase("https://site-culture.com/", "/", 0, "en-us")]
    [TestCase("https://site-culture.com/", "/", 1, "en-us")]
    [TestCase("https://site-culture.com/", "/", 2, "en-us")]
    [TestCase("https://site-culture.com/", "/", 5, "en-us")]
    [TestCase("https://site-culture.com/", "/", 10, "en-us")]
    public async Task GetFirstNodesContentDescendantsByAbsoluteRoute_Test(string baseUrl, string route, int firstCount, string culture)
    {
        var setup = new Setup();

        var result = await setup.UHeadlessClient.GetFirstNodesContentDescendantsByAbsoluteRoute.ExecuteAsync(baseUrl, route, firstCount, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes, Is.Not.Null);
        if(firstCount > 0)
        {
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!, Is.Not.Empty);
        }
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.Count == firstCount || !result.Data!.ContentDescendantsByAbsoluteRoute.PageInfo.HasNextPage, Is.True);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
    }

    [TestCase("https://site-1.com", "/", null)]
    [TestCase("https://site-1.com", "/collection-of-pages", null)]
    [TestCase("", "/no-domain-site", null)]
    [TestCase("https://site-2.com", "/", null)]
    [TestCase("https://site-culture.com", "/", "en-us")]
    [TestCase("https://site-culture.com", "/homepage", "en-us")]
    [TestCase("https://site-culture.com", "/", null)]
    [TestCase("https://site-culture.com", "/homepage", null)]
    [TestCase("https://site-culture.dk", "/", "da")]
    [TestCase("https://site-culture.dk", "/homepage", "da")]
    public async Task GetPropertiesContentDescendantsByAbsoluteRoute_Test(string baseUrl, string route, string culture)
    {
        var setup = new Setup();

        var result = await setup.UHeadlessClient.GetPropertiesContentDescendantsByAbsoluteRoute.ExecuteAsync(baseUrl, route, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute, Is.Not.Null);
        Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!, Is.Not.Empty);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Properties != null));
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Properties!.All(property => !string.IsNullOrEmpty(property!.Alias))));
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Properties!.All(property => !string.IsNullOrEmpty(property!.EditorAlias))));
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Properties!.All(property => property!.Value != null)));
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Properties!.All(property => IsPropertyValueValid(property!.Value!))));
            Assert.That(result.Data!.ContentDescendantsByAbsoluteRoute!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Properties != null && child.Properties.All(property => IsPropertyValueValid(property!.Value!)))));
        });
    }

    private static bool IsPropertyValueValid(IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Properties_Value value)
    {
        if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Properties_Value_BasicBlockListModel blockListModel)
        {
            Assert.That(blockListModel.Blocks, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(blockListModel.Blocks!.All(block => block.ContentProperties != null));
                Assert.That(blockListModel.Blocks!.All(block => block.ContentProperties.All(property => property!.Value != null)));
            });
            // TODO: ContentProperty validation
            // TODO: SettingProperty validation
            return true;
        } else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Properties_Value_BasicContentPicker contentPicker)
        {
            Assert.That(contentPicker.ContentList, Is.Not.Null);
            Assert.That(contentPicker.ContentList!.All(item => item.Id > 0), Is.True);
            return true;
        } else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Properties_Value_BasicDateTimePicker dateTimePicker)
        {
            Assert.That(dateTimePicker.DateTime == null || dateTimePicker.DateTime != default, Is.True);
            return true;
        } else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Properties_Value_BasicLabel label)
        {
            Assert.That(label.Label, Is.Not.Null);
            Assert.That(label.Label, Is.Not.Empty);
            return true;
        }
        else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Properties_Value_BasicMediaPicker mediaPicker)
        {
            Assert.That(mediaPicker.MediaItems, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(mediaPicker.MediaItems.All(item => item.Id > 0));
                Assert.That(mediaPicker.MediaItems.All(item => !string.IsNullOrEmpty(item.Url)));
            });
            return true;
        } else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Properties_Value_BasicMemberPicker memberPicker)
        {
            Assert.That(memberPicker.Members, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(memberPicker.Members.All(member => member.Id > 0));
                Assert.That(memberPicker.Members.All(member => !string.IsNullOrEmpty(member.Name)));
                Assert.That(memberPicker.Members.All(member => member.Properties != null));
            });
            // TODO: Member property validation
            return true;
        } else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Properties_Value_BasicMultiUrlPicker multiUrlPicker)
        {
            Assert.That(multiUrlPicker.Links, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(multiUrlPicker.Links.All(link => !string.IsNullOrEmpty(link.Name)));
                Assert.That(multiUrlPicker.Links.All(link => !string.IsNullOrEmpty(link.Url)));
            });
            return true;
        } else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Properties_Value_BasicPropertyValue basicValue)
        {
            return true;
        }
        else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Properties_Value_BasicRichText richText)
        {
            Assert.Multiple(() =>
            {
                Assert.That(richText.RichText, Is.Not.Null);
                Assert.That(richText.SourceValue == null || !string.IsNullOrEmpty(richText.RichText), Is.True);
            });
            return true;
        } else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Properties_Value_BasicUnsupportedPropertyValue unsupportedValue)
        {
            Assert.That(unsupportedValue.Message, Is.Not.Null);
            Assert.That(unsupportedValue.Message, Is.Not.Empty);
            return true;
        }

        return false;
    }

    private static bool IsPropertyValueValid(IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Children_Properties_Value value)
    {
        if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Children_Properties_Value_BasicBlockListModel blockListModel)
        {
            Assert.That(blockListModel.Blocks, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(blockListModel.Blocks!.All(block => block.ContentProperties != null));
                Assert.That(blockListModel.Blocks!.All(block => block.ContentProperties.All(property => property!.Value != null)));
            });
            // TODO: ContentProperty validation
            // TODO: SettingProperty validation
            return true;
        } else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Children_Properties_Value_BasicContentPicker contentPicker)
        {
            Assert.That(contentPicker.ContentList, Is.Not.Null);
            Assert.That(contentPicker.ContentList!.All(item => item.Id > 0), Is.True);
            return true;
        } else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Children_Properties_Value_BasicDateTimePicker dateTimePicker)
        {
            Assert.That(dateTimePicker.DateTime == null || dateTimePicker.DateTime != default, Is.True);
            return true;
        } else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Children_Properties_Value_BasicLabel label)
        {
            Assert.That(label.Label, Is.Not.Null);
            Assert.That(label.Label, Is.Not.Empty);
            return true;
        }
        else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Children_Properties_Value_BasicMediaPicker mediaPicker)
        {
            Assert.That(mediaPicker.MediaItems, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(mediaPicker.MediaItems.All(item => item.Id > 0));
                Assert.That(mediaPicker.MediaItems.All(item => !string.IsNullOrEmpty(item.Url)));
            });
            return true;
        } else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Children_Properties_Value_BasicMemberPicker memberPicker)
        {
            Assert.That(memberPicker.Members, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(memberPicker.Members.All(member => member.Id > 0));
                Assert.That(memberPicker.Members.All(member => !string.IsNullOrEmpty(member.Name)));
                Assert.That(memberPicker.Members.All(member => member.Properties != null));
            });
            // TODO: Member property validation
            return true;
        } else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Children_Properties_Value_BasicMultiUrlPicker multiUrlPicker)
        {
            Assert.That(multiUrlPicker.Links, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(multiUrlPicker.Links.All(link => !string.IsNullOrEmpty(link.Name)));
                Assert.That(multiUrlPicker.Links.All(link => !string.IsNullOrEmpty(link.Url)));
            });
            return true;
        } else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Children_Properties_Value_BasicPropertyValue basicValue)
        {
            return true;
        }
        else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Children_Properties_Value_BasicRichText richText)
        {
            Assert.Multiple(() =>
            {
                Assert.That(richText.RichText, Is.Not.Null);
                Assert.That(richText.SourceValue == null || !string.IsNullOrEmpty(richText.RichText), Is.True);
            });
            return true;
        } else if(value is IGetPropertiesContentDescendantsByAbsoluteRoute_ContentDescendantsByAbsoluteRoute_Nodes_Children_Properties_Value_BasicUnsupportedPropertyValue unsupportedValue)
        {
            Assert.That(unsupportedValue.Message, Is.Not.Null);
            Assert.That(unsupportedValue.Message, Is.Not.Empty);
            return true;
        }

        return false;
    }
}