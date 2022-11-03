using DemoApp.Application;
using DemoApp.SharedLibrary;
using MediatR;
using MediatrDemo.Logic.Pipelines.Advanced;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoApp.Data.Sql
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
