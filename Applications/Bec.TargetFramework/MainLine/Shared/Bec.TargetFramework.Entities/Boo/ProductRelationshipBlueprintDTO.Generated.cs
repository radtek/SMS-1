﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:38
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
    public partial class ProductRelationshipBlueprintDTO
    {
        #region Constructors
  
        public ProductRelationshipBlueprintDTO() {
        }

        public ProductRelationshipBlueprintDTO(global::System.Guid productRelationshipBlueprintID, global::System.Guid productRelationshipID, int defaultQuantity, bool isActive, bool isDeleted, ProductRelationshipDTO productRelationship) {

          this.ProductRelationshipBlueprintID = productRelationshipBlueprintID;
          this.ProductRelationshipID = productRelationshipID;
          this.DefaultQuantity = defaultQuantity;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductRelationship = productRelationship;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductRelationshipBlueprintID { get; set; }

        [DataMember]
        public global::System.Guid ProductRelationshipID { get; set; }

        [DataMember]
        public int DefaultQuantity { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductRelationshipDTO ProductRelationship { get; set; }

        #endregion
    }

}
