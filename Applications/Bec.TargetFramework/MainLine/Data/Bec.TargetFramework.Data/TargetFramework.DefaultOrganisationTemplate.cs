﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 02/04/2015 16:41:46
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
    /// There are no comments for Bec.TargetFramework.Data.DefaultOrganisationTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class DefaultOrganisationTemplate    {

        public DefaultOrganisationTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultOrganisationTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultOrganisationTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int DefaultOrganisationTemplateVersionNumber
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
        /// There are no comments for DefaultOrganisationProductTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationProductTemplate> DefaultOrganisationProductTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationUserTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationUserTypeTemplate> DefaultOrganisationUserTypeTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationLedgerTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationLedgerTemplate> DefaultOrganisationLedgerTemplates
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
        /// There are no comments for DefaultOrganisationNotificationConstructTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationNotificationConstructTemplate> DefaultOrganisationNotificationConstructTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationModuleTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationModuleTemplate> DefaultOrganisationModuleTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationBranchTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationBranchTemplate> DefaultOrganisationBranchTemplates
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
        /// There are no comments for DefaultOrganisationWorkflowTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationWorkflowTemplate> DefaultOrganisationWorkflowTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationRoleTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationRoleTemplate> DefaultOrganisationRoleTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationTargetTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationTargetTemplate> DefaultOrganisationTargetTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationStatusTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationStatusTypeTemplate> DefaultOrganisationStatusTypeTemplates
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
        /// There are no comments for DefaultOrganisationGroupTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationGroupTemplate> DefaultOrganisationGroupTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisations in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisation> DefaultOrganisations
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
        /// There are no comments for DefaultOrganisationShoppingCartBlueprintTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationShoppingCartBlueprintTemplate> DefaultOrganisationShoppingCartBlueprintTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationPaymentMethodTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationPaymentMethodTemplate> DefaultOrganisationPaymentMethodTemplates
        {
            get;
            set;
        }

        #endregion
    }

}
