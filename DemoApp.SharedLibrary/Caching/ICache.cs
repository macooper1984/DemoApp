using DemoApp.SharedLibrary.Caching;

namespace DemoApp.SharedLibrary
{
    public interface ICache
    {
        void AddToCache<T>(T item, string cacheKey);

        CacheResponse<T> GetFromCache<T>(string cacheKey);
    }
}
