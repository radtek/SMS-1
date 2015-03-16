using System;
namespace Bec.TargetFramework.Workflow.Interfaces
{
    public interface IWorkflowCommand : IWorkflowComponent
    {
        Guid WorkflowCommandID { get; set; }
        Guid? WorkflowObjectTypeID { get; set; }
        Guid WorkflowID { get; set; }

        bool ExecuteCommand { get; set; }
    }
}
