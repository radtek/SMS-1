using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Interfaces
{
    public interface IWorkflowExecutionComponent
    {
        bool CanStart();
        bool CanComplete();

        bool PerformPreCommands();
        bool PerformExecuteCommands();
        bool PerformPostCommands();

        List<IWorkflowCommand> PreCommands { get; set; }
        List<IWorkflowCommand> PostCommands { get; set; }
        List<IWorkflowCommand> ExecuteCommands { get; set; }

        List<IWorkflowCondition> CompleteConditions { get; set; }

        List<IWorkflowCondition> StartConditions { get; set; }
    }
}
