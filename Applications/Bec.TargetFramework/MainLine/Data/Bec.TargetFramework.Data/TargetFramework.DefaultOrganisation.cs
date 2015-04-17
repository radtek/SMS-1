﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 17/04/2015 16:46:51
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
    /// There are no comments for Bec.TargetFramework.Data.DefaultOrganisation in the schema.
    /// </summary>
    [System.Serializable]
    public partial class DefaultOrganisation    {

        public DefaultOrganisation()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultOrganisationID
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
        /// There are no comments for DefaultOrganisationVersionNumber in the schema.
        /// </summary>
        public virtual int DefaultOrganisationVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultOrganisationTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> DefaultOrganisationTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultOrganisationTemplateVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DefaultOrganisationTemplateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationTypeID in the schema.
        /// </summary>
        public virtual int OrganisationTypeID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationLedgers in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationLedger> DefaultOrganisationLedgers
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationModules in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationModule> DefaultOrganisationModules
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationStatusTypes in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationStatusType> DefaultOrganisationStatusTypes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationProducts in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationProduct> DefaultOrganisationProducts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationTargets in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationTarget> DefaultOrganisationTargets
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationUserTargets in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationUserTarget> DefaultOrganisationUserTargets
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationTemplate in the schema.
        /// </summary>
        public virtual DefaultOrganisationTemplate DefaultOrganisationTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationType in the schema.
        /// </summary>
        public virtual OrganisationType OrganisationType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationNotificationConstructs in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationNotificationConstruct> DefaultOrganisationNotificationConstructs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationWorkflows in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationWorkflow> DefaultOrganisationWorkflows
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationUserTypes in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationUserType> DefaultOrganisationUserTypes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationBranches in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationBranch> DefaultOrganisationBranches
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
        /// There are no comments for DefaultOrganisationGroups in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationGroup> DefaultOrganisationGroups
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationRoles in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationRole> DefaultOrganisationRoles
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BucketTemplates in the schema.
        /// </summary>
        public virtual ICollection<BucketTemplate> BucketTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationShoppingCartBlueprints in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationShoppingCartBlueprint> DefaultOrganisationShoppingCartBlueprints
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationPaymentMethods in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationPaymentMethod> DefaultOrganisationPaymentMethods
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Organisations in the schema.
        /// </summary>
        public virtual ICollection<Organisation> Organisations
        {
            get;
            set;
        }

        #endregion
    }

}
