﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:19 AM
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
    public partial class SpecificationAttributeRelationshipDTO
    {
        #region Constructors
  
        public SpecificationAttributeRelationshipDTO() {
        }

        public SpecificationAttributeRelationshipDTO(global::System.Guid specificationAttributeRelationshipID, global::System.Guid specificationAttributeID, global::System.Guid parentSpecificationAttributeID, bool isMandatory, bool isInverse, bool isActive, bool isDeleted, SpecificationAttributeDTO specificationAttribute_ParentSpecificationAttributeID, SpecificationAttributeDTO specificationAttribute_SpecificationAttributeID) {

          this.SpecificationAttributeRelationshipID = specificationAttributeRelationshipID;
          this.SpecificationAttributeID = specificationAttributeID;
          this.ParentSpecificationAttributeID = parentSpecificationAttributeID;
          this.IsMandatory = isMandatory;
          this.IsInverse = isInverse;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.SpecificationAttribute_ParentSpecificationAttributeID = specificationAttribute_ParentSpecificationAttributeID;
          this.SpecificationAttribute_SpecificationAttributeID = specificationAttribute_SpecificationAttributeID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid SpecificationAttributeRelationshipID { get; set; }

        [DataMember]
        public global::System.Guid SpecificationAttributeID { get; set; }

        [DataMember]
        public global::System.Guid ParentSpecificationAttributeID { get; set; }

        [DataMember]
        public bool IsMandatory { get; set; }

        [DataMember]
        public bool IsInverse { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public SpecificationAttributeDTO SpecificationAttribute_ParentSpecificationAttributeID { get; set; }

        [DataMember]
        public SpecificationAttributeDTO SpecificationAttribute_SpecificationAttributeID { get; set; }

        #endregion
    }

}
