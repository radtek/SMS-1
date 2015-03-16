using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class WorkflowInstanceStatusOverviewDTO
    {
        [DataMember]
        public WorkflowInstanceDTO Instance { get; set; }
        [DataMember]
        public List<WorkflowInstanceStatusDTO> InstanceStatuses { get; set; }
        [DataMember]
        public string InstanceStatus { get; set; }

        public WorkflowInstanceStatusOverviewDTO()
        {
            InstanceStatuses = new List<WorkflowInstanceStatusDTO>();
        }
    }
}
