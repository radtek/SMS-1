using Bec.TargetFramework.Entities.Workflow;
using System;
using System.Collections.Generic;
namespace Bec.TargetFramework.Workflow.Interfaces
{
    public interface IWorkflowProcessHandler
    {
        bool HasTransistionWorkflowCompleted();
        void RestartWorkflow();
        void SetCurrentTransistion(Guid transistionID);
        void StartWorkflow();

        IWorkflowTransistion CurrentTransistion { get; set; }

        IWorkflowMainComponent CurrentComponent { get; set; }

        List<IWorkflowMainComponent> CurrentQueue { get; set; }

        WorkflowInstanceCurrentStateDTO CurrentState { get; set; }
    }
}
