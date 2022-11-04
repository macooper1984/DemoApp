using DemoApp.Application.ApiValidation;
using DemoApp.Application.UseCases;
using DemoApp.Domain.Models;
using DemoApp.SharedLibrary.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ClientsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Client>> GetAllClients()
        {
            var request = new GetAllClientsRequest();
            var result = await mediator.Send(request);

            return result;
        }


        [HttpGet]
        [Route("{identifier}")]
        [ValidRequestAuthentication]
        public async Task<Client> GetClientByIdentifier(
            [ValidClientCode] string identifier)
        {
            var request = new GetClientRequest(identifier);
            var result = await mediator.Send(request);

            return result;
        }
    }
}
