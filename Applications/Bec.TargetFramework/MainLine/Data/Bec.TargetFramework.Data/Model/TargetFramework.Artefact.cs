﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
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
    /// There are no comments for Bec.TargetFramework.Data.Artefact in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Artefact    {

        public Artefact()
        {
          this.ArtefactVersionNumber = 1;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ArtefactID in the schema.
        /// </summary>
        public virtual global::System.Guid ArtefactID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ArtefactVersionNumber in the schema.
        /// </summary>
        public virtual int ArtefactVersionNumber
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ArtefactProducts in the schema.
        /// </summary>
        public virtual ICollection<ArtefactProduct> ArtefactProducts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationArtefacts in the schema.
        /// </summary>
        public virtual ICollection<OrganisationArtefact> OrganisationArtefacts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactTemplate in the schema.
        /// </summary>
        public virtual ArtefactTemplate ArtefactTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactSubscriptions in the schema.
        /// </summary>
        public virtual ICollection<ArtefactSubscription> ArtefactSubscriptions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleArtefacts in the schema.
        /// </summary>
        public virtual ICollection<ModuleArtefact> ModuleArtefacts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationArtefacts in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationArtefact> DefaultOrganisationArtefacts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactClaims in the schema.
        /// </summary>
        public virtual ICollection<ArtefactClaim> ArtefactClaims
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactNotificationConstructs in the schema.
        /// </summary>
        public virtual ICollection<ArtefactNotificationConstruct> ArtefactNotificationConstructs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactDependencies_ArtefactID_ArtefactVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<ArtefactDependency> ArtefactDependencies_ArtefactID_ArtefactVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactRoles in the schema.
        /// </summary>
        public virtual ICollection<ArtefactRole> ArtefactRoles
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypes in the schema.
        /// </summary>
        public virtual ICollection<StatusType> StatusTypes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactDependencies_DependencyArtefactID_DependencyArtefactVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<ArtefactDependency> ArtefactDependencies_DependencyArtefactID_DependencyArtefactVersionNumber
        {
            get;
            set;
        }

        #endregion
    }

}
