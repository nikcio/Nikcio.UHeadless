# Member Bases

In Nikcio.UHeadless, member bases provide a way to create custom models for handling member-related data. These bases allow you to define your own member data structure. It's important to note that using the interface to build new member models is not recommended because the member factory requires a specific model in the constructor that can be found in the concrete models, and it will not function without it. The following table presents the available member bases along with a brief description:

| Class Name  | Description                                 |
|-------------|---------------------------------------------|
| Member      | The base class for custom member models.    |
| IMember     | The interface for custom member models.     |

By utilizing these member bases, you can create your own member models tailored to your specific application requirements. These bases serve as the foundation for defining custom member structures within Nikcio.UHeadless.