using Bec.TargetFramework.Workflow.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Components.Actions
{
    class TermsConditionCOWorkflowAction : WorkflowActionBase
    {
        public override bool PerformExecuteCommands()
        {
            //show COLP's terms and conditions

            bool HasUserPerformed = false;

            try
            {
                if (this.Data.ContainsKey("TCClicked"))
                {
                    HasUserPerformed = this.Data["TCClicked"].Equals("true") ? true : false;
                }
            }
            catch (Exception ex)
            {
                this.AddWorkflowError(ex);

            }
            return HasUserPerformed;
        }
    }
}
