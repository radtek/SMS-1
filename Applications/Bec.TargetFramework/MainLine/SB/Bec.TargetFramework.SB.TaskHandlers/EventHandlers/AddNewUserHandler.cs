using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure;
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
    public class AddNewUserHandler : BaseEventHandler<AddNewUserEvent>
    {
        public INotificationLogicClient m_nLogic {get;set;}
        public ITFSettingsLogicClient SettingsClient { get; set; }

        public AddNewUserHandler()
        {
        }

        public override void Dispose()
        {
        }

        public override void HandleMessage(Messages.Events.AddNewUserEvent handlerEvent)
        {
            try 
            {
                var notificationConstruct = m_nLogic.GetLatestNotificationConstructIdFromName("AddNewUserTempDetails");
                //fudge in subject
                notificationConstruct.NotificationSubject = string.Format("Message from {0}", handlerEvent.AddNewCompanyAndAdministratorDto.InviterOrganisationName);

                CreateAndPublishContainer(
                    notificationConstruct,
                    SettingsClient.GetSettings().AsSettings<CommonSettings>(),
                    new List<NotificationRecipientDTO> { new NotificationRecipientDTO { UserAccountOrganisationID = handlerEvent.AddNewCompanyAndAdministratorDto.UserAccountOrganisationID } },
                    "AddNewCompanyAndAdministratorDTO",
                    handlerEvent.AddNewCompanyAndAdministratorDto);
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
