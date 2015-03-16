﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
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
    public partial class CurrencyRateDTO
    {
        #region Constructors
  
        public CurrencyRateDTO() {
        }

        public CurrencyRateDTO(string currencyCode, global::System.DateTime currencyRateDate, decimal currencyRate1, global::System.Nullable<decimal> currencyRateToGBP, decimal currencyRateToUSD, int currencyRateID) {

          this.CurrencyCode = currencyCode;
          this.CurrencyRateDate = currencyRateDate;
          this.CurrencyRate1 = currencyRate1;
          this.CurrencyRateToGBP = currencyRateToGBP;
          this.CurrencyRateToUSD = currencyRateToUSD;
          this.CurrencyRateID = currencyRateID;
        }

        #endregion

        #region Properties

        [DataMember]
        public string CurrencyCode { get; set; }

        [DataMember]
        public global::System.DateTime CurrencyRateDate { get; set; }

        [DataMember]
        public decimal CurrencyRate1 { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> CurrencyRateToGBP { get; set; }

        [DataMember]
        public decimal CurrencyRateToUSD { get; set; }

        [DataMember]
        public int CurrencyRateID { get; set; }

        #endregion
    }

}
