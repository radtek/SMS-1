﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
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
    public partial class ArtefactClaimTemplateDTO
    {
        #region Constructors
  
        public ArtefactClaimTemplateDTO() {
        }

        public ArtefactClaimTemplateDTO(global::System.Guid artefactClaimTemplateID, global::System.Nullable<System.Guid> artefactTemplateID, global::System.Nullable<int> artefactTemplateVersionNumber, global::System.Nullable<System.Guid> resourceID, global::System.Nullable<System.Guid> operationID, global::System.Nullable<System.Guid> stateID, global::System.Nullable<System.Guid> stateItemID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> artefactRoleTemplateID, global::System.Nullable<System.Guid> roleID, ArtefactRoleTemplateDTO artefactRoleTemplate, ArtefactTemplateDTO artefactTemplate, OperationDTO operation, ResourceDTO resource, StateDTO state, StateItemDTO stateItem, RoleDTO role) {

          this.ArtefactClaimTemplateID = artefactClaimTemplateID;
          this.ArtefactTemplateID = artefactTemplateID;
          this.ArtefactTemplateVersionNumber = artefactTemplateVersionNumber;
          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.StateID = stateID;
          this.StateItemID = stateItemID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ArtefactRoleTemplateID = artefactRoleTemplateID;
          this.RoleID = roleID;
          this.ArtefactRoleTemplate = artefactRoleTemplate;
          this.ArtefactTemplate = artefactTemplate;
          this.Operation = operation;
          this.Resource = resource;
          this.State = state;
          this.StateItem = stateItem;
          this.Role = role;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ArtefactClaimTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ArtefactTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ArtefactTemplateVersionNumber { get; set; }

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
        public global::System.Nullable<System.Guid> ArtefactRoleTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> RoleID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ArtefactRoleTemplateDTO ArtefactRoleTemplate { get; set; }

        [DataMember]
        public ArtefactTemplateDTO ArtefactTemplate { get; set; }

        [DataMember]
        public OperationDTO Operation { get; set; }

        [DataMember]
        public ResourceDTO Resource { get; set; }

        [DataMember]
        public StateDTO State { get; set; }

        [DataMember]
        public StateItemDTO StateItem { get; set; }

        [DataMember]
        public RoleDTO Role { get; set; }

        #endregion
    }

}
