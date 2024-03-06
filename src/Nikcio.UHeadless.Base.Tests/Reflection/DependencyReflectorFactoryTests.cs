using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Core.Reflection.Factories;
using NSubstitute;

namespace Nikcio.UHeadless.Base.Tests.Reflection;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class DependencyReflectorFactoryTests
{
    internal class BasicClass
    {
        public string Required { get; }
        public BasicClass(string required)
        {
            Required = required;
        }
    }

    [Test]
    public void GetReflectedType_BasicClass()
    {
        var serviceProvider = Substitute.For<IServiceProvider>();
        var logger = Substitute.For<ILogger<DependencyReflectorFactory>>();
        var reflectorFactory = new DependencyReflectorFactory(serviceProvider, logger);
        const string expectedRequiredValue = "Required";
        var constructorRequiredParamerters = new[] { expectedRequiredValue };

        var reflectedType = reflectorFactory.GetReflectedType<BasicClass>(typeof(BasicClass), constructorRequiredParamerters);

        Assert.That(reflectedType, Is.InstanceOf(typeof(BasicClass)));
        Assert.That(reflectedType!.Required, Is.EqualTo(expectedRequiredValue));
    }

    internal class ServiceClass
    {
        public string Required { get; }
        public ServiceClass? Service { get; }

        public ServiceClass(string required, ServiceClass? serviceClass)
        {
            Required = required;
            Service = serviceClass;
        }
    }

    [Test]
    public void GetReflectedType_ServiceClass()
    {
        const string expectedRequiredValue = "Required";
        var serviceProvider = Substitute.For<IServiceProvider>();
        serviceProvider.GetService(typeof(ServiceClass)).Returns(new ServiceClass(expectedRequiredValue, null));
        var logger = Substitute.For<ILogger<DependencyReflectorFactory>>();
        var reflectorFactory = new DependencyReflectorFactory(serviceProvider, logger);
        var constructorRequiredParamerters = new[] { expectedRequiredValue };

        var reflectedType = reflectorFactory.GetReflectedType<ServiceClass>(typeof(ServiceClass), constructorRequiredParamerters);

        Assert.That(reflectedType, Is.InstanceOf(typeof(ServiceClass)));
        Assert.Multiple(() =>
        {
            Assert.That(reflectedType!.Required, Is.EqualTo(expectedRequiredValue));
            Assert.That(reflectedType.Service, Is.InstanceOf(typeof(ServiceClass)));
        });
        Assert.Multiple(() =>
        {
            Assert.That(reflectedType!.Service, Is.Not.Null);
            Assert.That(reflectedType.Service?.Required, Is.EqualTo(expectedRequiredValue));
            Assert.That(reflectedType.Service?.Service, Is.EqualTo(null));
        });
    }

    internal class NoConstructorsClass
    {
        protected NoConstructorsClass()
        {
        }
    }

    [Test]
    public void GetReflectedType_NoContructorsClass()
    {
        var serviceProvider = Substitute.For<IServiceProvider>();
        var logger = Substitute.For<ILogger<DependencyReflectorFactory>>();
        var reflectorFactory = new DependencyReflectorFactory(serviceProvider, logger);
        var constructorRequiredParamerters = Array.Empty<object>();

        var reflectedType = reflectorFactory.GetReflectedType<NoConstructorsClass>(typeof(NoConstructorsClass), constructorRequiredParamerters);

        Assert.That(reflectedType, Is.Null);
    }

    internal class NoRequiredParametersClass
    {
        public NoRequiredParametersClass()
        {
        }
    }

    [Test]
    public void GetReflectedType_NoRequiredParametersClass()
    {
        var serviceProvider = Substitute.For<IServiceProvider>();
        var logger = Substitute.For<ILogger<DependencyReflectorFactory>>();
        var reflectorFactory = new DependencyReflectorFactory(serviceProvider, logger);
        var constructorRequiredParamerters = Array.Empty<object>();

        var reflectedType = reflectorFactory.GetReflectedType<NoRequiredParametersClass>(typeof(NoRequiredParametersClass), constructorRequiredParamerters);

        Assert.That(reflectedType, Is.Not.Null);
        Assert.That(reflectedType, Is.InstanceOf<NoRequiredParametersClass>());
    }

    internal class NoRequiredParameters_ServiceClass
    {
        public ServiceClass Service { get; }

        public NoRequiredParameters_ServiceClass(ServiceClass service)
        {
            Service = service;
        }
    }

    [Test]
    public void GetReflectedType_NoRequiredParameters_ServiceClass()
    {
        const string expectedRequiredValue = "Required";
        var serviceProvider = Substitute.For<IServiceProvider>();
        serviceProvider.GetService(typeof(ServiceClass)).Returns(new ServiceClass(expectedRequiredValue, null));
        var logger = Substitute.For<ILogger<DependencyReflectorFactory>>();
        var reflectorFactory = new DependencyReflectorFactory(serviceProvider, logger);
        var constructorRequiredParamerters = Array.Empty<object>();

        var reflectedType = reflectorFactory.GetReflectedType<NoRequiredParameters_ServiceClass>(typeof(NoRequiredParameters_ServiceClass), constructorRequiredParamerters);

        Assert.That(reflectedType, Is.Not.Null);
        Assert.That(reflectedType, Is.InstanceOf<NoRequiredParameters_ServiceClass>());
        Assert.Multiple(() => Assert.That(reflectedType!.Service, Is.InstanceOf(typeof(ServiceClass))));
        Assert.Multiple(() =>
        {
            Assert.That(reflectedType!.Service, Is.Not.Null);
            Assert.That(reflectedType.Service?.Required, Is.EqualTo(expectedRequiredValue));
            Assert.That(reflectedType.Service?.Service, Is.EqualTo(null));
        });
    }

    [Test]
    public void GetReflectedType_RequiredParametersIsNull_ServiceClass()
    {
        const string expectedRequiredValue = "Required";
        var serviceProvider = Substitute.For<IServiceProvider>();
        serviceProvider.GetService(typeof(ServiceClass)).Returns(new ServiceClass(expectedRequiredValue, null));
        var logger = Substitute.For<ILogger<DependencyReflectorFactory>>();
        var reflectorFactory = new DependencyReflectorFactory(serviceProvider, logger);
        object[]? constructorRequiredParamerters = null;

#pragma warning disable CS8604 // Possible null reference argument.
        var reflectedType = reflectorFactory.GetReflectedType<NoRequiredParameters_ServiceClass>(typeof(NoRequiredParameters_ServiceClass), constructorRequiredParamerters);
#pragma warning restore CS8604 // Possible null reference argument.

        Assert.That(reflectedType, Is.Not.Null);
        Assert.That(reflectedType, Is.InstanceOf<NoRequiredParameters_ServiceClass>());
        Assert.Multiple(() => Assert.That(reflectedType!.Service, Is.InstanceOf(typeof(ServiceClass))));
        Assert.Multiple(() =>
        {
            Assert.That(reflectedType!.Service, Is.Not.Null);
            Assert.That(reflectedType.Service?.Required, Is.EqualTo(expectedRequiredValue));
            Assert.That(reflectedType.Service?.Service, Is.EqualTo(null));
        });
    }

    internal class IntegerRequiredClass
    {
        public int Required { get; set; }
        public IntegerRequiredClass(int required)
        {
            Required = required;
        }
    }

    [Test]
    public void GetReflectedType_WrongRequiredParameters()
    {
        var serviceProvider = Substitute.For<IServiceProvider>();
        var logger = Substitute.For<ILogger<DependencyReflectorFactory>>();
        var reflectorFactory = new DependencyReflectorFactory(serviceProvider, logger);
        var constructorRequiredParamerters = new object[] { new BasicClass("Required") };

        var reflectedType = reflectorFactory.GetReflectedType<IntegerRequiredClass>(typeof(IntegerRequiredClass), constructorRequiredParamerters);

        Assert.That(reflectedType, Is.Null);
    }

    [Test]
    public void GetReflectedType_TooManyRequiredParameters()
    {
        var serviceProvider = Substitute.For<IServiceProvider>();
        var logger = Substitute.For<ILogger<DependencyReflectorFactory>>();
        var reflectorFactory = new DependencyReflectorFactory(serviceProvider, logger);
        var constructorRequiredParamerters = new object[] { 1, "TooMuch" };

        var reflectedType = reflectorFactory.GetReflectedType<IntegerRequiredClass>(typeof(IntegerRequiredClass), constructorRequiredParamerters);

        Assert.That(reflectedType, Is.Not.Null);
        Assert.That(reflectedType, Is.InstanceOf<IntegerRequiredClass>());
    }
}
