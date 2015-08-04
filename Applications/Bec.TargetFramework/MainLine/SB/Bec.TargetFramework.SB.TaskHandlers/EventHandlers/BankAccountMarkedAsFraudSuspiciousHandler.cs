﻿using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.SB.Handlers.Base;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.SB.Messages.Events;
using NServiceBus;
using System;
using System.Collections.Concurrent;
using System.Linq;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.SB.TaskHandlers.EventHandlers
{
    public class BankAccountMarkedAsFraudSuspiciousHandler : BaseEventHandler<BankAccountMarkedAsFraudSuspiciousEvent>
    {
        public INotificationLogicClient NotificationLogicClient { get; set; }
        public ITFSettingsLogicClient SettingsClient { get; set; }

        public override void HandleMessage(BankAccountMarkedAsFraudSuspiciousEvent handlerEvent)
        {
            try
            {
                var notificationConstruct = NotificationLogicClient.GetLatestNotificationConstructIdFromName(NotificationConstructEnum.BankAccountMarkedAsFraudSuspicious.GetStringValue());

                var dictionary = new ConcurrentDictionary<string, object>();
                dictionary.TryAdd("BankAccountMarkedAsFraudSuspiciousNotificationDTO", handlerEvent.BankAccountMarkedAsFraudSuspiciousNotificationDto);

                var recipients = handlerEvent.BankAccountMarkedAsFraudSuspiciousNotificationDto.UserAccountOrganisationIds
                    .Select(userAccountOrganisationId => new NotificationRecipientDTO 
                    {
                        UserAccountOrganisationID = userAccountOrganisationId
                    })
                    .ToList();

                var container = new NotificationContainerDTO(
                    notificationConstruct,
                    SettingsClient.GetSettings().AsSettings<CommonSettings>(),
                    recipients,
                    new NotificationDictionaryDTO 
                    { 
                        NotificationDictionary = dictionary 
                    });

                var notificationMessage = new NotificationEvent { NotificationContainer = container };

                Bus.SetMessageHeader(notificationMessage, "Source", AppDomain.CurrentDomain.FriendlyName);
                Bus.SetMessageHeader(notificationMessage, "MessageType", notificationMessage.GetType().FullName);
                Bus.SetMessageHeader(notificationMessage, "ServiceType", AppDomain.CurrentDomain.FriendlyName);
                Bus.SetMessageHeader(notificationMessage, "EventReference", Bus.CurrentMessageContext.Headers["EventReference"]);

                Bus.Publish(notificationMessage);

                LogMessageAsCompleted();
            }
            catch (Exception ex)
            {
                // log error
                LogError("Boo", ex, NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers).EventReference);
                throw;
            }
        }
    }
}
