using System;
using Sofa.SharedKernel;
using log4net;

namespace Sofa.Web
{
    public class Logger : ILogger
    {
        private readonly log4net.ILog _logger;
        public void Debug(string data, params object[] propertyValue)
        {
            foreach (var prop in propertyValue)
            {
                _logger.Debug(data + prop);
            }
        }

        public void Debug(string data)
        {
            _logger.Debug(data);
        }

        public void Error(string data, params object[] propertyValue)
        {
            foreach (var prop in propertyValue)
            {
                _logger.Error(data + prop);
            }
        }

        public void Error(string data)
        {
            _logger.Error(data);
        }

        public void Exception(Exception exception, string message)
        {
                _logger.Error(message, exception);
        }

        public void Information(string data, params object[] propertyValue)
        {
            foreach (var prop in propertyValue)
            {
                _logger.Info(data + prop);
            }
        }

        public void Information(string data)
        {
            _logger.Info(data);
        }

        public void Warning(string data, params object[] propertyValue)
        {
            foreach (var prop in propertyValue)
            {
                _logger.Warn(data + prop);
            }
        }

        public void Warning(string data)
        {
            _logger.Warn(data);
        }
    }
}
