﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:00
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
    public partial class ResourceOperationTargetDTO
    {
        #region Constructors
  
        public ResourceOperationTargetDTO() {
        }

        public ResourceOperationTargetDTO(global::System.Guid resourceID, global::System.Guid operationID, global::System.Nullable<int> organisationTypeID, global::System.Nullable<System.Guid> userTypeID, bool isActive, bool isDeleted, OperationDTO operation, OrganisationTypeDTO organisationType, ResourceDTO resource, UserTypeDTO userType) {

          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.OrganisationTypeID = organisationTypeID;
          this.UserTypeID = userTypeID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Operation = operation;
          this.OrganisationType = organisationType;
          this.Resource = resource;
          this.UserType = userType;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ResourceID { get; set; }

        [DataMember]
        public global::System.Guid OperationID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> UserTypeID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OperationDTO Operation { get; set; }

        [DataMember]
        public OrganisationTypeDTO OrganisationType { get; set; }

        [DataMember]
        public ResourceDTO Resource { get; set; }

        [DataMember]
        public UserTypeDTO UserType { get; set; }

        #endregion
    }

}
