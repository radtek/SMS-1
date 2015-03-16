using Bec.TargetFramework.Workflow.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Components.Actions
{
    class PaymentWithoutPreAuthWorkflowAction : WorkflowActionBase
    {
        public override bool PerformExecuteCommands()
        {
            //show without preauth payment screens
            bool HasUserPerformed = false;
            try
            {
                //based on some condition set HasUserPerformed true
                HasUserPerformed = this.Data.ContainsKey("PayClicked") && this.Data["PayClicked"].Equals("true") ? true : false;
            }
            catch (Exception ex)
            {
                this.AddWorkflowError(ex);
                return false;
            }
            return HasUserPerformed;
        }
    }
}
