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
    public class AddNewCompanyAndAdministratorHandler : BaseEventHandler<AddNewCompanyAndAdministratorEvent>
    {
        public INotificationLogicClient m_nLogic {get;set;}
        public ITFSettingsLogicClient SettingsClient { get; set; }

        public AddNewCompanyAndAdministratorHandler()
        {
        }

        public override void Dispose()
        {
        }

        public override void HandleMessage(Messages.Events.AddNewCompanyAndAdministratorEvent handlerEvent)
        {
            try 
            {
                CreateAndPublishContainer(
                    m_nLogic.GetLatestNotificationConstructIdFromName("AddCompanyAdministratorTempDetails"),
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
