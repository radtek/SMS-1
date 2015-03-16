using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Extensions;
namespace Bec.TargetFramework.Workflow.Components.Decisions
{
    class IsRegistrationWorkflowDecision : WorkflowDecisionBase
    {
        public override List<IWorkflowComponent> MakeDecision()
        {
            try
            {
                TemporaryAccountDTO data = base.GetData<TemporaryAccountDTO>(this.Data, WorkflowDataEnum.TemporaryAccountData.GetStringValue());
                if (data.IsRegistration)
                    base.IsSuccess = true;
                else
                    base.IsSuccess = false;

                return base.MakeDecision();
            }
            catch(Exception ex)
            {
                this.AddWorkflowError(ex);
                return base.FailureComponents;
            }
           
        }
    }
}
