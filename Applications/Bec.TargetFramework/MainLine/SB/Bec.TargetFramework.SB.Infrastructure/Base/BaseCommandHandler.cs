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
    public class BaseCommandHandler<T> : IHandleMessages<T>,IDisposable where T:ICommand
    {

        public IBus Bus { get; set; }

        public ILogger m_Logger { get; set; }
        public IBusLogicClient m_BusLogic { get; set; }
        public IEventPublishLogicClient m_EventPublish { get; set; }

        public BaseCommandHandler()
        {

        }

        public virtual void Handle(T message)
        {
        }

        protected bool HasMessageAlreadyBeenProcessed()
        {
            return m_BusLogic.HasMessageAlreadyBeenProcessed(AppDomain.CurrentDomain.FriendlyName, this.GetType().FullName, NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers));
        }

        protected bool LogMessageAsFailed()
        {
            return m_BusLogic.SaveBusMessage(BusMessageStatusEnum.Failed, AppDomain.CurrentDomain.FriendlyName, this.GetType().FullName, false,NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers));
        }

        protected bool LogMessageAsCompleted()
        {
            return m_BusLogic.SaveBusMessage( BusMessageStatusEnum.Successful, AppDomain.CurrentDomain.FriendlyName, this.GetType().FullName, false,NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers));
        }


        public virtual void Dispose()
        {
        }
    }
}
