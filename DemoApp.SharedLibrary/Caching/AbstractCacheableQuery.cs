using MediatR;
using System;

namespace DemoApp.SharedLibrary.Caching
{
    public abstract class AbstractCacheableQuery<T> : IRequest<T>
    {
        public abstract string CacheKey { get; }

        public abstract TimeSpan CacheDuration { get; }
    }
}
