﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
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
    public partial class VDefaultOrganisationUserTypeOrganisationTypeDTO
    {
        #region Constructors
  
        public VDefaultOrganisationUserTypeOrganisationTypeDTO() {
        }

        public VDefaultOrganisationUserTypeOrganisationTypeDTO(global::System.Guid defaultOrganisationID, int defaultOrganisationVersionNumber, string defaultOrganisationName, global::System.Guid userTypeID, string userTypeName, int organisationTypeID, string organisationTypeName) {

          this.DefaultOrganisationID = defaultOrganisationID;
          this.DefaultOrganisationVersionNumber = defaultOrganisationVersionNumber;
          this.DefaultOrganisationName = defaultOrganisationName;
          this.UserTypeID = userTypeID;
          this.UserTypeName = userTypeName;
          this.OrganisationTypeID = organisationTypeID;
          this.OrganisationTypeName = organisationTypeName;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationID { get; set; }

        [DataMember]
        public int DefaultOrganisationVersionNumber { get; set; }

        [DataMember]
        public string DefaultOrganisationName { get; set; }

        [DataMember]
        public global::System.Guid UserTypeID { get; set; }

        [DataMember]
        public string UserTypeName { get; set; }

        [DataMember]
        public int OrganisationTypeID { get; set; }

        [DataMember]
        public string OrganisationTypeName { get; set; }

        #endregion
    }

}
