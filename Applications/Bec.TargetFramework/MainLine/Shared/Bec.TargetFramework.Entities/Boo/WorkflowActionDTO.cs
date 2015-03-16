
using System.Runtime.Serialization;
namespace Bec.TargetFramework.Entities
{

    public partial class WorkflowActionDTO
    {

        [DataMember]
        public bool IsWaitingForComponents { get; set; }
        [DataMember]
        public bool IsWaitingForInput {get;set;}
        [DataMember]
        public bool? IsFailure { get; set; }
        [DataMember]
       
        public string ActionName { get; set; }
        [DataMember]
       
        public string ControllerName { get; set; }
        [DataMember]
       
        public string AreaName { get; set; }
        [DataMember]
        public int WorkflowInstanceExecutionStatusEventID { get; set; }
    }
}
