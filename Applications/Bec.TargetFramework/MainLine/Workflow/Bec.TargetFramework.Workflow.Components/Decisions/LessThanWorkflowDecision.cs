using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Workflow.Interfaces;

namespace Bec.TargetFramework.Workflow.Components.Decisions
{
    public class LessThanWorkflowDecision : WorkflowDecisionBase
    {
        public override List<IWorkflowComponent> MakeDecision()
        {
            int number = (int) Data["MyNumber"];

            if(number < 10)
            {
                SuccessComponents.ToList().ForEach(it => it.Initialise(this.ParentContainer,this.Data));

                return SuccessComponents;
            }
            else
            {
                FailureComponents.ToList().ForEach(it => it.Initialise(this.ParentContainer, this.Data));

                return FailureComponents;
            }
        }
    }
}
