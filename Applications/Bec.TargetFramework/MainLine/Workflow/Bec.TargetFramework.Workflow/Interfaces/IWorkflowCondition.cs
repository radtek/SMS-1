using System;
namespace Bec.TargetFramework.Workflow.Interfaces
{
    public interface IWorkflowCondition : IWorkflowComponent
    {
        Guid WorkflowConditionID { get; set; }
        Guid? WorkflowObjectTypeID { get; set; }

        bool ExecuteCondition { get; set; }
    }
}
