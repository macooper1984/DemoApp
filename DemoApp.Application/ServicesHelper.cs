using DemoApp.Application.Utils;
using DemoApp.SharedLibrary;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp.Application
{
    public static class ServicesHelper
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ICache, DodgyCache>();
            services.AddSingleton<ILogger, DodgyLogger>();
        }
    }
}
