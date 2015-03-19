using System.Runtime.CompilerServices;
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
using NServiceBus.Unicast.Subscriptions;
using NServiceBus.Unicast.Subscriptions.MessageDrivenSubscriptions;

namespace Bec.TargetFramework.SB.Handlers.Base
{
    public class BaseEventHandler<T> : IHandleMessages<T> where T:IEvent
    {

        public IBus Bus { get; set; }

        protected ILogger m_Logger;
        protected IBusLogic m_BusLogic;
        protected IClassificationDataLogic m_ClassificationDataLogic;
        protected CommonSettings m_CommonSettings;
        static readonly object m_ConcurrencyLock;

        static BaseEventHandler()
        {
            m_ConcurrencyLock = new object();
        }

        public BaseEventHandler(ILogger logger,
            IBusLogic busLogic, IClassificationDataLogic dataLogic,
            CommonSettings settings)
        {
            m_Logger = logger;
            m_ClassificationDataLogic = dataLogic;
            m_CommonSettings = settings;
            m_BusLogic = busLogic;

        }

        public virtual void Handle(T message)
        {
            lock (m_ConcurrencyLock)
            {
                if (!HasMessageAlreadyBeenProcessed())
                    HandleMessage(message);
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
            return m_BusLogic.HasMessageAlreadyBeenProcessed(GetBusMessageDTO(),AppDomain.CurrentDomain.FriendlyName,this.GetType().FullName);
        }

        protected bool LogMessageAsFailed()
        {
            return m_BusLogic.SaveBusMessage(GetBusMessageDTO(),
                BusMessageStatusEnum.Failed, AppDomain.CurrentDomain.FriendlyName, this.GetType().FullName, false);
        }

        protected bool LogMessageAsCompleted()
        {
            return m_BusLogic.SaveBusMessage(GetBusMessageDTO(),
                BusMessageStatusEnum.Successful, AppDomain.CurrentDomain.FriendlyName, this.GetType().FullName, false);
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
    }
}
