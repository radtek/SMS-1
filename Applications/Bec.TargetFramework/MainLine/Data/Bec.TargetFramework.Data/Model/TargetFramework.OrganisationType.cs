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
    /// There are no comments for Bec.TargetFramework.Data.OrganisationType in the schema.
    /// </summary>
    [System.Serializable]
    public partial class OrganisationType    {

        public OrganisationType()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationTypeID in the schema.
        /// </summary>
        public virtual int OrganisationTypeID
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
        /// There are no comments for DefaultOrganisationTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationTemplate> DefaultOrganisationTemplates
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
        /// There are no comments for DefaultOrganisationTargetTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationTargetTemplate> DefaultOrganisationTargetTemplates
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
        /// There are no comments for ComponentTierTemplates in the schema.
        /// </summary>
        public virtual ICollection<ComponentTierTemplate> ComponentTierTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ComponentTiers in the schema.
        /// </summary>
        public virtual ICollection<ComponentTier> ComponentTiers
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Discounts in the schema.
        /// </summary>
        public virtual ICollection<Discount> Discounts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DiscountTemplates in the schema.
        /// </summary>
        public virtual ICollection<DiscountTemplate> DiscountTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Deductions in the schema.
        /// </summary>
        public virtual ICollection<Deduction> Deductions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DeductionTemplates in the schema.
        /// </summary>
        public virtual ICollection<DeductionTemplate> DeductionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructGroupNotificationConstructs in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructGroupNotificationConstruct> NotificationConstructGroupNotificationConstructs
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
        /// There are no comments for NotificationConstructTargetTemplates in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructTargetTemplate> NotificationConstructTargetTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructTargets in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructTarget> NotificationConstructTargets
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ResourceOperationTargets in the schema.
        /// </summary>
        public virtual ICollection<ResourceOperationTarget> ResourceOperationTargets
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