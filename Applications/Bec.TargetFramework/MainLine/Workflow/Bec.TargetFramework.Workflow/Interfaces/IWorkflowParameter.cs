using System;
namespace Bec.TargetFramework.Workflow.Interfaces
{
    public interface IWorkflowParameter
    {
        string Description { get; set; }
        string Name { get; set; }
        string ObjectType { get; set; }
        string ObjectValue { get; set; }
        int VersionNumber { get; set; }
        Guid WorkflowID { get; set; }
    }
}
