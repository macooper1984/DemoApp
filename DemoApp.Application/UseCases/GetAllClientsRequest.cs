using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DemoApp.Api.Controllers
{
    public class GetAllClientsRequest : IRequest<List<Client>>
    {
    }

    public class GetAllClientsRequestHandler : IRequestHandler<GetAllClientsRequest, List<Client>>
    {
        private readonly IClientRepository repo;

        public GetAllClientsRequestHandler(IClientRepository repo)
        {
            this.repo = repo;
        }

        public async Task<List<Client>> Handle(GetAllClientsRequest request, CancellationToken cancellationToken)
        {
            var result = await repo.GetAllClients();

            return result;
        }
    }
}