using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp.SharedLibrary.Authentication
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ValidRequestAuthenticationAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var routeData = context.HttpContext.GetRouteData();
            var identifier = routeData.Values["identifier"]?.ToString();

            var result = ValidateRequest(context, identifier).Result;

            if (result == false)
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private async Task<bool> ValidateRequest(AuthorizationFilterContext context, string identifier)
        {
            var mediator = context.HttpContext.RequestServices.GetService<IMediator>();
            var result = await mediator.Send(new LoginQuery(identifier));

            return result;
        }
    }
}