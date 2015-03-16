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
using Bec.TargetFramework.Workflow.Interfaces;
using EnsureThat;
using Bec.TargetFramework.SB.Infrastructure;

namespace Bec.TargetFramework.SB.TaskHandlers.EventHandlers
{
    public class RegistrationCompletedSubscriber : BaseEventHandler<Bec.TargetFramework.SB.Messages.Events.RegistrationCompletedEvent>
    {
        private IWorkflowProcessService m_WorkflowService;

        public RegistrationCompletedSubscriber(ILogger logger,
            IBusLogic busLogic, IClassificationDataLogic dataLogic,
            CommonSettings settings,IWorkflowProcessService wService)
            : base(logger, busLogic, dataLogic, settings)
        {
            m_WorkflowService = wService;
        }

        public override void HandleMessage(Messages.Events.RegistrationCompletedEvent registrationEvent)
        {
            try
            {
                var workflow = m_WorkflowService.GetWorkflowFromName(WorkflowEnum.LoginWorkflow.GetStringValue());

                Ensure.That(workflow).IsNotNull();

                var dictionary = new ConcurrentDictionary<string, object>();

                dictionary.TryAdd(WorkflowDataEnum.RegistrationData.GetStringValue(), registrationEvent.RegistrationDto);
                dictionary.TryAdd(WorkflowDataEnum.TemporaryAccountData.GetStringValue(), registrationEvent.TemporaryAccountDto);

                bool workflowAlreadyExists =
                    m_WorkflowService.DoesWorkflowNotCompletedExistForParentId(workflow.WorkflowID,
                        workflow.WorkflowVersionNumber, registrationEvent.TemporaryAccountDto.TemporaryUserId);

                if(!workflowAlreadyExists)
                    m_WorkflowService.CreateWorkflowInstance(workflow.WorkflowID, workflow.WorkflowVersionNumber, new WorkflowDictionaryDTO { WorkflowDictionary = dictionary }, registrationEvent.TemporaryAccountDto.TemporaryUserId, new List<UserAccountOrganisationDTO>());

                LogMessageAsCompleted();
            }
            catch (System.Exception ex)
            {
                // log error
                LogError("RegistrationEvent Error",ex, NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers).EventReference);
            	
                throw;
            }
        }
    }
}
