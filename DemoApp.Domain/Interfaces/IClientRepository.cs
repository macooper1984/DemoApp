using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApp.Api.Controllers
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllClients();
        Task<Client> GetClient(string identifier);
    }
}