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
    public partial class ProductRelationshipBlueprintTemplateDTO
    {
        #region Constructors
  
        public ProductRelationshipBlueprintTemplateDTO() {
        }

        public ProductRelationshipBlueprintTemplateDTO(global::System.Guid productRelationshipBlueprintTemplateID, global::System.Guid productRelationshipTemplateID, int defaultQuantity, bool isActive, bool isDeleted, ProductRelationshipTemplateDTO productRelationshipTemplate) {

          this.ProductRelationshipBlueprintTemplateID = productRelationshipBlueprintTemplateID;
          this.ProductRelationshipTemplateID = productRelationshipTemplateID;
          this.DefaultQuantity = defaultQuantity;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductRelationshipTemplate = productRelationshipTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductRelationshipBlueprintTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ProductRelationshipTemplateID { get; set; }

        [DataMember]
        public int DefaultQuantity { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductRelationshipTemplateDTO ProductRelationshipTemplate { get; set; }

        #endregion
    }

}
