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
    public partial class OrganisationStatusTypeDTO
    {
        #region Constructors
  
        public OrganisationStatusTypeDTO() {
        }

        public OrganisationStatusTypeDTO(global::System.Guid organisationStatusTypeID, global::System.Guid organisationID, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Nullable<System.Guid> parentID, bool isActive, bool isDeleted, StatusTypeDTO statusType, OrganisationDTO organisation) {

          this.OrganisationStatusTypeID = organisationStatusTypeID;
          this.OrganisationID = organisationID;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.ParentID = parentID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.StatusType = statusType;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationStatusTypeID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public StatusTypeDTO StatusType { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
