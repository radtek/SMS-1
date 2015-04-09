using Bec.TargetFramework.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.Settings
{
    public class WorkflowSettings : ISettings
    {
        public bool LogWorkflowTaskSchedulerCommands { get; set; }

        public bool EnableWorkflowTrace { get; set; }

        public int GapBetweenProcessingTasksMilliseconds { get; set; }
    }
}
