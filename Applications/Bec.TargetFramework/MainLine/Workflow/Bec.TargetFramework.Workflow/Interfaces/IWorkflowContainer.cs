using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities.Workflow;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Workflow.Providers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Interfaces
{
    using Bec.TargetFramework.Entities;
    using Bec.TargetFramework.Entities.Settings;
    //Bec.TargetFramework.Entities
    using Bec.TargetFramework.Workflow.Configuration;

    public interface IWorkflowContainer : IWorkflowMainComponent, IWorkflowExecutionComponent
    {
        WorkflowSettings WorkflowSettings { get; set; }
        IWorkflowHierarchy Hierarchy { get; set; }
        List<IWorkflowComponent> Components { get; set; }

        List<IWorkflowTransistion> Transistions { get; set; }

        WorkflowTransistionHierarchyBase TransistionHierarchy { get; set; }

        IWorkflowProcessHandler WorkflowProcessHandler { get;set;}

        List<WorkflowRoleDTO> WorkflowRoles
        {
            get; set; 
        } 

        List<WorkflowClaimDTO> WorkflowClaims { get; set; }

        void InitialiseContainer(ConcurrentDictionary<string, object> data);

        void InitialiseContainerAndCreateInstance(ConcurrentDictionary<string, object> data, Guid parentID,bool notStarted, List<UserAccountOrganisationDTO> workflowUsers = null );

        void InitialiseContainerFromInstance(Guid instanceID);

        void UpdateInstance(IWorkflowInstance instance);

        IWorkflowInstance WorkflowInstance { get; set; }

        DbWorkflowProvider WorkflowProvider { get; set; }
        DbWorkflowInstanceProvider WorkflowInstanceProvider { get; set; }
        DbWorkflowTemplateProvider WorkflowTemplateProvider { get; set; }
        ILogger Logger { get; set; }

         void InitialiseContainerFromInstance(IWorkflowInstance instance);

        void LogTrace(string message);

    }
}
