
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher;
using Seq;
using Serilog;
using Serilog.Events;
using Serilog.Web.Extensions.Enrichers;
using ILogger = Serilog.ILogger;
using Serilog.Sinks.EventLog;
using LogNs = Serilog;


namespace Bec.TargetFramework.Infrastructure.Serilog
{
    public class SerilogLogger : Bec.TargetFramework.Infrastructure.Log.ILogger
    {
        public LoggerConfiguration m_LogConfiguration;
        public ILogger m_Log;

        public SerilogLogger(bool useDefault = true,bool useWebEnrichers =false, string logCategory = null)
        {
            if (useDefault)
                DefaultLoggingStrategy(logCategory,useWebEnrichers);
        }

        public void CreateLogger()
        {
            m_Log = m_LogConfiguration.CreateLogger();

            LogNs.Log.Logger = m_Log;
        }

        public void DefaultLoggingStrategy(string logCategory,bool webEnrichers)
        {
            var config = new LoggerConfiguration();

            var emailClient = new SmtpClient();

            // defaults are seq and eventLog
            config.Enrich.With(new ApplicationDetailsEnricher())
                .Enrich.With(new ExceptionDataEnricher())
                .Enrich.With(new ProcessSessionIdEnricher("ProcessID"))
                .Enrich.With(new PrincipalIdentityNameEnricher("PrincipalID"))
                .WriteTo.Seq(ConfigurationManager.AppSettings["SerilogSeqServerUrl"])
                .WriteTo.EventLog(ConfigurationManager.AppSettings["SerilogEventLogSource"],
                    ConfigurationManager.AppSettings["SerilogEventLogName"],restrictedToMinimumLevel: LogEventLevel.Error)
                .WriteTo.Email(ConfigurationManager.AppSettings["SerilogFromEmail"],
                    ConfigurationManager.AppSettings["SerilogToEmail"], emailClient.Host, emailClient.Credentials,
                    restrictedToMinimumLevel: LogEventLevel.Error);

            if (!string.IsNullOrEmpty(logCategory))
                config.Enrich.WithProperty("Category", logCategory);

            if (webEnrichers)
            {
                //config.Enrich.With(new HttpProfileEnricher("HttpProfile"));
                //config.Enrich.With(new HttpApplicationEnricher("HttpApplication"));
                //config.Enrich.With(new HttpSessionEnricher("HttpSession"));
            }

            m_LogConfiguration = config;

            // set default starting level of logging            
            m_LogConfiguration.MinimumLevel.Verbose();

            CreateLogger();
        }

        public void SetLoggerConfigurationAndCreateLogger(LoggerConfiguration config)
        {
            m_LogConfiguration = config;
            config.CreateLogger();
        }

        public LoggerConfiguration GetDefaultLoggerConfiguration(string logCategory)
        {
            var config = new LoggerConfiguration();

            var emailClient = new SmtpClient();

            // defaults are seq and eventLog
            config.Enrich.With(new ApplicationDetailsEnricher())
                .Enrich.With(new ExceptionDataEnricher())
                .WriteTo.Seq(ConfigurationManager.AppSettings["SerilogSeqServerUrl"])
                .WriteTo.EventLog(ConfigurationManager.AppSettings["SerilogEventLogSource"],
                    ConfigurationManager.AppSettings["SerilogEventLogName"], restrictedToMinimumLevel: LogEventLevel.Error)
                .WriteTo.Email(ConfigurationManager.AppSettings["SerilogFromEmail"],
                    ConfigurationManager.AppSettings["SerilogToEmail"], emailClient.Host, emailClient.Credentials,
                    restrictedToMinimumLevel: LogEventLevel.Error);

            if (!string.IsNullOrEmpty(logCategory))
                config.Enrich.WithProperty("Category", logCategory);

            return config;
        }

        public void Trace(string message)
        {
            m_Log.Verbose(message);
        }

        public void Trace(string message, params object[] args)
        {
            m_Log.Verbose(message, args);
            
        }

        public void Trace(TargetFrameworkLogDTO dto)
        {
            if(dto.Exception == null)
                m_Log.Verbose("Trace Information {@dto}",dto);
            else
                m_Log.Verbose(dto.Exception,"Trace Information {@dto}", dto);
        }

        public void Info(TargetFrameworkLogDTO dto)
        {
            if (dto.Exception == null)
                m_Log.Information("Trace Information {@dto}", dto);
            else
                m_Log.Information(dto.Exception, "Trace Information {@dto}", dto);
        }

        public void Error(TargetFrameworkLogDTO dto)
        {
            if (dto.Exception == null)
                m_Log.Error("Trace Information {@dto}", dto);
            else
                m_Log.Error(dto.Exception, "Trace Information {@dto}", dto);
        }

        public void Debug(TargetFrameworkLogDTO dto)
        {
            if (dto.Exception == null)
                m_Log.Debug("Trace Information {@dto}", dto);
            else
                m_Log.Debug(dto.Exception, "Trace Information {@dto}", dto);
        }

        public void Warning(TargetFrameworkLogDTO dto)
        {
            if (dto.Exception == null)
                m_Log.Warning("Trace Information {@dto}", dto);
            else
                m_Log.Warning(dto.Exception, "Trace Information {@dto}", dto);
        }

        public void Fatal(TargetFrameworkLogDTO dto)
        {
            if (dto.Exception == null)
                m_Log.Fatal("Trace Information {@dto}", dto);
            else
                m_Log.Fatal(dto.Exception, "Trace Information {@dto}", dto);
        }

        public void Debug(string message)
        {
            m_Log.Debug(message);
        }

        public void Debug(string message, params object[] args)
        {
            m_Log.Debug(message, args);
        }

        public void Info(string message)
        {
            m_Log.Information(message);
        }

        public void Info(string message, params object[] args)
        {
            m_Log.Information(message, args);
        }

        public void Warning(string message)
        {
            m_Log.Warning(message);
        }

        public void Warning(string message, params object[] args)
        {
            m_Log.Warning(message, args);
        }

        public void Error(string message)
        {
            m_Log.Error(message);
        }

        public void Error(Exception ex)
        {
            m_Log.Error(ex,ex.Message,null);
        }

        public void Error(string message, params object[] args)
        {
            m_Log.Error(message, args);
        }

        public void Error(Exception exception, string message)
        {
            m_Log.Error(exception,message);
        }

        public void Error(Exception exception, string message, params object[] args)
        {
            m_Log.Error(exception,message,args);
        }

        public void Fatal(string message)
        {
            m_Log.Fatal(message);
        }

        public void Fatal(string message, params object[] args)
        {
            m_Log.Fatal(message, args);
        }

        public void Fatal(Exception exception, string message)
        {
            m_Log.Fatal(exception,message);
        }

        public void Fatal(Exception exception, string message, params object[] args)
        {
            m_Log.Fatal(exception, message, args);
        }
    }
}
