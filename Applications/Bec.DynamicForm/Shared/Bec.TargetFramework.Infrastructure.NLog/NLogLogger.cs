using Bec.TargetFramework.Infrastructure.Log;
using Fabrik.Common;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.NLog
{
    public class NLogLogger : ILogger
    {
        static NLogLogger()
        {
            ExceptionDetailsRenderer.Register();
        }

        private Logger logger;

        public NLogLogger(Type loggerType)
        {
            Ensure.Argument.NotNull(loggerType, "loggerType");
            logger = LogManager.GetLogger(loggerType.FullName);
            
        }

        public NLogLogger()
        {
            logger = LogManager.GetLogger("Default");
            
        }

        public void Info(object toLog)
        {
            Log(toLog, LogLevel.Info);
        }

        public void Info(string messageFormat, params object[] parameters)
        {
            Log(messageFormat, parameters, LogLevel.Info);
        }

        public void Error(object toLog)
        {
            Log(toLog, LogLevel.Error);
        }

        public void Error(string message, Exception exception)
        {
            Log(message, exception, LogLevel.Error, "General");
        }

        private void Log(string messageFormat, object[] parameters, LogLevel logLevel)
        {
            string message = parameters.Length == 0 ? messageFormat
                : string.Format(messageFormat, parameters);
            Log(message, (Exception)null, logLevel, "General");
        }

        private void Log(object toLog, LogLevel logLevel)
        {
            if (toLog == null)
            {
                throw new ArgumentNullException("toLog");
            }

            if (toLog is Exception)
            {
                var exception = toLog as Exception;
                Log(exception.Message, exception, logLevel, "General");
            }
            else
            {
                var message = toLog.ToString();
                Log(message,null, logLevel,"General");
            }
        }

        private void Log(string message, Exception exception, LogLevel logLevel,string type)
        {
            if (exception == null && String.IsNullOrEmpty(message))
            {
                return;
            }

            // Note: Using the default constructor doesn't set the current date/time
            var logInfo = new LogEventInfo(logLevel, logger.Name, message);
            logInfo.Exception = exception;
            logger.Log(logInfo);

        }

        public void SetLogger(string name)
        {
            logger = LogManager.GetLogger(name);
        }


        public void Trace(string message)
        {
            Log(message,LogLevel.Trace);
        }

        public void Trace(string message, params object[] args)
        {
            Log(message,args,LogLevel.Trace);
        }

        public void Debug(string message)
        {
            Log(message,LogLevel.Debug);
        }

        public void Debug(string message, params object[] args)
        {
            Log(message,args,LogLevel.Debug);
        }

        public void Info(string message)
        {
            Log(message, LogLevel.Info);
        }

        public void Warning(string message)
        {
            Error(message);
        }

        public void Warning(string message, params object[] args)
        {
            Log(message,args,LogLevel.Warn);
        }

        public void Error(string message)
        {
            Log(message,LogLevel.Error);
        }

        public void Error(string message, params object[] args)
        {
            Log(message,args,LogLevel.Error);
        }

        public void Error(Exception exception, string message)
        {
            Log(message, exception, LogLevel.Error, "General");
        }

        public void Error(Exception exception, string message, params object[] args)
        {
            Log(message, exception, LogLevel.Error, "General");
        }

        public void Fatal(string message)
        {
            Log(message,LogLevel.Fatal);
        }

        public void Fatal(string message, params object[] args)
        {
            Log(message,args,LogLevel.Fatal);
        }

        public void Fatal(Exception exception, string message)
        {
            Log(message, exception, LogLevel.Fatal, "General");
        }

        public void Fatal(Exception exception, string message, params object[] args)
        {
            Log(message, exception, LogLevel.Fatal, "General");
        }
    }
}
