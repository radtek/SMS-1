using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Workflow.Interfaces;
using Fabrik.Common;
using System.Collections.Concurrent;

namespace Bec.TargetFramework.Workflow.Base
{
    using Bec.TargetFramework.Entities;
    using System.Reflection;

    [Serializable]
    public class WorkflowActionBase: WorkflowExecutionComponentBase, IWorkflowAction
    {
        public override void Initialise(IWorkflowContainer container, ConcurrentDictionary<string, object> data)
        {
            if (container.WorkflowSettings.EnableWorkflowTrace)
                container.Logger.Trace("Workflow Action: Initialise " + container.WorkflowProcessHandler.CurrentComponent.ID + " data:" + data);

            base.Initialise(container, data);

            // create instances of classes
        }

        public virtual void PreProcessDataBeforeWebUI(WorkflowStateBaseDTO data)
        {
        }

        public virtual void PostProcessDataAfterWebUI(WorkflowStateBaseDTO data)
        {
        }

       
    }
}
