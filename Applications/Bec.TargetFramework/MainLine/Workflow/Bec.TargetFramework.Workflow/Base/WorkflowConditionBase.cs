using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    public class WorkflowConditionBase : WorkflowComponentBase, IWorkflowCondition
    {
        public System.Guid WorkflowConditionID { get; set; }
        public Nullable<System.Guid> WorkflowObjectTypeID { get; set; }
        public System.Guid WorkflowID { get; set; }
        public bool ExecuteCondition
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
