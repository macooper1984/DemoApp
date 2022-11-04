using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoApp.SharedLibrary.Caching
{
    public class SafeCachingPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : AbstractCacheableQuery<TResponse>
    {
        private readonly ICache cache;

        static SemaphoreSlim semaphore = new SemaphoreSlim(initialCount: 0, maxCount: 1);

        public SafeCachingPipeline(ICache cache)
        {
            this.cache = cache;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var cacheResult = cache.GetFromCache<TResponse>(request.CacheKey);

            if (cacheResult.FromCache)
            {
                return cacheResult.Data;
            }
            
            try
            {
                // Only allow one thread to update the cache at a time, prevents hammering the data source.
                await semaphore.WaitAsync();

                var result = await UpdateCache(request, next);

                return result;
            }
            finally
            {
                semaphore.Release();
            }
        }

        private async Task<TResponse> UpdateCache(TRequest request, RequestHandlerDelegate<TResponse> next)
        {
            // Data may now be in the cache so give it one more try before retrieving data from the source.
            var cacheResult = cache.GetFromCache<TResponse>(request.CacheKey);

            if (cacheResult.FromCache)
            {
                return cacheResult.Data;
            }

            var result = await next.Invoke();

            cache.AddToCache(result, request.CacheKey);

            return result;
        }
    }
}