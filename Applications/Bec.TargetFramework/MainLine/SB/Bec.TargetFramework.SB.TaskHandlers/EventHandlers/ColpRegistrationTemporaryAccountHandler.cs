using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Workflow;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Framework.Configuration;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Handlers.Base;
using Bec.TargetFramework.SB.Messages.Commands;
using Bec.TargetFramework.Workflow.Interfaces;
using EnsureThat;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.SB.Infrastructure.Extensions;
using NServiceBus;

namespace Bec.TargetFramework.SB.TaskHandlers.EventHandlers
{
    public class ColpRegistratioTemporaryAccountHandler : BaseEventHandler<Bec.TargetFramework.SB.Messages.Events.ColpRegistrationTemporaryAccountEvent>
    {
        private IWorkflowProcessService m_WorkflowService;
        private IUserLogic m_UserLogic;
        private INotificationDataService m_NotificationDataService;
        private INotificationLogic m_NotificationLogic;

        public ColpRegistratioTemporaryAccountHandler(ILogger logger,
            IBusLogic busLogic, IClassificationDataLogic dataLogic,
            CommonSettings settings,IWorkflowProcessService wService, IUserLogic userLogic,INotificationDataService notificationDataService,INotificationLogic nLogic)
            : base(logger, busLogic, dataLogic, settings)
        {
            m_WorkflowService = wService;
            m_UserLogic = userLogic;
            m_NotificationDataService = notificationDataService;
            m_NotificationLogic = nLogic;
        }

        public override void HandleMessage(Messages.Events.ColpRegistrationTemporaryAccountEvent accountEvent)
        {
            try 
            {
                WorkflowDictionaryDTO dictionary = JsonHelper.DeserializeData<WorkflowDictionaryDTO>(accountEvent.DataDictionary);

                var temporaryAccountDto =
                    dictionary.WorkflowDictionary[WorkflowDataEnum.TemporaryAccountData.GetStringValue()] as TemporaryAccountDTO;

                // do not process if not registration
                if (!temporaryAccountDto.IsRegistration)
                    return;

                ProcessCOLP(dictionary);

                // CLC Firm Notifications Removed
                //ProcessCLCFirm(dictionary);

                LogMessageAsCompleted();
            }
            catch (System.Exception ex)
            {
                // log error
                LogError("createLoginEvent Error", ex, NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers).EventReference);
                throw;
            }
        }

        private void ProcessCOLP(WorkflowDictionaryDTO dictionary)
        {
            var registrationDto = dictionary.WorkflowDictionary[WorkflowDataEnum.RegistrationData.GetStringValue()] as RegistrationDTO;

            var temporaryAccountDto =
                   dictionary.WorkflowDictionary[WorkflowDataEnum.TemporaryAccountData.GetStringValue()] as TemporaryAccountDTO;


            var temporaryAccountContact = new ContactDTO();
            var contact = new ContactDTO();

            // create colp contact if not existing
            if (!m_UserLogic.ContactExists(temporaryAccountDto.TemporaryUserId))
            {
                temporaryAccountContact.ContactName = registrationDto.COFirstName + " " + registrationDto.COLastName;
                temporaryAccountContact.FirstName = registrationDto.COFirstName;
                temporaryAccountContact.LastName = registrationDto.COLastName;
                temporaryAccountContact.EmailAddress1 = registrationDto.COEmail;
                temporaryAccountContact.ParentID = temporaryAccountDto.TemporaryUserId;
                temporaryAccountContact.IsPrimaryContact = true;

                m_UserLogic.CreateContact(temporaryAccountContact);
            }

            // create notification
            var notificationConstruct =
                m_NotificationLogic.GetLatestNotificationConstructIdFromName(
                    NotificationConstructEnum.ColpRegistration.GetStringValue());

            Bus.SendNotificationToUserViaUAO<ColpRegistratioTemporaryAccountHandler>(m_NotificationLogic, m_CommonSettings,
                NotificationConstructEnum.ColpRegistration.GetStringValue(), 
                temporaryAccountDto.UserAccountOrganisationID, 
                new NotificationDictionaryDTO { NotificationDictionary = dictionary.WorkflowDictionary });
        }

        private void ProcessCLCFirm(WorkflowDictionaryDTO dictionary)
        {
            var registrationDto = dictionary.WorkflowDictionary[WorkflowDataEnum.RegistrationData.GetStringValue()] as RegistrationDTO;

            if (!string.IsNullOrEmpty(registrationDto.CORegulator) && registrationDto.CORegulator.Equals("CLC"))
            {
                // create notification
                var notificationConstruct =
                    m_NotificationLogic.GetLatestNotificationConstructIdFromName(
                        NotificationConstructEnum.ScpFirmApproval.GetStringValue());

                // add coltemp accountid as recipient
                var container = new NotificationContainerDTO(
                    m_CommonSettings,
                    notificationConstruct.NotificationConstructID,
                    notificationConstruct.NotificationConstructVersionNumber,
                    new List<NotificationRecipientDTO> { new NotificationRecipientDTO { UserAccountOrganisationID = Guid.Parse(m_CommonSettings.PrimaryUserIDFromBecAdministrationNotifications) } },
                    new NotificationDictionaryDTO { NotificationDictionary = dictionary.WorkflowDictionary },
                    notificationConstruct.DefaultNotificationExportFormatID.GetValueOrDefault(0));

                var notificationMessage = new SendNotificationCommand { NotificationContainer = container };

                Bus.SetMessageHeader(notificationMessage, "Source", "ColpRegistrationCompletedHandler");
                Bus.SetMessageHeader(notificationMessage, "MessageType", notificationMessage.GetType().ToString());
                Bus.SetMessageHeader(notificationMessage, "ServiceType", "ColpRegistrationCompletedHandler");
                Bus.Publish(notificationMessage);
            }
        }
    }
}
