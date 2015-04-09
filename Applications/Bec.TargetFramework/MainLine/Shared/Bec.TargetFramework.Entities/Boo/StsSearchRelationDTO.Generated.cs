﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
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
    public partial class StsSearchRelationDTO
    {
        #region Constructors
  
        public StsSearchRelationDTO() {
        }

        public StsSearchRelationDTO(global::System.Guid buyerStsSearchID, global::System.Guid sellerStsSearchID, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Guid statusTypeValueID, bool isCancelled, bool isClosed, StsSearchDTO stsSearch_BuyerStsSearchID, StsSearchDTO stsSearch_SellerStsSearchID, StatusTypeDTO statusType, StatusTypeValueDTO statusTypeValue) {

          this.BuyerStsSearchID = buyerStsSearchID;
          this.SellerStsSearchID = sellerStsSearchID;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.StatusTypeValueID = statusTypeValueID;
          this.IsCancelled = isCancelled;
          this.IsClosed = isClosed;
          this.StsSearch_BuyerStsSearchID = stsSearch_BuyerStsSearchID;
          this.StsSearch_SellerStsSearchID = stsSearch_SellerStsSearchID;
          this.StatusType = statusType;
          this.StatusTypeValue = statusTypeValue;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid BuyerStsSearchID { get; set; }

        [DataMember]
        public global::System.Guid SellerStsSearchID { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        [DataMember]
        public bool IsCancelled { get; set; }

        [DataMember]
        public bool IsClosed { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public StsSearchDTO StsSearch_BuyerStsSearchID { get; set; }

        [DataMember]
        public StsSearchDTO StsSearch_SellerStsSearchID { get; set; }

        [DataMember]
        public StatusTypeDTO StatusType { get; set; }

        [DataMember]
        public StatusTypeValueDTO StatusTypeValue { get; set; }

        #endregion
    }

}
