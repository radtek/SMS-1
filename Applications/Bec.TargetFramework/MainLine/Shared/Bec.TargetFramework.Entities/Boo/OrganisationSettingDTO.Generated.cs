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
    public partial class OrganisationSettingDTO
    {
        #region Constructors
  
        public OrganisationSettingDTO() {
        }

        public OrganisationSettingDTO(int organisationSettingID, string name, string value, bool isActive, bool isDeleted, global::System.Guid organisationID, OrganisationDTO organisation) {

          this.OrganisationSettingID = organisationSettingID;
          this.Name = name;
          this.Value = value;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.OrganisationID = organisationID;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public int OrganisationSettingID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
