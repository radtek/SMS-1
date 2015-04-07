﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:18
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
    public partial class ProductRelationshipTemplateDTO
    {
        #region Constructors
  
        public ProductRelationshipTemplateDTO() {
        }

        public ProductRelationshipTemplateDTO(global::System.Guid productRelationshipTemplateID, global::System.Guid parentProductTemplateID, global::System.Guid childProductTemplateID, int productRelationshipTypeID, bool isMandatory, bool isActive, bool isDeleted, int parentProductVersionID, int childProductVersionID, List<ProductRelationshipBlueprintTemplateDTO> productRelationshipBlueprintTemplates, ProductTemplateDTO productTemplate_ParentProductTemplateID_ParentProductVersionID, ProductTemplateDTO productTemplate_ChildProductTemplateID_ChildProductVersionID) {

          this.ProductRelationshipTemplateID = productRelationshipTemplateID;
          this.ParentProductTemplateID = parentProductTemplateID;
          this.ChildProductTemplateID = childProductTemplateID;
          this.ProductRelationshipTypeID = productRelationshipTypeID;
          this.IsMandatory = isMandatory;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ParentProductVersionID = parentProductVersionID;
          this.ChildProductVersionID = childProductVersionID;
          this.ProductRelationshipBlueprintTemplates = productRelationshipBlueprintTemplates;
          this.ProductTemplate_ParentProductTemplateID_ParentProductVersionID = productTemplate_ParentProductTemplateID_ParentProductVersionID;
          this.ProductTemplate_ChildProductTemplateID_ChildProductVersionID = productTemplate_ChildProductTemplateID_ChildProductVersionID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductRelationshipTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ParentProductTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ChildProductTemplateID { get; set; }

        [DataMember]
        public int ProductRelationshipTypeID { get; set; }

        [DataMember]
        public bool IsMandatory { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int ParentProductVersionID { get; set; }

        [DataMember]
        public int ChildProductVersionID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ProductRelationshipBlueprintTemplateDTO> ProductRelationshipBlueprintTemplates { get; set; }

        [DataMember]
        public ProductTemplateDTO ProductTemplate_ParentProductTemplateID_ParentProductVersionID { get; set; }

        [DataMember]
        public ProductTemplateDTO ProductTemplate_ChildProductTemplateID_ChildProductVersionID { get; set; }

        #endregion
    }

}
