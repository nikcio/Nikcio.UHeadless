using System.Collections.Generic;

namespace Nikcio.UHeadless.Maps.Bases
{
    /// <summary>
    /// The base for maps
    /// </summary>
    public abstract class BaseMap
    {
        /// <summary>
        /// Adds a mapping to a dictionary map
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="key"></param>
        /// <param name="map"></param>
        protected void AddMapping<TType>(string key, Dictionary<string, string> map) where TType : class
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
