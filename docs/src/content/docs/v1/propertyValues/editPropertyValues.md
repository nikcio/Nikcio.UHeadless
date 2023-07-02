---
title: How to edit your property values
---

In this example, we will create a property value for the user picker.

Create a model for the property value that inherits from `PropertyValueBaseGraphType` or any of the other base models.
```csharp
using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;
using Umbraco.Cms.Core.Services;

namespace CustomPropertyMappings
{
    public class CustomUserPicker : PropertyValueBaseGraphType
    {
        public string Name { get; set; }

        public CustomUserPicker(CreatePropertyValue createPropertyValue, IUserService userService) : base(createPropertyValue)
        {
            var value = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (value == null)
            {
                return;
            }
            else if (value is int id)
            {
                var user = userService.GetUserById(id);
                Name = user.Name;
            }
        }
    }
}
```

Then you just add it to the custom property mappings:
```csharp
services.AddUmbraco(_env, _config)
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .AddUHeadless(customPropertyMappings: new List<Action<IPropertyMap>>
    {
        (x) => x.AddEditorMapping<CustomUserPicker>(Constants.PropertyEditors.Aliases.UserPicker)
    })
    .Build();
```

In this case, we change the model for the entire editor but it's also possible to make changes to a editor model on a specific content type using the `AddAliasMapping` method.