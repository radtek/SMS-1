using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Interfaces
{
    public interface IWorkflowTransistion : IWorkflowComponent
    {
        void Initialise(IWorkflowContainer container);

        IList<IWorkflowComponent> TransistionComponents { get; set; }

        IList<IWorkflowHierarchyComponent> TransistionHierarchy { get; set; }
        bool IsStart { get; set; }
        bool IsEnd { get; set; }
        string TransistionStatus { get; set; }

        IList<IWorkflowComponent> WorkflowComponentExecutionHistory { get; set; }
    }
}
