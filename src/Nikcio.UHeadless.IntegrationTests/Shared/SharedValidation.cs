namespace Nikcio.UHeadless.IntegrationTests.Shared;
public static class SharedValidation
{
    internal static bool IsPropertyValueValid(IPropertyValues value)
    {
        if (value is IPropertyValues_BasicBlockListModel blockListModel)
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
        } else if (value is IPropertyValues_BasicContentPicker contentPicker)
        {
            Assert.That(contentPicker.ContentList, Is.Not.Null);
            Assert.That(contentPicker.ContentList!.All(item => item.Id > 0), Is.True);
            return true;
        } else if (value is IPropertyValues_BasicDateTimePicker dateTimePicker)
        {
            Assert.That(dateTimePicker.DateTime == null || dateTimePicker.DateTime != default, Is.True);
            return true;
        } else if (value is IPropertyValues_BasicLabel label)
        {
            Assert.That(label.Label, Is.Not.Null);
            //Assert.That(label.Label, Is.Not.Empty);
            return true;
        } else if (value is IPropertyValues_BasicMediaPicker mediaPicker)
        {
            Assert.That(mediaPicker.MediaItems, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(mediaPicker.MediaItems.All(item => item.Id > 0));
                Assert.That(mediaPicker.MediaItems.All(item => !string.IsNullOrEmpty(item.Url)));
            });
            return true;
        } else if (value is IPropertyValues_BasicMemberPicker memberPicker)
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
        } else if (value is IPropertyValues_BasicMultiUrlPicker multiUrlPicker)
        {
            Assert.That(multiUrlPicker.Links, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(multiUrlPicker.Links.All(link => !string.IsNullOrEmpty(link.Name)));
                Assert.That(multiUrlPicker.Links.All(link => !string.IsNullOrEmpty(link.Url)));
            });
            return true;
        } else if (value is IPropertyValues_BasicPropertyValue basicValue)
        {
            return true;
        } else if (value is IPropertyValues_BasicRichText richText)
        {
            Assert.Multiple(() =>
            {
                Assert.That(richText.RichText, Is.Not.Null);
                Assert.That(richText.SourceValue == null || !string.IsNullOrEmpty(richText.RichText), Is.True);
            });
            return true;
        } else if (value is IPropertyValues_BasicUnsupportedPropertyValue unsupportedValue)
        {
            Assert.That(unsupportedValue.Message, Is.Not.Null);
            Assert.That(unsupportedValue.Message, Is.Not.Empty);
            return true;
        } else if (value is IPropertyValues_BasicBlockGridModel blockGrid)
        {
            return true; // TODO: Add asserts
        }

        return false;
    }
}
