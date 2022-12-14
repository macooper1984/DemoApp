using DemoApp.SharedLibrary.Caching;
using MediatR;
using System;

namespace DemoApp.SharedLibrary.Authentication
{
    public class LoginQuery : AbstractCacheableQuery<bool>
    {
        public LoginQuery(string identifier)
        {
            Identifier = identifier;
        }

        public string Identifier { get; }

        public override string CacheKey => $"Login:{Identifier}";

        public override TimeSpan CacheDuration => TimeSpan.FromMinutes(15);
    }

    public class LoginQueryHandler : RequestHandler<LoginQuery, bool>
    {
        protected override bool Handle(LoginQuery request)
        {
            return request.Identifier != null && request.Identifier != "NoEntry";
        }
    }
}
