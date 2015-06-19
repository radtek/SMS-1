using Autofac;
using Autofac.Core;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Client.Interfaces;
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
    public class ConcurrentBaseHandler<T> : BaseHandler<T>, IDisposable where T : IEvent
    {
        static readonly object m_ConcurrencyLock;

        static ConcurrentBaseHandler()
        {
            m_ConcurrencyLock = new object();
        }

        public ConcurrentBaseHandler(ILogger logger, IBusLogicClient busLogic, IEventPublishLogicClient eventClient)
            : base(logger, busLogic,eventClient)
        {
        
        }

        public override void Handle(T message)
        {
           lock(m_ConcurrencyLock)
           {
               if (!HasMessageAlreadyBeenProcessed())
               {
                   try
                   {
                       HandleMessage(message);
                   }
                   catch (System.Exception)
                   {
                    throw;
                   }
                   finally{
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

        public virtual void Dispose()
        {
        }
    }
}
