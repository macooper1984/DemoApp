using System;
using System.Net;

namespace DemoApp.SharedLibrary.ExceptionHandling
{
    public abstract class ResponseException : Exception
    {
        public ResponseException(string message)
            :base(message)
        {
        }

        public abstract HttpStatusCode StatusCode { get; }
    }
}
