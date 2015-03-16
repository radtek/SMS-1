using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    [DataContract]
    public class WorkflowStateBase : IWorkflowStateBase
    {
        [DataMember]
        public ConcurrentDictionary<string, object> Data { get;set;}
        [DataMember]
        public Guid CurrentWorkflowComponentID { get;set;}

        [DataMember]
        public List<KeyValuePair<Guid,Guid>> Queue { get;set;}
        [DataMember]
        public Guid? PreviousCurrentWorkflowComponentID { get; set; }
        [DataMember]
        public Guid? TransistionID { get; set; }
    }
}
