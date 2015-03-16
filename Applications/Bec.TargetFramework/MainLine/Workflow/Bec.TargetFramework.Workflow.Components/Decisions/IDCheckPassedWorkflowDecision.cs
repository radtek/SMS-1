﻿using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Components.Decisions
{
    public class IDCheckPassedWorkflowDecision : WorkflowDecisionBase
    {
        public override List<IWorkflowComponent> MakeDecision()
        {

            //return base.MakeDecision();

            return SuccessComponents;
        }
    }
}
