﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
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
    public partial class VOrganisationUserTypeDTO
    {
        #region Constructors
  
        public VOrganisationUserTypeDTO() {
        }

        public VOrganisationUserTypeDTO(global::System.Guid organisationID, global::System.Nullable<System.Guid> organisationbranchid, global::System.Guid defaultOrganisationID, string name, global::System.Guid userTypeID) {

          this.OrganisationID = organisationID;
          this.Organisationbranchid = organisationbranchid;
          this.DefaultOrganisationID = defaultOrganisationID;
          this.Name = name;
          this.UserTypeID = userTypeID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> Organisationbranchid { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public global::System.Guid UserTypeID { get; set; }

        #endregion
    }

}
