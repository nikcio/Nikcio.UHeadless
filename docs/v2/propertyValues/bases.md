# Base models

Bases are used for creating totally custom models. Bases do not require any properties but needs a constructor with the first arguemnt being a `Create` command. For example: `CreatePropertyValue` 

## Master base
* [PropertyValue](../../../src/Nikcio.UHeadless/UmbracoElements/Properties/Bases/Models/PropertyValue.cs)

This is the base for all property values.

## Block list
* [BlockListItem](../../../src/Nikcio.UHeadless/UmbracoElements/Properties/EditorsValues/BlockList/Models/BlockListItem.cs)

## Content picker
* [ContentPickerItem](../../../src/Nikcio.UHeadless/UmbracoElements/Properties/EditorsValues/ContentPicker/ContentPickerItem.cs)

## Media picker
* [MediaPickerItem](../../../src/Nikcio.UHeadless/UmbracoElements/Properties/EditorsValues/MediaPicker/Models/MediaPickerItem.cs)

## Member picker
* [MemberPickerItem](../../../src/Nikcio.UHeadless/UmbracoElements/Properties/EditorsValues/MemberPicker/Models/MemberPickerItem.cs)

## Multi url picker
* [MultiUrlPickerItem](../../../src/Nikcio.UHeadless/UmbracoElements/Properties/EditorsValues/MultiUrlPicker/Models/LinkPickerItem.cs)

## Nested Content
* [NestedContentElement](../../../src/Nikcio.UHeadless/UmbracoElements/Properties/EditorsValues/NestedContent/Models/NestedContentElement.cs)