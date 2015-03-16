using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Collections;
using Bec.TargetFramework.Workflow.Interfaces;

namespace Bec.TargetFramework.Workflow
{
    using Bec.TargetFramework.Entities;
    using Bec.TargetFramework.Workflow.Base;

    public interface IWorkflowAction : IWorkflowMainComponent, IWorkflowExecutionComponent
    {
        void PreProcessDataBeforeWebUI(WorkflowStateBaseDTO data);

        void PostProcessDataAfterWebUI(WorkflowStateBaseDTO data);
    }
}
