using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    public class WorkflowInstanceSessionBase
    {
        public System.Guid WorkflowInstanceSessionID { get; set; }
        public Nullable<System.Guid> WorkflowInstanceID { get; set; }
        public System.DateTime SessionStartedOn { get; set; }
        public System.DateTime SessionEndedOn { get; set; }
    }
}
