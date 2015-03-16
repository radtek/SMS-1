using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    public class WorkflowMainComponentBase : WorkflowComponentBase, IWorkflowMainComponent
    {
        public bool IsStart {get;set;}

        public bool IsEnd { get; set; }

        public bool IsManual {get;set;}

        public bool IsWaitingForComponents {get;set;}

        public bool IsWaitingForInput {get;set;}

        public List<IWorkflowComponent> WaitingForComponents {get;set;}
    }
}
