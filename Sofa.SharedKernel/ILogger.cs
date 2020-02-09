using System;

namespace Sofa.SharedKernel
{
    public interface ILogger
    {
        void Warning(string data, params object[] propertyValue);
        void Debug(string data, params object[] propertyValue);
        void Error(string data, params object[] propertyValue);
        void Information(string data, params object[] propertyValue);
        void Exception(Exception exception, string message);
        void Warning(string data);
        void Debug(string data);
        void Error(string data);
        void Information(string data);
    }
}
