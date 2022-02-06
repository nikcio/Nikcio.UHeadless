using System.Collections.Generic;

namespace Nikcio.UHeadless.Maps.Bases
{
    public abstract class BaseMap
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
