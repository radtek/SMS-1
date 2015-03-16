using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Workflow.Base;

namespace Bec.TargetFramework.Workflow.Test.Implementations
{
    public class SubtractWorkflowAction : WorkflowActionBase
    {
        public override bool PerformExecutions()
        {
            int number = (int) Data["MyNumber"];

            Data["MyNumber"] = number - 1;

            return true;
        }
    }
}
