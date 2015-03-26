﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:14:59
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class DefaultOrganisationRoleClaimDTO
    {
        #region Constructors
  
        public DefaultOrganisationRoleClaimDTO() {
        }

        public DefaultOrganisationRoleClaimDTO(int defaultOrganisationRoleClaimID, global::System.Guid defaultOrganisationRoleID, global::System.Nullable<System.Guid> resourceID, global::System.Nullable<System.Guid> operationID, global::System.Nullable<System.Guid> stateID, global::System.Nullable<System.Guid> stateItemID, bool isActive, bool isDeleted, OperationDTO operation, ResourceDTO resource, StateDTO state, StateItemDTO stateItem, DefaultOrganisationRoleDTO defaultOrganisationRole) {

          this.DefaultOrganisationRoleClaimID = defaultOrganisationRoleClaimID;
          this.DefaultOrganisationRoleID = defaultOrganisationRoleID;
          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.StateID = stateID;
          this.StateItemID = stateItemID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Operation = operation;
          this.Resource = resource;
          this.State = state;
          this.StateItem = stateItem;
          this.DefaultOrganisationRole = defaultOrganisationRole;
        }

        #endregion

        #region Properties

        [DataMember]
        public int DefaultOrganisationRoleClaimID { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationRoleID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ResourceID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OperationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> StateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> StateItemID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OperationDTO Operation { get; set; }

        [DataMember]
        public ResourceDTO Resource { get; set; }

        [DataMember]
        public StateDTO State { get; set; }

        [DataMember]
        public StateItemDTO StateItem { get; set; }

        [DataMember]
        public DefaultOrganisationRoleDTO DefaultOrganisationRole { get; set; }

        #endregion
    }

}
