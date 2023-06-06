# Property Basics

In Nikcio.UHeadless, property basics provide a way to extend existing models and customize their behavior by adding additional properties and functionality. These basics allow you to modify and enhance the behavior and data structure of property models according to your specific requirements. The following table presents the available property basics along with a brief description:

| Class Name                                     | Description                                                                                       |
|------------------------------------------------|---------------------------------------------------------------------------------------------------|
| BasicProperty                                  | The basic class for extending the property model.                                                |
| BasicBlockGridArea                             | The basic class for extending block grid area model.                                            |
| BasicBlockGridArea\<TBlockGridItem>            | The basic class for extending block grid area model with a specific block grid item type.        |
| BasicBlockGridItem                             | The basic class for extending block grid item model.                                            |
| BasicBlockGridItem\<TProperty>                 | The basic class for extending block grid item model with properties of type TProperty.           |
| BasicBlockGridItem\<TProperty, TBlockGridArea> | The basic class for extending block grid item model with properties of type TProperty and a block grid area. |
| BasicBlockGridModel                            | The basic class for extending block grid model.                                                 |
| BasicBlockGridModel\<TBlockGridItem>           | The basic class for extending block grid model with a specific block grid item type.             |
| BasicBlockListItem                             | The basic class for extending block list item model.                                            |
| BasicBlockListItem\<TProperty>                 | The basic class for extending block list item model with properties of type TProperty.           |
| BasicBlockListModel                            | The basic class for extending block list model.                                                 |
| BasicBlockListModel\<TBlockListItem>           | The basic class for extending block list model with a specific block list item type.             |
| BasicContentPicker                             | The basic class for extending content picker model.                                             |
| BasicContentPicker\<TContentPickerItem>        | The basic class for extending content picker model with a specific content picker item type.     |
| BasicContentPickerItem                         | The basic class for extending content picker item model.                                        |
| BasicDateTimePicker                            | The basic class for extending date-time picker model.                                           |
| BasicPropertyValue                             | The basic class for extending property value model.                                             |
| BasicUnsupportedPropertyValue                  | The basic class for extending unsupported property value model.                                 |
| BasicLabel                                     | The basic class for extending label model.                                                      |
| BasicMediaPicker                               | The basic class for extending media picker model.                                               |
| BasicMediaPicker\<TMediaItem>                  | The basic class for extending media picker model with a specific media item type.               |
| BasicMediaPickerItem                           | The basic class for extending media picker item model.                                          |
| BasicMemberPicker                              | The basic class for extending member picker model.                                              |
| BasicMemberPicker\<TMember>                    | The basic class for extending member picker model with a specific member type.                  |
| BasicMemberPickerItem                          | The basic class for extending member picker item model.                                         |
| BasicMemberPickerItem\<TProperty>              | The basic class for extending member picker item model with properties of type TProperty.       |
| BasicMultiUrlPicker                            | The basic class for extending multi-url picker model.                                           |
| BasicMultiUrlPicker\<TLink>                    | The basic class for extending multi-url picker model with a specific link type.                 |
| BasicMultiUrlPickerItem                        | The basic class for extending multi-url picker item model.                                      |
| BasicNestedContent                             | The basic class for extending nested content model.                                             |
| BasicNestedContent\<TNestedContentElement>     | The basic class for extending nested content model with a specific nested content element type.  |
| BasicNestedContentElement                      | The basic class for extending nested content element model.                                     |
| BasicNestedContentElement\<TProperty>          | The basic class for extending nested content element model with properties of type TProperty.   |
| BasicRichText                                  | The basic class for extending rich text model.                                                  |

By utilizing these property basics, you can extend existing property models and tailor them to your specific application requirements. These basics serve as the foundation for modifying and enhancing the data of property model within Nikcio.UHeadless. They allow you to add custom properties.

Note that the property basics should be used for extending existing models, and it's not recommended to use them for creating entirely new property models from scratch. The existing models provide a solid foundation, and extending them through the property basics offers flexibility and customization options without reinventing the wheel. If you want to create your property model from scratch you want to use a [base model](bases.md).