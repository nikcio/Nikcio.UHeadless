using Nikcio.UHeadless.IntegrationTests.Extensions;
using StrawberryShake;

namespace Nikcio.UHeadless.IntegrationTests.Content.Queries;

[TestFixture]
public class ContentAllTests : IntegrationTestBase
{
    [TestCase(null)]
    [TestCase("en-us")]
    [TestCase("da")]
    public async Task GetGeneralContentAll_Test(string culture)
    {
        var setup = new Setup();

        var result = await setup.UHeadlessClient.GetGeneralContentAll.ExecuteAsync(culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentAll, Is.Not.Null);
        Assert.That(result.Data!.ContentAll!.Nodes, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentAll!.Nodes!, Is.Not.Empty);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Id > 0), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Key != null), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => !string.IsNullOrEmpty(node!.Name)), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.CreatorId == -1), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.WriterId == -1), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Properties != null && node.Properties.All(property => property != null && !string.IsNullOrEmpty(property.Alias))), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => !string.IsNullOrEmpty(node!.ItemType.ToString())), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Level > 0), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Redirect == null || !string.IsNullOrEmpty(node.Redirect.RedirectUrl)), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.SortOrder > -1), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.TemplateId == null || node!.TemplateId > 0), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => !string.IsNullOrEmpty(node!.Url)), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => !string.IsNullOrEmpty(node!.UrlSegment)), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => !string.IsNullOrEmpty(node!.AbsoluteUrl)), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Name))), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.CreatorId == -1)), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.WriterId == -1)), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Properties != null && child.Properties.All(property => !string.IsNullOrEmpty(property!.Alias)))), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.ItemType.ToString()))), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Level > node.Level)), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Parent != null)), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Parent!.Name))), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Redirect == null || !string.IsNullOrEmpty(child.Redirect.RedirectUrl))), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.SortOrder > -1)), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.TemplateId == null || child!.TemplateId > 0)), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.Url))), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.UrlSegment))), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Children == null || node.Children.All(child => !string.IsNullOrEmpty(child!.AbsoluteUrl))), Is.True);
        });
    }

    [TestCase(null)]
    [TestCase("en-us")]
    [TestCase("da")]
    public async Task GetNodeIdContentAll_Test(string culture)
    {
        var setup = new Setup();

        var result = await setup.UHeadlessClient.GetNodeIdContentAll.ExecuteAsync(culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentAll, Is.Not.Null);
        Assert.That(result.Data!.ContentAll!.Nodes, Is.Not.Null);
        Assert.That(result.Data!.ContentAll!.Nodes!, Is.Not.Empty);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
    }

    /// <summary>
    /// Tests preview nodes
    /// </summary>
    /// <remarks>
    /// If this starts to fail it might be because there's more than 50 nodes in the output and the native limit of 50 when selecting with "first: 50" will have to be set higher. Note: without the "first: 50" statement a maximum of 10 nodes will be returned at one time.
    /// </remarks>
    [TestCase(null)]
    [TestCase("en-us")]
    [TestCase("da")]
    public async Task GetPreviewNodeIdContentAll_Test(string culture)
    {
        var setup = new Setup();

        var normalResult = await setup.UHeadlessClient.GetNodeIdContentAll.ExecuteAsync(culture);

        var previewResult = await setup.UHeadlessClient.GetPreviewNodeIdContentAll.ExecuteAsync(culture);

        normalResult.Errors.EnsureNoErrors();
        Assert.That(normalResult, Is.Not.Null);
        Assert.That(normalResult.Data, Is.Not.Null);
        Assert.That(normalResult.Data!.ContentAll, Is.Not.Null);
        Assert.That(normalResult.Data!.ContentAll!.Nodes, Is.Not.Null);
        Assert.That(normalResult.Data!.ContentAll!.Nodes!, Is.Not.Empty);
        Assert.Multiple(() =>
        {
            Assert.That(normalResult.Data!.ContentAll!.Nodes!.All(node => node != null), Is.True);
            Assert.That(normalResult.Data!.ContentAll!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
        previewResult.Errors.EnsureNoErrors();
        Assert.That(previewResult, Is.Not.Null);
        Assert.That(previewResult.Data, Is.Not.Null);
        Assert.That(previewResult.Data!.ContentAll, Is.Not.Null);
        Assert.That(previewResult.Data!.ContentAll!.Nodes, Is.Not.Null);
        Assert.That(previewResult.Data!.ContentAll!.Nodes!, Is.Not.Empty);
        Assert.Multiple(() =>
        {
            Assert.That(previewResult.Data!.ContentAll!.Nodes!.All(node => node != null), Is.True);
            Assert.That(previewResult.Data!.ContentAll!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
        Assert.That(previewResult.Data!.ContentAll!.Nodes!, Has.Count.GreaterThan(normalResult.Data!.ContentAll!.Nodes!.Count));
    }

    [TestCase(0, null)]
    [TestCase(1, null)]
    [TestCase(2, null)]
    [TestCase(5, null)]
    [TestCase(10, null)]
    [TestCase(0, "en-us")]
    [TestCase(1, "en-us")]
    [TestCase(2, "en-us")]
    [TestCase(5, "en-us")]
    [TestCase(10, "en-us")]
    [TestCase(5, "da")]
    public async Task GetFirstNodesContentAll_Test(int firstCount, string culture)
    {
        var setup = new Setup();

        var result = await setup.UHeadlessClient.GetFirstNodesContentAll.ExecuteAsync(firstCount, culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentAll, Is.Not.Null);
        Assert.That(result.Data!.ContentAll!.Nodes, Is.Not.Null);
        if(firstCount > 0)
        {
            Assert.That(result.Data!.ContentAll!.Nodes!, Is.Not.Empty);
        }
        Assert.That(result.Data!.ContentAll!.Nodes!.Count == firstCount || !result.Data!.ContentAll.PageInfo.HasNextPage, Is.True);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Id > 0), Is.True);
        });
    }

    [TestCase(null)]
    [TestCase("en-us")]
    [TestCase("da")]
    public async Task GetPropertiesContentAll_Test(string culture)
    {
        var setup = new Setup();

        var result = await setup.UHeadlessClient.GetPropertiesContentAll.ExecuteAsync(culture);

        result.Errors.EnsureNoErrors();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.ContentAll, Is.Not.Null);
        Assert.That(result.Data!.ContentAll!.Nodes, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Data!.ContentAll!.Nodes!, Is.Not.Empty);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node != null), Is.True);
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Properties != null));
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Properties!.All(property => !string.IsNullOrEmpty(property!.Alias))));
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Properties!.All(property => !string.IsNullOrEmpty(property!.EditorAlias))));
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Properties!.All(property => property!.Value != null)));
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Properties!.All(property => IsPropertyValueValid(property!.Value!))));
            Assert.That(result.Data!.ContentAll!.Nodes!.All(node => node!.Children == null || node.Children.All(child => child!.Properties != null && child.Properties.All(property => IsPropertyValueValid(property!.Value!)))));
        });
    }

    private static bool IsPropertyValueValid(IGetPropertiesContentAll_ContentAll_Nodes_Properties_Value value)
    {
        if(value is IGetPropertiesContentAll_ContentAll_Nodes_Properties_Value_BasicBlockListModel blockListModel)
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
        } else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Properties_Value_BasicContentPicker contentPicker)
        {
            Assert.That(contentPicker.ContentList, Is.Not.Null);
            Assert.That(contentPicker.ContentList!.All(item => item.Id > 0), Is.True);
            return true;
        } else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Properties_Value_BasicDateTimePicker dateTimePicker)
        {
            Assert.That(dateTimePicker.DateTime == null || dateTimePicker.DateTime != default, Is.True);
            return true;
        } else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Properties_Value_BasicLabel label)
        {
            Assert.That(label.Label, Is.Not.Null);
            Assert.That(label.Label, Is.Not.Empty);
            return true;
        }
        else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Properties_Value_BasicMediaPicker mediaPicker)
        {
            Assert.That(mediaPicker.MediaItems, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(mediaPicker.MediaItems.All(item => item.Id > 0));
                Assert.That(mediaPicker.MediaItems.All(item => !string.IsNullOrEmpty(item.Url)));
            });
            return true;
        } else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Properties_Value_BasicMemberPicker memberPicker)
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
        } else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Properties_Value_BasicMultiUrlPicker multiUrlPicker)
        {
            Assert.That(multiUrlPicker.Links, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(multiUrlPicker.Links.All(link => !string.IsNullOrEmpty(link.Name)));
                Assert.That(multiUrlPicker.Links.All(link => !string.IsNullOrEmpty(link.Url)));
            });
            return true;
        } else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Properties_Value_BasicPropertyValue basicValue)
        {
            return true;
        }
        else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Properties_Value_BasicRichText richText)
        {
            Assert.Multiple(() =>
            {
                Assert.That(richText.RichText, Is.Not.Null);
                Assert.That(richText.SourceValue == null || !string.IsNullOrEmpty(richText.RichText), Is.True);
            });
            return true;
        } else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Properties_Value_BasicUnsupportedPropertyValue unsupportedValue)
        {
            Assert.That(unsupportedValue.Message, Is.Not.Null);
            Assert.That(unsupportedValue.Message, Is.Not.Empty);
            return true;
        }

        return false;
    }

    private static bool IsPropertyValueValid(IGetPropertiesContentAll_ContentAll_Nodes_Children_Properties_Value value)
    {
        if(value is IGetPropertiesContentAll_ContentAll_Nodes_Children_Properties_Value_BasicBlockListModel blockListModel)
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
        } else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Children_Properties_Value_BasicContentPicker contentPicker)
        {
            Assert.That(contentPicker.ContentList, Is.Not.Null);
            Assert.That(contentPicker.ContentList!.All(item => item.Id > 0), Is.True);
            return true;
        } else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Children_Properties_Value_BasicDateTimePicker dateTimePicker)
        {
            Assert.That(dateTimePicker.DateTime == null || dateTimePicker.DateTime != default, Is.True);
            return true;
        } else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Children_Properties_Value_BasicLabel label)
        {
            Assert.That(label.Label, Is.Not.Null);
            Assert.That(label.Label, Is.Not.Empty);
            return true;
        }
        else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Children_Properties_Value_BasicMediaPicker mediaPicker)
        {
            Assert.That(mediaPicker.MediaItems, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(mediaPicker.MediaItems.All(item => item.Id > 0));
                Assert.That(mediaPicker.MediaItems.All(item => !string.IsNullOrEmpty(item.Url)));
            });
            return true;
        } else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Children_Properties_Value_BasicMemberPicker memberPicker)
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
        } else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Children_Properties_Value_BasicMultiUrlPicker multiUrlPicker)
        {
            Assert.That(multiUrlPicker.Links, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(multiUrlPicker.Links.All(link => !string.IsNullOrEmpty(link.Name)));
                Assert.That(multiUrlPicker.Links.All(link => !string.IsNullOrEmpty(link.Url)));
            });
            return true;
        } else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Children_Properties_Value_BasicPropertyValue basicValue)
        {
            return true;
        }
        else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Children_Properties_Value_BasicRichText richText)
        {
            Assert.Multiple(() =>
            {
                Assert.That(richText.RichText, Is.Not.Null);
                Assert.That(richText.SourceValue == null || !string.IsNullOrEmpty(richText.RichText), Is.True);
            });
            return true;
        } else if(value is IGetPropertiesContentAll_ContentAll_Nodes_Children_Properties_Value_BasicUnsupportedPropertyValue unsupportedValue)
        {
            Assert.That(unsupportedValue.Message, Is.Not.Null);
            Assert.That(unsupportedValue.Message, Is.Not.Empty);
            return true;
        }

        return false;
    }
}