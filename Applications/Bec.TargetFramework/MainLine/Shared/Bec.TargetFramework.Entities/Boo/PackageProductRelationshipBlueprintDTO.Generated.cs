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
    public partial class PackageProductRelationshipBlueprintDTO
    {
        #region Constructors
  
        public PackageProductRelationshipBlueprintDTO() {
        }

        public PackageProductRelationshipBlueprintDTO(global::System.Guid packageProductRelationshipBlueprintID, global::System.Guid packageProductRelationshipID, int defaultQuantity, bool isActive, bool isDeleted, PackageProductRelationshipDTO packageProductRelationship) {

          this.PackageProductRelationshipBlueprintID = packageProductRelationshipBlueprintID;
          this.PackageProductRelationshipID = packageProductRelationshipID;
          this.DefaultQuantity = defaultQuantity;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.PackageProductRelationship = packageProductRelationship;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PackageProductRelationshipBlueprintID { get; set; }

        [DataMember]
        public global::System.Guid PackageProductRelationshipID { get; set; }

        [DataMember]
        public int DefaultQuantity { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public PackageProductRelationshipDTO PackageProductRelationship { get; set; }

        #endregion
    }

}
