using Bec.TargetFramework.Workflow.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Components.Actions
{
    class IDCheckWorkflowAction : WorkflowActionBase
    {
        public override bool PerformExecuteCommands()
        {
            // pass experian the credentials and get the result
            return base.PerformExecuteCommands();
        }
    }
}
