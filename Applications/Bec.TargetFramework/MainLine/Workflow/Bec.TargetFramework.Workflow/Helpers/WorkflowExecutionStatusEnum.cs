using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Helpers
{
    public enum WorkflowExecutionStatusEnum
    {
        Initialized=1,
        Closed=2,
        Executing=3,
        WaitingForComponents=4,
        WaitingForInput=5,
        Faulting=6,
        Compensating=7,
        Cancelling=8,
        Queued=9,
        Dequeued=10
    }
}
