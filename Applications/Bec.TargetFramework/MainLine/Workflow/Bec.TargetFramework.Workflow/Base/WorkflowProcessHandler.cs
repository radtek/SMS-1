using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities.Workflow;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Workflow.Helpers;
using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure.Extensions;
namespace Bec.TargetFramework.Workflow.Base
{
    using System.ComponentModel.Design;

    using Fabrik.Common;
    using Bec.TargetFramework.Entities;
    using Bec.TargetFramework.Entities.Enums;

    public class WorkflowProcessHandler : IWorkflowProcessHandler
    {
        private IWorkflowContainer m_Container;
        private IWorkflowTransistion m_CurrentTransistion;

        public IWorkflowTransistion CurrentTransistion
        {
            get { return m_CurrentTransistion; }
            set { m_CurrentTransistion = value; }
        }
        private IWorkflowHierarchyComponent m_StartHierarchyComponent;
        private IWorkflowMainComponent m_CurrentWorkflowComponent;

        public WorkflowInstanceCurrentStateDTO CurrentState { get; set; }

        public IWorkflowMainComponent CurrentComponent
        {
            get { return m_CurrentWorkflowComponent; }
            set { m_CurrentWorkflowComponent = value; }
        }
        private IWorkflowHierarchyComponent m_CurrentWorkflowHierarchyComponent;
        private WorkflowHandlerState m_ProcessState;

        private List<IWorkflowMainComponent> m_CurrentTransistionQueue;

        public List<IWorkflowMainComponent> CurrentQueue
        {
            get { return m_CurrentTransistionQueue; }
            set { m_CurrentTransistionQueue = value; }
        }

        public WorkflowProcessHandler(IWorkflowContainer container)
        {
            m_Container = container;
            m_CurrentTransistionQueue = new List<IWorkflowMainComponent>();
        }

        public void SetCurrentTransistion(Guid transistionID)
        {
            m_CurrentTransistion = m_Container.Transistions.Single(tr => tr.ID.Equals(transistionID));
        }

        public bool HasTransistionWorkflowCompleted()
        {
            return m_Container.WorkflowInstance.Executions.Any(it => m_CurrentTransistion.TransistionHierarchy.Single(tc => tc.ChildComponent.ID.Equals(it.WorkflowComponentID)).IsEnd);
        }

        public void RestartWorkflow()
        {
            m_Container.LogTrace("Workflow Process Handler: Initialise Workflow Restart Instance ID:" + m_Container.WorkflowInstance.ID + " data:" + m_Container.WorkflowInstance.LastLoadedState);

            m_CurrentTransistion = m_Container.Transistions.First();

            var data = m_Container.WorkflowInstance.LastLoadedState;

            m_CurrentTransistionQueue.Clear();
            m_Container.Data = data.WorkflowDictionaryDto.WorkflowDictionary;

            // rebuild queue
            data.Queue.ForEach(item =>
                {
                    var component = m_CurrentTransistion.TransistionComponents.Single(tc => tc.ID.Equals(item.Key));

                    // validate previous componentID
                    var previousComponentList = m_CurrentTransistion.TransistionHierarchy.Where(
                       it => it.ParentComponent != null && it.ChildComponent.ID.Equals(item.Key) && it.ParentComponent.ID.Equals(item.Value));

                    if (previousComponentList.Count() > 0 && previousComponentList.First().Equals(item.Value))
                    {
                        component.PreviousComponentID = item.Value;
                    }
                        else
                        {
                            // TBF Sometime
                            // check previous without using compobnentID and take first one
                            previousComponentList = m_CurrentTransistion.TransistionHierarchy.Where(
                                    it => it.ParentComponent != null && it.ChildComponent.ID.Equals(component.ID));

                            if (previousComponentList.Count() > 0)
                                component.PreviousComponentID = previousComponentList.First().ParentComponent.ID;
                            else
                                throw new ArgumentException("Workflow Item has no previous component");
                        }
                    m_CurrentTransistionQueue.Add(component);
                });

            if(data.PreviousCurrentWorkflowComponentID.HasValue)
                m_StartHierarchyComponent = m_CurrentTransistion.TransistionHierarchy.Single(th => th.ParentComponent != null && th.ChildComponent.ID.Equals(data.CurrentWorkflowComponentID) && th.ParentComponent.ID.Equals(data.PreviousCurrentWorkflowComponentID.Value));
            else
                m_StartHierarchyComponent = m_CurrentTransistion.TransistionHierarchy.Single(th => th.ChildComponent.ID.Equals(data.CurrentWorkflowComponentID) && th.ParentComponent == null);

            m_CurrentWorkflowHierarchyComponent = m_StartHierarchyComponent;

            // set start component
            m_CurrentWorkflowComponent = m_StartHierarchyComponent.ChildComponent;

            m_Container.LogTrace("Workflow Process Handler: Set First Workflow Component to Process :" + m_CurrentWorkflowComponent.ID + " name:" + m_CurrentWorkflowComponent.Name);

            m_CurrentWorkflowComponent.PreviousComponentID = data.PreviousCurrentWorkflowComponentID;
            m_CurrentWorkflowComponent.Data = m_Container.Data;

            PopulateCurrentState(Helpers.WorkflowExecutionStatusEnum.Initialized, m_CurrentWorkflowComponent);
            m_Container.WorkflowInstance.CreateNewExecutionWithEvent(Helpers.WorkflowExecutionStatusEnum.Initialized, this.CurrentState.WorkflowState);
            
            ProcessCurrentWorkflowComponent();
        }

        public void StartWorkflow()
        {
            if (m_CurrentTransistion == null)
                m_CurrentTransistion =
                    m_Container.TransistionHierarchy.Hierarchy.Single(
                        s => s.IsWorkflowStart && s.ParentComponent == null).ChildComponent;

 
            m_StartHierarchyComponent = m_CurrentTransistion.TransistionHierarchy.Single(it => it.IsStart && it.ParentComponent == null);

            m_CurrentWorkflowHierarchyComponent = m_StartHierarchyComponent;

            // set start component
            m_CurrentWorkflowComponent = m_StartHierarchyComponent.ChildComponent;
            m_CurrentWorkflowComponent.Data = m_Container.Data;

            PopulateCurrentState(Helpers.WorkflowExecutionStatusEnum.Initialized, m_CurrentWorkflowComponent);

            m_Container.WorkflowInstance.CreateNewExecutionWithEvent(Helpers.WorkflowExecutionStatusEnum.Initialized,this.CurrentState.WorkflowState);
            
            if (m_Container.WorkflowSettings.EnableWorkflowTrace)
                m_Container.Logger.Trace("Workflow Process Handler: Start Workflow Workflow ID:" + m_Container.WorkflowInstance.WorkflowID + " InstanceID:" + m_Container.WorkflowInstance.ID + " first component:" + m_CurrentWorkflowComponent.ID + " name:" + m_CurrentWorkflowComponent.Name);
            m_Container.UpdateInstance(m_Container.WorkflowInstance);  //changing the instance status to inprogress

            m_ProcessState = WorkflowHandlerState.IsActive;

            ProcessCurrentWorkflowComponent();
        }

        private void MoveToNextWorkflowComponent(List<IWorkflowHierarchyComponent> childComponents)
        {
            if(childComponents.Count > 0)
            {
                var hierarchyComponent = childComponents.First();

                var parentID =  m_CurrentWorkflowComponent.ID;

                // remove component and queue others
                childComponents.RemoveAt(0);

                childComponents.ToList().ForEach(cc => 
                    {
                        cc.ChildComponent.PreviousComponentID = parentID;

                        m_CurrentTransistionQueue.Add(cc.ChildComponent);
                    });
                SetNextWorkflowComponent(hierarchyComponent,parentID,true);
            }
        }

        private void SetNextWorkflowComponent(IWorkflowHierarchyComponent component,Guid parentID, bool movedNext)
        {
            m_CurrentWorkflowHierarchyComponent = component;
            m_CurrentWorkflowComponent = m_CurrentWorkflowHierarchyComponent.ChildComponent;
            m_CurrentWorkflowComponent.IsFailure = m_CurrentWorkflowHierarchyComponent.IsFailure;
            m_CurrentWorkflowComponent.PreviousComponentID = parentID;

            m_Container.LogTrace("Workflow Process Handler: SetNextWorkflowComponent ID:" + m_CurrentWorkflowComponent.ID + " name:" + m_CurrentWorkflowComponent.Name + " previous:" + m_CurrentWorkflowComponent.PreviousComponentID.GetValueOrDefault(Guid.Empty));

            if (movedNext)
            {
                PopulateCurrentState(WorkflowExecutionStatusEnum.Initialized, m_CurrentWorkflowComponent);
                m_Container.WorkflowInstance.CreateNewExecutionWithEvent(WorkflowExecutionStatusEnum.Initialized,this.CurrentState.WorkflowState);
            }
               
            else
            {
                PopulateCurrentState(WorkflowExecutionStatusEnum.Dequeued, m_CurrentWorkflowComponent);
                m_Container.WorkflowInstance.CreateNewExecutionWithEvent(WorkflowExecutionStatusEnum.Dequeued, this.CurrentState.WorkflowState);
            }

            if(m_ProcessState == WorkflowHandlerState.IsActive)
            {
                ProcessCurrentWorkflowComponent();
            }
        }

        private void TransistionHasFinished()
        {
            m_Container.LogTrace("Workflow Process Handler: Workflow Transition has finished InstanceID:" + m_Container.WorkflowInstance.ID + " last item:" + m_CurrentWorkflowComponent.ID + " name:" + m_CurrentWorkflowComponent.Name);

            Console.ReadLine();
        }

        private void TransistionIsPending()
        {
            m_Container.LogTrace("Workflow Process Handler: Workflow Transition set to Pending InstanceID:" + m_Container.WorkflowInstance.ID + " last item:" + m_CurrentWorkflowComponent.ID + " name:" + m_CurrentWorkflowComponent.Name);

            Console.ReadLine();
        }

        private List<IWorkflowHierarchyComponent> GetCurrentWorkflowComponentChildren()
        {
            return m_CurrentTransistion.TransistionHierarchy.Where(
                        it => it.ParentComponent != null && it.ParentComponent.ID.Equals(m_CurrentWorkflowComponent.ID)).ToList();
        }

        private List<IWorkflowHierarchyComponent> GetCurrentWorkflowComponentChildrenForDecisionResult(List<IWorkflowMainComponent> components,bool failure)
        {
            var list =  m_CurrentTransistion.TransistionHierarchy.Where(
                        it => it.ParentComponent != null && it.ParentComponent.ID.Equals(m_CurrentWorkflowComponent.ID) && components.Any(cc => cc.ID.Equals(it.ChildComponent.ID))).ToList();

            list.ForEach(item => item.IsFailure = failure);

            return list;
        }

        private List<IWorkflowHierarchyComponent> GetCurrentWorkflowComponentParentsForDecisionResult(List<IWorkflowMainComponent> components, bool failure)
        {
            var parentsList = m_CurrentTransistion.TransistionHierarchy.Where(
                        it => it.ChildComponent.ID.Equals(m_CurrentWorkflowComponent.ID)).Select(p => p.ParentComponent.ID).ToList();

            var components1 = m_CurrentTransistion.TransistionHierarchy.Where(
                        it => parentsList.Any(pl => pl.Equals(it.ChildComponent.ID)) && components.Any(cc => cc.ID.Equals(it.ChildComponent.ID))).ToList();

            // if not a parent could be a child on a failure path
            if (!components1.Any())
            {
                var foo = m_CurrentTransistion.TransistionHierarchy.Where(p => p.ParentComponent != null && components.Any(cc => cc.ID.Equals(p.ChildComponent.ID)) && p.ParentComponent.ID.Equals(m_CurrentWorkflowComponent.ID)).ToList();

                foo.ForEach(item => item.IsFailure = failure);

                return foo;
            }
            else
            {
                components1.ForEach(item => item.IsFailure = failure);

                return components1;
            }
        }

        private IWorkflowHierarchyComponent GetHierarchyComponentForWorkflowComponent(IWorkflowMainComponent component)
        {
            var previousComponentList = m_CurrentTransistion.TransistionHierarchy.Where(
                        it => it.ParentComponent != null && it.ChildComponent.ID.Equals(component.ID) && it.ParentComponent.ID.Equals(component.PreviousComponentID));

            if (previousComponentList.Count() > 0)
                return previousComponentList.First();
            else
            {
                // TBF Sometime
                // check previous without using compobnentID and take first one
                previousComponentList = m_CurrentTransistion.TransistionHierarchy.Where(
                        it => it.ParentComponent != null && it.ChildComponent.ID.Equals(component.ID));

                if (previousComponentList.Count() > 0)
                    return previousComponentList.First();
                else
                    return null;
            }
        }

        private void PopulateStateAndUpdateExecutionWithEvent(WorkflowExecutionStatusEnum enumValue,
            IWorkflowMainComponent component)
        {
            // populatestate
            PopulateCurrentState(enumValue ,component);

            // update current execution with event
            m_Container.WorkflowInstance.UpdateExecutionWithEvent(enumValue,this.CurrentState.WorkflowState);
        }

        private void ProcessCurrentWorkflowComponent()
        {
            m_Container.LogTrace("Workflow Process Handler: Process Current Workflow Component InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + m_CurrentWorkflowComponent.ID + " name:" + m_CurrentWorkflowComponent.Name);

            // check whether we need to pause current component ... e.g. reliant on another and move to next
            if (DoWeNeedToPauseCurrentComponent())
            {
                m_Container.LogTrace("Workflow Process Handler: Queue Current Component InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + m_CurrentWorkflowComponent.ID + " name:" + m_CurrentWorkflowComponent.Name);

                // pause so queue current //  check if not in queue
                if (!m_CurrentTransistionQueue.Any(it => it.ID.Equals(m_CurrentWorkflowComponent.ID)))
                { 
                    if(!m_CurrentTransistionQueue.Any(wc => wc.ID.Equals(m_CurrentWorkflowComponent.ID)))
                    {
                        PopulateStateAndUpdateExecutionWithEvent(WorkflowExecutionStatusEnum.WaitingForComponents, m_CurrentWorkflowComponent);
                        PopulateStateAndUpdateExecutionWithEvent(WorkflowExecutionStatusEnum.Queued, m_CurrentWorkflowComponent);
                        PopulateCurrentState(WorkflowExecutionStatusEnum.Queued, m_CurrentWorkflowComponent);
                        m_CurrentTransistionQueue.Add(m_CurrentWorkflowComponent);
                    }

                    if (m_CurrentTransistionQueue.Count > 0 && m_CurrentTransistionQueue.Any(fr => !fr.IsWaitingForComponents))
                    {
                        // take first none paused item from queue
                        var component = m_CurrentTransistionQueue.First(fr => !fr.IsWaitingForComponents);

                        m_CurrentTransistionQueue.RemoveAt(0);

    
                        SetNextWorkflowComponent(GetHierarchyComponentForWorkflowComponent(component),m_CurrentWorkflowComponent.ID,false);
                    }
                }
                // check for another item on queue that is not the paused one
                else if(m_CurrentTransistionQueue.Any(it => !it.ID.Equals(m_CurrentWorkflowComponent.ID)))
                {
                    // current item is paused so find alternative item on queue and execute
                    var component = m_CurrentTransistionQueue.First(fr => !fr.IsWaitingForComponents);

                    m_CurrentTransistionQueue.RemoveAt(0);

                    SetNextWorkflowComponent(GetHierarchyComponentForWorkflowComponent(component), m_CurrentWorkflowComponent.ID, false);
                }
                else
                {

                }
            }
            else
            {
                // process current
                if(m_CurrentWorkflowComponent is IWorkflowAction)
                {
                    m_Container.LogTrace("Workflow Process Handler: Process Action InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + m_CurrentWorkflowComponent.ID + " name:" + m_CurrentWorkflowComponent.Name);

                    // if current component exists on queue and is paused then remove from queue
                    if (m_CurrentTransistionQueue.Any(wc => wc.IsWaitingForComponents && wc.ID.Equals(m_CurrentWorkflowComponent.ID)))
                        m_CurrentTransistionQueue.Remove(m_CurrentTransistionQueue.First(wc => wc.IsWaitingForComponents && wc.ID.Equals(m_CurrentWorkflowComponent.ID)));

                    // execute action
                    if(!m_CurrentWorkflowComponent.IsWaitingForInput && !m_CurrentWorkflowComponent.HasErrors && ProcessAction())
                    {
                        if (m_CurrentWorkflowHierarchyComponent.IsEnd)
                        {
                            m_ProcessState = WorkflowHandlerState.IsFinished;
                            m_Container.WorkflowInstance.WorkflowInstanceStatusID = WorkflowInstanceStatusIDEnum.Complete.GetIntValue();
                            m_Container.LogTrace("Workflow Process Handler: Complete Workflow Workflow ID:" + m_Container.WorkflowInstance.ID + " InstanceID:" + m_Container.WorkflowInstance.ID + " last component:" + m_CurrentWorkflowComponent.ID + " name:" + m_CurrentWorkflowComponent.Name);
                        }
                        else
                        {
                            m_Container.LogTrace("Workflow Process Handler: Move to next Workflow Component InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + m_CurrentWorkflowComponent.ID + " name:" + m_CurrentWorkflowComponent.Name);


                            MoveToNextWorkflowComponent(GetCurrentWorkflowComponentChildren());
                        }                    
                    }
                    else
                    {
                        PopulateStateAndUpdateExecutionWithEvent(WorkflowExecutionStatusEnum.Queued,
                            m_CurrentWorkflowComponent);

                        m_CurrentTransistionQueue.Add(m_CurrentWorkflowComponent);

                        var components = m_CurrentTransistionQueue.Where(fr => !fr.IsWaitingForComponents && !fr.IsWaitingForInput && !fr.HasErrors);

                        if(components.Count() > 0)
                        { 
                            // get next item2
                            var component = components.First();

                            m_CurrentTransistionQueue.RemoveAt(0);

                            m_Container.LogTrace("Workflow Process Handler: Move to next component as previous is pending InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + component.ID + " name:" + component.Name);


                            SetNextWorkflowComponent(GetHierarchyComponentForWorkflowComponent(component), m_CurrentWorkflowComponent.ID, false);
                        }
                        else
                            m_ProcessState =  WorkflowHandlerState.IsPending;
                    }
                }
                else if(m_CurrentWorkflowComponent is IWorkflowDecision)
                {
                    ProcessDecision();
                }

            }
                       
        }

        #region functions

        private void LogComponentError(IWorkflowMainComponent comp,string methodName)
        {
            m_Container.LogTrace("Workflow Process Handler: Log Errors InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + comp.ID + " name:" + comp.Name);


            if (comp is IWorkflowAction)
            {
                var action = comp as IWorkflowAction;

                PopulateStateAndUpdateExecutionWithEvent(WorkflowExecutionStatusEnum.Faulting,
                           action);
                
            }
            else if (comp is IWorkflowDecision)
            {

                var action = comp as IWorkflowDecision;

                PopulateStateAndUpdateExecutionWithEvent(WorkflowExecutionStatusEnum.Faulting,
                           action); 
            }

            m_Container.WorkflowInstance.CreateExecutionWithExecutionTrace(this.CurrentComponent, null, null, methodName, 1,this.CurrentState.WorkflowState);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// if error occurs then we close the workflow until the next round

        private bool ProcessAction()
        {
            Ensure.Argument.NotNull(m_CurrentWorkflowComponent);
            
            var action = m_CurrentWorkflowComponent as IWorkflowAction;

            int numberOfRetries = action.NumberOfRetries.GetValueOrDefault(1);

            int currentExecution = 0;

            bool success = false;

            while (currentExecution < numberOfRetries)
            {
                m_Container.LogTrace("Workflow Process Handler: Process Action InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + action.ID + " name:" + action.Name + " execution cycle:" + (currentExecution) + " maxNumberOfRetries:" + numberOfRetries);

                PopulateStateAndUpdateExecutionWithEvent(WorkflowExecutionStatusEnum.Executing,
                           action); 

                action.Initialise(m_Container, m_Container.Data);

                if (action.CanStart())
                {
                    m_Container.LogTrace("Workflow Process Handler: Process Action Can Start InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + action.ID + " name:" + action.Name);
                    m_Container.WorkflowInstance.CreateExecutionWithExecutionTrace(this.CurrentComponent, null, null, "CanStart", 1,this.CurrentState.WorkflowState);

                    if (action.PerformPreCommands())
                    {
                        m_Container.LogTrace("Workflow Process Handler: Process Action Pre Commands Completed InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + action.ID + " name:" + action.Name);
                        m_Container.WorkflowInstance.CreateExecutionWithExecutionTrace(this.CurrentComponent, null, null, "PerformPreCommands", 1, this.CurrentState.WorkflowState);

                        if (action.PerformExecuteCommands())
                        {
                            m_Container.LogTrace("Workflow Process Handler: Process Action Execute Commands Completed InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + action.ID + " name:" + action.Name);

                            m_Container.WorkflowInstance.CreateExecutionWithExecutionTrace(this.CurrentComponent, null, null, "PerformExecuteCommands", 1, this.CurrentState.WorkflowState);

                            if (action.PerformPostCommands())
                            {
                                m_Container.LogTrace("Workflow Process Handler: Process Action Post Commands Completed InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + action.ID + " name:" + action.Name);
                                m_Container.WorkflowInstance.CreateExecutionWithExecutionTrace(this.CurrentComponent, null, null, "PerformPostCommands", 1, this.CurrentState.WorkflowState);

                                PopulateStateAndUpdateExecutionWithEvent(WorkflowExecutionStatusEnum.Closed,
                           action); 
                            }
                            else if (action.HasErrors)
                                LogComponentError(action, "PerformPostCommands");
                            else
                            {
                                action.IsWaitingForInput = true;

                                PopulateStateAndUpdateExecutionWithEvent(WorkflowExecutionStatusEnum.WaitingForInput,
                           action); 
                            }
                        }
                        else if (action.HasErrors)
                            LogComponentError(action, "PerformExecuteCommands");
                        else
                        {
                            action.IsWaitingForInput = true;
                            PopulateStateAndUpdateExecutionWithEvent(WorkflowExecutionStatusEnum.WaitingForInput,
                          action); 
                        }
                    }
                    else if (action.HasErrors)
                        LogComponentError(action, "PerformPreCommands");
                    else
                    {
                        action.IsWaitingForInput = true;
                        PopulateStateAndUpdateExecutionWithEvent(WorkflowExecutionStatusEnum.WaitingForInput,
                          action); 
                    }
                }
                else if (action.HasErrors) LogComponentError(action, "CanStart");
                else
                {
                    action.IsWaitingForInput = true;
                    PopulateStateAndUpdateExecutionWithEvent(WorkflowExecutionStatusEnum.WaitingForInput,
                           action); 
                }

                // update data
                m_Container.Data = action.Data;

                success =  (!action.IsWaitingForInput && !action.HasErrors);

                if (success) break;
                else
                    currentExecution++;
            }

            return success;
        }


        /// <summary>
        /// If a decision fails because of an exception return to sender
        /// </summary>
        private void ProcessDecision()
        {
            Ensure.Argument.NotNull(m_CurrentWorkflowComponent);

            var decision = m_CurrentWorkflowComponent as IWorkflowDecision;

            m_Container.LogTrace("Workflow Process Handler: Process Decision InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + decision.ID + " name:" + decision.Name);


            decision.Initialise(m_Container, m_Container.Data);

            PopulateStateAndUpdateExecutionWithEvent(WorkflowExecutionStatusEnum.Executing,
                          decision); 

            List<IWorkflowComponent> decisionResults = new List<IWorkflowComponent>();

            //// get decision results e.g. pass failure
            if (decision.PerformPreCommands())
            {
                m_Container.LogTrace("Workflow Process Handler: Process Decision Pre Commands Completed InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + decision.ID + " name:" + decision.Name);


                m_Container.WorkflowInstance.CreateExecutionWithExecutionTrace(this.CurrentComponent, null, null, "PerformPreCommands", 1,this.CurrentState.WorkflowState);

                decisionResults = decision.MakeDecision();

                if (decision.HasErrors) this.LogComponentError(decision, "MakeDecision");
                else
                {
                    m_Container.LogTrace("Workflow Process Handler: Process Decision Execute Commands Completed InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + decision.ID + " name:" + decision.Name);
                    m_Container.WorkflowInstance.CreateExecutionWithExecutionTrace(this.CurrentComponent, null, null, "MakeDecision", 1,this.CurrentState.WorkflowState);
                }



                if (!decision.PerformPostCommands()) this.LogComponentError(decision, "PerformPostCommands");
                else
                {
                    m_Container.LogTrace("Workflow Process Handler: Process Decision Post Commands Completed InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + decision.ID + " name:" + decision.Name);
                    m_Container.WorkflowInstance.CreateExecutionWithExecutionTrace(this.CurrentComponent, null, null, "PerformPostCommands", 1, this.CurrentState.WorkflowState);
                }
                   
            }
            else if(decision.HasErrors)
                LogComponentError(decision, "PerformPreCommands");

            if (!decision.HasErrors)
            {
                m_Container.LogTrace("Workflow Process Handler: Process Decision Complete InstanceID:" + m_Container.WorkflowInstance.ID + " item:" + decision.ID + " name:" + decision.Name);


                PopulateStateAndUpdateExecutionWithEvent(WorkflowExecutionStatusEnum.Closed,
                              decision); 

            }

            m_Container.Data = decision.Data;

            if(decision.HasErrors && decision.ErrorComponents != null && decision.ErrorComponents.Count > 0)
                MoveToNextWorkflowComponent(GetCurrentWorkflowComponentChildrenForDecisionResult(decisionResults.Select(s => s as IWorkflowMainComponent).ToList(), true));
            else if (decision.IsSuccess && !decision.HasErrors)
                // add decision results to queue and move forward
                MoveToNextWorkflowComponent(GetCurrentWorkflowComponentChildrenForDecisionResult(decisionResults.Select(s => s as IWorkflowMainComponent).ToList(), false));
            else
               // add decision reslts and move backwards
                MoveToNextWorkflowComponent(GetCurrentWorkflowComponentParentsForDecisionResult(decisionResults.Select(s => s as IWorkflowMainComponent).ToList(), true));
            //}
        }



        private bool DoWeNeedToPauseCurrentComponent()
        {
            List<IWorkflowMainComponent> components = new List<IWorkflowMainComponent>();

            // related decisions and related actions
            var parentList = m_CurrentTransistion.TransistionHierarchy.Where(th => th.ParentComponent != null && th.ChildComponent.ID.Equals(m_CurrentWorkflowComponent.ID)).Select(s => s.ParentComponent.ID);

            // determine path (failure or success
            // find last decision and check for decision making

            // add all parents to list
            m_CurrentTransistion.TransistionComponents.Where(tc => parentList.Any(c => c.Equals(tc.ID))).ToList().ForEach(item => components.Add(item));

            m_CurrentTransistion.TransistionComponents.OfType<IWorkflowDecision>().ToList().ForEach(it =>
            {
                if (it.SuccessComponents.Any(sc => sc.ID.Equals(m_CurrentWorkflowComponent.ID)) || it.FailureComponents.Any(sc => sc.ID.Equals(m_CurrentWorkflowComponent.ID)))
                {
                    // filter out items component is parent of
                    if (!m_CurrentTransistion.TransistionHierarchy.Any(hc => hc.ChildComponent.ID.Equals(it.ID)
                        && hc.ParentComponent.ID.Equals(m_CurrentWorkflowComponent.ID)))
                        components.Add(it);
                }
            });

            // check for previous actions that are needed ti cimplete this action
            m_CurrentTransistion.TransistionHierarchy.ToList().ForEach(it =>
            {
                if (it.ParentComponent != null && it.ChildComponent != null && it.ChildComponent.ID.Equals(m_CurrentWorkflowComponent.ID) && it.IsChildDependentOnParent)
                    components.Add(it.ParentComponent);
            });

            // now check whether all these items have executed
            bool doWeWait = false;

            components.ForEach(it =>
            {
                if (!m_Container.WorkflowInstance.Executions.Any(si => si.WorkflowComponentID.Equals(it.ID)))
                    {
                        // add waiting items to component
                        if(m_CurrentWorkflowComponent.WaitingForComponents == null)
                            m_CurrentWorkflowComponent.WaitingForComponents = new List<IWorkflowComponent>();

                        if (!m_CurrentWorkflowComponent.WaitingForComponents.Any(wfc => wfc.ID.Equals(it.ID)))
                        {
                            if(m_CurrentTransistion.TransistionHierarchy.ToList().Any(th => th.IsChildDependentOnParent
                                && th.ChildComponent.ID.Equals(m_CurrentWorkflowComponent.ID) && th.ParentComponent.ID.Equals(it.ID)))
                            {
                                m_CurrentWorkflowComponent.WaitingForComponents.Add(it);

                                if (!doWeWait)
                                    doWeWait = true;
                            }
                        }
                    }
            });

            if(doWeWait)
            {
                m_Container.LogTrace("Workflow Process Handler: Pause Workflow Component :" + m_CurrentWorkflowComponent.ID + " name:" + m_CurrentWorkflowComponent.Name);


                m_CurrentWorkflowComponent.IsWaitingForComponents = true;
            }

            return doWeWait;
        }

        #endregion

        
        private void PopulateCurrentState(WorkflowExecutionStatusEnum status,IWorkflowMainComponent actionDecision)
        {
            CurrentState = new WorkflowInstanceCurrentStateDTO();

            // instance
            CurrentState.InstanceDTO = new WorkflowInstanceDTO();
            CurrentState.InstanceDTO.InjectFrom<NullableInjection>(m_Container.WorkflowInstance);
            CurrentState.InstanceDTO.WorkflowInstanceID = m_Container.WorkflowInstance.ID;
            CurrentState.InstanceDTO.WorkflowID = m_Container.WorkflowInstance.WorkflowID;
            CurrentState.InstanceDTO.WorkflowVersionNumber = m_Container.WorkflowInstance.WorkflowVersionNumber;
            CurrentState.InstanceDTO.WorkflowInstanceID = m_Container.WorkflowInstance.ID;
            CurrentState.InstanceDTO.ParentID = m_Container.WorkflowInstance.ParentID;
           
            // execution
            CurrentState.InstanceExecutionDTO = new WorkflowInstanceExecutionDTO();
            CurrentState.InstanceExecutionDTO.WorkflowID = m_Container.WorkflowInstance.WorkflowID;
            CurrentState.InstanceExecutionDTO.WorkflowVersionNumber = m_Container.WorkflowInstance.WorkflowVersionNumber;
            CurrentState.InstanceExecutionDTO.WorkflowInstanceID = m_Container.WorkflowInstance.ID;
            CurrentState.InstanceExecutionDTO.WorkflowInstanceSessionID = m_Container.WorkflowInstance.InstanceSession.WorkflowInstanceSessionID;
            CurrentState.InstanceExecutionDTO.WorkflowTransistionID = m_Container.WorkflowProcessHandler.CurrentTransistion.ID;
            if (m_Container.WorkflowInstance.CurrentExecution != null)
            {
                CurrentState.InstanceExecutionDTO.InjectFrom<NullableInjection>(m_Container.WorkflowInstance.CurrentExecution);
                CurrentState.InstanceExecutionDTO.WorkflowInstanceExecutionID = m_Container.WorkflowInstance.CurrentExecution.WorkflowInstanceExecutionID;
            }
           
          
            // dataitem
            CurrentState.InstanceExecutionDataEventDTO = new WorkflowInstanceExecutionStatusEventDTO();
            CurrentState.InstanceExecutionDataEventDTO.EventBy = Environment.UserName;
            CurrentState.InstanceExecutionDataEventDTO.EventDate = DateTime.Now;
            CurrentState.InstanceExecutionDataEventDTO.WorkflowExecutionStatusID = (int) status;
            CurrentState.InstanceExecutionDataEventDTO.WorkflowID = m_Container.WorkflowInstance.WorkflowID;
            CurrentState.InstanceExecutionDataEventDTO.WorkflowVersionNumber = m_Container.WorkflowInstance.WorkflowVersionNumber;
            CurrentState.InstanceExecutionDataEventDTO.WorkflowInstanceID = m_Container.WorkflowInstance.ID;
            CurrentState.InstanceExecutionDataEventDTO.WorkflowInstanceSessionID = m_Container.WorkflowInstance.InstanceSession.WorkflowInstanceSessionID;

            CurrentState.InstanceExecutionDataItemDTO = new WorkflowInstanceExecutionDataItemDTO();
            CurrentState.InstanceExecutionDataItemDTO.DataNotJsonSerialized = false;
            CurrentState.InstanceExecutionDataItemDTO.FieldName = Environment.UserName;
            CurrentState.InstanceExecutionDataItemDTO.WorkflowInstanceExecutionID = CurrentState.InstanceExecutionDTO.WorkflowInstanceExecutionID;

            WorkflowStateBaseDTO stateDto = WorkflowDataHelper.CreateWorkflowState(
                (IWorkflowComponent)actionDecision,
                this.CurrentQueue,
                this.CurrentTransistion.ID,this.m_Container.Data);

            // set current state
            CurrentState.WorkflowState = stateDto;
            CurrentState.WorkflowState.InstanceID = m_Container.WorkflowInstance.ID;

            if(actionDecision != null)
            {
                if(actionDecision is IWorkflowAction)
                {
                    var action = actionDecision as IWorkflowAction;

                    CurrentState.CurrentComponentIsAction = true;

                    CurrentState.CurrentActionDTO = new WorkflowActionDTO();
                    CurrentState.CurrentActionDTO.WorkflowObjectType = new WorkflowObjectTypeDTO();
                    CurrentState.CurrentActionDTO.WorkflowObjectType.Name = action.ObjectType.Name;
                    CurrentState.CurrentActionDTO.WorkflowObjectType.Description = action.ObjectType.Description;
                    CurrentState.CurrentActionDTO.WorkflowObjectType.ObjectTypeAssembly = action.ObjectType.ObjectTypeAssembly;
                    CurrentState.CurrentActionDTO.WorkflowObjectType.ObjectTypeName = action.ObjectType.ObjectTypeName;
                    CurrentState.CurrentActionDTO.WorkflowObjectType.ObjectTypeNameSpace = action.ObjectType.ObjectTypeNameSpace;
                    CurrentState.CurrentActionDTO.WorkflowObjectType.WorkflowObjectTypeID = action.ObjectType.WorkflowObjectTypeID;
                    CurrentState.CurrentActionDTO.IsManual = action.IsManual;
                    CurrentState.CurrentActionDTO.IsTransistionEnd = action.IsEnd;
                    CurrentState.CurrentActionDTO.IsTransistionStart = action.IsStart;
                    CurrentState.CurrentActionDTO.IsWaitingForComponents=action.IsWaitingForComponents;
                    CurrentState.CurrentActionDTO.IsWaitingForInput=action.IsWaitingForInput;
                    CurrentState.CurrentActionDTO.IsFailure = action.HasErrors;
                    CurrentState.CurrentActionDTO.WorkflowActionID = action.ID;
                    CurrentState.CurrentActionDTO.WorkflowID = m_Container.WorkflowInstance.ID;
                    CurrentState.CurrentActionDTO.WorkflowVersionNumber = m_Container.WorkflowInstance.WorkflowVersionNumber;
                    CurrentState.CurrentActionDTO.Name = action.Name;
                    CurrentState.CurrentActionDTO.Description = action.Description;
                    CurrentState.WorkflowErrors = action.Errors;
                    CurrentState.Parameters = new List<WorkflowParameterDTO>();

                    action.Parameters.ForEach(item =>
                        {
                            var dto = new WorkflowParameterDTO();
                            dto.Description = item.Description;
                            dto.Name = item.Name;
                            dto.ObjectType = item.ObjectType;
                            dto.ObjectValue = item.ObjectValue;
                            CurrentState.Parameters.Add(dto);
                        });

                    // need to set controller, area and action
                    if (action.Parameters.Any(s => s.Name.Equals("Action")))
                        CurrentState.CurrentActionDTO.ActionName =
                            action.Parameters.Single(s => s.Name.Equals("Action")).ObjectValue.ToString();

                    if (action.Parameters.Any(s => s.Name.Equals("Controller")))
                        CurrentState.CurrentActionDTO.ControllerName =
                            action.Parameters.Single(s => s.Name.Equals("Controller")).ObjectValue.ToString();

                    if (action.Parameters.Any(s => s.Name.Equals("Area")))
                        CurrentState.CurrentActionDTO.AreaName =
                            action.Parameters.Single(s => s.Name.Equals("Area")).ObjectValue.ToString();
                }
                else
                {
                    CurrentState.CurrentComponentIsAction = false;

                    var decision = actionDecision as IWorkflowDecision;

                    CurrentState.CurrentComponentIsAction = true;

                    CurrentState.CurrentDecisionDTO = new WorkflowDecisionDTO();
                    CurrentState.CurrentDecisionDTO.WorkflowObjectType = new WorkflowObjectTypeDTO();
                    CurrentState.CurrentDecisionDTO.WorkflowObjectType.Name = decision.ObjectType.Name;
                    CurrentState.CurrentDecisionDTO.WorkflowObjectType.Description = decision.ObjectType.Description;
                    CurrentState.CurrentDecisionDTO.WorkflowObjectType.ObjectTypeAssembly = decision.ObjectType.ObjectTypeAssembly;
                    CurrentState.CurrentDecisionDTO.WorkflowObjectType.ObjectTypeName = decision.ObjectType.ObjectTypeName;
                    CurrentState.CurrentDecisionDTO.WorkflowObjectType.ObjectTypeNameSpace = decision.ObjectType.ObjectTypeNameSpace;
                    CurrentState.CurrentDecisionDTO.WorkflowObjectType.WorkflowObjectTypeID = decision.ObjectType.WorkflowObjectTypeID;
                    CurrentState.CurrentDecisionDTO.WorkflowDecisionID = decision.ID;
                    CurrentState.CurrentDecisionDTO.WorkflowID = m_Container.WorkflowInstance.ID;
                    CurrentState.CurrentDecisionDTO.WorkflowVersionNumber = m_Container.WorkflowInstance.WorkflowVersionNumber;
                    CurrentState.CurrentDecisionDTO.Name = decision.Name;
                    CurrentState.CurrentDecisionDTO.Description = decision.Description;
                    CurrentState.CurrentDecisionDTO.IsSuccess = decision.IsSuccess;
                    CurrentState.Parameters = new List<WorkflowParameterDTO>();
                    CurrentState.WorkflowErrors = decision.Errors; 

                    decision.Parameters.ForEach(item =>
                        {
                            var dto = new WorkflowParameterDTO();
                            dto.Description = item.Description;
                            dto.Name = item.Name;
                            dto.ObjectType = item.ObjectType;
                            dto.ObjectValue = item.ObjectValue;
                            CurrentState.Parameters.Add(dto);
                        });
                }
            }
        }

    }

    public enum WorkflowHandlerState
    {
        IsActive=0,
        IsPending,
        IsFinished
    }
}
