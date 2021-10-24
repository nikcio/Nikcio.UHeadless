using System.Collections.Generic;

namespace Nikcio.Umbraco.Headless.Core.Mappers.Bases
{
    public abstract class BaseMapper
    {
        protected static void AddMapping<TType>(string key, Dictionary<string, string> map) where TType : class
        {
            key = key.ToLowerInvariant();
            if (!map.ContainsKey(key))
            {
                lock (map)
                {
                    if (!map.ContainsKey(key))
                    {
                        map.Add(key, typeof(TType).AssemblyQualifiedName);
                    }
                }
            }
        }
    }
}
