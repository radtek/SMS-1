using System;
namespace Bec.TargetFramework.Workflow.Interfaces
{
    public interface IWorkflowObjectType
    {
        string Description { get; set; }
        string Name { get; set; }
        string ObjectTypeAssembly { get; set; }
        string ObjectTypeName { get; set; }
        string ObjectTypeNameSpace { get; set; }
        int VersionNumber { get; set; }
        Guid WorkflowObjectTypeID { get; set; }
        Guid WorkflowID { get; set; }

        T CreateInstanceOfObject<T>();
    }
}
