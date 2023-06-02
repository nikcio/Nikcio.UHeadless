using Nikcio.UHeadless.IntegrationTests.Extensions;
using StrawberryShake;

namespace Nikcio.UHeadless.IntegrationTests.Content.Queries;

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
            Assert.That(result.Data!.ContentByGuid!.Properties!.All(property => IsPropertyValueValid(property!.Value!)), Is.True);
            Assert.That(result.Data!.ContentByGuid!.Children?.All(child => child!.Properties != null && child.Properties.All(property => IsPropertyValueValid(property!.Value!))), Is.True);
        });
    }

    private static bool IsPropertyValueValid(IGetPropertiesContentByGuid_ContentByGuid_Properties_Value value)
    {
        if (value is IGetPropertiesContentByGuid_ContentByGuid_Properties_Value_BasicBlockListModel blockListModel)
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
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Properties_Value_BasicContentPicker contentPicker)
        {
            Assert.That(contentPicker.ContentList, Is.Not.Null);
            Assert.That(contentPicker.ContentList!.All(item => item.Id > 0), Is.True);
            return true;
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Properties_Value_BasicDateTimePicker dateTimePicker)
        {
            Assert.That(dateTimePicker.DateTime == null || dateTimePicker.DateTime != default, Is.True);
            return true;
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Properties_Value_BasicLabel label)
        {
            Assert.That(label.Label, Is.Not.Null);
            Assert.That(label.Label, Is.Not.Empty);
            return true;
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Properties_Value_BasicMediaPicker mediaPicker)
        {
            Assert.That(mediaPicker.MediaItems, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(mediaPicker.MediaItems.All(item => item.Id > 0));
                Assert.That(mediaPicker.MediaItems.All(item => !string.IsNullOrEmpty(item.Url)));
            });
            return true;
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Properties_Value_BasicMemberPicker memberPicker)
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
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Properties_Value_BasicMultiUrlPicker multiUrlPicker)
        {
            Assert.That(multiUrlPicker.Links, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(multiUrlPicker.Links.All(link => !string.IsNullOrEmpty(link.Name)));
                Assert.That(multiUrlPicker.Links.All(link => !string.IsNullOrEmpty(link.Url)));
            });
            return true;
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Properties_Value_BasicPropertyValue basicValue)
        {
            return true;
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Properties_Value_BasicRichText richText)
        {
            Assert.Multiple(() =>
            {
                Assert.That(richText.RichText, Is.Not.Null);
                Assert.That(richText.SourceValue == null || !string.IsNullOrEmpty(richText.RichText), Is.True);
            });
            return true;
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Properties_Value_BasicUnsupportedPropertyValue unsupportedValue)
        {
            Assert.That(unsupportedValue.Message, Is.Not.Null);
            Assert.That(unsupportedValue.Message, Is.Not.Empty);
            return true;
        }

        return false;
    }

    private static bool IsPropertyValueValid(IGetPropertiesContentByGuid_ContentByGuid_Children_Properties_Value value)
    {
        if (value is IGetPropertiesContentByGuid_ContentByGuid_Children_Properties_Value_BasicBlockListModel blockListModel)
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
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Children_Properties_Value_BasicContentPicker contentPicker)
        {
            Assert.That(contentPicker.ContentList, Is.Not.Null);
            Assert.That(contentPicker.ContentList!.All(item => item.Id > 0), Is.True);
            return true;
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Children_Properties_Value_BasicDateTimePicker dateTimePicker)
        {
            Assert.That(dateTimePicker.DateTime == null || dateTimePicker.DateTime != default, Is.True);
            return true;
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Children_Properties_Value_BasicLabel label)
        {
            Assert.That(label.Label, Is.Not.Null);
            Assert.That(label.Label, Is.Not.Empty);
            return true;
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Children_Properties_Value_BasicMediaPicker mediaPicker)
        {
            Assert.That(mediaPicker.MediaItems, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(mediaPicker.MediaItems.All(item => item.Id > 0));
                Assert.That(mediaPicker.MediaItems.All(item => !string.IsNullOrEmpty(item.Url)));
            });
            return true;
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Children_Properties_Value_BasicMemberPicker memberPicker)
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
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Children_Properties_Value_BasicMultiUrlPicker multiUrlPicker)
        {
            Assert.That(multiUrlPicker.Links, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(multiUrlPicker.Links.All(link => !string.IsNullOrEmpty(link.Name)));
                Assert.That(multiUrlPicker.Links.All(link => !string.IsNullOrEmpty(link.Url)));
            });
            return true;
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Children_Properties_Value_BasicPropertyValue basicValue)
        {
            return true;
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Children_Properties_Value_BasicRichText richText)
        {
            Assert.Multiple(() =>
            {
                Assert.That(richText.RichText, Is.Not.Null);
                Assert.That(richText.SourceValue == null || !string.IsNullOrEmpty(richText.RichText), Is.True);
            });
            return true;
        } else if (value is IGetPropertiesContentByGuid_ContentByGuid_Children_Properties_Value_BasicUnsupportedPropertyValue unsupportedValue)
        {
            Assert.That(unsupportedValue.Message, Is.Not.Null);
            Assert.That(unsupportedValue.Message, Is.Not.Empty);
            return true;
        }

        return false;
    }
}