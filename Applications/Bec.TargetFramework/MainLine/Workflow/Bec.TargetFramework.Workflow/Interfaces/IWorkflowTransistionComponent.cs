using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Interfaces
{
    public interface IWorkflowTransistion : IWorkflowComponent,IWorkflowExecutionComponent
    {
        List<IWorkflowMainComponent> TransistionComponents { get; set; }

        List<IWorkflowHierarchyComponent> TransistionHierarchy { get; set; }
        bool IsStart { get; set; }
        bool IsEnd { get; set; }
        string TransistionStatus { get; set; }

        List<IWorkflowComponent> WorkflowComponentExecutionHistory { get; set; }

        List<IWorkflowTransistionHistory> TransistionHistory { get; set; }
    }
}
