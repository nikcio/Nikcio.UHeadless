using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Core.Reflection.Factories;

namespace Nikcio.UHeadless.Core.Tests.Reflection.Factories {
    public class DependencyReflectorFactoryTests {
        internal class BasicClass {
            public string Required { get; }
            public BasicClass(string required) {
                Required = required;
            }
        }

        [Test]
        public void GetReflectedType_BasicClass() {
            var serviceProvider = new Mock<IServiceProvider>();
            var logger = new Mock<ILogger<DependencyReflectorFactory>>();
            var reflectorFactory = new DependencyReflectorFactory(serviceProvider.Object, logger.Object);
            var expectedRequiredValue = "Required";
            var constructorRequiredParamerters = new[] { expectedRequiredValue };

            var reflectedType = reflectorFactory.GetReflectedType<BasicClass>(typeof(BasicClass), constructorRequiredParamerters);

            Assert.That(reflectedType, Is.InstanceOf(typeof(BasicClass)));
            Assert.That(reflectedType.Required, Is.EqualTo(expectedRequiredValue));
        }

        internal class ServiceClass {
            public string Required { get; }
            public ServiceClass? Service { get; }

            public ServiceClass(string required, ServiceClass? serviceClass) {
                Required = required;
                Service = serviceClass;
            }
        }

        [Test]
        public void GetReflectedType_ServiceClass() {
            var expectedRequiredValue = "Required";
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(ServiceClass)))
                .Returns(new ServiceClass(expectedRequiredValue, null));
            var logger = new Mock<ILogger<DependencyReflectorFactory>>();
            var reflectorFactory = new DependencyReflectorFactory(serviceProvider.Object, logger.Object);
            var constructorRequiredParamerters = new[] { expectedRequiredValue };

            var reflectedType = reflectorFactory.GetReflectedType<ServiceClass>(typeof(ServiceClass), constructorRequiredParamerters);

            Assert.That(reflectedType, Is.InstanceOf(typeof(ServiceClass)));
            Assert.Multiple(() => {
                Assert.That(reflectedType.Required, Is.EqualTo(expectedRequiredValue));
                Assert.That(reflectedType.Service, Is.InstanceOf(typeof(ServiceClass)));
            });
            Assert.Multiple(() => {
                Assert.That(reflectedType.Service, Is.Not.Null);
                Assert.That(reflectedType.Service?.Required, Is.EqualTo(expectedRequiredValue));
                Assert.That(reflectedType.Service?.Service, Is.EqualTo(null));
            });
        }

        internal class NoConstructorsClass {
            protected NoConstructorsClass() {
            }
        }

        [Test]
        public void GetReflectedType_NoContructorsClass() {
            var serviceProvider = new Mock<IServiceProvider>();
            var logger = new Mock<ILogger<DependencyReflectorFactory>>();
            var reflectorFactory = new DependencyReflectorFactory(serviceProvider.Object, logger.Object);
            var constructorRequiredParamerters = Array.Empty<object>();

            var reflectedType = reflectorFactory.GetReflectedType<NoConstructorsClass>(typeof(NoConstructorsClass), constructorRequiredParamerters);

            Assert.That(reflectedType, Is.Null);
        }

        internal class NoRequiredParametersClass {
            public NoRequiredParametersClass() {
            }
        }

        [Test]
        public void GetReflectedType_NoRequiredParametersClass() {
            var serviceProvider = new Mock<IServiceProvider>();
            var logger = new Mock<ILogger<DependencyReflectorFactory>>();
            var reflectorFactory = new DependencyReflectorFactory(serviceProvider.Object, logger.Object);
            var constructorRequiredParamerters = Array.Empty<object>();

            var reflectedType = reflectorFactory.GetReflectedType<NoRequiredParametersClass>(typeof(NoRequiredParametersClass), constructorRequiredParamerters);

            Assert.That(reflectedType, Is.Not.Null);
            Assert.That(reflectedType, Is.InstanceOf<NoRequiredParametersClass>());
        }

        internal class NoRequiredParameters_ServiceClass {
            public ServiceClass Service { get; }

            public NoRequiredParameters_ServiceClass(ServiceClass service) {
                Service = service;
            }
        }

        [Test]
        public void GetReflectedType_NoRequiredParameters_ServiceClass() {
            var expectedRequiredValue = "Required";
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(ServiceClass)))
                .Returns(new ServiceClass(expectedRequiredValue, null));
            var logger = new Mock<ILogger<DependencyReflectorFactory>>();
            var reflectorFactory = new DependencyReflectorFactory(serviceProvider.Object, logger.Object);
            var constructorRequiredParamerters = Array.Empty<object>();

            var reflectedType = reflectorFactory.GetReflectedType<NoRequiredParameters_ServiceClass>(typeof(NoRequiredParameters_ServiceClass), constructorRequiredParamerters);

            Assert.That(reflectedType, Is.Not.Null);
            Assert.That(reflectedType, Is.InstanceOf<NoRequiredParameters_ServiceClass>());
            Assert.Multiple(() => {
                Assert.That(reflectedType.Service, Is.InstanceOf(typeof(ServiceClass)));
            });
            Assert.Multiple(() => {
                Assert.That(reflectedType.Service, Is.Not.Null);
                Assert.That(reflectedType.Service?.Required, Is.EqualTo(expectedRequiredValue));
                Assert.That(reflectedType.Service?.Service, Is.EqualTo(null));
            });
        }
    }
}
