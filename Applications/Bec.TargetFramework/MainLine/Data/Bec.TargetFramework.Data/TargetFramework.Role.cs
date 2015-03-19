﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 18/03/2015 19:00:45
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
    /// There are no comments for Bec.TargetFramework.Data.Role in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Role    {

        public Role()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsGlobal = true;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for RoleID in the schema.
        /// </summary>
        public virtual global::System.Guid RoleID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RoleName in the schema.
        /// </summary>
        public virtual string RoleName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RoleDescription in the schema.
        /// </summary>
        public virtual string RoleDescription
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RoleTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RoleTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RoleSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RoleSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RoleCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RoleCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RoleSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RoleSubCategoryID
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
        public virtual global::System.Nullable<bool> IsGlobal
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ModuleClaims in the schema.
        /// </summary>
        public virtual ICollection<ModuleClaim> ModuleClaims
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelClaimTemplates in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelClaimTemplate> InterfacePanelClaimTemplates
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
        /// There are no comments for InterfacePanelClaims in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelClaim> InterfacePanelClaims
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
        /// There are no comments for ProductClaims in the schema.
        /// </summary>
        public virtual ICollection<ProductClaim> ProductClaims
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductClaimTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductClaimTemplate> ProductClaimTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeClaimTemplates in the schema.
        /// </summary>
        public virtual ICollection<StatusTypeClaimTemplate> StatusTypeClaimTemplates
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
        /// There are no comments for ModuleClaimTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleClaimTemplate> ModuleClaimTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructClaims in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructClaim> NotificationConstructClaims
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructClaimTemplates in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructClaimTemplate> NotificationConstructClaimTemplates
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
        /// There are no comments for ArtefactClaims in the schema.
        /// </summary>
        public virtual ICollection<ArtefactClaim> ArtefactClaims
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for GroupRoles in the schema.
        /// </summary>
        public virtual ICollection<GroupRole> GroupRoles
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for RoleClaims in the schema.
        /// </summary>
        public virtual ICollection<RoleClaim> RoleClaims
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowClaims in the schema.
        /// </summary>
        public virtual ICollection<WorkflowClaim> WorkflowClaims
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ActorClaimRoleMappings in the schema.
        /// </summary>
        public virtual ICollection<ActorClaimRoleMapping> ActorClaimRoleMappings
        {
            get;
            set;
        }

        #endregion
    }

}
