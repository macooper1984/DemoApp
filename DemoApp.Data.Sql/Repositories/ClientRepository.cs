using DemoApp.Api.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Data.Sql.Repositories
{
    internal class ClientRepository : IClientRepository
    {
        private static readonly List<Client> clients = new List<Client>()
        {
            new Client("AOL", "AO.com"),
            new Client("COTSWOLD", "Cotswold Furniture co."),
            new Client("HOOVER", "Hoover"),
            new Client("ARGOS","Argos"),
            new Client("EBY", "eBay (ao.com)")
        };

        public async Task<List<Client>> GetAllClients()
        {
            return await Task.FromResult(clients);
        }

        public async Task<Client> GetClient(string identifier)
        {
            var result = clients.SingleOrDefault(n => n.Identifier == identifier);

            return await Task.FromResult(result);
        }
    }
}
