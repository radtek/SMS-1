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
    public partial class PackageProductRelationshipBlueprintTemplateDTO
    {
        #region Constructors
  
        public PackageProductRelationshipBlueprintTemplateDTO() {
        }

        public PackageProductRelationshipBlueprintTemplateDTO(global::System.Guid packageProductRelationshipBlueprintTemplateID, global::System.Nullable<System.Guid> packageProductRelationshipTemplateID, int defaultQuantity, bool isActive, bool isDeleted, PackageProductRelationshipTemplateDTO packageProductRelationshipTemplate) {

          this.PackageProductRelationshipBlueprintTemplateID = packageProductRelationshipBlueprintTemplateID;
          this.PackageProductRelationshipTemplateID = packageProductRelationshipTemplateID;
          this.DefaultQuantity = defaultQuantity;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.PackageProductRelationshipTemplate = packageProductRelationshipTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PackageProductRelationshipBlueprintTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> PackageProductRelationshipTemplateID { get; set; }

        [DataMember]
        public int DefaultQuantity { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public PackageProductRelationshipTemplateDTO PackageProductRelationshipTemplate { get; set; }

        #endregion
    }

}
