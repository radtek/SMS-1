using Bec.TargetFramework.Workflow.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Components.Actions
{
    class NextStepsCORegisterWorkflowAction : WorkflowActionBase
    {
        public override bool PerformExecuteCommands()
        {
            // show Co next steps using webcontroller WIP
            //return base.PerformExecuteCommands();
            bool HasUserPerformed = false;

            try
            {
                //get the button cicked name and take decision based on this);
                if (this.Data.ContainsKey("NSClicked"))
                {
                    HasUserPerformed = this.Data["NSClicked"].Equals("true") ? true : false;
                }
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
