using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
namespace Bec.TargetFramework.Workflow.Components.Decisions
{
    class NextOrPreviousWorkflowDecision : WorkflowDecisionBase
    {
        public override List<IWorkflowComponent> MakeDecision()
        {

            try
            {
                if (this.Data.ContainsKey(WorkflowClickEnum.NextClicked.GetStringValue()) && this.Data["NextClicked"].Equals("true"))
                {
                    IsSuccess = true;

                    return SuccessComponents;
                }
                else
                {
                    IsSuccess = false;
                    return FailureComponents;
                }
            }
            catch (Exception ex)
            {
                this.AddWorkflowError(ex);
            }

            return base.MakeDecision();
        }
    }
}
