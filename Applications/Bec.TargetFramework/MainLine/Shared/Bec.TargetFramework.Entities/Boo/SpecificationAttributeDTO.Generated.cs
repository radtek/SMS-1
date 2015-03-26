﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:00
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
    public partial class SpecificationAttributeDTO
    {
        #region Constructors
  
        public SpecificationAttributeDTO() {
        }

        public SpecificationAttributeDTO(global::System.Guid specificationAttributeID, global::System.Guid specificationAttributeTemplateID, string name, string description, int displayOrder, bool isActive, bool isDeleted, global::System.Nullable<int> specificationAttributeTypeID, global::System.Nullable<int> specificationAttributeCategoryID, global::System.Nullable<int> specificationAttributeSubTypeID, global::System.Nullable<int> specificationAttributeSubCategoryID, List<ProductSpecificationAttributeDTO> productSpecificationAttributes, SpecificationAttributeTemplateDTO specificationAttributeTemplate, List<SpecificationAttributeRelationshipDTO> specificationAttributeRelationships_ParentSpecificationAttributeID, List<SpecificationAttributeRelationshipDTO> specificationAttributeRelationships_SpecificationAttributeID, List<SpecificiationAttributeOptionDTO> specificiationAttributeOptions) {

          this.SpecificationAttributeID = specificationAttributeID;
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
          this.ProductSpecificationAttributes = productSpecificationAttributes;
          this.SpecificationAttributeTemplate = specificationAttributeTemplate;
          this.SpecificationAttributeRelationships_ParentSpecificationAttributeID = specificationAttributeRelationships_ParentSpecificationAttributeID;
          this.SpecificationAttributeRelationships_SpecificationAttributeID = specificationAttributeRelationships_SpecificationAttributeID;
          this.SpecificiationAttributeOptions = specificiationAttributeOptions;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid SpecificationAttributeID { get; set; }

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

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ProductSpecificationAttributeDTO> ProductSpecificationAttributes { get; set; }

        [DataMember]
        public SpecificationAttributeTemplateDTO SpecificationAttributeTemplate { get; set; }

        [DataMember]
        public List<SpecificationAttributeRelationshipDTO> SpecificationAttributeRelationships_ParentSpecificationAttributeID { get; set; }

        [DataMember]
        public List<SpecificationAttributeRelationshipDTO> SpecificationAttributeRelationships_SpecificationAttributeID { get; set; }

        [DataMember]
        public List<SpecificiationAttributeOptionDTO> SpecificiationAttributeOptions { get; set; }

        #endregion
    }

}
