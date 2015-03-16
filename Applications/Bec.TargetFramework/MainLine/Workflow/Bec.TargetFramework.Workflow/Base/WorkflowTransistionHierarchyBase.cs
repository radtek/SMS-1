using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Workflow.Interfaces;
using System.Collections.Concurrent;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    public class WorkflowTransistionHierarchyBase : WorkflowComponentBase
    {
        public List<WorkflowTransistionHierarchyComponentBase> Hierarchy { get; set; }

        public WorkflowTransistionHierarchyBase()
        {
            Hierarchy = new List<WorkflowTransistionHierarchyComponentBase>();
        }
    }
}
