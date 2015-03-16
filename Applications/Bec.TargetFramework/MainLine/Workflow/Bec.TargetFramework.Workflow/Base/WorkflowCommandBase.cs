using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    public class WorkflowCommandBase : WorkflowComponentBase, IWorkflowCommand
    {
        public System.Guid WorkflowCommandID { get; set; }
        public Nullable<System.Guid> WorkflowObjectTypeID { get; set; }
        public System.Guid WorkflowID { get; set; }

        public bool ExecuteCommand
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
