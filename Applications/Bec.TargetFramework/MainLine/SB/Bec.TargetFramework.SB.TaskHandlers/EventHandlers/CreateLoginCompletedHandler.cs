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
using Bec.TargetFramework.SB.Infrastructure.Extensions;
using Bec.TargetFramework.Security;
using Bec.TargetFramework.Workflow.Interfaces;
using EnsureThat;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.Infrastructure.Helpers;
using NServiceBus;

namespace Bec.TargetFramework.SB.TaskHandlers.EventHandlers
{
    public class CreateLoginCompletedHandler : BaseEventHandler<Bec.TargetFramework.SB.Messages.Events.CreateLoginCompletedEvent>
    {
        private IWorkflowProcessService m_WorkflowService;
        private IUserLogic m_UserLogic;
        private INotificationLogic m_NotificationLogic;

        public CreateLoginCompletedHandler(ILogger logger,
            IBusLogic busLogic, IClassificationDataLogic dataLogic,
            CommonSettings settings,IWorkflowProcessService wService, IUserLogic userLogic,INotificationLogic nLogic)
            : base(logger, busLogic, dataLogic, settings)
        {
            m_WorkflowService = wService;
            m_UserLogic = userLogic;
            m_NotificationLogic = nLogic;
        }

        public override void HandleMessage(Messages.Events.CreateLoginCompletedEvent createLoginEvent)
        {
            try 
            { 
                //TDB check for permanment account existing and UAO existing

                WorkflowStateBaseDTO state = JsonHelper.DeserializeData<WorkflowStateBaseDTO>(createLoginEvent.WorkflowData);

                m_WorkflowService.RestartWorkflowInstanceViaWebUI(state.InstanceID.Value, state);

                object acc;
                state.WorkflowDictionaryDto.WorkflowDictionary.TryGetValue(WorkflowDataEnum.PermanentAccountData.GetStringValue(), out acc);
                PermanentAccountDTO permanentAcc = (PermanentAccountDTO)acc;

                object tempacc;
                state.WorkflowDictionaryDto.WorkflowDictionary.TryGetValue(WorkflowDataEnum.TemporaryAccountData.GetStringValue(), out tempacc);
                TemporaryAccountDTO temporaryAcc = (TemporaryAccountDTO)tempacc;

                // need to ginf personal useraccountid
                var peramUaoID = m_UserLogic.GetPersonalUserAccountOrganisation(permanentAcc.UserID);

                var userTypeID = temporaryAcc.UserTypeEnumValue.GetGuidValue();
                var organisationTypeID = (int) temporaryAcc.OrganisationTypeEnumValue;

                m_NotificationLogic.GetNotificationGroupConstructs(userTypeID, organisationTypeID, NotificationGroupTypeIDEnum.TermsConditions)
                    .ForEach(s =>
                    {
                        var dictionary = new ConcurrentDictionary<string, object>();

                        var tcDto = new TermsConditionsDataDTO
                        {
                            VerificationCode = RandomPasswordGenerator.Generate(20)
                        };

                        dictionary.TryAdd("TermsConditionsDataDTO", tcDto);

                        // send notification
                        var notificationConstruct =
                        m_NotificationLogic.GetLatestNotificationConstructIdFromName(s.NotificationConstructName);

                        Bus.SendNotificationToUserViaUAO<CreateLoginCompletedHandler>(m_NotificationLogic,m_CommonSettings,
                            s.NotificationConstructName,
                            peramUaoID,
                            new NotificationDictionaryDTO { NotificationDictionary = dictionary }
                            );
                    });

                // create workflow if it doesnt exist
                if (!m_WorkflowService.DoesWorkflowNotCompletedExistForParentId(temporaryAcc.WorkflowID,
                    temporaryAcc.WorkflowVersionNumber, peramUaoID))
                {
                    m_WorkflowService.CreateWorkflowInstance(temporaryAcc.WorkflowID, temporaryAcc.WorkflowVersionNumber,
                       new WorkflowDictionaryDTO { WorkflowDictionary = state.WorkflowDictionaryDto.WorkflowDictionary }, peramUaoID, new List<UserAccountOrganisationDTO> { new UserAccountOrganisationDTO { UserAccountOrganisationID = peramUaoID } });
                }

                LogMessageAsCompleted();
            }
            catch (System.Exception ex)
            {
                // log error
                LogError("createLoginEvent Error", ex, NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers).EventReference);
                throw;
            }
        }
    }
}
