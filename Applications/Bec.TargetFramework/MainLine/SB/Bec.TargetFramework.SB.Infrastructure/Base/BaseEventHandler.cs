using System.Runtime.CompilerServices;
using Autofac;
using Autofac.Core;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Infrastructure;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus.Unicast.Subscriptions;
using NServiceBus.Unicast.Subscriptions.MessageDrivenSubscriptions;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Entities.Enums;

namespace Bec.TargetFramework.SB.Handlers.Base
{
    public class BaseEventHandler<T> : IHandleMessages<T>, IDisposable where T:IEvent
    {

        public IBus Bus { get; set; }

        protected ILogger m_Logger;
        protected IBusLogicClient m_BusLogic;
        protected SBSettings m_SBSettings;
        static readonly object m_ConcurrencyLock;

        static BaseEventHandler()
        {
            m_ConcurrencyLock = new object();
        }

        public BaseEventHandler(ILogger logger,
            IBusLogicClient busLogic,
            SBSettings settings)
        {
            m_Logger = logger;
            m_SBSettings = settings;
            m_BusLogic = busLogic;

        }

        public virtual void Handle(T message)
        {
            lock (m_ConcurrencyLock)
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
                    finally
                    {
                        Dispose();
                    }
                }
                else
                    return;
            }
        }
        public virtual void HandleMessage(T message)
        {

        }

        private BusMessageDTO GetBusMessageDTO()
        {
            var messageDto = NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers);

            return messageDto;
        }

        protected bool HasMessageAlreadyBeenProcessed()
        {
            return m_BusLogic.HasMessageAlreadyBeenProcessed(AppDomain.CurrentDomain.FriendlyName,this.GetType().FullName,GetBusMessageDTO());
        }

        protected bool LogMessageAsFailed()
        {
            return m_BusLogic.SaveBusMessage(BusMessageStatusEnum.Failed, AppDomain.CurrentDomain.FriendlyName, this.GetType().FullName, false,GetBusMessageDTO());
              
        }

        protected bool LogMessageAsCompleted()
        {
            return m_BusLogic.SaveBusMessage(BusMessageStatusEnum.Successful, AppDomain.CurrentDomain.FriendlyName, this.GetType().FullName, false,GetBusMessageDTO());
              
        }

        protected void LogError(string message, Exception ex, string source, string sourceType = "")
        {
            m_Logger.Error(new TargetFrameworkLogDTO
            {
                Exception = ex,
                ApplicationSource = source,
                ApplicationSourceType = sourceType,
                Message = message
            });

            LogMessageAsFailed();
        }

        public virtual void Dispose()
        {
        }
    }
}
