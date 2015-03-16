using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Workflow.Interfaces;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    public class WorkflowTransistionHierarchyComponentBase
    {
        public WorkflowTransistionBase ChildComponent { get; set; }
        public WorkflowTransistionBase ParentComponent { get; set; }

        public bool IsWorkflowStart { get; set; }
        public bool IsWorkflowEnd { get; set; }
        public bool IsCriticalPath { get; set; }
    }
}
