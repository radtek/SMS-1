using Bec.TargetFramework.Workflow.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Components.Actions
{
    class FirmDetailsCOWorkflowAction : WorkflowActionBase
    {
        public override bool PerformExecuteCommands()
        {
            // show firm details script
            bool HasUserPerformed = false;
            try
            {
                //based on some condition set HasUserPerformed true
                HasUserPerformed = this.Data.ContainsKey("FDClicked") && this.Data["FDClicked"].Equals("true") ? true : false;
            }
            catch (Exception ex)
            {
                this.AddWorkflowError(ex);
                return false;
            }
            return HasUserPerformed;
           // return base.PerformExecuteCommands();
        }
    }
}
