using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Interfaces
{
    public interface IWorkflowMainComponent : IWorkflowComponent
    {
        bool IsStart { get; set; }
        bool IsEnd { get; set; }
        bool IsManual { get; set; }

        bool IsWaitingForComponents { get; set; }

        bool IsWaitingForInput { get; set; }

        List<IWorkflowComponent> WaitingForComponents { get; set; }


    }
}
