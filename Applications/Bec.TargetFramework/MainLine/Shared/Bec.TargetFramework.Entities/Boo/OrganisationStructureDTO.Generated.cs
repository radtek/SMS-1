﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
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
    public partial class OrganisationStructureDTO
    {
        #region Constructors
  
        public OrganisationStructureDTO() {
        }

        public OrganisationStructureDTO(global::System.Guid organisationStructureID, global::System.Nullable<System.Guid> parentOrganisationStructureID, string name, bool isLeafNode, global::System.Nullable<System.Guid> organisationID, bool isActive, bool isDeleted, OrganisationDTO organisation) {

          this.OrganisationStructureID = organisationStructureID;
          this.ParentOrganisationStructureID = parentOrganisationStructureID;
          this.Name = name;
          this.IsLeafNode = isLeafNode;
          this.OrganisationID = organisationID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationStructureID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentOrganisationStructureID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsLeafNode { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationID { get; set; }

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
