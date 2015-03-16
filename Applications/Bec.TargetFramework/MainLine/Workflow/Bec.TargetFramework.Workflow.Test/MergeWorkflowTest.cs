using Bec.TargetFramework.Infrastructure.Collections;
using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Workflow.Interfaces;
using Bec.TargetFramework.Workflow.Test.Implementations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Test
{
    public class MergeWorkflowTest
    {
        List<IWorkflowHierarchyComponent> hierarchyComponents = new List<IWorkflowHierarchyComponent>();
        List<IWorkflowComponent> workflowComponents = new List<IWorkflowComponent>();

        public MergeWorkflowTest()
        {
            CreateWorkflowComponents();
            CreateWorkflowHierarchy();
            ExecuteWorkflow();
        }

        private Queue<IWorkflowComponent> m_WorkflowComponentQueue = new Queue<IWorkflowComponent>();
        private List<IWorkflowComponent> m_ExecutedWorkflowItems = new List<IWorkflowComponent>();

        private void ExecuteWorkflow()
        {
            // get transistions
            var transistions = workflowComponents.OfType<IWorkflowTransistionComponent>().ToList();

            m_WorkflowComponentQueue.Clear();
            m_ExecutedWorkflowItems.Clear();

            if(transistions.Count > 0)
            {
                // A -> D -> A
                var transistion = transistions[0];

                // find start component in hierarchy
                var startHierarchyComponent = hierarchyComponents.Single(it => it.IsStart && it.ParentComponent == null);

                // must be an action
                var action = startHierarchyComponent.ChildComponent as IWorkflowAction;

                // create GenericData and add a number
                var genericData = new Dictionary<string,object>();

                genericData["MyNumber"] = 10;

                // execute first action
                if (action.PerformExecutions(genericData))
                {
                    ProcessNextWorkflowComponent(action, genericData, null);

                    IDictionary<string, object> data = null;

                    while(m_WorkflowComponentQueue.Count > 0)
                    {
                        // dequeue item and process branch
                        var component = m_WorkflowComponentQueue.Dequeue();

                        // determine if still waiting for other impacting branch to take place
                        if (DoWeNeedToWaitForComponent(component))
                        {
                            Console.WriteLine("Component " + component.Name + " is paused as needs to wait for other to complete");
                        
                            if(!m_WorkflowComponentQueue.Any(it => it.ID.Equals(component.ID)))
                                m_WorkflowComponentQueue.Enqueue(component);
                        }
                        else
                        {
                            // if any items match this on the queue then dequeue
                            m_WorkflowComponentQueue.Where(it => it.ID.Equals(component.ID)).ToList().ForEach(item => m_WorkflowComponentQueue.Dequeue());

                            ProcessNextWorkflowComponent(null, component.Data, component);
                        }
                    }
                }
            }
        }

        private bool DoWeNeedToWaitForComponent(IWorkflowComponent component)
        {
            List<IWorkflowComponent> components = new List<IWorkflowComponent>();

            workflowComponents.OfType<IWorkflowDecision>().ToList().ForEach(it =>
            {
                if (it.SuccessComponents.Any(sc => sc.ID.Equals(component.ID))
                    || it.FailureComponents.Any(sc => sc.ID.Equals(component.ID)))
                {
                    // filter out items component is parent of
                    if(!hierarchyComponents.Any(hc => hc.ChildComponent.ID.Equals(it.ID)
                        && hc.ParentComponent.ID.Equals(component.ID)))
                    components.Add(it);
                }
            });

            // check for previous actions that are needed ti cimplete this action

            hierarchyComponents.ForEach(it =>
            {
                if (it.ParentComponent != null && it.ChildComponent != null && it.ChildComponent.ID.Equals(component.ID))
                    components.Add(it.ParentComponent);
            });

            // now check whether all these items have executed
            bool doWeWait = false;

            components.ForEach(it =>
            {
                if(!doWeWait)
                    if (!m_ExecutedWorkflowItems.Any(si => si.ID.Equals(it.ID)))
                        doWeWait = true;

            });

            return doWeWait;
        }
        private IDictionary<string, object> ProcessAction(IWorkflowAction action,IDictionary<string, object> data)
        {
            m_ExecutedWorkflowItems.Add(action);
            Console.WriteLine("Executed Action:" + action.Name);
            if (action.CanExecute())
                action.PerformExecutions(data);

            // update data
            return action.Data;
        }

        private IList<IWorkflowComponent> ProcessDecision(IWorkflowDecision decision, IDictionary<string, object> data)
        {
            m_ExecutedWorkflowItems.Add(decision);
            Console.WriteLine("Executed Decision:" + decision.Name);
            return decision.MakeDecision(data);
        }

        private void ProcessNextWorkflowComponent(IWorkflowComponent parent, IDictionary<string, object> data,IWorkflowComponent child)
        {
            // determine next steps, could be parallel
            IList<IWorkflowHierarchyComponent> childComponents = null;

            if (child == null)
                childComponents =
                    hierarchyComponents.Where(
                        it => it.ParentComponent != null && it.ParentComponent.ID.Equals(parent.ID)).ToList();
            else
                childComponents = new List<IWorkflowHierarchyComponent>() {new WorkflowHierarchyComponentBase{ChildComponent = child}};

            // iterate components and process as needed
            childComponents.ToList().ForEach(it =>
            {
                if (it.ChildComponent is IWorkflowAction)
                {
                    if (DoWeNeedToWaitForComponent(it.ChildComponent))
                    {
                        Console.WriteLine("Component " + it.ChildComponent.Name +
                                          " is paused as needs to wait for others to complete");

                        if (!m_WorkflowComponentQueue.Any(ip => ip.ID.Equals(it.ChildComponent.ID)))
                            m_WorkflowComponentQueue.Enqueue(it.ChildComponent);
                    }
                    else
                    {
                        m_WorkflowComponentQueue.Where(ip => ip.ID.Equals(it.ChildComponent.ID)).ToList().ForEach(item => m_WorkflowComponentQueue.Dequeue());

                        data = ProcessAction(it.ChildComponent as IWorkflowAction,data);

                        ProcessNextWorkflowComponent(it.ChildComponent, data, null);
                    }
                }
                else if (it.ChildComponent is IWorkflowDecision)
                {
                    ProcessDecision(it.ChildComponent as IWorkflowDecision, data)
                        .ToList().ForEach(i => m_WorkflowComponentQueue.Enqueue(i));
                }
            });


        }

        /// <summary>
        /// D->2xA
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="data"></param>
        /// <param name="nextKnown"></param>

        //private void ProcessWorkflowComponent(IWorkflowComponent parent,IDictionary<string,object> data,bool nextKnown)
        //{
        //    IWorkflowComponent component = null;
 
        //    if(!nextKnown)
        //        component = hierarchyComponents.Single(it => it.ParentComponent != null &&  it.ParentComponent.ID.Equals(parent.ID)).ChildComponent;
        //    else
        //        component = parent;

        //    if(component is IWorkflowAction)
        //    {
        //        var action = component as IWorkflowAction;

        //        if(action.PerformExecutions(data))
        //        {
        //            if(!action.IsEnd)
        //                ProcessWorkflowComponent(action,action.Data,false);
        //            else
        //                Console.WriteLine("End:" + action.Name);

        //        }
        //    }
        //    else if (component is IWorkflowDecision)
        //    {
        //        var decision = component as IWorkflowDecision;

        //        decision.MakeDecision(data).ToList()
        //            .ForEach(item =>
        //                {
        //                    ProcessWorkflowComponent(item, item.Data, true);
        //                });
                
        //    }
        //}


        private void PopulateWorkflowDecisions()
        {
            hierarchyComponents.Where(it => it.ChildComponent is IWorkflowDecision).ToList()
                .ForEach(it =>
                    {
                        // find all decision options
                        var decision = it.ChildComponent as IWorkflowDecision;

                        // get all related and add to tree where decision is Parent
                        decision.DecisionComponents = hierarchyComponents.Where(hc => hc.ParentComponent != null && hc.ParentComponent.ID.Equals(decision.ID)).Select(p => p as IWorkflowComponent).ToList();
                    });
        }

        private void CreateWorkflowHierarchy()
        {
             // create hierarchy
            hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            {
                ChildComponent = workflowComponents.Single(it => it.Name.Equals("A1")),
                ParentComponent = null,
                IsStart = true,
                IsCriticalPath = true
            });

            hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            {
                ChildComponent = workflowComponents.Single(it => it.Name.Equals("D1")),
                ParentComponent = workflowComponents.Single(it => it.Name.Equals("A1"))
            });

            hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            {
                ChildComponent = workflowComponents.Single(it => it.Name.Equals("A2")),
                ParentComponent = workflowComponents.Single(it => it.Name.Equals("D1"))
            });

            hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            {
                ChildComponent = workflowComponents.Single(it => it.Name.Equals("A3")),
                ParentComponent = workflowComponents.Single(it => it.Name.Equals("D1"))
            });

            hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            {
                ChildComponent = workflowComponents.Single(it => it.Name.Equals("A4")),
                ParentComponent = workflowComponents.Single(it => it.Name.Equals("D1")),
                IsEnd = true
            });

            hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            {
                ChildComponent = workflowComponents.Single(it => it.Name.Equals("A5")),
                ParentComponent = workflowComponents.Single(it => it.Name.Equals("A2"))
            });

            hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            {
                ChildComponent = workflowComponents.Single(it => it.Name.Equals("A5")),
                ParentComponent = workflowComponents.Single(it => it.Name.Equals("A3"))
            });

            hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            {
                ChildComponent = workflowComponents.Single(it => it.Name.Equals("A5")),
                ParentComponent = workflowComponents.Single(it => it.Name.Equals("A4"))
            });

            // determine paths


            //hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            //{
            //    ChildComponent = workflowComponents.Single(it => it.Name.Equals("A3")),
            //    ParentComponent = workflowComponents.Single(it => it.Name.Equals("D1"))
            //});



            //hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            //{
            //    ChildComponent = workflowComponents.Single(it => it.Name.Equals("D2")),
            //    ParentComponent = workflowComponents.Single(it => it.Name.Equals("A3"))
            //});

            //hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            //{
            //    ChildComponent = workflowComponents.Single(it => it.Name.Equals("D3")),
            //    ParentComponent = workflowComponents.Single(it => it.Name.Equals("D2"))
            //});

            //hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            //{
            //    ChildComponent = workflowComponents.Single(it => it.Name.Equals("A4")),
            //    ParentComponent = workflowComponents.Single(it => it.Name.Equals("D3"))
            //});

            //hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            //{
            //    ChildComponent = workflowComponents.Single(it => it.Name.Equals("D4")),
            //    ParentComponent = workflowComponents.Single(it => it.Name.Equals("A4"))
            //});

            //hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            //{
            //    ChildComponent = workflowComponents.Single(it => it.Name.Equals("T2")),
            //    ParentComponent = workflowComponents.Single(it => it.Name.Equals("D4"))
            //});

            //hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            //{
            //    ChildComponent = workflowComponents.Single(it => it.Name.Equals("T1")),
            //    ParentComponent = workflowComponents.Single(it => it.Name.Equals("A2"))
            //});

            //hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            //{
            //    ChildComponent = workflowComponents.Single(it => it.Name.Equals("D1")),
            //    ParentComponent = workflowComponents.Single(it => it.Name.Equals("D3"))
            //});

            //hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            //{
            //    ChildComponent = workflowComponents.Single(it => it.Name.Equals("D2")),
            //    ParentComponent = workflowComponents.Single(it => it.Name.Equals("D4"))
            //});
        }

        private void CreateWorkflowComponents()
        {
            WorkflowTransistionBase transistion = new WorkflowTransistionBase
            {
                ID = Guid.NewGuid(),
                Name = "Transistion",
                IsStart = true
            };

            workflowComponents.Add(transistion);

            workflowComponents.Add(new ManualWorkflowAction
            {
                ID = Guid.NewGuid(),
                Name = "A1",
                ParentTransistion = transistion,
                IsStart = true
            });

            workflowComponents.Add(new ManualWorkflowAction
            {
                ID = Guid.NewGuid(),
                Name = "A2",
                ParentTransistion = transistion
            });

            workflowComponents.Add(new ManualWorkflowAction
            {
                ID = Guid.NewGuid(),
                Name = "A3",
                ParentTransistion = transistion,
                IsEnd = true
            });

            workflowComponents.Add(new ManualWorkflowAction
            {
                ID = Guid.NewGuid(),
                Name = "A4",
                ParentTransistion = transistion,
                IsEnd = true
            });

            workflowComponents.Add(new ManualWorkflowAction
            {
                ID = Guid.NewGuid(),
                Name = "A5",
                ParentTransistion = transistion,
                IsEnd = true
            });

            workflowComponents.Add(new Is100WorkflowDecision
            {
                ID = Guid.NewGuid(),
                Name = "D1",
                ParentTransistion = transistion,
                SuccessComponents = workflowComponents.Where(it => it.Name.Equals("A2") || it.Name.Equals("A3") || it.Name.Equals("A4")).ToList(),
                FailureComponents = workflowComponents.Where(it => it.Name.Equals("A1")).ToList()
            });

        }
    }
}
