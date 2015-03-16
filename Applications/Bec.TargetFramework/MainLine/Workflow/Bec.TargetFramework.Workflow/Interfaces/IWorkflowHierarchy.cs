using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Interfaces
{
    public interface IWorkflowHierarchy : IWorkflowComponent
    {
        List<IWorkflowHierarchyComponent> Hierarchy { get; set; }

        List<IWorkflowMainComponent> WorkflowComponents { get; set; }

        List<IWorkflowHierarchyComponent> GetTransistionHierarchy(Guid workflowtransitionID);

    }
}
