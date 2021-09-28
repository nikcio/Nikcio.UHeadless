using System;
using System.Collections.Generic;

namespace Nikcio.Umbraco.Headless.Core.Mappers.Bases
{
    public abstract class BaseMapper
    {
        protected static void AddMapping(string key, Type type, Dictionary<string, Type> map)
        {
            key = key.ToLower();
            if (!map.ContainsKey(key))
            {
                lock (map)
                {
                    if (!map.ContainsKey(key))
                    {
                        map.Add(key, type);
                    }
                }
            }
        }
    }
}
