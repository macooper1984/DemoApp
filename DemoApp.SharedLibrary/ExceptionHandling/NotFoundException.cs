using DemoApp.SharedLibrary.ExceptionHandling;
using System.Net;

namespace MediatrDemo.Domain.Exceptions
{
    public class NotFoundException : ResponseException
    {
        public NotFoundException(string message)
         : base(message)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    }
}