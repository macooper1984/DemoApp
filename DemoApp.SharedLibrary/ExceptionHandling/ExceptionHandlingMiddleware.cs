using DemoApp.SharedLibrary;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoApp.SharedLibrary.ExceptionHandling
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger logger;

        public ExceptionHandlingMiddleware(ILogger logger)
        {
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ResponseException ex)
            {
                await HandleResponseException(context, ex);
            }
            catch (Exception ex)
            {
                await HandleUnhandledException(context, ex);
            }
        }

        private async Task HandleUnhandledException(HttpContext context, Exception ex)
        {
            logger.LogError("Unhandled exception", ex);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;


            var body = new ErrorResponse("I'm not telling you what went wrong, but something did!!!");
            await context.Response.WriteAsync(JsonSerializer.Serialize(body));
        }

        private async Task HandleResponseException(HttpContext context, ResponseException ex)
        {
            var statusCode = ex.StatusCode;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var body = new ErrorResponse(ex.Message);
            await context.Response.WriteAsync(JsonSerializer.Serialize(body));
        }
    }
}