using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Workflow.Interfaces;

namespace Bec.TargetFramework.Workflow.Test.Implementations
{
    public class Is100WorkflowDecision : WorkflowDecisionBase
    {
        public override List<IWorkflowComponent> MakeDecision()
        {
            int number = Convert.ToInt32(Data["MyNumber"]);

            if(number >= 100)
            {
                IsSuccess = true;
                Console.WriteLine("Over 100 Success");
                SuccessComponents.ToList().ForEach(it => it.Initialise(this.ParentContainer, this.Data));

                return SuccessComponents;
            }
            else
            {
                Console.WriteLine("Less than 100 Failure");
                FailureComponents.ToList().ForEach(it => it.Initialise(this.ParentContainer, this.Data));

                return FailureComponents;
            }
        }
    }
}
