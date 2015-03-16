using Autofac;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Workflow.Configuration;
using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Workflow.Providers;
using Bec.TargetFramework.Entities;
using ServiceStack.Text;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Workflow.Engine
{
    using Bec.TargetFramework.Data;
    using Bec.TargetFramework.Entities.Workflow;
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Workflow.Exceptions;
    using Bec.TargetFramework.Workflow.Helpers;

    using Fabrik.Common;

    //Bec.TargetFramework.Entities

    public class WorkflowEngine
    {
        private ILogger m_Logger;
        private DbWorkflowProvider m_wProvider;
        private DbWorkflowInstanceProvider m_wIProvider;
        private DbWorkflowTemplateProvider m_wTProvider;
        private IWorkflowContainer m_EmptyContainer;

        private ICacheProvider m_CacheProvider;

        public WorkflowEngine(ILogger logger, DbWorkflowProvider wProvider, DbWorkflowInstanceProvider wIProvider,
            DbWorkflowTemplateProvider wTProvider, IWorkflowContainer emptyContainer,ICacheProvider cacheProvider)
        {
            m_Logger = logger;
            m_wProvider = wProvider;
            m_wIProvider = wIProvider;
            m_wTProvider = wTProvider;
            m_EmptyContainer = emptyContainer;
            m_CacheProvider = cacheProvider;
        }


        public IWorkflowContainer CreateNewWorkflowInstanceContainerNotStarted(Guid workflowID,int versionNumber,Guid parentId,ConcurrentDictionary<string,object> data,List<UserAccountOrganisationDTO> workflowUsers = null )
        {
            IWorkflowContainer container = m_wProvider.Load(m_EmptyContainer, workflowID, versionNumber);

            container.InitialiseContainerAndCreateInstance(data, parentId, true,workflowUsers);

            return container;
        }

        public IWorkflowContainer CreateNewWorkflowFromTemplate(Guid workflowTemplateID, int versionNumber, ConcurrentDictionary<string, object> data, Guid parentId, List<UserAccountOrganisationDTO> workflowUsers = null)
        {
            var workflow = m_wTProvider.CreateFromTemplate(workflowTemplateID, versionNumber);

            IWorkflowContainer container = m_wProvider.Load(m_EmptyContainer, workflow.WorkflowID, workflow.WorkflowVersionNumber);

            container.InitialiseContainerAndCreateInstance(data, parentId, true,workflowUsers);

            return container;
        }

        public IWorkflowContainer LoadWorkflowInstanceContainerNotStarted(Guid workflowInstanceID, WorkflowStateBaseDTO stateBase = null)
        {
            // load and create new instance
            var instance = m_wIProvider.Load(workflowInstanceID, stateBase);

            IWorkflowContainer container = m_wProvider.Load(m_EmptyContainer, instance.WorkflowID, instance.WorkflowVersionNumber);

            container.InitialiseContainerFromInstance(instance);

            return container;
        }

        public WorkflowStateBaseDTO LoadDataForWorkflowInstanceStatusEvent(int workflowInstanceExecutionStatusEventID)
        {
            WorkflowStateBaseDTO state = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, m_Logger))
            {
                var items =
                    scope.DbContext.WorkflowInstanceExecutionDataItems.Where(
                        s => s.WorkflowInstanceExecutionStatusEventID == workflowInstanceExecutionStatusEventID).ToList();

                if (items.Count > 0)
                {
                    state = WorkflowDataHelper.DeserializeData(items.First().DataContent);
                }

                // determine action and preprocess data
                var executionItems = scope.DbContext.WorkflowInstanceExecutionStatusEvents.Include("WorkflowInstanceExecution")
                    .Where(s => s.WorkflowInstanceExecutionStatusEventID.Equals(workflowInstanceExecutionStatusEventID)).ToList();

                if (executionItems.Count > 0 && executionItems.First().WorkflowInstanceExecution != null
                    && executionItems.First().WorkflowInstanceExecution.WorkflowActionID.HasValue)
                {
                    Guid actionID = executionItems.First().WorkflowInstanceExecution.WorkflowActionID.Value;

                    var actions =
                        scope.DbContext.WorkflowActions.Include("WorkflowObjectType").Where(
                            s => s.WorkflowActionID.Equals(actionID)).ToList();

                    Ensure.Argument.Is(actions.Count > 0);
                    Ensure.Argument.NotNull(actions.First().WorkflowObjectType);
                    Ensure.Argument.NotNullOrEmpty(actions.First().WorkflowObjectType.ObjectTypeName);
                    Ensure.Argument.NotNullOrEmpty(actions.First().WorkflowObjectType.ObjectTypeAssembly);
                    Ensure.Argument.NotNullOrEmpty(actions.First().WorkflowObjectType.ObjectTypeNameSpace);

                    var action = Activator.CreateInstance(Type.GetType(actions.First().WorkflowObjectType.ObjectTypeNameSpace.ReplaceLineBreaks("")
                        + "." + actions.First().WorkflowObjectType.ObjectTypeName.ReplaceLineBreaks("")
                        + ", " + actions.First().WorkflowObjectType.ObjectTypeAssembly.ReplaceLineBreaks(""))) as WorkflowActionBase;

                    // invoke preprocess
                    action.PreProcessDataBeforeWebUI(state);
                }
            }

            return state;
        }

        public WorkflowStateBaseDTO PostProcessDataForWorkflowInstance(WorkflowStateBaseDTO stateBase)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, m_Logger))
            {
                // determine action and preprocess data
                Ensure.Argument.NotNull(stateBase);
                Ensure.Argument.NotNull(stateBase.CurrentWorkflowComponentID);

                    var actions =
                        scope.DbContext.WorkflowActions.Include("WorkflowObjectType").Where(
                            s => s.WorkflowActionID.Equals(stateBase.CurrentWorkflowComponentID)).ToList();

                    Ensure.Argument.Is(actions.Count > 0);
                    Ensure.Argument.NotNull(actions.First().WorkflowObjectType);
                    Ensure.Argument.NotNullOrEmpty(actions.First().WorkflowObjectType.ObjectTypeName);
                    Ensure.Argument.NotNullOrEmpty(actions.First().WorkflowObjectType.ObjectTypeAssembly);
                    Ensure.Argument.NotNullOrEmpty(actions.First().WorkflowObjectType.ObjectTypeNameSpace);

                    var action = Activator.CreateInstance(Type.GetType(actions.First().WorkflowObjectType.ObjectTypeNameSpace.ReplaceLineBreaks("")
                        + "." + actions.First().WorkflowObjectType.ObjectTypeName.ReplaceLineBreaks("")
                        + ", " + actions.First().WorkflowObjectType.ObjectTypeAssembly.ReplaceLineBreaks(""))) as WorkflowActionBase;

                    // invoke preprocess
                    action.PostProcessDataAfterWebUI(stateBase);
                
            }

            return stateBase;
        }

        public WorkflowInstanceCurrentStateDTO LoadWorkflowInstanceManualAction(Guid workflowInstanceID)
        {
            Ensure.Argument.NotNull(workflowInstanceID);

            var dto = new WorkflowInstanceCurrentStateDTO();

            using (
                var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, m_Logger))
            {
                var latestEntry =
                    scope.DbContext.VWorkflowInstanceExecutionNotCompleteds.Where(
                        item => item.WorkflowInstanceID.Equals(workflowInstanceID)).ToList();

                if (latestEntry.Count == 0)
                    throw new ArgumentNullException("No Manual Action needs to be processed for workflowInstance:" + workflowInstanceID);
                else
                {
                    var lastNotCompleted = latestEntry.First();

                    // ensure ID is not null
                    Ensure.Argument.NotNull(lastNotCompleted.StepID);

                    // determine if expected values are available
                    if(lastNotCompleted.ActionAction.IsNullOrEmpty()
                        || lastNotCompleted.ActionController.IsNullOrEmpty())
                        throw new ManualActionMissingParametersException("WorkflowInstance:" + workflowInstanceID + " last Action:" + lastNotCompleted.StepName + " is missing some of the action parameters necessary to execute");

                    // construct DTO
                    dto.CurrentActionDTO = new WorkflowActionDTO
                                               {
                                                   WorkflowActionID = lastNotCompleted.StepID.Value,
                                                   Name = lastNotCompleted.StepName,
                                                   ActionName = lastNotCompleted.ActionAction,
                                                   AreaName = string.IsNullOrEmpty(lastNotCompleted.ActionArea) ? "" : lastNotCompleted.ActionArea,
                                                   ControllerName = lastNotCompleted.ActionController,
                                                   WorkflowInstanceExecutionStatusEventID = lastNotCompleted.WorkflowInstanceExecutionStatusEventID
                                               };

                    dto.InstanceDTO = new WorkflowInstanceDTO();
                    dto.InstanceDTO.WorkflowInstanceID = workflowInstanceID;
                }
            }

            return dto;
        }
    }
}
