﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
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
    public partial class DefaultOrganisationProductDTO
    {
        #region Constructors
  
        public DefaultOrganisationProductDTO() {
        }

        public DefaultOrganisationProductDTO(global::System.Guid defaultOrganisationID, int defaultOrganisationVersionNumber, global::System.Guid productID, int productVersionID, bool isActive, bool isDeleted, DefaultOrganisationDTO defaultOrganisation, ProductDTO product) {

          this.DefaultOrganisationID = defaultOrganisationID;
          this.DefaultOrganisationVersionNumber = defaultOrganisationVersionNumber;
          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisation = defaultOrganisation;
          this.Product = product;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationID { get; set; }

        [DataMember]
        public int DefaultOrganisationVersionNumber { get; set; }

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
        public DefaultOrganisationDTO DefaultOrganisation { get; set; }

        [DataMember]
        public ProductDTO Product { get; set; }

        #endregion
    }

}
