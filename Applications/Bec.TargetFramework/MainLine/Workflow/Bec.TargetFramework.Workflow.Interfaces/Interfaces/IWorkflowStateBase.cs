using System;
namespace Bec.TargetFramework.Workflow.Interfaces
{
    public interface IWorkflowStateBase
    {
        Guid CurrentWorkflowComponentID { get; set; }
        System.Collections.Concurrent.ConcurrentDictionary<string, object> Data { get; set; }
        System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<Guid, Guid>> Queue { get; set; }

        Guid? TransistionID { get; set; }
        Guid? PreviousCurrentWorkflowComponentID { get; set; }
    }
}
