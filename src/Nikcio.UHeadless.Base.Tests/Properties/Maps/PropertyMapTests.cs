using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Maps;
using Nikcio.UHeadless.Base.Properties.Models;

namespace Nikcio.UHeadless.Base.Tests.Properties.Maps;

public class PropertyMapTests
{
    public class BasicClass : PropertyValue
    {
        public BasicClass(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
        {
        }
    }

    [Test]
    public void AddEditorMapping_BasicClass()
    {
        var propertyMap = new PropertyMap();
        const string editorName = "Editor";
        var basicClassAssemblyName = typeof(BasicClass).AssemblyQualifiedName;

        propertyMap.AddEditorMapping<BasicClass>(editorName);
        var containsEditor = propertyMap.ContainsEditor(editorName);
        var types = propertyMap.GetAllTypes();
        var value = propertyMap.GetEditorValue(editorName);

        Assert.That(containsEditor, Is.True);
        Assert.Multiple(() =>
        {
            Assert.That(types.Count(), Is.EqualTo(1));
            Assert.That(types, Is.InstanceOf<IEnumerable<Type>>());
        });
        Assert.That(value, Is.EqualTo(basicClassAssemblyName));
    }

    [Test]
    public void AddAliasMapping_BasicClass()
    {
        var propertyMap = new PropertyMap();
        const string contentTypeAlias = "contentType";
        const string propertyTypeAlias = "propertyType";
        var basicClassAssemblyName = typeof(BasicClass).AssemblyQualifiedName;

        propertyMap.AddAliasMapping<BasicClass>(contentTypeAlias, propertyTypeAlias);
        var containsEditor = propertyMap.ContainsAlias(contentTypeAlias, propertyTypeAlias);
        var types = propertyMap.GetAllTypes();
        var value = propertyMap.GetAliasValue(contentTypeAlias, propertyTypeAlias);

        Assert.That(containsEditor, Is.True);
        Assert.Multiple(() =>
        {
            Assert.That(types.Count(), Is.EqualTo(1));
            Assert.That(types, Is.InstanceOf<IEnumerable<Type>>());
        });
        Assert.That(value, Is.EqualTo(basicClassAssemblyName));
    }
}
