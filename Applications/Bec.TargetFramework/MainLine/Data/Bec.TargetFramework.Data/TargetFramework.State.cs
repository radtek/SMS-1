﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 26/03/2015 16:14:58
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
    /// There are no comments for Bec.TargetFramework.Data.State in the schema.
    /// </summary>
    [System.Serializable]
    public partial class State    {

        public State()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for StateID in the schema.
        /// </summary>
        public virtual global::System.Guid StateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StateName in the schema.
        /// </summary>
        public virtual string StateName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StateDescription in the schema.
        /// </summary>
        public virtual string StateDescription
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StateTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> StateTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StateCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> StateCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StateSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> StateSubCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentStateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentStateID
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
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentID
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
        /// There are no comments for InterfacePanelClaims in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelClaim> InterfacePanelClaims
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationRoleClaims in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationRoleClaim> DefaultOrganisationRoleClaims
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationRoleClaims in the schema.
        /// </summary>
        public virtual ICollection<OrganisationRoleClaim> OrganisationRoleClaims
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
        /// There are no comments for DefaultOrganisationRoleClaimTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationRoleClaimTemplate> DefaultOrganisationRoleClaimTemplates
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
        /// There are no comments for StatusTypeClaims in the schema.
        /// </summary>
        public virtual ICollection<StatusTypeClaim> StatusTypeClaims
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
        /// There are no comments for StateItems in the schema.
        /// </summary>
        public virtual ICollection<StateItem> StateItems
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
