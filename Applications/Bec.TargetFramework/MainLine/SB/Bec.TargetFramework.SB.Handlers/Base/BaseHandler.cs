using Autofac;
using Autofac.Core;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Framework.Configuration;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Infrastructure;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Handlers.Base
{
    public class BaseHandler<T> : IHandleMessages<T> where T:IEvent
    {

        public IBus Bus { get; set; }

        protected ILogger m_Logger;
        protected IBusLogic m_BusLogic;
        protected CommonSettings m_CommonSettings;

        public BaseHandler(ILogger logger,
            IBusLogic busLogic,
            CommonSettings settings)
        {
            m_Logger = logger;
            m_CommonSettings = settings;
            m_BusLogic = busLogic;
        }

        public virtual void Handle(T message)
        {
        }

        protected bool HasMessageAlreadyBeenProcessed()
        {
            return m_BusLogic.HasMessageAlreadyBeenProcessed(NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers), AppDomain.CurrentDomain.FriendlyName, this.GetType().FullName);
        }

        protected bool LogMessageAsFailed()
        {
            return m_BusLogic.SaveBusMessage(NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers),
                BusMessageStatusEnum.Failed, AppDomain.CurrentDomain.FriendlyName, this.GetType().FullName, false);
        }

        protected bool LogMessageAsCompleted()
        {
            return m_BusLogic.SaveBusMessage(NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers),
                BusMessageStatusEnum.Successful, AppDomain.CurrentDomain.FriendlyName, this.GetType().FullName, false);
        }
        
    }
}
