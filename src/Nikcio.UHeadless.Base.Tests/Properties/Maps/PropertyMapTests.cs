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

    public class BasicClassAlternate : PropertyValue
    {
        public BasicClassAlternate(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
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

    [Test]
    public void ContainsEditor_ReturnsFalse_WhenEditorIsNotMapped()
    {
        var propertyMap = new PropertyMap();
        const string editorName = "Editor";

        var containsEditor = propertyMap.ContainsEditor(editorName);

        Assert.That(containsEditor, Is.False);
    }

    [Test]
    public void ContainsAlias_ReturnsFalse_WhenAliasIsNotMapped()
    {
        var propertyMap = new PropertyMap();
        const string contentTypeAlias = "contentType";
        const string propertyTypeAlias = "propertyType";

        var containsAlias = propertyMap.ContainsAlias(contentTypeAlias, propertyTypeAlias);

        Assert.That(containsAlias, Is.False);
    }

    [Test]
    public void GetEditorValue_ThrowsException_WhenEditorIsNotMapped()
    {
        var propertyMap = new PropertyMap();
        const string editorName = "Editor";

        Assert.Throws<KeyNotFoundException>(() => propertyMap.GetEditorValue(editorName));
    }

    [Test]
    public void GetAliasValue_ThrowsException_WhenAliasIsNotMapped()
    {
        var propertyMap = new PropertyMap();
        const string contentTypeAlias = "contentType";
        const string propertyTypeAlias = "propertyType";

        Assert.Throws<KeyNotFoundException>(() => propertyMap.GetAliasValue(contentTypeAlias, propertyTypeAlias));
    }

    [Test]
    public void GetAllTypes_ReturnsEmptyCollection_WhenNoMappings()
    {
        var propertyMap = new PropertyMap();

        var types = propertyMap.GetAllTypes();

        Assert.That(types.Count(), Is.EqualTo(0));
    }

    [Test]
    public void GetAllTypes_ReturnsCollectionWithOneType_WhenOneMapping()
    {
        var propertyMap = new PropertyMap();
        const string editorName = "Editor";
        var basicClassAssemblyName = typeof(BasicClass).AssemblyQualifiedName;

        propertyMap.AddEditorMapping<BasicClass>(editorName);
        var types = propertyMap.GetAllTypes();

        Assert.Multiple(() =>
        {
            Assert.That(types.Count(), Is.EqualTo(1));
            Assert.That(types, Is.InstanceOf<IEnumerable<Type>>());
            Assert.That(types.First().AssemblyQualifiedName, Is.EqualTo(basicClassAssemblyName));
        });
    }

    [Test]
    public void GetAllTypes_ReturnsCollectionWithTwoTypes_WhenTwoMappings()
    {
        var propertyMap = new PropertyMap();
        const string editorName = "Editor";
        const string contentTypeAlias = "contentType";
        const string propertyTypeAlias = "propertyType";
        var basicClassAssemblyName = typeof(BasicClass).AssemblyQualifiedName;

        propertyMap.AddEditorMapping<BasicClass>(editorName);
        propertyMap.AddAliasMapping<BasicClassAlternate>(contentTypeAlias, propertyTypeAlias);
        var types = propertyMap.GetAllTypes();

        Assert.Multiple(() =>
        {
            Assert.That(types.Count(), Is.EqualTo(2));
            Assert.That(types, Is.InstanceOf<IEnumerable<Type>>());
            Assert.That(types.First().AssemblyQualifiedName, Is.EqualTo(basicClassAssemblyName));
        });
    }

    [Test]
    public void GetAllTypes_ReturnsCollectionWithTwoTypes_WhenTwoMappingsWithSameType()
    {
        var propertyMap = new PropertyMap();
        const string editorName = "Editor";
        const string contentTypeAlias = "contentType";
        const string propertyTypeAlias = "propertyType";
        var basicClassAlternateAssemblyName = typeof(BasicClassAlternate).AssemblyQualifiedName;

        propertyMap.AddEditorMapping<BasicClassAlternate>(editorName);
        propertyMap.AddAliasMapping<BasicClass>(contentTypeAlias, propertyTypeAlias);
        propertyMap.AddAliasMapping<BasicClass>(contentTypeAlias, propertyTypeAlias);
        var types = propertyMap.GetAllTypes();

        Assert.Multiple(() =>
        {
            Assert.That(types.Count(), Is.EqualTo(2));
            Assert.That(types, Is.InstanceOf<IEnumerable<Type>>());
            Assert.That(types.First().AssemblyQualifiedName, Is.EqualTo(basicClassAlternateAssemblyName));
        });
    }

    [Test]
    public void GetAllTypes_ReturnsCollectionWithTwoTypes_WhenTwoMappingsWithSameTypeAndOneDifferent()
    {
        var propertyMap = new PropertyMap();
        const string editorName = "Editor";
        const string contentTypeAlias = "contentType";
        const string propertyTypeAlias = "propertyType";
        var basicClassAlternateAssemblyName = typeof(BasicClassAlternate).AssemblyQualifiedName;

        propertyMap.AddEditorMapping<BasicClassAlternate>(editorName);
        propertyMap.AddAliasMapping<BasicClass>(contentTypeAlias, propertyTypeAlias);
        propertyMap.AddAliasMapping<BasicClassAlternate>(contentTypeAlias, propertyTypeAlias);
        var types = propertyMap.GetAllTypes();

        Assert.Multiple(() =>
        {
            Assert.That(types.Count(), Is.EqualTo(2));
            Assert.That(types, Is.InstanceOf<IEnumerable<Type>>());
            Assert.That(types.First().AssemblyQualifiedName, Is.EqualTo(basicClassAlternateAssemblyName));
        });
    }

    [Test]
    public void GetAllTypes_ReturnsCollectionWithOneType_WhenTwoMappingsWithSameTypeAndOneDifferentAndOneEditor()
    {
        var propertyMap = new PropertyMap();
        const string editorName = "Editor";
        const string contentTypeAlias = "contentType";
        const string propertyTypeAlias = "propertyType";
        var basicClassAssemblyName = typeof(BasicClass).AssemblyQualifiedName;

        propertyMap.AddEditorMapping<BasicClass>(editorName);
        propertyMap.AddAliasMapping<BasicClass>(contentTypeAlias, propertyTypeAlias);
        propertyMap.AddAliasMapping<BasicClassAlternate>(contentTypeAlias, propertyTypeAlias);
        var types = propertyMap.GetAllTypes();

        Assert.Multiple(() =>
        {
            Assert.That(types.Count(), Is.EqualTo(1));
            Assert.That(types, Is.InstanceOf<IEnumerable<Type>>());
            Assert.That(types.First().AssemblyQualifiedName, Is.EqualTo(basicClassAssemblyName));
        });
    }
}
