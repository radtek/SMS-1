using Bec.TargetFramework.Infrastructure.Log;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Interfaces
{
    using Bec.TargetFramework.Entities;

    public interface IWorkflowComponent
    {
        int WorkflowVersionNumber { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        Guid? PreviousComponentID { get;set;}

        int? NumberOfRetries { get; }

        Guid ID { get; set; }
        IWorkflowContainer ParentContainer { get; set; }
        

        // data can only be set internally
        ConcurrentDictionary<string, object> Data { get;set;}

        // Initialise Component with container and data
        void Initialise(IWorkflowContainer container, ConcurrentDictionary<string, object> data);

        List<IWorkflowParameter> Parameters { get;set;}

        IWorkflowObjectType ObjectType { get;set;}

        bool? IsFailure { get; set; }

        List<WorkflowErrorBaseDTO> Errors { get; set; }
        IWorkflowErrorHandler ErrorHandler { get; set; }

        bool HasErrors { get; set; }

        void AddWorkflowError(Exception ex);
    }
}
