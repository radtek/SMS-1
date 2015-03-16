using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Workflow.Interfaces;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    public class WorkflowHierarchyComponentBase : WorkflowComponentBase, IWorkflowHierarchyComponent
    {
        public IWorkflowMainComponent ChildComponent { get;set;}
        public IWorkflowMainComponent ParentComponent { get;set;}

        public bool IsStart {get;set;}
        public bool IsEnd {get;set;}
        public bool IsCriticalPath {get;set;}

        public bool? IsFailure { get; set; }

        public bool IsChildDependentOnParent {get;set;}

    }
}
