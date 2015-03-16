using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class WorkflowInstanceProgressDTO
    {
        [DataMember]
        public System.Guid ID { get; set; }
         [DataMember]
        public string StepName { get; set; }
         [DataMember]
        public string StepStatus { get; set; }
         [DataMember]
        public System.DateTime StepDate { get; set; }
        [DataMember]
         public string StepExecutedBy { get; set; }
         [DataMember]
        public int StepOrder { get; set; }
         [DataMember]
        public string StepType { get; set; }
         [DataMember]
        public int StepIsManual { get; set; }
         [DataMember]
        public Nullable<bool> StepIsStart { get; set; }
        [DataMember]
         public Nullable<bool> StepIsEnd { get; set; }
         [DataMember]
        public string TransistionName { get; set; }
         [DataMember]
        public Nullable<bool> IsWorkflowStart { get; set; }
         [DataMember]
        public Nullable<bool> IsWorkflowEnd { get; set; }
         [DataMember]
        public Nullable<System.Guid> WorkflowTransistionID { get; set; }
         [DataMember]
        public Nullable<System.Guid> WorkflowInstanceID { get; set; }
          [DataMember]
        public int WorkflowInstanceExecutionStatusEventID { get; set; }
          [DataMember]
        public int WorkflowExecutionStatusID { get; set; }
          [DataMember]
        public int WorkflowInstanceExecutionID { get; set; }
          [DataMember]
        public Nullable<System.Guid> WorkflowInstanceSessionID { get; set; }
    }
}
