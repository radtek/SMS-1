using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Base
{
    using Bec.TargetFramework.Entities;
    [Serializable]
    public class WorkflowInstanceExecutionBase
    {
        public int WorkflowInstanceExecutionID { get; set; }
        public System.Guid WorkflowInstanceID { get; set; }
        public System.Guid WorkflowID { get; set; }
        public System.Guid WorkflowTransistionID { get; set; }
        public Nullable<System.Guid> WorkflowActionID { get; set; }
        public Nullable<System.Guid> WorkflowDecisionID { get; set; }
        public Nullable<System.Guid> WorkflowConditionID { get; set; }
        public Nullable<System.Guid> WorkflowCommandID { get; set; }

        public Guid TransistionID { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid WorkflowComponentID { get; set; }
        public WorkflowStateBaseDTO WorkflowState { get; set; }

        public List<WorkflowInstanceExecutionStatusEventBase> Events {get;set;}
    }
}
