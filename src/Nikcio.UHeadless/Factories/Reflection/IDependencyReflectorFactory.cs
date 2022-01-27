using System;

namespace Nikcio.UHeadless.Factories.Reflection
{
    public interface IDependencyReflectorFactory
    {
        T GetReflectedType<T>(Type typeToReflect, object[] constructorRequiredParamerters) where T : class;
    }
}