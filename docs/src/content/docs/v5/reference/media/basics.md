---
title: Media Basics
description: Overview of media basics in Nikcio.UHeadless.
---

In Nikcio.UHeadless, media basics provide a way to extend existing models and customize their behavior. These basics allow you to modify and enhance the functionality of media models according to your specific requirements. The following table presents the available media basics along with a brief description:

| Class Name                            | Description                                                                                     |
|---------------------------------------|-------------------------------------------------------------------------------------------------|
| BasicMedia                            | The basic class for extending the media model.                                                  |
| BasicMedia\<TProperty>                | The basic class for extending media models with properties of type TProperty.                   |
| BasicMedia\<TProperty, TContentType>  | The basic class for extending media models with properties of type TProperty and content type.   |
| BasicMedia\<TProperty, TContentType, TMedia> | The basic class for extending media models with properties of type TProperty, content type, and media data. |

By utilizing these media basics, you can extend existing media models and tailor them to your specific application requirements. These basics serve as the foundation for modifying and enhancing the data of media model within Nikcio.UHeadless. They allow you to add custom properties.

Note that the media basics should be used for extending existing models, and it's not recommended to use them for creating entirely new media models from scratch. The existing models provide a solid foundation, and extending them through the media basics offers flexibility and customization options without reinventing the wheel. If you want to create your media model from scratch you want to use a [base model](../bases).