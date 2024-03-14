﻿using CuentasDiarias.Transversal.Common;
using Microsoft.Extensions.Logging;

namespace CuentasDiarias.Transversal.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        public readonly ILogger<T> _logger;

        public LoggerAdapter(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<T>();
        }
        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message,args);    
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
    }
}