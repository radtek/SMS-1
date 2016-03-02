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
    public class BankAccountMarkedAsSafeHandler : BaseEventHandler<BankAccountMarkedAsSafeEvent>
    {
        public INotificationLogicClient NotificationLogicClient { get; set; }
        public ITFSettingsLogicClient SettingsClient { get; set; }

        public override void HandleMessage(BankAccountMarkedAsSafeEvent handlerEvent)
        {
            try
            {
                var recipients = NotificationLogicClient.GetNotificationOrganisationUaoIds(handlerEvent.BankAccountMarkedAsSafeNotificationDto.OrganisationId, null)
                    .Select(x => new NotificationRecipientDTO { UserAccountOrganisationID = x }).ToList();

                CreateAndPublishContainer(
                    NotificationLogicClient.GetLatestNotificationConstructIdFromName(NotificationConstructEnum.BankAccountMarkedAsSafe.GetStringValue()),
                    SettingsClient.GetSettings().AsSettings<CommonSettings>(),
                    recipients,
                    "BankAccountMarkedAsSafeNotificationDTO",
                    handlerEvent.BankAccountMarkedAsSafeNotificationDto,
                    ActivityType.BankAccount,
                    handlerEvent.BankAccountMarkedAsSafeNotificationDto.OrganisationBankAccountID);
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
