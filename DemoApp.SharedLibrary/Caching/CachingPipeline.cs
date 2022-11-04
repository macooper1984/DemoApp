using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoApp.SharedLibrary.Caching
{
    public class CachingPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : AbstractCacheableQuery<TResponse>
    {
        private readonly ICache cache;

        public CachingPipeline(ICache cache)
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

            var result = await next.Invoke();

            cache.AddToCache(result, request.CacheKey);

            return result;
        }
    }
}