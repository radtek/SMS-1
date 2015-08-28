using Bec.TargetFramework.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace Bec.TargetFramework.Data.Infrastructure
{
    /// <summary>
    /// Intercept EF Logging
    /// </summary>
    public class LoggerCommandInterceptor : IDbCommandInterceptor
    {
        private readonly ILogger m_Logger;
        private readonly bool m_Debug;
        private readonly bool m_LogDbTrace;

        public LoggerCommandInterceptor(ILogger logger, bool logDbTrace = false, bool debug = false)
        {
            m_Logger = logger;
            m_Debug = debug;
            m_LogDbTrace = logDbTrace;

            m_Logger.SetLogger("Database");
        }

        public void NonQueryExecuting(
            DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
          
        }

        public void NonQueryExecuted(
            DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogIfError(command, interceptionContext);
            LogIfDebug(command, interceptionContext);
            LogIfTrace(command, interceptionContext);
        }

        public void ReaderExecuting(
            DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            
        }

        public void ReaderExecuted(
            DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogIfError(command, interceptionContext);
            LogIfDebug(command, interceptionContext);
            LogIfTrace(command, interceptionContext);
        }

        public void ScalarExecuting(
            DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
           
        }

        public void ScalarExecuted(
            DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogIfError(command, interceptionContext);
            LogIfDebug(command, interceptionContext);
            LogIfTrace(command, interceptionContext);
        }

        private void LogIfNonAsync<TResult>(
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            //if (!interceptionContext.IsAsync)
            //{
            //    m_Logger.Warning("Non-async command used: {0}", command.CommandText);
            // }
        }

        private void LogIfDebug<TResult>(
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if (m_Debug)
            {
                if (interceptionContext.Exception != null)
                {
                    m_Logger.Error(interceptionContext.Exception, command.CommandText);
                }
                else
                    m_Logger.Debug("Debug trace: {0}", command.CommandText);
            }
        }

        private void LogIfError<TResult>(
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if (interceptionContext.Exception != null)
            {
                m_Logger.Error(interceptionContext.Exception,command.CommandText);
            }
        }

        private void LogIfTrace<TResult>(
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if (m_LogDbTrace)
            {
                Dictionary<string,string> paramDic = new Dictionary<string, string>();

                command.Parameters.OfType<DbParameter>().ToList()
                    .ForEach(p => paramDic.Add(p.ParameterName,p.Value.ToString()));


                m_Logger.Trace("Trace: " + command.CommandText + " Parameters:" + paramDic.Dump());
            }
        }
    }
}
