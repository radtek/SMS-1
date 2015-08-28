using Autofac;
using Autofac.Core;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Client.Interfaces;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Entities.Enums;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.SB.Interfaces;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Handlers.Base
{
    public class BaseHandler<T> : IHandleMessages<T>,IDisposable where T:IEvent
    {

        public IBus Bus { get; set; }

        protected ILogger m_Logger;
        protected IBusLogicClient m_BusLogic;
        protected IEventPublishLogicClient m_EventClient;

        public BaseHandler(ILogger logger, IBusLogicClient busLogic, IEventPublishLogicClient eventClient)
        {
            m_Logger = logger;
            m_BusLogic = busLogic;
            m_EventClient = eventClient;
        }

        public virtual void Handle(T message)
        {
        }

        protected bool HasMessageAlreadyBeenProcessed()
        {
            return m_BusLogic.HasMessageAlreadyBeenProcessed(AppDomain.CurrentDomain.FriendlyName, this.GetType().FullName,NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers));
        }

        protected bool LogMessageAsFailed()
        {
            return m_BusLogic.SaveBusMessage(BusMessageStatusEnum.Failed, AppDomain.CurrentDomain.FriendlyName,
                this.GetType().FullName, false, NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers));
        }

        protected bool LogMessageAsCompleted()
        {
            return m_BusLogic.SaveBusMessage(BusMessageStatusEnum.Successful, AppDomain.CurrentDomain.FriendlyName, this.GetType().FullName, false,NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers));
        }

        public virtual void Dispose()
        {
        }
    }
}
