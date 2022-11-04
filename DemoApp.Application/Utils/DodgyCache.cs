using DemoApp.SharedLibrary;
using DemoApp.SharedLibrary.Caching;
using System.Collections.Generic;

namespace DemoApp.Application.Utils
{
    public class DodgyCache : ICache
    {
        private readonly Dictionary<string, object> cache = new Dictionary<string, object>();

        public void AddToCache<T>(T item, string cacheKey)
        {
            cache[cacheKey] = item;
        }

        public CacheResponse<T> GetFromCache<T>(string cacheKey)
        {
            if (!cache.ContainsKey(cacheKey))
            {
                return new CacheResponse<T>(false, default);
            }
            else
            {
                return new CacheResponse<T>(true, (T)cache[cacheKey]);
            }
        }
    }
}
