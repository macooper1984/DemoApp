using DemoApp.Application.Interfaces;
using DemoApp.Infrastructure.SqlServer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp.Infrastructure.SqlServer
{
    public static class ServicesHelper
    {
        public static void RegisterDataServices(this IServiceCollection services)
        {
            services.AddSingleton<IClientRepository, ClientRepository>();
        }
    }
}
