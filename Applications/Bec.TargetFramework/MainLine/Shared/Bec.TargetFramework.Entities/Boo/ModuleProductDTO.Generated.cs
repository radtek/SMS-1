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
    public partial class ModuleProductDTO
    {
        #region Constructors
  
        public ModuleProductDTO() {
        }

        public ModuleProductDTO(global::System.Guid moduleID, int moduleVersionNumber, global::System.Guid productID, int productVersionID, bool isActive, bool isDeleted, ModuleDTO module, ProductDTO product) {

          this.ModuleID = moduleID;
          this.ModuleVersionNumber = moduleVersionNumber;
          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Module = module;
          this.Product = product;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ModuleID { get; set; }

        [DataMember]
        public int ModuleVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleDTO Module { get; set; }

        [DataMember]
        public ProductDTO Product { get; set; }

        #endregion
    }

}
