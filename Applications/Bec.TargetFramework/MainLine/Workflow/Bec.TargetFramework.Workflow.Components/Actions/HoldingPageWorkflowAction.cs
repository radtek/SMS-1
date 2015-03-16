using Bec.TargetFramework.Workflow.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Components.Actions
{
    public class HoldingPageWorkflowAction : WorkflowActionBase
    {
        public override bool PerformExecuteCommands()
        {
            // show holding page
            return base.PerformExecuteCommands();
        }
    }
}
