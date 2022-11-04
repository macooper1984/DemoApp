using DemoApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApp.Application.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllClients();
        Task<Client> GetClient(string identifier);
    }
}