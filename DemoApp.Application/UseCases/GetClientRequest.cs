using DemoApp.Application.Interfaces;
using DemoApp.Domain.Models;
using DemoApp.SharedLibrary.Caching;
using DemoApp.SharedLibrary.ExceptionHandling;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoApp.Application.UseCases
{
    public class GetClientRequest : AbstractCacheableQuery<Client>
    {
        public GetClientRequest(string identifier)
        {
            Identifier = identifier;
        }

        public string Identifier { get; }

        public override string CacheKey => $"GetClient:{Identifier}";
    }

    public class GetClientRequestHandler : IRequestHandler<GetClientRequest, Client>
    {
        private readonly IClientRepository repo;

        public GetClientRequestHandler(IClientRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Client> Handle(GetClientRequest request, CancellationToken cancellationToken)
        {
            if (request.Identifier == "TESTERROR")
            {
                throw new InvalidOperationException("Make an error occur");
            }

            var result = await repo.GetClient(request.Identifier);

            if (result == null)
            {
                throw new NotFoundException($"Client could not be found: {request.Identifier}");
            }

            return result;
        }
    }
}