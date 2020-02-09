using System;
using Serilog;

namespace Sofa.Identity.WebAPI
{
    public class Logger : Sofa.SharedKernel.ILogger
    {
        public void Information(string data)
        {
            Log.Information(data);
        }

        public void Information(string data, params object[] propertyValue)
        {
            Log.Information(data, propertyValue);
        }

        public void Error(string data)
        {
            Log.Error(data);
        }

        public void Error(string data, params object[] propertyValue)
        {
            Log.Error(data, propertyValue);
        }

        public void Debug(string data)
        {
            Log.Debug(data);
        }

        public void Debug(string data, params object[] propertyValue)
        {
            Log.Debug(data, propertyValue);
        }

        public void Warning(string data)
        {
            Log.Warning(data);
        }

        public void Warning(string data, params object[] propertyValue)
        {
            Log.Warning(data, propertyValue);
        }

        public void Exception(Exception exception, string message)
        {
            Log.Error(exception, message);
        }
    }

}
