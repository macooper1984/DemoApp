using DemoApp.SharedLibrary;
using System;

namespace DemoApp.Application.Utils
{
    public class DodgyLogger : ILogger
    {
        public void LogError(string message, Exception exception)
        {
        }

        public void LogInfo(string message)
        {
        }
    }
}
