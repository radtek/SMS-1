using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;
using Bec.TargetFramework.Workflow.Helpers;
using ServiceStack.Text;
using System.Transactions;
using Bec.TargetFramework.Entities.Injections;

namespace Bec.TargetFramework.Workflow.Providers
{
    using System.ComponentModel;

    //Bec.TargetFramework.Entities
    using Bec.TargetFramework.Entities;

    using ServiceStack.Messaging;
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    [Serializable]
    public class DbWorkflowInstanceProvider : ProviderBase
    {
        private IClassificationDataLogic m_ClassificationDataLogic;
        public DbWorkflowInstanceProvider(ILogger logger, IClassificationDataLogic logic)
            : base(logger)
        {
            m_ClassificationDataLogic = logic;
        }

        public WorkflowInstanceBase Load(Guid instanceID,WorkflowStateBaseDTO stateBase = null)
        {
            var instanceBase = new WorkflowInstanceBase();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing,Logger))
            {
                var instance = scope.DbContext.WorkflowInstances.Include("WorkflowInstanceRestrictions").Single(s => s.WorkflowInstanceID.Equals(instanceID));

                instanceBase.InjectFrom<NullableInjection>(instance);

                instanceBase.ID = instance.WorkflowInstanceID;
                
                scope.DbContext.WorkflowInstanceExecutions.Where(it => it.WorkflowInstanceID.Equals(instanceID)).OrderBy(it => it.WorkflowInstanceExecutionID).ToList().ForEach(item =>
                    {
                        WorkflowInstanceExecutionBase evb = new WorkflowInstanceExecutionBase();

                        evb.InjectFrom<NullableInjection>(item);
                        evb.WorkflowTransistionID = item.WorkflowTransistionID;

                        if (item.WorkflowActionID.HasValue)
                            evb.WorkflowComponentID = item.WorkflowActionID.Value;

                        if (item.WorkflowDecisionID.HasValue)
                            evb.WorkflowComponentID = item.WorkflowDecisionID.Value;

                        instanceBase.Executions.Add(evb);
                    });

                // load data state from last queued execution
                // only set last if loaded successfully
                if (instanceBase.Executions.Count > 0)
                {
                    var lastExecutionID = instanceBase.Executions.Last().WorkflowInstanceExecutionID;

                    var lastStatusEvent = scope.DbContext.WorkflowInstanceExecutionStatusEvents.Where(s => s.WorkflowInstanceExecutionID.Equals(lastExecutionID))
                    .OrderByDescending(s => s.WorkflowExecutionStatusID).First();

                    if(stateBase != null)
                        instanceBase.LastLoadedState = stateBase;
                    else
                        instanceBase.LastLoadedState = WorkflowDataHelper.DeserializeData(scope.DbContext.WorkflowInstanceExecutionDataItems.Single(s => s.WorkflowInstanceExecutionStatusEventID.Equals(lastStatusEvent.WorkflowInstanceExecutionStatusEventID)).DataContent);

                    instanceBase.CurrentExecution = instanceBase.Executions.Last();
                }



                // create session
                 instanceBase.InstanceSession = new WorkflowInstanceSessionBase();
                instanceBase.InstanceSession.SessionStartedOn = DateTime.Now;
                instanceBase.InstanceSession.WorkflowInstanceID = instanceBase.ID;
                instanceBase.InstanceSession.WorkflowInstanceSessionID = Guid.NewGuid();

                var session = new WorkflowInstanceSession
                    {
                        SessionStartedOn = instanceBase.InstanceSession.SessionStartedOn,
                        SessionEndedOn = DateTime.Now,
                        WorkflowInstanceID = instanceBase.InstanceSession.WorkflowInstanceID.Value,
                        WorkflowInstanceSessionID = instanceBase.InstanceSession.WorkflowInstanceSessionID,
                        WorkflowID = instanceBase.WorkflowID,
                        WorkflowVersionNumber = instanceBase.WorkflowVersionNumber
                    };

                    scope.DbContext.WorkflowInstanceSessions.Add(session);

                scope.Save();
            }

           

            return instanceBase;
        }

        public void Save(IWorkflowInstance instance)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var winstance = new WorkflowInstance
                {
                    ParentID = instance.ParentID,
                    WorkflowVersionNumber = instance.WorkflowVersionNumber,
                    WorkflowID = instance.WorkflowID,
                    WorkflowInstanceID = instance.ID,
                    WorkflowInstanceStatusID = instance.WorkflowInstanceStatusID
                };

                if(instance.TempData != null)
                    winstance.WorkflowInstanceTempData = WorkflowDataHelper.SerializeData(new WorkflowStateBaseDTO{WorkflowDictionaryDto = instance.TempData});

                scope.DbContext.WorkflowInstances.Add(winstance);
               
                // save session
                var session = new WorkflowInstanceSession
                {
                    SessionStartedOn = instance.InstanceSession.SessionStartedOn,
                    SessionEndedOn = DateTime.Now,
                    WorkflowInstanceID = instance.InstanceSession.WorkflowInstanceID.Value,
                    WorkflowInstanceSessionID = instance.InstanceSession.WorkflowInstanceSessionID,
                    WorkflowID = instance.WorkflowID,
                    WorkflowVersionNumber = instance.WorkflowVersionNumber
                };

                scope.DbContext.WorkflowInstanceSessions.Add(session);
               

                scope.Save();
            }
        }

        public void Update(IWorkflowInstance instance)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var winstance = scope.DbContext.WorkflowInstances.Single(s => s.WorkflowID.Equals(instance.WorkflowID)
                                                                              &&
                                                                              s.WorkflowVersionNumber.Equals(
                                                                                  instance.WorkflowVersionNumber)
                                                                              &&
                                                                              s.WorkflowInstanceID.Equals(instance.ID));

                winstance.ParentID = instance.ParentID;
                winstance.WorkflowInstanceStatusID = instance.WorkflowInstanceStatusID;

                var session = scope.DbContext.WorkflowInstanceSessions.Single(s => s.WorkflowID.Equals(instance.WorkflowID)
                                                                              &&
                                                                              s.WorkflowVersionNumber.Equals(
                                                                                  instance.WorkflowVersionNumber)
                                                                              &&
                                                                              s.WorkflowInstanceID.Equals(instance.ID)
                                                                              && s.WorkflowInstanceSessionID.Equals(instance.InstanceSession.WorkflowInstanceSessionID));
                // save session
                session.SessionStartedOn = instance.InstanceSession.SessionStartedOn;
                session.SessionEndedOn = DateTime.Now;

                scope.Save();
            }
        }
        public void Create()
        {

        }

        public void UpdateExecutionWithEvent(IWorkflowProcessHandler handler, WorkflowInstanceBase instanceBase, WorkflowExecutionStatusEnum status,WorkflowStateBaseDTO currentStateDto, IWorkflowCommand command = null, IWorkflowCondition condition = null)
        {
            var component = handler.CurrentComponent;
            var workflowInstanceExecution = new WorkflowInstanceExecution();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var count = scope.DbContext.WorkflowInstanceExecutionStatusEvents.Count(s => s.WorkflowInstanceExecutionID.Equals(instanceBase.CurrentExecution.WorkflowInstanceExecutionID));

                // check whether item already exists if so update that otherwise create another
                bool exists = false;

                exists = scope.DbContext.WorkflowInstanceExecutionStatusEvents.Any(s =>
                    s.WorkflowID == instanceBase.WorkflowID
                    && s.WorkflowVersionNumber == instanceBase.WorkflowVersionNumber
                    && s.WorkflowInstanceID == instanceBase.ID
                    && s.WorkflowInstanceExecutionID == instanceBase.CurrentExecution.WorkflowInstanceExecutionID
                    && s.WorkflowInstanceSessionID == instanceBase.InstanceSession.WorkflowInstanceSessionID
                    && s.WorkflowExecutionStatusID == (int) status);

                if (!exists)
                {
                    // add statusEvent
                    var statusEvent = new WorkflowInstanceExecutionStatusEvent
                    {
                        EventBy = "boo",
                        EventDate = DateTime.Now,
                        EventOrder = count,
                        WorkflowExecutionStatusID = (int)status,
                        WorkflowInstanceExecutionID = instanceBase.CurrentExecution.WorkflowInstanceExecutionID,
                        WorkflowInstanceSessionID = instanceBase.InstanceSession.WorkflowInstanceSessionID,
                        WorkflowID = instanceBase.WorkflowID,
                        WorkflowVersionNumber = instanceBase.WorkflowVersionNumber,
                        WorkflowInstanceID = instanceBase.ID
                    };

                    scope.DbContext.WorkflowInstanceExecutionStatusEvents.Add(statusEvent);

                    // create dataItem
                    var dataItem = new WorkflowInstanceExecutionDataItem
                    {
                        WorkflowInstanceExecutionStatusEventID = statusEvent.WorkflowInstanceExecutionStatusEventID,
                        DataNotJsonSerialized = false,
                        FieldName = "boo",
                        WorkflowInstanceExecutionID = workflowInstanceExecution.WorkflowInstanceExecutionID,
                        DataContent = WorkflowDataHelper.SerializeData(currentStateDto)
                    };

                    scope.DbContext.WorkflowInstanceExecutionDataItems.Add(dataItem);

                    scope.Save();
                }
            }

        }

        public void CreateExecutionWithTrace(IWorkflowProcessHandler handler, WorkflowInstanceBase instanceBase, string methodName, IWorkflowComponent wfComponent, bool hasError = false, int numberOfRetries = 1, IWorkflowCommand command = null, IWorkflowCondition condition = null)
        {
            var component = handler.CurrentComponent;
            var workflowInstanceExecution = new WorkflowInstanceExecution();
        
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                // add statusEvent
                var trace = new WorkflowInstanceExecutionTrace
                {
                    WorkflowInstanceExecutionTraceID = Guid.NewGuid(),
                    ExecutedOn = DateTime.Now,
                    ExecutedBy = Environment.UserName,
                    WorkflowInstanceExecutionID = instanceBase.CurrentExecution.WorkflowInstanceExecutionID,
                    WorkflowInstanceSessionID = instanceBase.InstanceSession.WorkflowInstanceSessionID,
                    WorkflowID = instanceBase.WorkflowID,
                    WorkflowVersionNumber = instanceBase.WorkflowVersionNumber,
                    WorkflowInstanceID = instanceBase.ID,
                    HasError = wfComponent.HasErrors,
                    NumberOfRetries = numberOfRetries,
                    
                };

                if (!string.IsNullOrEmpty(methodName)) trace.TraceDetail = methodName;

                if (handler.CurrentComponent is IWorkflowAction) trace.WorkflowActionID = handler.CurrentComponent.ID;
                if (handler.CurrentComponent is IWorkflowDecision) trace.WorkflowDecisionID = handler.CurrentComponent.ID;

                if (wfComponent.HasErrors)
                {
                    StringBuilder errorString = new StringBuilder();

                    if (wfComponent.Errors.First().WorkflowException.InnerException != null)
                    {
                        errorString.AppendLine(wfComponent.Errors.First().WorkflowException.InnerException.Message);
                        errorString.AppendLine(wfComponent.Errors.First().WorkflowException.InnerException.StackTrace);
                    }
                    errorString.AppendLine(wfComponent.Errors.First().WorkflowException.Message);
                    errorString.AppendLine(wfComponent.Errors.First().WorkflowException.StackTrace);
                }
                   

                if (command != null) trace.WorkflowCommandID = command.ID;
                if (condition != null) trace.WorkflowConditionID = condition.ID;

                scope.DbContext.WorkflowInstanceExecutionTraces.Add(trace);

                scope.Save();
            }

        }

        public WorkflowInstanceExecutionBase CreateNewExecutionWithEvent(IWorkflowProcessHandler handler, WorkflowInstanceBase instanceBase, WorkflowExecutionStatusEnum status,WorkflowStateBaseDTO currentStateDto, IWorkflowCommand command = null, IWorkflowCondition condition = null)
        {
            var component = handler.CurrentComponent;
            var workflowInstanceExecution = new WorkflowInstanceExecution();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                workflowInstanceExecution.WorkflowID = instanceBase.WorkflowID;
                workflowInstanceExecution.WorkflowVersionNumber = instanceBase.WorkflowVersionNumber;
                workflowInstanceExecution.WorkflowInstanceID = instanceBase.ID;
                workflowInstanceExecution.WorkflowTransistionID = handler.CurrentTransistion.ID;
                workflowInstanceExecution.WorkflowInstanceSessionID = instanceBase.InstanceSession.WorkflowInstanceSessionID;

                if(component is IWorkflowAction)
                {
                    var action = component as IWorkflowAction;

                    workflowInstanceExecution.WorkflowActionID = action.ID;
                }
                else if(component is IWorkflowDecision)
                {
                    var decision = component as IWorkflowDecision;

                    workflowInstanceExecution.WorkflowDecisionID = decision.ID;
                }

                if(command != null)
                    workflowInstanceExecution.WorkflowCommandID = command.ID;

                if(condition != null)
                    workflowInstanceExecution.WorkflowConditionID = condition.ID;

                scope.DbContext.WorkflowInstanceExecutions.Add(workflowInstanceExecution);

                // add statusEvent
                var statusEvent = new WorkflowInstanceExecutionStatusEvent
                {
                    EventBy = "boo",
                    EventDate = DateTime.Now,
                    EventOrder = 0,
                    WorkflowExecutionStatusID = (int) WorkflowExecutionStatusEnum.Initialized,
                    WorkflowInstanceExecutionID = workflowInstanceExecution.WorkflowInstanceExecutionID,
                    WorkflowInstanceSessionID = instanceBase.InstanceSession.WorkflowInstanceSessionID,
                    WorkflowID = instanceBase.WorkflowID,
                    WorkflowVersionNumber = instanceBase.WorkflowVersionNumber,
                    WorkflowInstanceID = instanceBase.ID
                };

                scope.DbContext.WorkflowInstanceExecutionStatusEvents.Add(statusEvent);

                // create dataItem
                var dataItem = new WorkflowInstanceExecutionDataItem
                {
                    WorkflowInstanceExecutionStatusEventID = statusEvent.WorkflowInstanceExecutionStatusEventID,
                    FieldName = "Boo",
                    DataNotJsonSerialized = false,
                    WorkflowInstanceExecutionID = workflowInstanceExecution.WorkflowInstanceExecutionID,
                    DataContent = WorkflowDataHelper.SerializeData(currentStateDto)
                };

                scope.DbContext.WorkflowInstanceExecutionDataItems.Add(dataItem);

                scope.Save();
            }


            var executionBase = new WorkflowInstanceExecutionBase
            {
                WorkflowInstanceExecutionID = workflowInstanceExecution.WorkflowInstanceExecutionID,
                WorkflowState = currentStateDto
            };

            return executionBase;

        }

        public void SaveExecutionStatusEvent()
        { }
    }
}
