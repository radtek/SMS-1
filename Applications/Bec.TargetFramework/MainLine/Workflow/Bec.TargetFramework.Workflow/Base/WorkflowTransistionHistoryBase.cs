using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Base
{
    using Bec.TargetFramework.Entities;
    [Serializable]
    public class WorkflowTransistionHistoryBase : IWorkflowTransistionHistory
    {
        public Guid TransistionID { get;set;}
        public DateTime CreatedOn { get; set; }
        public Guid WorkflowComponentID { get; set; }
        public WorkflowStateBaseDTO WorkflowState { get; set; }

    }
}
