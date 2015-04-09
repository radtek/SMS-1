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
    public partial class OrganisationProductPurchaseDTO
    {
        #region Constructors
  
        public OrganisationProductPurchaseDTO() {
        }

        public OrganisationProductPurchaseDTO(global::System.Guid organisationID, global::System.Guid productID, int productVersionID, global::System.Guid invoiceLineItemID, ProductDTO product, InvoiceLineItemDTO invoiceLineItem, OrganisationDTO organisation) {

          this.OrganisationID = organisationID;
          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.InvoiceLineItemID = invoiceLineItemID;
          this.Product = product;
          this.InvoiceLineItem = invoiceLineItem;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public global::System.Guid InvoiceLineItemID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductDTO Product { get; set; }

        [DataMember]
        public InvoiceLineItemDTO InvoiceLineItem { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
