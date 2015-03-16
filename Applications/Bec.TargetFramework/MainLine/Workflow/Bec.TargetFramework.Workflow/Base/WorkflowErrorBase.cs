using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    public class WorkflowErrorBase : IWorkflowError
    {
        private Exception m_WorkflowException;
        public Exception WorkflowException
        {
            get
            {
                return m_WorkflowException;
            }
            set
            {
                m_WorkflowException = value;
            }
        }
    }
}
