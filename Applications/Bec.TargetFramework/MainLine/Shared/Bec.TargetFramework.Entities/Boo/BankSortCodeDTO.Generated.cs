﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
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
    public partial class BankSortCodeDTO
    {
        #region Constructors
  
        public BankSortCodeDTO() {
        }

        public BankSortCodeDTO(string sortCode, string address, string bankName) {

          this.SortCode = sortCode;
          this.Address = address;
          this.BankName = bankName;
        }

        #endregion

        #region Properties

        [DataMember]
        public string SortCode { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string BankName { get; set; }

        #endregion
    }

}
