using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    public class WorkflowParameterBase : IWorkflowParameter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int VersionNumber { get; set; }
        public string ObjectType { get; set; }
        public string ObjectValue { get; set; }
        public Guid WorkflowID { get; set; }
    }
}
