using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;

namespace Nikcio.UHeadless.Factories.Reflection
{
    public class DependencyReflectorFactory : IDependencyReflectorFactory
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<DependencyReflectorFactory> logger;

        public DependencyReflectorFactory(IServiceProvider serviceProvider, ILogger<DependencyReflectorFactory> logger)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        public T GetReflectedType<T>(Type typeToReflect, object[] constructorRequiredParamerters)
            where T : class
        {
            var propertyTypeAssemblyQualifiedName = typeToReflect.AssemblyQualifiedName;
            var constructors = typeToReflect.GetConstructors();
            if (constructors.Length == 0)
            {
                LogConstructorError(typeToReflect, constructorRequiredParamerters);
                return null;
            }
            var parameters = GetConstructor(constructors, constructorRequiredParamerters)?.GetParameters();
            if(parameters == null)
            {
                LogConstructorError(typeToReflect, constructorRequiredParamerters);
                return null;
            }
            object[] injectedParamerters = null;
            if (constructorRequiredParamerters == null)
            {
                injectedParamerters = parameters.Select(parameter => serviceProvider.GetService(parameter.ParameterType)).ToArray();
            }
            else
            {
                injectedParamerters = constructorRequiredParamerters
                .Concat(parameters.Skip(constructorRequiredParamerters.Length).Select(parameter => serviceProvider.GetService(parameter.ParameterType)))
                .ToArray();
            }
            return (T)Activator.CreateInstance(Type.GetType(propertyTypeAssemblyQualifiedName), injectedParamerters);
        }

        private void LogConstructorError(Type typeToReflect, object[] constructorRequiredParamerters)
        {
            string constructorNames = string.Join(", ", constructorRequiredParamerters?.Select(item => item.GetType().Name));
            string message = $"Unable to create instance of {typeToReflect.Name}. " +
                $"Could not find a constructor with {constructorNames} as first argument(s)";
            logger.LogError(message);
        }

        private ParameterInfo[] TakeConstructorRequiredParamters(ConstructorInfo constructor, int constructorRequiredParamertersLength)
        {
            var parameters = constructor.GetParameters();
            if (parameters.Length < constructorRequiredParamertersLength)
            {
                return parameters;
            }
            return parameters?.Take(constructorRequiredParamertersLength).ToArray();
        }

        private bool ValidateConstructorRequiredParameters(ConstructorInfo constructor, object[] constructorRequiredParameters)
        {
            if (constructorRequiredParameters == null)
            {
                return true;
            }
            var parameters = TakeConstructorRequiredParamters(constructor, constructorRequiredParameters.Length);
            for (int i = 0; i < parameters.Length; i++)
            {
                var requiredParameter = constructorRequiredParameters[i].GetType();
                if (parameters[i].ParameterType != requiredParameter)
                {
                    return false;
                }
            }
            return true;
        }

        private ConstructorInfo GetConstructor(ConstructorInfo[] constructors, object[] constructorRequiredParameters)
        {
            return constructors?.FirstOrDefault(constructor =>
              ValidateConstructorRequiredParameters(constructor, constructorRequiredParameters));
        }
    }
}
