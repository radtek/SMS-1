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
    public partial class SpecificationAttributeTemplateDTO
    {
        #region Constructors
  
        public SpecificationAttributeTemplateDTO() {
        }

        public SpecificationAttributeTemplateDTO(global::System.Guid specificationAttributeTemplateID, string name, string description, int displayOrder, bool isActive, bool isDeleted, global::System.Nullable<int> specificationAttributeTypeID, global::System.Nullable<int> specificationAttributeCategoryID, global::System.Nullable<int> specificationAttributeSubTypeID, global::System.Nullable<int> specificationAttributeSubCategoryID, int order, List<ProductSpecificationAttributeTemplateDTO> productSpecificationAttributeTemplates, List<SpecificationAttributeOptionTemplateDTO> specificationAttributeOptionTemplates, List<SpecificationAttributeDTO> specificationAttributes, List<SpecificationAttributeRelationshipTemplateDTO> specificationAttributeRelationshipTemplates_ParentSpecificationAttributeTemplateID, List<SpecificationAttributeRelationshipTemplateDTO> specificationAttributeRelationshipTemplates_SpecificationAttributeTemplateID) {

          this.SpecificationAttributeTemplateID = specificationAttributeTemplateID;
          this.Name = name;
          this.Description = description;
          this.DisplayOrder = displayOrder;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.SpecificationAttributeTypeID = specificationAttributeTypeID;
          this.SpecificationAttributeCategoryID = specificationAttributeCategoryID;
          this.SpecificationAttributeSubTypeID = specificationAttributeSubTypeID;
          this.SpecificationAttributeSubCategoryID = specificationAttributeSubCategoryID;
          this.Order = order;
          this.ProductSpecificationAttributeTemplates = productSpecificationAttributeTemplates;
          this.SpecificationAttributeOptionTemplates = specificationAttributeOptionTemplates;
          this.SpecificationAttributes = specificationAttributes;
          this.SpecificationAttributeRelationshipTemplates_ParentSpecificationAttributeTemplateID = specificationAttributeRelationshipTemplates_ParentSpecificationAttributeTemplateID;
          this.SpecificationAttributeRelationshipTemplates_SpecificationAttributeTemplateID = specificationAttributeRelationshipTemplates_SpecificationAttributeTemplateID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid SpecificationAttributeTemplateID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<int> SpecificationAttributeTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> SpecificationAttributeCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> SpecificationAttributeSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> SpecificationAttributeSubCategoryID { get; set; }

        [DataMember]
        public int Order { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ProductSpecificationAttributeTemplateDTO> ProductSpecificationAttributeTemplates { get; set; }

        [DataMember]
        public List<SpecificationAttributeOptionTemplateDTO> SpecificationAttributeOptionTemplates { get; set; }

        [DataMember]
        public List<SpecificationAttributeDTO> SpecificationAttributes { get; set; }

        [DataMember]
        public List<SpecificationAttributeRelationshipTemplateDTO> SpecificationAttributeRelationshipTemplates_ParentSpecificationAttributeTemplateID { get; set; }

        [DataMember]
        public List<SpecificationAttributeRelationshipTemplateDTO> SpecificationAttributeRelationshipTemplates_SpecificationAttributeTemplateID { get; set; }

        #endregion
    }

}
