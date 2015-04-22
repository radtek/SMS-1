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
    public partial class VCountryAndCurrencyDTO
    {
        #region Constructors
  
        public VCountryAndCurrencyDTO() {
        }

        public VCountryAndCurrencyDTO(string countryCode, string countryName, string currencyCode, string currencyName, global::System.DateTime currencyRateDate, decimal currencyRate, global::System.Nullable<decimal> currencyRateToGBP, decimal currencyRateToUSD) {

          this.CountryCode = countryCode;
          this.CountryName = countryName;
          this.CurrencyCode = currencyCode;
          this.CurrencyName = currencyName;
          this.CurrencyRateDate = currencyRateDate;
          this.CurrencyRate = currencyRate;
          this.CurrencyRateToGBP = currencyRateToGBP;
          this.CurrencyRateToUSD = currencyRateToUSD;
        }

        #endregion

        #region Properties

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string CountryName { get; set; }

        [DataMember]
        public string CurrencyCode { get; set; }

        [DataMember]
        public string CurrencyName { get; set; }

        [DataMember]
        public global::System.DateTime CurrencyRateDate { get; set; }

        [DataMember]
        public decimal CurrencyRate { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> CurrencyRateToGBP { get; set; }

        [DataMember]
        public decimal CurrencyRateToUSD { get; set; }

        #endregion
    }

}
