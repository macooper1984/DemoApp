using DemoApp.Api.Controllers;
using DemoApp.Data.Sql.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp.Data.Sql
{
    public static class ServicesHelper
    {
        public static void RegisterDataServices(this IServiceCollection services)
        {
            services.AddSingleton<IClientRepository, ClientRepository>();
        }
    }
}
