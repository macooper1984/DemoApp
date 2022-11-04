using DemoApp.Application.Utils;
using DemoApp.SharedLibrary;
using DemoApp.SharedLibrary.Caching;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoApp.Application
{
    public static class ServicesHelper
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingPipeline<,>));

            services.AddSingleton<ICache, DodgyCache>();
            services.AddSingleton<ILogger, DodgyLogger>();
        }
    }
}
