﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class ProductAttributeTemplateDTO
    {
        #region Constructors
  
        public ProductAttributeTemplateDTO() {
        }

        public ProductAttributeTemplateDTO(global::System.Guid productAttributeTemplateID, string name, string description, bool isActive, bool isDeleted, List<ProductProductAttributeTemplateDTO> productProductAttributeTemplates) {

          this.ProductAttributeTemplateID = productAttributeTemplateID;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductProductAttributeTemplates = productProductAttributeTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductAttributeTemplateID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ProductProductAttributeTemplateDTO> ProductProductAttributeTemplates { get; set; }

        #endregion
    }

}
