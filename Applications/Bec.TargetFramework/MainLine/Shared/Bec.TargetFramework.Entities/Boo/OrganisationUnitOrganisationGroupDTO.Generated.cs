﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:06 PM
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
    public partial class OrganisationUnitOrganisationGroupDTO
    {
        #region Constructors
  
        public OrganisationUnitOrganisationGroupDTO() {
        }

        public OrganisationUnitOrganisationGroupDTO(int organisationUnitID, global::System.Guid organisationGroupID, bool isActive, bool isDeleted, OrganisationGroupDTO organisationGroup, OrganisationUnitDTO organisationUnit) {

          this.OrganisationUnitID = organisationUnitID;
          this.OrganisationGroupID = organisationGroupID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.OrganisationGroup = organisationGroup;
          this.OrganisationUnit = organisationUnit;
        }

        #endregion

        #region Properties

        [DataMember]
        public int OrganisationUnitID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationGroupID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationGroupDTO OrganisationGroup { get; set; }

        [DataMember]
        public OrganisationUnitDTO OrganisationUnit { get; set; }

        #endregion
    }

}
