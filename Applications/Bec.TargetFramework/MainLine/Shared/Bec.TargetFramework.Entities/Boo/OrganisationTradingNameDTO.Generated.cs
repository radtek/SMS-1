﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:14:59
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
    public partial class OrganisationTradingNameDTO
    {
        #region Constructors
  
        public OrganisationTradingNameDTO() {
        }

        public OrganisationTradingNameDTO(int organisationTradingNameID, global::System.Guid organisationID, string name, bool isActive, bool isDeleted, OrganisationDTO organisation) {

          this.OrganisationTradingNameID = organisationTradingNameID;
          this.OrganisationID = organisationID;
          this.Name = name;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public int OrganisationTradingNameID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
