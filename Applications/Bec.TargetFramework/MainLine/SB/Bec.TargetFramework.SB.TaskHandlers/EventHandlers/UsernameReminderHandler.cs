using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Handlers.Base;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.SB.Messages.Commands;
using Bec.TargetFramework.SB.Messages.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Bec.TargetFramework.SB.TaskHandlers.EventHandlers

{
    public class UsernameReminderHandler : BaseEventHandler<UsernameReminderEvent>
    {
        private INotificationLogicClient m_nLogic;
        private CommonSettings m_CommonSettings;

        public UsernameReminderHandler(ILogger logger,
            IBusLogicClient bLogic, SBSettings settings, INotificationLogicClient nLogic, CommonSettings common)
            : base(logger, bLogic, settings)
        {
            m_nLogic= nLogic;
            m_CommonSettings = common;
        }

        public override void Dispose()
        {
        }

        public override void HandleMessage(Messages.Events.UsernameReminderEvent handlerEvent)
        {
            try 
            {
                var notificationConstruct = m_nLogic.GetLatestNotificationConstructIdFromName("UsernameReminder");

                var dictionary = new ConcurrentDictionary<string, object>();
                dictionary.TryAdd("UsernameReminderDTO", handlerEvent.UsernameReminderDto);

                // add coltemp accountid as recipient
                var container = new NotificationContainerDTO(
                    m_CommonSettings,
                    notificationConstruct.NotificationConstructID,
                    notificationConstruct.NotificationConstructVersionNumber,
                    new List<NotificationRecipientDTO> { new NotificationRecipientDTO { UserAccountOrganisationID = handlerEvent.UsernameReminderDto.UserAccountOrganisationID } },
                    new NotificationDictionaryDTO { NotificationDictionary = dictionary },
                    notificationConstruct.DefaultNotificationExportFormatID.GetValueOrDefault(0));

                var notificationMessage = new NotificationEvent { NotificationContainer = container };

                Bus.SetMessageHeader(notificationMessage, "Source", AppDomain.CurrentDomain.FriendlyName);
                Bus.SetMessageHeader(notificationMessage, "MessageType", notificationMessage.GetType().FullName);
                Bus.SetMessageHeader(notificationMessage, "ServiceType", AppDomain.CurrentDomain.FriendlyName);
                Bus.SetMessageHeader(notificationMessage, "EventReference", Bus.CurrentMessageContext.Headers["EventReference"]);

                Bus.Publish(notificationMessage);

                LogMessageAsCompleted();
            }
            catch (System.Exception ex)
            {
                // log error
                LogError("Boo", ex, NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers).EventReference);
                throw;
            }
        }
    }
}
