# Property Bases

In Nikcio.UHeadless, property bases provide a way to create custom models for handling property-related data. These bases allow you to define your own property data structure and behavior. It's important to note that using the interface to build new property models is not recommended because the property factory requires a specific model in the constructor that can be found in the concrete models, and it will not function without it. The following table presents the available property bases along with a brief description:

| Class Name             | Description                                                      |
|------------------------|------------------------------------------------------------------|
| Property               | The base class for custom property models.                       |
| IProperty              | The interface for custom property models.                        |
| PropertyValue          | The base class for property value models.                        |
| BlockGridArea          | The base class for block grid area models.                       |
| BlockGridItem          | The base class for block grid item models.                       |
| BlockListItem          | The base class for block list item models.                       |
| ContentPickerItem      | The base class for content picker item models.                   |
| MediaPickerItem        | The base class for media picker item models.                     |
| MemberPickerItem       | The base class for member picker item models.                    |
| MultiUrlPickerItem     | The base class for multi-url picker item models.                 |
| NestedContentElement   | The base class for nested content element models.                |

By utilizing these property bases, you can create your own property models tailored to your specific application requirements. These bases serve as the foundation for defining custom property structures within Nikcio.UHeadless.