using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Interfaces
{
    public interface IWorkflowHierarchyComponent
    {
        IWorkflowMainComponent ChildComponent { get; set; }
        IWorkflowMainComponent ParentComponent { get; set; }

        bool IsStart { get; set; }
        bool IsEnd { get; set; }

        bool IsCriticalPath { get; set; }

        bool? IsFailure { get; set; }

        bool IsChildDependentOnParent { get; set; }
    }
}
