using System.Net;

namespace DemoApp.SharedLibrary.ExceptionHandling
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