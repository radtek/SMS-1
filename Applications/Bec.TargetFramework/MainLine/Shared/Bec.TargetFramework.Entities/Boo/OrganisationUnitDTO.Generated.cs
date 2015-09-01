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
    public partial class OrganisationUnitDTO
    {
        #region Constructors
  
        public OrganisationUnitDTO() {
        }

        public OrganisationUnitDTO(int organisationUnitID, string name, string description, string divisionName, global::System.Nullable<System.Guid> organisationID, global::System.Nullable<int> organisationUnitTypeID, global::System.Nullable<int> organisationUnitCategoryID, bool isActive, bool isDeleted, List<UserAccountOrganisationDTO> userAccountOrganisations, List<OrganisationUnitOrganisationGroupDTO> organisationUnitOrganisationGroups, List<OrganisationUnitOrganisationRoleDTO> organisationUnitOrganisationRoles, List<OrganisationUnitStructureDTO> organisationUnitStructures, OrganisationDTO organisation) {

          this.OrganisationUnitID = organisationUnitID;
          this.Name = name;
          this.Description = description;
          this.DivisionName = divisionName;
          this.OrganisationID = organisationID;
          this.OrganisationUnitTypeID = organisationUnitTypeID;
          this.OrganisationUnitCategoryID = organisationUnitCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.UserAccountOrganisations = userAccountOrganisations;
          this.OrganisationUnitOrganisationGroups = organisationUnitOrganisationGroups;
          this.OrganisationUnitOrganisationRoles = organisationUnitOrganisationRoles;
          this.OrganisationUnitStructures = organisationUnitStructures;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public int OrganisationUnitID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string DivisionName { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationUnitTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationUnitCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<UserAccountOrganisationDTO> UserAccountOrganisations { get; set; }

        [DataMember]
        public List<OrganisationUnitOrganisationGroupDTO> OrganisationUnitOrganisationGroups { get; set; }

        [DataMember]
        public List<OrganisationUnitOrganisationRoleDTO> OrganisationUnitOrganisationRoles { get; set; }

        [DataMember]
        public List<OrganisationUnitStructureDTO> OrganisationUnitStructures { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}