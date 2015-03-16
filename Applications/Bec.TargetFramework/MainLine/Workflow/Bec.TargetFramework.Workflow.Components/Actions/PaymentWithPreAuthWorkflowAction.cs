using Bec.TargetFramework.Workflow.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Components.Actions
{
    class PaymentWithPreAuthWorkflowAction : WorkflowActionBase
    {
        public override bool PerformExecuteCommands()
        {
            //with preauth
            return base.PerformExecuteCommands();
        }
    }
}
