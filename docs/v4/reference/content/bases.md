# Content Bases

In Nikcio.UHeadless, content bases provide a way to create custom models that can be used in place of existing models. These bases allow you to define your own content data structure. It's important to note that using the interface to build new content models is not recommended because the content factory requires a specific model in the constructor that can be found in the concrete models and will not function without it. The following table presents the available content bases along with a brief description:

| Class Name        | Description                                                          |
|-------------------|----------------------------------------------------------------------|
| Content           | The base class for custom content models.                            |
| IContent          | The interface for custom content models.                             |
| ContentRedirect   | The base class for content redirect models.                          |
| IContentRedirect  | The interface for content redirect models.                           |

By utilizing these content bases, you can create your own content models tailored to your specific application requirements. These bases serve as the foundation for defining custom content structures within Nikcio.UHeadless.