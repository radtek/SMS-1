using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    public class WorkflowErrorBaseDTO
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
