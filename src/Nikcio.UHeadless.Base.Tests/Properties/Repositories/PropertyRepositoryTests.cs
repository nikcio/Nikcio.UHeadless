using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Base.Properties.Repositories;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;

namespace Nikcio.UHeadless.Base.Tests.Properties.Repositories;

public class PropertyRepositoryTests
{
    internal class TestProperty : Property
    {
        public TestProperty(CreateProperty _) : base(_)
        {
        }
    }

    private PropertyRespository<IProperty> _propertyRepository;

    [SetUp]
    public void Setup()
    {
        var property = new Mock<IPublishedProperty>();
        var content = new Mock<IPublishedContent>();
        content
            .Setup(x => x.Properties)
            .Returns(new List<IPublishedProperty> { property.Object });

        var createProperty = new Mock<CreateProperty>(property.Object, string.Empty, content.Object);
        var propertyFactory = new Mock<IPropertyFactory<IProperty>>();
        propertyFactory
            .Setup(x => x.GetProperty(It.IsAny<IPublishedProperty>(), It.IsAny<IPublishedContent>(), It.IsAny<string>()))
            .Returns(new TestProperty(createProperty.Object));


        var publishedContentCache = new Mock<IPublishedContentCache>();
        publishedContentCache
            .Setup(x => x.GetById(It.IsAny<int>()))
            .Returns(content.Object);
        publishedContentCache
            .Setup(x => x.GetAtRoot(It.IsAny<string>()))
            .Returns(new List<IPublishedContent> { content.Object, content.Object });

        var publishedSnapshot = new Mock<IPublishedSnapshot>();
        publishedSnapshot
            .Setup(x => x.Content)
            .Returns(publishedContentCache.Object);
        var publishedSnapshotObject = publishedSnapshot.Object;

        var publishedSnapshotAccessor = new Mock<IPublishedSnapshotAccessor>();
        publishedSnapshotAccessor
            .Setup(x => x.TryGetPublishedSnapshot(out publishedSnapshotObject))
            .Returns(true);

        var umbracoContextFactory = new Mock<IUmbracoContextFactory>();
        var logger = new Mock<ILogger<PropertyRespository<IProperty>>>();
        _propertyRepository = new PropertyRespository<IProperty>(propertyFactory.Object, publishedSnapshotAccessor.Object, umbracoContextFactory.Object, logger.Object);
    }

    [Test]
    public void GetContentItemProperties_GetContentById()
    {
        var contentItemProperties = _propertyRepository.GetContentItemProperties(x => x?.GetById(0), null);

        Assert.That(contentItemProperties, Is.Not.Null);
        Assert.That(contentItemProperties.ToList(), Is.InstanceOf<List<IProperty>>());
    }

    [Test]
    public void GetContentItemProperties_GetContentAtRoot()
    {
        var contentItemProperties = _propertyRepository.GetContentItemsProperties(x => x?.GetAtRoot(), null);

        Assert.That(contentItemProperties, Is.Not.Null);
        Assert.That(contentItemProperties.ToList(), Is.InstanceOf<List<IEnumerable<IProperty>>>());
    }

}
