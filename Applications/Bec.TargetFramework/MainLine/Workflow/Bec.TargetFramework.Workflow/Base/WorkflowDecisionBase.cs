using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Workflow.Interfaces;
using System.Collections.Concurrent;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    public class WorkflowDecisionBase : WorkflowExecutionComponentBase, IWorkflowDecision
    {
        public bool IsSuccess { get; set; }
        public List<IWorkflowComponent> SuccessComponents { get; set; }
        public List<IWorkflowComponent> FailureComponents { get; set; }

        public List<IWorkflowComponent> ErrorComponents { get; set; }

        public virtual List<IWorkflowComponent> MakeDecision()
        {
            if (IsSuccess)
                return SuccessComponents;
            else
                return FailureComponents;
        }
    }
}
