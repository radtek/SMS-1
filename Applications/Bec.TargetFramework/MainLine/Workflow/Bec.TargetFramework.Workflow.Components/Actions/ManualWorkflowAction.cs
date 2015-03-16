using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Workflow.Base;

namespace Bec.TargetFramework.Workflow.Components.Actions
{
    using Bec.TargetFramework.Aop.Aspects;

    [Trace(TraceExceptionsOnly = true)]
    public class ManualWorkflowAction : WorkflowActionBase
    {
        
        public override bool PerformExecuteCommands()
        {
            bool pass = true;

            try
            {
                string args = "12";

                Data["MyNumber"] = int.Parse(args);

                throw new Exception("boo");

                return !string.IsNullOrEmpty(args);
            }
            catch (Exception ex)
            {
                this.AddWorkflowError(ex);
                pass = false;
            }

            return pass;

        }

        public override bool CanStart()
        {
            // manual so blah
           return true;
        }
    }
}
