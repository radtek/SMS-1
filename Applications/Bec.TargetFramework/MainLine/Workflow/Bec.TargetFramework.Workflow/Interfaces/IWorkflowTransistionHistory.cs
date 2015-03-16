using Bec.TargetFramework.Workflow.Base;
using System;
namespace Bec.TargetFramework.Workflow.Interfaces
{
    using Bec.TargetFramework.Entities;

    public interface IWorkflowTransistionHistory
    {
        DateTime CreatedOn { get; set; }
        Guid TransistionID { get; set; }
        Guid WorkflowComponentID { get; set; }

        WorkflowStateBaseDTO WorkflowState {get;set;}
    }
}
