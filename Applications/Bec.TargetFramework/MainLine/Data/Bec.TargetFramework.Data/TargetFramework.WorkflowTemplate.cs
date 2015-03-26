﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 26/03/2015 16:14:57
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Bec.TargetFramework.Data
{

    /// <summary>
    /// There are no comments for Bec.TargetFramework.Data.WorkflowTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowTemplate    {

        public WorkflowTemplate()
        {
          this.WorkflowTemplateVersionNumber = 0;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int WorkflowTemplateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> WorkflowTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> WorkflowSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> WorkflowCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> WorkflowSubCategoryID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationWorkflowTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationWorkflowTemplate> DefaultOrganisationWorkflowTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorflowParameterTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorflowParameterTemplate> WorflowParameterTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowClaimTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowClaimTemplate> WorkflowClaimTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowCommandConditionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowCommandConditionTemplate> WorkflowCommandConditionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowCommandParameterTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowCommandParameterTemplate> WorkflowCommandParameterTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowCommandTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowCommandTemplate> WorkflowCommandTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionCompleteConditionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionCompleteConditionTemplate> WorkflowTransistionCompleteConditionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionStartConditionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionStartConditionTemplate> WorkflowTransistionStartConditionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionWorkflowActionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionWorkflowActionTemplate> WorkflowTransistionWorkflowActionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowStatusTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowStatusTypeTemplate> WorkflowStatusTypeTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationUserTargetTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationUserTargetTemplate> DefaultOrganisationUserTargetTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleWorkflowTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleWorkflowTemplate> ModuleWorkflowTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowConditionParameterTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowConditionParameterTemplate> WorkflowConditionParameterTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionParameterTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionParameterTemplate> WorkflowTransistionParameterTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionHierarchyTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionHierarchyTemplate> WorkflowTransistionHierarchyTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Workflows in the schema.
        /// </summary>
        public virtual ICollection<Workflow> Workflows
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionTemplate> WorkflowDecisionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowHierarchyTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowHierarchyTemplate> WorkflowHierarchyTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowObjectTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowObjectTypeTemplate> WorkflowObjectTypeTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionTemplate> WorkflowActionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionTemplate> WorkflowTransistionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowRoleTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowRoleTemplate> WorkflowRoleTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowNotificationConstructTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowNotificationConstructTemplate> WorkflowNotificationConstructTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactWorkflowTemplates in the schema.
        /// </summary>
        public virtual ICollection<ArtefactWorkflowTemplate> ArtefactWorkflowTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructGroupNotificationConstructTemplates in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructGroupNotificationConstructTemplate> NotificationConstructGroupNotificationConstructTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowParameterTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowParameterTemplate> WorkflowParameterTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowCommandTemplate1s in the schema.
        /// </summary>
        public virtual ICollection<WorkflowCommandTemplate1> WorkflowCommandTemplate1s
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowMainParameterTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowMainParameterTemplate> WorkflowMainParameterTemplates
        {
            get;
            set;
        }

        #endregion
    }

}
