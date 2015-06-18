using Autofac;
using Autofac.Core;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Interfaces;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Handlers.Base
{
    public class ConcurrentBaseCommandHandler<T> : BaseCommandHandler<T> where T : ICommand
    {
        static readonly object m_ConcurrencyLock;

        static ConcurrentBaseCommandHandler()
        {
            m_ConcurrencyLock = new object();
        }

        public ConcurrentBaseCommandHandler()
           
        {

        }

        public override void Handle(T message)
        {
            lock (m_ConcurrencyLock)
            {
                if (!HasMessageAlreadyBeenProcessed())
                {
                    try
                    {
                        HandleMessage(message);
                    }
                    catch (System.Exception ex)
                    {
                    	throw;
                    }
                    finally
                    {
                        Dispose();
                    }
                }
                    
                else
                    return;
            }
        }

        protected void LogError(string message, Exception ex, string source, string sourceType = "")
        {
            m_Logger.Error(ex);

            m_Logger.Error(new TargetFrameworkLogDTO
            {
                Exception = ex,
                ApplicationSource = source,
                ApplicationSourceType = sourceType,
                Message = message
            });

            LogMessageAsFailed();
        }

        public virtual void HandleMessage(T message)
        {

        }
    }
}
