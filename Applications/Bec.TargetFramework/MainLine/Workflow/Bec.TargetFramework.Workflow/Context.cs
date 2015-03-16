using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Workflow.Interfaces;

namespace Bec.TargetFramework.Workflow
{
    class Context
    {
        public void boo()
        {
            // hierarchy
            //List<IWorkflowHierarchyComponent> hierarchyComponents = new List<IWorkflowHierarchyComponent>();

            //WorkflowTransistionBase transistion = new WorkflowTransistionBase
            //{
            //    ID = Guid.NewGuid(),
            //    Name = "Transistion",
            //    IsStart = true
            //};

            //List<IWorkflowComponent> workflowComponents = new List<IWorkflowComponent>();

            //workflowComponents.Add(transistion);

            //workflowComponents.Add(new WorkflowActionBase
            //{
            //    ID = Guid.NewGuid(),
            //    Name = "A1",
            //    ParentTransistion = transistion,
            //    IsStart = true
            //});

            //workflowComponents.Add(new WorkflowActionBase
            //{
            //    ID = Guid.NewGuid(),
            //    Name = "A2",
            //    ParentTransistion = transistion
            //});

            //workflowComponents.Add(new WorkflowActionBase
            //{
            //    ID = Guid.NewGuid(),
            //    Name = "A3",
            //    ParentTransistion = transistion
            //});

            //workflowComponents.Add(new WorkflowActionBase
            //{
            //    ID = Guid.NewGuid(),
            //    Name = "A4",
            //    ParentTransistion = transistion
            //});

            //workflowComponents.Add(new WorkflowActionBase
            //{
            //    ID = Guid.NewGuid(),
            //    Name = "T1",
            //    ParentTransistion = transistion
            //});

            //workflowComponents.Add(new WorkflowActionBase
            //{
            //    ID = Guid.NewGuid(),
            //    Name = "T2",
            //    ParentTransistion = transistion
            //});

            //workflowComponents.Add(new WorkflowDecisionBase
            //{
            //    ID = Guid.NewGuid(),
            //    Name = "D1",
            //    ParentTransistion = transistion
            //});

            //workflowComponents.Add(new WorkflowDecisionBase
            //{
            //    ID = Guid.NewGuid(),
            //    Name = "D2",
            //    ParentTransistion = transistion
            //});

            //workflowComponents.Add(new WorkflowDecisionBase
            //{
            //    ID = Guid.NewGuid(),
            //    Name = "D3",
            //    ParentTransistion = transistion
            //});

            //workflowComponents.Add(new WorkflowDecisionBase
            //{
            //    ID = Guid.NewGuid(),
            //    Name = "D4",
            //    ParentTransistion = transistion
            //});



            //// create hierarchy
            //hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            //{
            //    ChildComponent = workflowComponents.Single(it => it.Name.Equals("A1")),
            //    ParentComponent = null,
            //    IsStart = true
            //});

            //hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            //{
            //    ChildComponent = workflowComponents.Single(it => it.Name.Equals("D1")),
            //    ParentComponent = workflowComponents.Single(it => it.Name.Equals("A1"))
            //});

            //hierarchyComponents.Add(new WorkflowHierarchyComponentBase
            //{
            //    ChildComponent = workflowComponents.Single(it => it.Name.Equals("A2")),
            //    ParentComponent = workflowComponents.Single(it => it.Name.Equals("D1"))
            //});

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
    }
}
