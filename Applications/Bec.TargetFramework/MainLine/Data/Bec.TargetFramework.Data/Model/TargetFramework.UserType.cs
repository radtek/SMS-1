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
    /// There are no comments for Bec.TargetFramework.Data.UserType in the schema.
    /// </summary>
    [System.Serializable]
    public partial class UserType    {

        public UserType()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsGlobal = false;
          this.IsPrincipal = true;
          this.IsSecondary = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for UserTypeID in the schema.
        /// </summary>
        public virtual global::System.Guid UserTypeID
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
        /// There are no comments for IsGlobal in the schema.
        /// </summary>
        public virtual bool IsGlobal
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPrincipal in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsPrincipal
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsSecondary in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsSecondary
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationUserTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationUserTypeTemplate> DefaultOrganisationUserTypeTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserAccountOrganisations in the schema.
        /// </summary>
        public virtual ICollection<UserAccountOrganisation> UserAccountOrganisations
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
        /// There are no comments for DefaultOrganisationUserTargetTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationUserTargetTemplate> DefaultOrganisationUserTargetTemplates
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
        /// There are no comments for OrganisationUserTypes in the schema.
        /// </summary>
        public virtual ICollection<OrganisationUserType> OrganisationUserTypes
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
        /// There are no comments for UserAccountOrganisationSecondaryUserTypes in the schema.
        /// </summary>
        public virtual ICollection<UserAccountOrganisationSecondaryUserType> UserAccountOrganisationSecondaryUserTypes
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

        #endregion
    }

}