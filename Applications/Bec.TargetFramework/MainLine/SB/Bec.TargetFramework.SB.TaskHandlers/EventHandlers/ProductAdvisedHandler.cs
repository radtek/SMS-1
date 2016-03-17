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
using System.Collections.Concurrent;
using System.Linq;

namespace Bec.TargetFramework.SB.TaskHandlers.EventHandlers
{
    public class ProductAdvisedHandler : BaseEventHandler<ProductAdvisedEvent>
    {
        public INotificationLogicClient NotificationLogicClient { get; set; }
        public ISmsTransactionLogicClient SmsTransactionLogicClient { get; set; }
        public ITFSettingsLogicClient SettingsClient { get; set; }

        public override void HandleMessage(ProductAdvisedEvent handlerEvent)
        {
            try
            {
                var recipients = SmsTransactionLogicClient.GetSmsTransactionRelatedPartyUaoIdsSync(handlerEvent.ProductAdvisedNotificationDTO.TransactionID)
                    .Select(x => new NotificationRecipientDTO { UserAccountOrganisationID = x }).ToList();

                CreateAndPublishContainer(
                    NotificationLogicClient.GetLatestNotificationConstructIdFromNameSync(NotificationConstructEnum.ProductAdvised.GetStringValue()),
                    SettingsClient.GetSettingsSync().AsSettings<CommonSettings>(),
                    recipients,
                    "ProductAdvisedNotificationDTO",
                    handlerEvent.ProductAdvisedNotificationDTO,
                    ActivityType.SmsTransaction,
                    handlerEvent.ProductAdvisedNotificationDTO.TransactionID);
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
