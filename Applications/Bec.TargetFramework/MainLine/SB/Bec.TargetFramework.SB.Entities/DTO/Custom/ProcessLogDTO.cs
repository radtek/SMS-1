using Bec.TargetFramework.SB.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Entities
{
    [DataContract]
    public class ProcessLogDTO
    {
        [DataMember]
        public bool HasError { get; set; }
        [DataMember]
        
        public string ProcessMessage { get; set; }
        [DataMember]
        
        public bool IsComplete { get; set; }
        [DataMember]
        
        public string ProcessDetail { get; set; }
        [DataMember]
        
        public int NumberOfRetries { get; set; }
        [DataMember]
        public VBusTaskScheduleDTO ScheduleDto { get; set; }
        [DataMember]
        public Guid? ParentID { get; set; }
        [DataMember]
        public BusTaskStatusEnum StatusValue { get; set; }
    }
}
