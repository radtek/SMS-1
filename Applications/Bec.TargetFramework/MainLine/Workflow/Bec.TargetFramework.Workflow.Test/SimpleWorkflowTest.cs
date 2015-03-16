using Bec.TargetFramework.Infrastructure.Collections;
using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Workflow.Interfaces;
using Bec.TargetFramework.Workflow.Test.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Test
{
    public class SimpleWorkflowTest
    {
        List<IWorkflowHierarchyComponent> hierarchyComponents = new List<IWorkflowHierarchyComponent>();
        List<IWorkflowComponent> workflowComponents = new List<IWorkflowComponent>();

        public SimpleWorkflowTest()
        {
            CreateWorkflowComponents();
            CreateWorkflowHierarchy();
            ExecuteWorkflow();
        }

        private void ExecuteWorkflow()
        {
            // get transistions
            var transistions = workflowComponents.OfType<IWorkflowTransistionComponent>().ToList();

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
                if(action.PerformExecutions(genericData))
                {
                    ProcessWorkflowComponent(action,genericData,false);
                    
                }
            }
        }

        private void ProcessWorkflowComponent(IWorkflowComponent parent,IDictionary<string,object> data,bool nextKnown)
        {

            IWorkflowComponent component = null;
 
            if(!nextKnown)
                component = hierarchyComponents.Single(it => it.ParentComponent != null &&  it.ParentComponent.ID.Equals(parent.ID)).ChildComponent;
            else
                component = parent;

            if(component is IWorkflowAction)
            {
                var action = component as IWorkflowAction;

                if(action.PerformExecutions(data))
                {
                    if(!action.IsEnd)
                        ProcessWorkflowComponent(action,action.Data,false);
                    else
                        return;
                }
            }
            else if (component is IWorkflowDecision)
            {
                var decision = component as IWorkflowDecision;

                decision.MakeDecision(data).ToList()
                    .ForEach(item =>
                    {
                        ProcessWorkflowComponent(item, item.Data, true);
                    });
            }
        }

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
                IsStart = true
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

            workflowComponents.Add(new AdditionWorkflowAction
            {
                ID = Guid.NewGuid(),
                Name = "A1",
                ParentTransistion = transistion,
                IsStart = true
            });

            workflowComponents.Add(new AdditionWorkflowAction
            {
                ID = Guid.NewGuid(),
                Name = "A2",
                ParentTransistion = transistion,
                IsEnd = true
            });

            workflowComponents.Add(new AdditionWorkflowAction
            {
                ID = Guid.NewGuid(),
                Name = "A3",
                ParentTransistion = transistion
            });

            workflowComponents.Add(new AdditionWorkflowAction
            {
                ID = Guid.NewGuid(),
                Name = "A4",
                ParentTransistion = transistion
            });

            workflowComponents.Add(new AdditionWorkflowAction
            {
                ID = Guid.NewGuid(),
                Name = "T1",
                ParentTransistion = transistion
            });

            workflowComponents.Add(new AdditionWorkflowAction
            {
                ID = Guid.NewGuid(),
                Name = "T2",
                ParentTransistion = transistion
            });

            workflowComponents.Add(new GreaterThanWorkflowDecision
            {
                ID = Guid.NewGuid(),
                Name = "D1",
                ParentTransistion = transistion,
                SuccessComponents = workflowComponents.Where(it => it.Name.Equals("A2")).ToList(),
                FailureComponents = workflowComponents.Where(it => it.Name.Equals("A1")).ToList()
            });

            workflowComponents.Add(new GreaterThanWorkflowDecision
            {
                ID = Guid.NewGuid(),
                Name = "D2",
                ParentTransistion = transistion
            });

            workflowComponents.Add(new GreaterThanWorkflowDecision
            {
                ID = Guid.NewGuid(),
                Name = "D3",
                ParentTransistion = transistion
            });

            workflowComponents.Add(new GreaterThanWorkflowDecision
            {
                ID = Guid.NewGuid(),
                Name = "D4",
                ParentTransistion = transistion
            });
        }
    }
}
