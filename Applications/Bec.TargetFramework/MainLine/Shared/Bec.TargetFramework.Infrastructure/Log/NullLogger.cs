using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.Log
{
    public class NullLogger : ILogger
    {
        public void Trace(string message)
        {
        }

        public void Trace(string message, params object[] args)
        {
        }

        public void Debug(string message)
        {
        }

        public void Debug(string message, params object[] args)
        {
        }

        public void Info(string message)
        {
        }

        public void Info(string message, params object[] args)
        {
        }

        public void Warning(string message)
        {
        }

        public void Warning(string message, params object[] args)
        {
        }

        public void Error(string message)
        {
        }

        public void Error(string message, params object[] args)
        {
        }

        public void Error(Exception exception, string message)
        {
        }

        public void Error(Exception exception, string message, params object[] args)
        {
        }

        public void Fatal(string message)
        {
        }

        public void Fatal(string message, params object[] args)
        {
        }

        public void Fatal(Exception exception, string message)
        {
        }

        public void Fatal(Exception exception, string message, params object[] args)
        {
        }

        public void SetLogger(string name)
        {
        }
        public void Error(Exception ex)
        {
        }


        public void Trace(TargetFrameworkLogDTO dto)
        {
            throw new NotImplementedException();
        }

        public void Info(TargetFrameworkLogDTO dto)
        {
            throw new NotImplementedException();
        }

        public void Error(TargetFrameworkLogDTO dto)
        {
            throw new NotImplementedException();
        }

        public void Debug(TargetFrameworkLogDTO dto)
        {
            throw new NotImplementedException();
        }

        public void Warning(TargetFrameworkLogDTO dto)
        {
            throw new NotImplementedException();
        }

        public void Fatal(TargetFrameworkLogDTO dto)
        {
            throw new NotImplementedException();
        }

        public void CreateLogger()
        {
            throw new NotImplementedException();
        }

        public void DefaultLoggingStrategy(string logCategory)
        {
            throw new NotImplementedException();
        }

        public void SetLoggerConfigurationAndCreateLogger(Serilog.LoggerConfiguration config)
        {
            throw new NotImplementedException();
        }

        public Serilog.LoggerConfiguration GetDefaultLoggerConfiguration(string logCategory)
        {
            throw new NotImplementedException();
        }


        public void DefaultLoggingStrategy(string logCategory, bool webEnrichers)
        {
            throw new NotImplementedException();
        }

        public Serilog.LoggerConfiguration GetDefaultLoggerConfiguration(string logCategory, bool webEnrichers)
        {
            throw new NotImplementedException();
        }
    }
}
