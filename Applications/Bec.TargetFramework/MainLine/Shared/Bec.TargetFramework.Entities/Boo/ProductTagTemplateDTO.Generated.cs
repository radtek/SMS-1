﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:50
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
    public partial class ProductTagTemplateDTO
    {
        #region Constructors
  
        public ProductTagTemplateDTO() {
        }

        public ProductTagTemplateDTO(global::System.Guid productTagTemplateID, string name, global::System.Guid productTemplateID, int productVersionID, ProductTemplateDTO productTemplate) {

          this.ProductTagTemplateID = productTagTemplateID;
          this.Name = name;
          this.ProductTemplateID = productTemplateID;
          this.ProductVersionID = productVersionID;
          this.ProductTemplate = productTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductTagTemplateID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public global::System.Guid ProductTemplateID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductTemplateDTO ProductTemplate { get; set; }

        #endregion
    }

}
