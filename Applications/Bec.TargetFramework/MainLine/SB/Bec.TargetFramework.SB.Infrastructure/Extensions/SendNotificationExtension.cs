using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Framework.Configuration;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.SB.Messages.Commands;
using NServiceBus;

namespace Bec.TargetFramework.SB.Infrastructure.Extensions
{
    public static class SendNotificationExtension
    {
        public static void SendNotificationToUserViaUAO<T>(this IBus bus,INotificationLogic nLogic,CommonSettings commonSettings, string notificationConstructName,Guid uaoId,NotificationDictionaryDTO dto) where T:class
        {

            var notificationConstruct =
                nLogic.GetLatestNotificationConstructIdFromName(
                    notificationConstructName);

            bool hasNotificationAlreadyBeenSent = nLogic.HasNotificationAlreadyBeenSentInTheLastTimePeriod(uaoId, null,
                notificationConstruct.NotificationConstructID,
                notificationConstruct.NotificationConstructVersionNumber,
                null,
                false,
                TimeSpan.FromMinutes(commonSettings.TimeSinceLastNotificationOfSameTypeWasSent));

            if (!hasNotificationAlreadyBeenSent)
            {
                // add coltemp accountid as recipient
                var container = new NotificationContainerDTO(
                    commonSettings,
                    notificationConstruct.NotificationConstructID,
                    notificationConstruct.NotificationConstructVersionNumber,
                    new List<NotificationRecipientDTO> { new NotificationRecipientDTO { UserAccountOrganisationID = uaoId } },
                    dto,
                        notificationConstruct.DefaultNotificationExportFormatID.GetValueOrDefault(0));

                var notificationMessage = new SendNotificationCommand { NotificationContainer = container };

                bus.SetMessageHeader(notificationMessage, "Source", typeof(T).GetType().FullName);
                bus.SetMessageHeader(notificationMessage, "MessageType", notificationMessage.GetType().ToString());
                bus.SetMessageHeader(notificationMessage, "ServiceType", typeof(T).GetType().FullName);
                bus.Publish(notificationMessage);
            }

            
        }
    }
}
