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
    public class BankAccountCheckNoMatchHandler : BaseEventHandler<BankAccountCheckNoMatchEvent>
    {
        public INotificationLogicClient NotificationLogicClient { get; set; }
        public ITFSettingsLogicClient SettingsClient { get; set; }

        public override void HandleMessage(BankAccountCheckNoMatchEvent handlerEvent)
        {
            try
            {
                var recipients = NotificationLogicClient.GetNotificationOrganisationUaoIdsSync(handlerEvent.BankAccountCheckNoMatchNotificationDto.OrganisationId, null)
                    .Select(x => new NotificationRecipientDTO { UserAccountOrganisationID = x }).ToList();

                CreateAndPublishContainer(
                    NotificationLogicClient.GetLatestNotificationConstructIdFromNameSync(NotificationConstructEnum.BankAccountCheckNoMatch.GetStringValue()),
                    SettingsClient.GetSettingsSync().AsSettings<CommonSettings>(),
                    recipients,
                    "BankAccountCheckNoMatchNotificationDTO",
                    handlerEvent.BankAccountCheckNoMatchNotificationDto,
                    ActivityType.SmsTransaction,
                    handlerEvent.BankAccountCheckNoMatchNotificationDto.TransactionId);
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
