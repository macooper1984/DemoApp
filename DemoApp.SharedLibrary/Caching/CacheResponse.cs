namespace DemoApp.SharedLibrary.Caching
{
    public class CacheResponse<T>
    {
        public CacheResponse(bool fromCache, T data)
        {
            FromCache = fromCache;
            Data = data;
        }

        public bool FromCache { get; }

        public T Data { get; }
    }
}
