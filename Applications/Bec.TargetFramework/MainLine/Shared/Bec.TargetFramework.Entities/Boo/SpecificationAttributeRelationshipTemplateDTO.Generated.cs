﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
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
    public partial class SpecificationAttributeRelationshipTemplateDTO
    {
        #region Constructors
  
        public SpecificationAttributeRelationshipTemplateDTO() {
        }

        public SpecificationAttributeRelationshipTemplateDTO(global::System.Guid specificationAttributeRelationshipTemplateID, global::System.Guid specificationAttributeTemplateID, global::System.Guid parentSpecificationAttributeTemplateID, bool isMandatory, bool isInverse, bool isActive, bool isDeleted, SpecificationAttributeTemplateDTO specificationAttributeTemplate_ParentSpecificationAttributeTemplateID, SpecificationAttributeTemplateDTO specificationAttributeTemplate_SpecificationAttributeTemplateID) {

          this.SpecificationAttributeRelationshipTemplateID = specificationAttributeRelationshipTemplateID;
          this.SpecificationAttributeTemplateID = specificationAttributeTemplateID;
          this.ParentSpecificationAttributeTemplateID = parentSpecificationAttributeTemplateID;
          this.IsMandatory = isMandatory;
          this.IsInverse = isInverse;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.SpecificationAttributeTemplate_ParentSpecificationAttributeTemplateID = specificationAttributeTemplate_ParentSpecificationAttributeTemplateID;
          this.SpecificationAttributeTemplate_SpecificationAttributeTemplateID = specificationAttributeTemplate_SpecificationAttributeTemplateID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid SpecificationAttributeRelationshipTemplateID { get; set; }

        [DataMember]
        public global::System.Guid SpecificationAttributeTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ParentSpecificationAttributeTemplateID { get; set; }

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
        public SpecificationAttributeTemplateDTO SpecificationAttributeTemplate_ParentSpecificationAttributeTemplateID { get; set; }

        [DataMember]
        public SpecificationAttributeTemplateDTO SpecificationAttributeTemplate_SpecificationAttributeTemplateID { get; set; }

        #endregion
    }

}
