using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Workflow.Helpers;
using Bec.TargetFramework.Workflow.Providers;
using System;
namespace Bec.TargetFramework.Workflow.Interfaces
{
    using System.Collections.Generic;

    using Bec.TargetFramework.Entities;
    using Bec.TargetFramework.Entities.DTO.Workflow;

    //Bec.TargetFramework.Entities

    public interface IWorkflowInstance
    {
        System.Collections.Generic.List<WorkflowInstanceExecutionBase> Executions { get; set; }
        Guid ID { get; set; }
        bool IsActive { get; set; }
        Guid ParentID { get; set; }
        void CreateNewExecutionWithEvent(WorkflowExecutionStatusEnum status, WorkflowStateBaseDTO currentStateDto);
        void UpdateExecutionWithEvent(WorkflowExecutionStatusEnum status, WorkflowStateBaseDTO currentStateDto);

        WorkflowDictionaryDTO TempData { get;set;}

        void CreateExecutionWithExecutionTrace(
            IWorkflowComponent component,
            IWorkflowCommand command,
            IWorkflowCondition condition,
            string methodExecution,
            int retries, WorkflowStateBaseDTO currentStateDto);

        void Initialise(IWorkflowContainer container);

        int WorkflowVersionNumber { get; set; }
        Guid WorkflowID { get; set; }
        IWorkflowContainer ParentContainer { get; set; }

        WorkflowInstanceExecutionBase CurrentExecution { get; set; }

        WorkflowStateBaseDTO LastLoadedState { get; set;}

        WorkflowInstanceSessionBase InstanceSession { get; set; }

        int WorkflowInstanceStatusID { get; set; }
    }
}
