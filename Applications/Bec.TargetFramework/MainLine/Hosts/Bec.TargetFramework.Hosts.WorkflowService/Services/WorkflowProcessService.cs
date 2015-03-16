using System.Reflection;
using Autofac;
using Bec.TargetFramework.Entities.DTO;
using Bec.TargetFramework.Entities.DTO.Workflow;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Entities.Workflow;
using Bec.TargetFramework.Infrastructure.WCF.Exception;
using Bec.TargetFramework.Workflow.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bec.TargetFramework.Hosts.WorkflowService.Services
{
    using System.Collections.Concurrent;

    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Data;
    //Bec.TargetFramework.Entities
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Workflow.Base;
    using Bec.TargetFramework.Workflow.Configuration;
    using Bec.TargetFramework.Entities;
    using Bec.TargetFramework.Workflow.Helpers;
    using Bec.TargetFramework.Workflow.Interfaces;

    using NHibernate.Engine;
    using Bec.TargetFramework.Data.Infrastructure;
    using Fabrik.Common;
    using ServiceStack.Text;
    using Bec.TargetFramework.Entities.Settings;

    [Trace(TraceExceptionsOnly = true)]
    [WcfGlobalExceptionOperationBehaviorAttribute(typeof(WcfGlobalErrorHandler))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class WorkflowProcessService : IWorkflowProcessService
    {
        private WorkflowEngine m_WorkflowEngine;
        private WorkflowTaskManager m_WorkflowTaskManager;

        private WorkflowSettings m_WorkflowSetting;

        private ILogger m_Logger;

        public WorkflowProcessService(WorkflowSettings settings, ILogger logger,WorkflowEngine engine,WorkflowTaskManager manager)
        {
            m_WorkflowEngine = engine;
            m_WorkflowTaskManager = manager;
            m_Logger = logger;
            m_WorkflowSetting = settings;
        }



        public WorkflowDTO GetWorkflowFromName(string workflowName)
        {
            
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, m_Logger))
            {
                var repository = scope.GetGenericRepositoryNoTracking<Workflow, int>();

                var items = repository.FindAll(item => item.Name.Equals(workflowName)).ToList();

               return WorkflowConverter.ToDto(items.OrderByDescending(i => i.WorkflowVersionNumber).FirstOrDefault());
            }
        }

        public VUserWorkflowInstanceStatusDTO GetWorkflowInstanceFromParentID(Guid parentID)
        {
            Ensure.NotNull(parentID);
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, m_Logger))
            {

                var repository = scope.GetGenericRepositoryNoTracking<VUserWorkflowInstanceStatus, Guid>();

                var instance = repository.Find(item => item.ParentID.Equals(parentID));

                return VUserWorkflowInstanceStatusConverter.ToDto(instance);
            }
        }
        public VUserWorkflowInstanceStatusDTO GetWorkflowInstanceFromUserID(Guid userID)
        {
            Ensure.NotNull(userID);
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, m_Logger))
            {

                var repository = scope.GetGenericRepositoryNoTracking<VUserWorkflowInstanceStatus, Guid>();

                var instance = repository.Find(item => item.UserID.HasValue && item.UserID.Value.Equals(userID));

                return VUserWorkflowInstanceStatusConverter.ToDto(instance);
            }
        }
        public WorkflowInstanceCurrentStateDTO CreateAndStartWorkflowInstance(Guid workflowID, int versionNumber, WorkflowDictionaryDTO data, Guid parentID, List<UserAccountOrganisationDTO> workflowUsers)
        {
            var workflowContainer = m_WorkflowEngine.CreateNewWorkflowInstanceContainerNotStarted(workflowID, versionNumber, parentID, data.WorkflowDictionary, workflowUsers);

            m_WorkflowTaskManager.AddWorkflowInstanceBeingManuallyProcessedToPreventExecution(workflowContainer.WorkflowInstance.ID);

            if (m_WorkflowSetting.EnableWorkflowTrace)
                m_Logger.Trace(
                    "Workflow Process Service: Create and Start New Workflow Instance WorkflowID:" + workflowID + " version:"
                    + versionNumber + " parentID:" + parentID);

            
            workflowContainer.WorkflowProcessHandler.StartWorkflow();
            
            return workflowContainer.WorkflowProcessHandler.CurrentState;
        }

        public void CreateWorkflowInstance(Guid workflowID, int versionNumber, WorkflowDictionaryDTO data, Guid parentID, List<UserAccountOrganisationDTO> workflowUsers)
        {
            if (m_WorkflowSetting.EnableWorkflowTrace)
                m_Logger.Trace(
                    "Workflow Process Service: Create New Workflow Instance WorkflowID:" + workflowID + " version:"
                    + versionNumber + " parentID:" + parentID);

            var workflowContainer = m_WorkflowEngine.CreateNewWorkflowInstanceContainerNotStarted(workflowID, versionNumber, parentID, data.WorkflowDictionary, workflowUsers);
        }

        public WorkflowInstanceCurrentStateDTO StartWorkflowInstance(Guid workflowInstanceID, Guid parentID)
        {
            var workflowContainer = m_WorkflowEngine.LoadWorkflowInstanceContainerNotStarted(workflowInstanceID);

            m_WorkflowTaskManager.AddWorkflowInstanceBeingManuallyProcessedToPreventExecution(workflowInstanceID);

            if (m_WorkflowSetting.EnableWorkflowTrace)
                m_Logger.Trace(
                    "Workflow Process Service: Start Workflow Instance workflowInstanceID:" + workflowInstanceID + " parentID:" + parentID);

            // execute work flow and return result
            workflowContainer.WorkflowProcessHandler.StartWorkflow();

            return workflowContainer.WorkflowProcessHandler.CurrentState;
        }
        
        public WorkflowInstanceCurrentStateDTO RestartWorkflowInstance(Guid workflowInstanceID, Guid parentID)
        {
            var workflowContainer = m_WorkflowEngine.LoadWorkflowInstanceContainerNotStarted(workflowInstanceID);

            m_WorkflowTaskManager.AddWorkflowInstanceBeingManuallyProcessedToPreventExecution(workflowInstanceID);

            if (m_WorkflowSetting.EnableWorkflowTrace)
                m_Logger.Trace(
                    "Workflow Process Service: Restart Workflow Instance workflowInstanceID:" + workflowInstanceID + " parentID:" + parentID); 

            // execute work flow and return result
            workflowContainer.WorkflowProcessHandler.RestartWorkflow();

            return workflowContainer.WorkflowProcessHandler.CurrentState;
        }

        public bool DoesWorkflowNotCompletedExistForParentId(Guid workflowId, int workflowVersionNumber,Guid parentId)
        {
            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, m_Logger))
            {
                int inProgress = (int) WorkflowInstanceStatusIDEnum.InProgress;

                exists = scope.DbContext.WorkflowInstances.Any(s => s.ParentID.Equals(parentId)
                                                                    && s.WorkflowID.Equals(workflowId)
                                                                    &&
                                                                    s.WorkflowVersionNumber.Equals(workflowVersionNumber)
                                                                    && s.WorkflowInstanceStatusID.Equals(inProgress));
            }

            return exists;
        }

        public WorkflowInstanceCurrentStateDTO RestartWorkflowInstanceViaWebUI(Guid workflowInstanceID, WorkflowStateBaseDTO stateDTO)
        {
            // post process web data via last action
            m_WorkflowEngine.PostProcessDataForWorkflowInstance(stateDTO);

            var workflowContainer = m_WorkflowEngine.LoadWorkflowInstanceContainerNotStarted(workflowInstanceID, stateDTO);

            m_WorkflowTaskManager.AddWorkflowInstanceBeingManuallyProcessedToPreventExecution(workflowInstanceID);

            if (m_WorkflowSetting.EnableWorkflowTrace)
                m_Logger.Trace(
                    "Workflow Process Service: Restart Workflow Instance workflowInstanceID:" + workflowInstanceID);

            // execute work flow and return result
            workflowContainer.WorkflowProcessHandler.RestartWorkflow();

            return workflowContainer.WorkflowProcessHandler.CurrentState;
        }


        public WorkflowInstanceCurrentStateDTO GetCurrentWorkflowInstanceManualActionNotCompleted(Guid workflowInstanceID)
        {
            return m_WorkflowEngine.LoadWorkflowInstanceManualAction(workflowInstanceID);
        }

        public WorkflowStateBaseDTO GetDataForWorkflowInstanceStatusEvent(int workflowInstanceStatusEventID)
        {
            var wfB = m_WorkflowEngine.LoadDataForWorkflowInstanceStatusEvent(workflowInstanceStatusEventID);

            return wfB;
        }

        protected UserIdentificationMessageDTO GetUserIdentificationMessageDTOFromContext()
        {
            ServiceSecurityContext cxtSec = ServiceSecurityContext.Current;
            int index = OperationContext.Current.IncomingMessageHeaders.FindHeader("UserIdentificationMessageDTO", "http://tempuri.org");
            UserIdentificationMessageDTO dto = null;
            if (index > -1)
            {
                dto = OperationContext.Current.IncomingMessageHeaders.GetHeader<UserIdentificationMessageDTO>(index);
            }
            return dto;
        }


    }
}
