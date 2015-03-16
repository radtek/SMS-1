using Bec.TargetFramework.Data;
using Bec.TargetFramework.Workflow.Helpers;
using Bec.TargetFramework.Workflow.Interfaces;
using Bec.TargetFramework.Workflow.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Base
{
    using Bec.TargetFramework.Entities;
    using Bec.TargetFramework.Entities.DTO.Workflow;

    //Bec.TargetFramework.Entities
    [Serializable]
    public class WorkflowInstanceBase : IWorkflowInstance
    {
        public Guid ID { get; set; }
        public Guid WorkflowID { get; set; }
        public bool IsActive { get; set; }
        public int WorkflowVersionNumber { get; set; }
        public Guid ParentID { get; set; }
        public List<WorkflowInstanceExecutionBase> Executions { get; set; }
        public IWorkflowContainer ParentContainer { get; set; }

        public WorkflowDictionaryDTO TempData { get; set; }

        public WorkflowInstanceExecutionBase CurrentExecution { get; set; }

        public WorkflowStateBaseDTO LastLoadedState { get; set;}
        public WorkflowInstanceSessionBase InstanceSession { get; set; }
        public int WorkflowInstanceStatusID { get; set; }

        public WorkflowInstanceBase()
        {
            Executions = new List<WorkflowInstanceExecutionBase>();
            InstanceSession = new WorkflowInstanceSessionBase();
        }

        public void CreateNewExecutionWithEvent(WorkflowExecutionStatusEnum status,WorkflowStateBaseDTO currentStateDto)
        {
            // save execution status
            CurrentExecution = ParentContainer.WorkflowInstanceProvider.CreateNewExecutionWithEvent(ParentContainer.WorkflowProcessHandler, this, status, currentStateDto);

            CurrentExecution.WorkflowComponentID = ParentContainer.WorkflowProcessHandler.CurrentComponent.ID;

            Executions.Add(CurrentExecution);
        }

        public void UpdateExecutionWithEvent(WorkflowExecutionStatusEnum status, WorkflowStateBaseDTO currentStateDto)
        {
            // save execution status


            ParentContainer.WorkflowInstanceProvider.UpdateExecutionWithEvent(ParentContainer.WorkflowProcessHandler, this, status, currentStateDto);
        }

        public void CreateExecutionWithExecutionTrace(IWorkflowComponent component, IWorkflowCommand command, IWorkflowCondition condition, string methodExecution, int retries, WorkflowStateBaseDTO currentStateDto)
        {
            ParentContainer.WorkflowInstanceProvider.CreateExecutionWithTrace(ParentContainer.WorkflowProcessHandler, this, methodExecution, component, component.HasErrors, retries,command,condition);
        }

        public void Initialise(IWorkflowContainer container)
        {
            ParentContainer = container;
        }
    }
}
