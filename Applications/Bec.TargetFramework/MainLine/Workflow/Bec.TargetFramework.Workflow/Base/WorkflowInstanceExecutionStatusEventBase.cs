using Bec.TargetFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    public class WorkflowInstanceExecutionStatusEventBase
    {
        public int WorkflowInstanceExecutionStatusEventID { get; set; }
        public System.DateTime EventDate { get; set; }
        public string EventBy { get; set; }
        public int WorkflowExecutionStatusID { get; set; }
        public int WorkflowInstanceExecutionID { get; set; }
        public int EventOrder { get; set; }

        public WorkflowInstanceExecutionDataItemBase DataItem { get; set; }

        public virtual WorkflowExecutionStatus WorkflowExecutionStatus { get; set; }
        public virtual WorkflowInstanceExecution WorkflowInstanceExecution { get; set; }
        public virtual ICollection<WorkflowInstanceExecutionDataItem> WorkflowInstanceExecutionDataItems { get; set; }
    }
}
