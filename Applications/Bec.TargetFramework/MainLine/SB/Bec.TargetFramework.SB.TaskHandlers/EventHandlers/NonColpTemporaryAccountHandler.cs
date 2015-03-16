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
using Bec.TargetFramework.Infrastructure.Helpers;
namespace Bec.TargetFramework.SB.TaskHandlers.EventHandlers
{
    public class NonColpTemporaryAccountHandler : BaseEventHandler<Bec.TargetFramework.SB.Messages.Events.NonColpTemporaryAccountEvent>
    {
        private IWorkflowProcessService m_WorkflowService;
        private IUserLogic m_UserLogic;

        public NonColpTemporaryAccountHandler(ILogger logger,
            IBusLogic busLogic, IClassificationDataLogic dataLogic,
            CommonSettings settings,IWorkflowProcessService wService, IUserLogic userLogic)
            : base(logger, busLogic, dataLogic, settings)
        {
            m_WorkflowService = wService;
            m_UserLogic = userLogic;
        }

        public override void HandleMessage(Messages.Events.NonColpTemporaryAccountEvent accountEvent)
        {
            try 
            {
                WorkflowDictionaryDTO dictionary = JsonHelper.DeserializeData<WorkflowDictionaryDTO>(accountEvent.DataDictionary);

                var temporaryAccountDto =
                    dictionary.WorkflowDictionary[WorkflowDataEnum.TemporaryAccountData.GetStringValue()] as TemporaryAccountDTO;

                // do not process if  registration
                if (temporaryAccountDto.IsRegistration)
                    return;


                
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
