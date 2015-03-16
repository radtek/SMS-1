using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class WorkflowInstanceStatusDTO
    {
        [DataMember]
        public string StepName { get; set; }
        [DataMember]
        public string StepStatus { get; set; }
        [DataMember]
        public Nullable<System.Guid> WorkflowinstanceID { get; set; }
        [DataMember]
        public int WorkflowInstanceExecutionStatusEventID { get; set; }
    }
}
