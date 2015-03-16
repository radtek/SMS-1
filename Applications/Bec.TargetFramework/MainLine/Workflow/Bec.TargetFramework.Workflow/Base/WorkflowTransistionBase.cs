using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Workflow.Interfaces;
using ServiceStack.Text;
using System.Collections.Concurrent;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    public class WorkflowTransistionBase : WorkflowExecutionComponentBase,IWorkflowTransistion
    {
        public List<IWorkflowMainComponent> TransistionComponents { get;set;}
        public List<IWorkflowHierarchyComponent> TransistionHierarchy { get; set; }
        public List<IWorkflowComponent> WorkflowComponentExecutionHistory { get; set; }
        public List<IWorkflowTransistionHistory> TransistionHistory { get; set; }

        public string TransistionStatus { get; set; }

        public WorkflowTransistionBase()
        {
            TransistionHistory = new List<IWorkflowTransistionHistory>();
        }
        
    }
}
