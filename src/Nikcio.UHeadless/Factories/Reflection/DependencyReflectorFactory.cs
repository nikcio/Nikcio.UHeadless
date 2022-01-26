using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nikcio.UHeadless.Factories.Reflection
{
    public class DependencyReflectorFactory
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
            if(constructors.Length == 0)
            {
                LogConstructorError(typeToReflect, constructorRequiredParamerters);
                return null;
            }
            var parameters = GetConstructor(constructors, constructorRequiredParamerters).GetParameters();
            var injectedParamerters = constructorRequiredParamerters
                .Concat(parameters.Skip(constructorRequiredParamerters.Length).Select(parameter => serviceProvider.GetService(parameter.ParameterType)))
                .ToArray();
            return (T)Activator.CreateInstance(Type.GetType(propertyTypeAssemblyQualifiedName), injectedParamerters);
        }

        private void LogConstructorError(Type typeToReflect, object[] constructorRequiredParamerters)
        {
            string constructorNames = string.Join(", ", constructorRequiredParamerters.Select(item => item.GetType().Name));
            string message = $"Unable to create instance of {typeToReflect.Name}. " +
                $"Could not find a constructor with {constructorNames} as first argument(s)";
            logger.LogError(message);
        }

        private ParameterInfo[] TakeConstructorRequiredParamters(ConstructorInfo constructor, int constructorRequiredParamertersLength)
        {
            return constructor.GetParameters()?.Take(constructorRequiredParamertersLength).ToArray();
        }

        private bool ValidateConstructorRequiredParameters(ConstructorInfo constructor, object[] constructorRequiredParameters)
        {
            var parameters = TakeConstructorRequiredParamters(constructor, constructorRequiredParameters.Length);
            for(int i = 0; i < parameters.Length; i++)
            {
                var requiredParameter = constructorRequiredParameters[i].GetType();
                if(parameters[i].ParameterType != requiredParameter)
                {
                    return false;
                }
            }
            return true;
        }

        private ConstructorInfo GetConstructor (ConstructorInfo[] constructors, object[] constructorRequiredParameters)
        {
            return constructors?.FirstOrDefault(constructor =>
              ValidateConstructorRequiredParameters(constructor, constructorRequiredParameters));
        }
    }
}
