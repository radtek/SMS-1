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
    public partial class OrganisationDiscountDTO
    {
        #region Constructors
  
        public OrganisationDiscountDTO() {
        }

        public OrganisationDiscountDTO(global::System.Guid organisationID, global::System.Guid discountID, int discountVersionNumber, bool isActive, bool isDeleted, DiscountDTO discount, OrganisationDTO organisation) {

          this.OrganisationID = organisationID;
          this.DiscountID = discountID;
          this.DiscountVersionNumber = discountVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Discount = discount;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.Guid DiscountID { get; set; }

        [DataMember]
        public int DiscountVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DiscountDTO Discount { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
