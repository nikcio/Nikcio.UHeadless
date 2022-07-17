# Base models

Bases are used for creating totally custom models. Bases do not require any properties but needs a constructor with the first arguemnt being a `Create` command. For example: `CreatePropertyValue` 

## Master base
* [PropertyValue](../../../src/Nikcio.UHeadless.Base/Properties/Models/PropertyValue.cs)

This is the base for all property values.

## Block list
* [BlockListItem](../../../src/Nikcio.UHeadless.Base/Properties/EditorsValues/BlockList/Models/BlockListItem.cs)

## Content picker
* [ContentPickerItem](../../../src/Nikcio.UHeadless.Base/Properties/EditorsValues/ContentPicker/Models/ContentPickerItem.cs)

## Media picker
* [MediaPickerItem](../../../src/Nikcio.UHeadless.Base/Properties/EditorsValues/MediaPicker/Models/MediaPickerItem.cs)

## Member picker
* [MemberPickerItem](../../../src/Nikcio.UHeadless.Base/Properties/EditorsValues/MemberPicker/Models/MemberPickerItem.cs)

## Multi url picker
* [MultiUrlPickerItem](../../../src/Nikcio.UHeadless.Base/Properties/EditorsValues/MultiUrlPicker/Models/MultiUrlPickerItem.cs)

## Nested Content
* [NestedContentElement](../../../src/Nikcio.UHeadless.Base/Properties/EditorsValues/NestedContent/Models/NestedContentElement.cs)