using MediatR;

namespace DemoApp.SharedLibrary.Caching
{
    public abstract class AbstractCacheableQuery<T> : IRequest<T>
    {
        public abstract string CacheKey { get; }
    }
}
