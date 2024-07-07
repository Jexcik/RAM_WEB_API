using Application.Contracts.Logging;
using Microsoft.Extensions.Logging;

namespace Infrastructure.LoggerAdapter
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger _loggerFactory;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory.CreateLogger<T>();
        }

        public void LogInformation(string message, params object[] args)
        {
            _loggerFactory.LogInformation(message, args);
        }

        public void LogWarnings(string message, params object[] args)
        {
            _loggerFactory.LogWarning(message, args);
        }
    }
}
