using System;
using Vendor.WebApi.Services.Interfaces;

namespace Vendor.WebApi.Services
{
    public class LoggerService : ILoggerService
    {
        public void Info(string message)
        {
            Console.WriteLine("Info: " + message);
        }

        public void Error(string message)
        {
            Console.WriteLine("Error: " + message);
        }

        public void Debug(string message)
        {
            Console.WriteLine("Debug: " + message);
        }
    }
}