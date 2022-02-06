using System;

namespace Nikcio.UHeadless.Reflection.Factories
{
    public interface IDependencyReflectorFactory
    {
        T GetReflectedType<T>(Type typeToReflect, object[] constructorRequiredParamerters) where T : class;
    }
}