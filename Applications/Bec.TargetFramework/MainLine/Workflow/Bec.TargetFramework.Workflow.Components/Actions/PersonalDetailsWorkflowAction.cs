using Bec.TargetFramework.Workflow.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Components.Actions
{
    class PersonalDetailsWorkflowAction : WorkflowActionBase
    {
        public override bool PerformExecuteCommands()
        {
           // show personal details screen
           // return base.PerformExecuteCommands();
            bool HasUserPerformed = false;
            try
            {
                 if (this.Data.ContainsKey("PDClicked"))
                 {
                //based on some condition set HasUserPerformed true
                    HasUserPerformed = this.Data["PDClicked"].Equals("true") ? true : false;
                 }
            }
            catch (Exception ex)
            {
                this.AddWorkflowError(ex);
                return false;
            }
            return HasUserPerformed;
          //  return base.PerformExecuteCommands();
        }
    }
}
