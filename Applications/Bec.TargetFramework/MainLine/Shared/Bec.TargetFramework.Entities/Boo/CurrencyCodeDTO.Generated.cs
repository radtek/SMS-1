﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
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
    public partial class CurrencyCodeDTO
    {
        #region Constructors
  
        public CurrencyCodeDTO() {
        }

        public CurrencyCodeDTO(string currencyCode1, string currencyName, List<CountryCodeDTO> countryCodes) {

          this.CurrencyCode1 = currencyCode1;
          this.CurrencyName = currencyName;
          this.CountryCodes = countryCodes;
        }

        #endregion

        #region Properties

        [DataMember]
        public string CurrencyCode1 { get; set; }

        [DataMember]
        public string CurrencyName { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<CountryCodeDTO> CountryCodes { get; set; }

        #endregion
    }

}
