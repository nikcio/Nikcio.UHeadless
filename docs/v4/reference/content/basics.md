# Content Basics

In Nikcio.UHeadless, content basics provide a way to extend existing models. These basics allow you to modify and enhance the functionality of content models according to your specific requirements. The following table presents the available content basics along with a brief description:

| Class Name                                                  | Description                                                                                     |
|-------------------------------------------------------------|-------------------------------------------------------------------------------------------------|
| BasicContent                                                | The basic class for extending the content model.                                                |
| BasicContent\<TProperty>                                    | The basic class for extending content models with properties of type TProperty.                 |
| BasicContent\<TProperty, TContentType>                      | The basic class for extending content models with properties of type TProperty and content type. |
| BasicContent\<TProperty, TContentType, TContentRedirect>    | The basic class for extending content models with properties of type TProperty, content type, and content redirect. |
| BasicContent\<TProperty, TContentType, TContentRedirect, TContent> | The basic class for extending content models with properties of type TProperty, content type, content redirect, and content. |
| BasicContentRedirect                                        | The basic class for extending content redirect models.                                           |

By utilizing these content basics, you can extend existing content models and tailor them to your specific application requirements. These basics serve as the foundation for modifying and enhancing the data of content model within Nikcio.UHeadless. They allow you to add custom properties and handle content redirection.

Note that the content basics should be used for extending existing models, and it's not recommended to use them for creating entirely new content models from scratch. The existing models provide a solid foundation, and extending them through the content basics offers flexibility and customization options without reinventing the wheel. If you want to create your content model from scratch you want to use a [base model](bases.md).