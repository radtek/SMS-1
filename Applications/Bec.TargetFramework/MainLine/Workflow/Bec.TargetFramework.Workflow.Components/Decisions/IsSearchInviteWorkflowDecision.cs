﻿using Bec.TargetFramework.Entities;
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
    class IsSearchInviteWorkflowDecision : WorkflowDecisionBase
    {
        public override List<IWorkflowComponent> MakeDecision()
        {
            TemporaryAccountDTO data = base.GetData<TemporaryAccountDTO>(this.Data, WorkflowDataEnum.TemporaryAccountData.GetStringValue());
            if (data.IsSearchInvite)
                base.IsSuccess = true;
            else
                base.IsSuccess = false;

            return base.MakeDecision();
        }
    }
}
