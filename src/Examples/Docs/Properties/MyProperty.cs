using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Factories;

namespace Examples.Docs.Properties;

public class MyProperty : BasicProperty
{
    public string MyString { get; set; }

    public MyProperty(CreateProperty createProperty, IPropertyValueFactory propertyValueFactory) : base(createProperty, propertyValueFactory)
    {
        MyString = "My string";
    }
}
