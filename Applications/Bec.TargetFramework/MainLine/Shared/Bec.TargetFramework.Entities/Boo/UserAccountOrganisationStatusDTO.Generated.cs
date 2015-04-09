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
    public partial class UserAccountOrganisationStatusDTO
    {
        #region Constructors
  
        public UserAccountOrganisationStatusDTO() {
        }

        public UserAccountOrganisationStatusDTO(global::System.Guid userAccountOrganisationID, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Guid statusTypeValueID, global::System.DateTime statusChangedOn, string statusChangedBy, global::System.Nullable<System.Guid> parentID, StatusTypeDTO statusType, StatusTypeValueDTO statusTypeValue, UserAccountOrganisationDTO userAccountOrganisation) {

          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.StatusTypeValueID = statusTypeValueID;
          this.StatusChangedOn = statusChangedOn;
          this.StatusChangedBy = statusChangedBy;
          this.ParentID = parentID;
          this.StatusType = statusType;
          this.StatusTypeValue = statusTypeValue;
          this.UserAccountOrganisation = userAccountOrganisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        [DataMember]
        public global::System.DateTime StatusChangedOn { get; set; }

        [DataMember]
        public string StatusChangedBy { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public StatusTypeDTO StatusType { get; set; }

        [DataMember]
        public StatusTypeValueDTO StatusTypeValue { get; set; }

        [DataMember]
        public UserAccountOrganisationDTO UserAccountOrganisation { get; set; }

        #endregion
    }

}
