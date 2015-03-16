using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Workflow.Base;

namespace Bec.TargetFramework.Workflow.Test.Implementations
{
    public class ManualWorkflowAction : WorkflowActionBase
    {
        public override bool PerformExecuteCommands()
        {
            Console.WriteLine("Enter Number " + this.Name);

            string args = Console.ReadLine();

            Data["MyNumber"] = int.Parse(args);

            return !string.IsNullOrEmpty(args);
        }

        public override bool CanStart()
        {
           return true;
        }
    }
}
