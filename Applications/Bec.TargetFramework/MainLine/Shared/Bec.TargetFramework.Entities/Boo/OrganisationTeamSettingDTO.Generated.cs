﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class OrganisationTeamSettingDTO
    {
        #region Constructors
  
        public OrganisationTeamSettingDTO() {
        }

        public OrganisationTeamSettingDTO(int organisationTeamSettingID, string name, string value, bool isActive, bool isDeleted, global::System.Guid organisationTeamID, OrganisationTeamDTO organisationTeam) {

          this.OrganisationTeamSettingID = organisationTeamSettingID;
          this.Name = name;
          this.Value = value;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.OrganisationTeamID = organisationTeamID;
          this.OrganisationTeam = organisationTeam;
        }

        #endregion

        #region Properties

        [DataMember]
        public int OrganisationTeamSettingID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid OrganisationTeamID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationTeamDTO OrganisationTeam { get; set; }

        #endregion
    }

}
