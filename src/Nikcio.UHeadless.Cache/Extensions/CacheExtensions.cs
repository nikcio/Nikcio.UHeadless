using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChocolate.Execution.Processing;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Nikcio.UHeadless.Cache.Extensions
{
    /// <summary>
    /// Extensions for cache
    /// </summary>
    public static class CacheExtensions
    {
        /// <summary>
        /// Sets a record
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="recordId"></param>
        /// <param name="data"></param>
        /// <param name="absoluteExpirationRelativeToNow"></param>
        /// <param name="slidingExpiration"></param>
        /// <returns></returns>
        public static async Task SetRecordAsync<T>(this IDistributedCache cache, string recordId, T data, TimeSpan absoluteExpirationRelativeToNow, TimeSpan slidingExpiration) {
            var options = new DistributedCacheEntryOptions {
                AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow,
                SlidingExpiration = slidingExpiration
            };

            var jsonData = JsonConvert.SerializeObject(data, new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            });
            await cache.SetStringAsync(recordId, jsonData, options);
        }

        /// <summary>
        /// Gets a record
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public static async Task<T?> GetRecordAsync<T>(this IDistributedCache cache, string recordId) {
            var jsonData = await cache.GetStringAsync(recordId);
            
            if(jsonData is null) {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(jsonData, new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                ObjectCreationHandling = ObjectCreationHandling.Auto,
                Converters = new List<JsonConverter>() {
                    new ReadOnlyDictionaryConverter()
                }
            });
        }
    }

    public class ReadOnlyDictionaryConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(IReadOnlyDictionary<string, object>);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer) {
            var value = reader.ReadAsString();
            //var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(existingValue.ToString(), new JsonSerializerSettings {
            //    TypeNameHandling = TypeNameHandling.All,
            //    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            //});
            //return new ReadOnlyDictionary<string, object?>(dictionary);
            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}
