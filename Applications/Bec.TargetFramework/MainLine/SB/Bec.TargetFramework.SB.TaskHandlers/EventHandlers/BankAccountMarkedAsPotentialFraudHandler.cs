using Bec.TargetFramework.Business.Client.Interfaces;
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
    public class BankAccountMarkedAsPotentialFraudHandler : BaseEventHandler<BankAccountMarkedAsPotentialFraudEvent>
    {
        public INotificationLogicClient NotificationLogicClient { get; set; }
        public ITFSettingsLogicClient SettingsClient { get; set; }

        public override void HandleMessage(BankAccountMarkedAsPotentialFraudEvent handlerEvent)
        {
            try
            {
                var recipients = NotificationLogicClient.GetNotificationOrganisationUaoIdsSync(handlerEvent.BankAccountMarkedAsPotentialFraudNotificationDto.OrganisationId, "Organisation Administrator")
                    .Select(x => new NotificationRecipientDTO { UserAccountOrganisationID = x }).ToList();

                CreateAndPublishContainer(
                    NotificationLogicClient.GetLatestNotificationConstructIdFromNameSync(NotificationConstructEnum.BankAccountMarkedAsPotentialFraud.GetStringValue()),
                    SettingsClient.GetSettingsSync().AsSettings<CommonSettings>(),
                    recipients,
                    "BankAccountMarkedAsPotentialFraudNotificationDTO",
                    handlerEvent.BankAccountMarkedAsPotentialFraudNotificationDto,
                    ActivityType.BankAccount,
                    handlerEvent.BankAccountMarkedAsPotentialFraudNotificationDto.OrganisationBankAccountID);

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
