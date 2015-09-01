﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
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
    public partial class OrganisationTeamDTO
    {
        #region Constructors
  
        public OrganisationTeamDTO() {
        }

        public OrganisationTeamDTO(global::System.Guid organisationTeamID, string name, string description, string emailAddress, bool isDefault, global::System.Nullable<int> teamTypeID, global::System.Nullable<int> teamSubTypeID, global::System.Nullable<int> teamCategoryID, int teamSubCategoryID, bool isActive, bool isDeleted, global::System.Guid organisationID, List<UserAccountOrganisationTeamDTO> userAccountOrganisationTeams, List<OrganisationTeamSettingDTO> organisationTeamSettings, OrganisationDTO organisation) {

          this.OrganisationTeamID = organisationTeamID;
          this.Name = name;
          this.Description = description;
          this.EmailAddress = emailAddress;
          this.IsDefault = isDefault;
          this.TeamTypeID = teamTypeID;
          this.TeamSubTypeID = teamSubTypeID;
          this.TeamCategoryID = teamCategoryID;
          this.TeamSubCategoryID = teamSubCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.OrganisationID = organisationID;
          this.UserAccountOrganisationTeams = userAccountOrganisationTeams;
          this.OrganisationTeamSettings = organisationTeamSettings;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationTeamID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public bool IsDefault { get; set; }

        [DataMember]
        public global::System.Nullable<int> TeamTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> TeamSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> TeamCategoryID { get; set; }

        [DataMember]
        public int TeamSubCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<UserAccountOrganisationTeamDTO> UserAccountOrganisationTeams { get; set; }

        [DataMember]
        public List<OrganisationTeamSettingDTO> OrganisationTeamSettings { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}