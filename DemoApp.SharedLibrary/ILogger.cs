using System;

namespace DemoApp.SharedLibrary
{
    public interface ILogger
    {
        public void LogError(string message, Exception exception);
        public void LogInfo(string message);
    }
}