using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Workflow.Interfaces;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Bec.TargetFramework.Workflow.Providers;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.Workflow.Base
{
    //Bec.TargetFramework.Entities
    using Bec.TargetFramework.Workflow.Configuration;
    using Bec.TargetFramework.Entities;
    using Bec.TargetFramework.Entities.Settings;
using Bec.TargetFramework.Entities.DTO.Workflow;
    [Serializable]
    public class WorkflowContainerBase : WorkflowExecutionComponentBase, IWorkflowContainer
    {
        public IWorkflowHierarchy Hierarchy { get;set;}
        public List<IWorkflowComponent> Components { get; set; }
        public IWorkflowProcessHandler WorkflowProcessHandler { get;set;}
        public List<IWorkflowTransistion> Transistions { get; set; }
        public WorkflowTransistionHierarchyBase TransistionHierarchy { get; set; }

        public IWorkflowInstance WorkflowInstance { get; set; }

        public DbWorkflowProvider WorkflowProvider { get; set; }
        public DbWorkflowInstanceProvider WorkflowInstanceProvider { get; set; }
        public DbWorkflowTemplateProvider WorkflowTemplateProvider { get; set; }

        public List<WorkflowRoleDTO> WorkflowRoles
        {
            get;
            set;
        }

        public List<WorkflowClaimDTO> WorkflowClaims
        {
            get;
            set;
        }

        public ILogger Logger { get; set; }

        public WorkflowSettings WorkflowSettings { get; set; }

        public WorkflowContainerBase(WorkflowSettings setting,ILogger logger, DbWorkflowProvider wProvider, DbWorkflowInstanceProvider wIProvider,
            DbWorkflowTemplateProvider wTProvider)
        {
            WorkflowSettings = setting;
            Logger = logger;
            WorkflowProvider = wProvider;
            WorkflowInstanceProvider = wIProvider;
            WorkflowTemplateProvider = wTProvider;
        }

        public void InitialiseContainer(ConcurrentDictionary<string, object> data)
        {
            Data = data;

            WorkflowProcessHandler = new WorkflowProcessHandler(this);
        }

        public void InitialiseContainerAndCreateInstance(ConcurrentDictionary<string, object> data, Guid parentID,bool notStarted, List<UserAccountOrganisationDTO> workflowUsers = null)
        {
            Data = data;

            WorkflowInstance = WorkflowProvider.CreateInstance(ID, WorkflowVersionNumber, parentID);
            WorkflowProcessHandler = new WorkflowProcessHandler(this);

            WorkflowInstance.Initialise(this);

            if(notStarted)
                WorkflowInstance.TempData = new WorkflowDictionaryDTO{ WorkflowDictionary = data};

            // save initial instance
            WorkflowInstanceProvider.Save(WorkflowInstance);
        }

        public void UpdateInstance(IWorkflowInstance instance)
        {
            WorkflowInstance = WorkflowProvider.ModifyInstanceStatus(instance);
            //update instance with inprogress status
            WorkflowInstanceProvider.Update(WorkflowInstance);
        }

        public void InitialiseContainerFromInstance(Guid instanceID)
        {
            this.LogTrace("Workflow Container: Initialize Workflow Instance :" + instanceID);

            WorkflowInstance = WorkflowInstanceProvider.Load(instanceID);
            WorkflowInstance.Initialise(this);

            WorkflowProcessHandler = new WorkflowProcessHandler(this);
        }

        public void InitialiseContainerFromInstance(IWorkflowInstance instance)
        {
            this.LogTrace("Workflow Container: Initialize Workflow Instance :" + instance.ID);

            WorkflowInstance = instance;
            WorkflowInstance.Initialise(this);

            WorkflowProcessHandler = new WorkflowProcessHandler(this);
        }

        public void LogTrace(string message)
        {
            string instanceID = string.Empty;

            if (WorkflowInstance != null) instanceID = WorkflowInstance.ID.ToString();

            if (this.WorkflowSettings.EnableWorkflowTrace)
                this.Logger.Trace(
                    new TargetFrameworkLogDTO
                        {
                            WorkflowInstanceID = instanceID,
                            ApplicationSource = "Workflow",
                            Message = message,
                            UserID = Environment.UserName,
                            ApplicationSourceType = "WorkflowContainer"
                        });
        }
        
    }
}
