﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 2/12/2015 3:31:04 PM
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
    /// There are no comments for Bec.TargetFramework.Data.ArtefactTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ArtefactTemplate    {

        public ArtefactTemplate()
        {
          this.ArtefactTemplateVersionNumber = 1;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ArtefactTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ArtefactTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ArtefactTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int ArtefactTemplateVersionNumber
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
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual bool IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual bool IsDeleted
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ArtefactProductTemplates in the schema.
        /// </summary>
        public virtual ICollection<ArtefactProductTemplate> ArtefactProductTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactSubscriptionTemplates in the schema.
        /// </summary>
        public virtual ICollection<ArtefactSubscriptionTemplate> ArtefactSubscriptionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationArtefactTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationArtefactTemplate> DefaultOrganisationArtefactTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Artefacts in the schema.
        /// </summary>
        public virtual ICollection<Artefact> Artefacts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactClaimTemplates in the schema.
        /// </summary>
        public virtual ICollection<ArtefactClaimTemplate> ArtefactClaimTemplates
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
        /// There are no comments for ArtefactNotificationConstructTemplates in the schema.
        /// </summary>
        public virtual ICollection<ArtefactNotificationConstructTemplate> ArtefactNotificationConstructTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactRoleTemplates in the schema.
        /// </summary>
        public virtual ICollection<ArtefactRoleTemplate> ArtefactRoleTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactDependencyTemplates_ArtefactTemplateID_ArtefactTemplateVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<ArtefactDependencyTemplate> ArtefactDependencyTemplates_ArtefactTemplateID_ArtefactTemplateVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleArtefactTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleArtefactTemplate> ModuleArtefactTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<StatusTypeTemplate> StatusTypeTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactDependencyTemplates_DependencyArtefactTemplateID_DependencyArtefactTemplateVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<ArtefactDependencyTemplate> ArtefactDependencyTemplates_DependencyArtefactTemplateID_DependencyArtefactTemplateVersionNumber
        {
            get;
            set;
        }

        #endregion
    }

}
