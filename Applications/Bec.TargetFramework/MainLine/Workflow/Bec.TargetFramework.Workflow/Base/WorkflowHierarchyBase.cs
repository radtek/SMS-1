using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Workflow.Interfaces;
using System.Collections.Concurrent;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    public class WorkflowHierarchyBase : WorkflowComponentBase, IWorkflowHierarchy
    {
        public List<IWorkflowHierarchyComponent> Hierarchy { get; set; }
        public List<IWorkflowMainComponent> WorkflowComponents { get; set; }

        public List<IWorkflowHierarchyComponent> GetTransistionHierarchy(Guid workflowtransitionID)
        {
            var transistionComponent = ParentContainer.Transistions.Single(it => it.ID.Equals(workflowtransitionID));

            return transistionComponent.TransistionHierarchy;
        }
    }
}
