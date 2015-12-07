﻿using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.SB.Handlers.Base;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.SB.Messages.Events;
using NServiceBus;
using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Bec.TargetFramework.SB.TaskHandlers.EventHandlers
{
    public class BankAccountCheckNoMatchHandler : BaseEventHandler<BankAccountCheckNoMatchEvent>
    {
        public INotificationLogicClient NotificationLogicClient { get; set; }
        public ITFSettingsLogicClient SettingsClient { get; set; }

        public override void HandleMessage(BankAccountCheckNoMatchEvent handlerEvent)
        {
            try
            {
                var notificationConstruct = NotificationLogicClient.GetLatestNotificationConstructIdFromName(NotificationConstructEnum.BankAccountCheckNoMatch.GetStringValue());

                var dictionary = new ConcurrentDictionary<string, object>();
                dictionary.TryAdd("BankAccountCheckNoMatchNotificationDTO", handlerEvent.BankAccountCheckNoMatchNotificationDto);

                var recipients = NotificationLogicClient.GetNotificationOrganisationUsers(handlerEvent.BankAccountCheckNoMatchNotificationDto.OrganisationId)
                    .Select(x => new NotificationRecipientDTO { UserAccountOrganisationID = x }).ToList();

                var container = new NotificationContainerDTO(
                    notificationConstruct,
                    SettingsClient.GetSettings().AsSettings<CommonSettings>(),
                    recipients,
                    new NotificationDictionaryDTO
                    {
                        NotificationDictionary = dictionary
                    },
                    ActivityType.SmsTransaction,
                    handlerEvent.BankAccountCheckNoMatchNotificationDto.TransactionId
                    );

                var notificationMessage = new NotificationEvent { NotificationContainer = container };

                Bus.SetMessageHeader(notificationMessage, "Source", AppDomain.CurrentDomain.FriendlyName);
                Bus.SetMessageHeader(notificationMessage, "MessageType", notificationMessage.GetType().FullName);
                Bus.SetMessageHeader(notificationMessage, "ServiceType", AppDomain.CurrentDomain.FriendlyName);
                Bus.SetMessageHeader(notificationMessage, "EventReference", Bus.CurrentMessageContext.Headers["EventReference"]);

                Bus.Publish(notificationMessage);

                NotificationLogicClient.PublishNewInternalMessagesNotificationEvent(1, handlerEvent.BankAccountCheckNoMatchNotificationDto.OrganisationId,
                    NotificationConstructEnum.BankAccountCheckNoMatch);

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
