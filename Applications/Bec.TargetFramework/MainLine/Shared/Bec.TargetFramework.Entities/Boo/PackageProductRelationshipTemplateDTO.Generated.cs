﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
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
    public partial class PackageProductRelationshipTemplateDTO
    {
        #region Constructors
  
        public PackageProductRelationshipTemplateDTO() {
        }

        public PackageProductRelationshipTemplateDTO(global::System.Guid packageProductRelationshipTemplateID, global::System.Guid parentProductTemplateID, global::System.Guid childProductTemplateID, int productRelationshipTypeID, bool isMandatory, bool isActive, bool isDeleted, global::System.Guid packageProductTemplateID, int parentProductVersionID, int childProductVersionID, global::System.Guid packageTemplateID, int packageTemplateVersionNumber, ProductTemplateDTO productTemplate_ParentProductTemplateID_ParentProductVersionID, ProductTemplateDTO productTemplate_ChildProductTemplateID_ChildProductVersionID, PackageProductTemplateDTO packageProductTemplate, List<PackageProductRelationshipBlueprintTemplateDTO> packageProductRelationshipBlueprintTemplates) {

          this.PackageProductRelationshipTemplateID = packageProductRelationshipTemplateID;
          this.ParentProductTemplateID = parentProductTemplateID;
          this.ChildProductTemplateID = childProductTemplateID;
          this.ProductRelationshipTypeID = productRelationshipTypeID;
          this.IsMandatory = isMandatory;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.PackageProductTemplateID = packageProductTemplateID;
          this.ParentProductVersionID = parentProductVersionID;
          this.ChildProductVersionID = childProductVersionID;
          this.PackageTemplateID = packageTemplateID;
          this.PackageTemplateVersionNumber = packageTemplateVersionNumber;
          this.ProductTemplate_ParentProductTemplateID_ParentProductVersionID = productTemplate_ParentProductTemplateID_ParentProductVersionID;
          this.ProductTemplate_ChildProductTemplateID_ChildProductVersionID = productTemplate_ChildProductTemplateID_ChildProductVersionID;
          this.PackageProductTemplate = packageProductTemplate;
          this.PackageProductRelationshipBlueprintTemplates = packageProductRelationshipBlueprintTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PackageProductRelationshipTemplateID { get; set; }

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
        public global::System.Guid PackageProductTemplateID { get; set; }

        [DataMember]
        public int ParentProductVersionID { get; set; }

        [DataMember]
        public int ChildProductVersionID { get; set; }

        [DataMember]
        public global::System.Guid PackageTemplateID { get; set; }

        [DataMember]
        public int PackageTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductTemplateDTO ProductTemplate_ParentProductTemplateID_ParentProductVersionID { get; set; }

        [DataMember]
        public ProductTemplateDTO ProductTemplate_ChildProductTemplateID_ChildProductVersionID { get; set; }

        [DataMember]
        public PackageProductTemplateDTO PackageProductTemplate { get; set; }

        [DataMember]
        public List<PackageProductRelationshipBlueprintTemplateDTO> PackageProductRelationshipBlueprintTemplates { get; set; }

        #endregion
    }

}
