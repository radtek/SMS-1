﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:38
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
    public partial class OrganisationRoleClaimDTO
    {
        #region Constructors
  
        public OrganisationRoleClaimDTO() {
        }

        public OrganisationRoleClaimDTO(int organisationRoleClaimID, global::System.Nullable<System.Guid> organisationRoleID, global::System.Nullable<System.Guid> resourceID, global::System.Nullable<System.Guid> operationID, global::System.Nullable<System.Guid> stateID, global::System.Nullable<System.Guid> stateItemID, bool isActive, bool isDeleted, global::System.Guid organisationID, OrganisationRoleDTO organisationRole, OperationDTO operation, ResourceDTO resource, StateDTO state, StateItemDTO stateItem, OrganisationDTO organisation) {

          this.OrganisationRoleClaimID = organisationRoleClaimID;
          this.OrganisationRoleID = organisationRoleID;
          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.StateID = stateID;
          this.StateItemID = stateItemID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.OrganisationID = organisationID;
          this.OrganisationRole = organisationRole;
          this.Operation = operation;
          this.Resource = resource;
          this.State = state;
          this.StateItem = stateItem;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public int OrganisationRoleClaimID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationRoleID { get; set; }

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

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationRoleDTO OrganisationRole { get; set; }

        [DataMember]
        public OperationDTO Operation { get; set; }

        [DataMember]
        public ResourceDTO Resource { get; set; }

        [DataMember]
        public StateDTO State { get; set; }

        [DataMember]
        public StateItemDTO StateItem { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
