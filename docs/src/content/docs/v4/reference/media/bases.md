---
title: Media Bases
description: Overview of media bases in Nikcio.UHeadless.
---

In Nikcio.UHeadless, media bases provide a way to create custom models for handling media content. These bases allow you to define your own media data structure and behavior. It's important to note that using the interface to build new media models is not recommended because the media factory requires a specific model in the constructor that can be found in the concrete models, and it will not function without it. The following table presents the available media bases along with a brief description:

| Class Name  | Description                                 |
|-------------|---------------------------------------------|
| Media       | The base class for custom media models.     |
| IMedia      | The interface for custom media models.      |

By utilizing these media bases, you can create your own media models tailored to your specific application requirements. These bases serve as the foundation for defining custom media structures within Nikcio.UHeadless.