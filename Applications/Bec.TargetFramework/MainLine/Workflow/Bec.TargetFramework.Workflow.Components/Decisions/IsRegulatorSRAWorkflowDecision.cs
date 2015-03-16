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
    public class IsRegulatorSRAWorkflowDecision : WorkflowDecisionBase
    {
        public override List<IWorkflowComponent> MakeDecision()
        {
            try
            {
                if (DataContains(WorkflowDataEnum.PersonalDetailData.GetStringValue()))
                {
                    var data = base.GetData<PersonalDetailDTO>(this.Data, WorkflowDataEnum.PersonalDetailData.GetStringValue());

                    if (data.RegulatorTypeID == RegulatorIDEnum.SRA.GetIntValue())
                        IsSuccess = true;
                    else
                        IsSuccess = false;
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
