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
    public partial class VOrganisationBankAccountsWithStatusDTO
    {
        #region Constructors
  
        public VOrganisationBankAccountsWithStatusDTO() {
        }

        public VOrganisationBankAccountsWithStatusDTO(global::System.Guid organisationID, string name, global::System.Guid organisationBankAccountID, string bankAccountNumber, global::System.DateTime created, string status, string sortCode) {

          this.OrganisationID = organisationID;
          this.Name = name;
          this.OrganisationBankAccountID = organisationBankAccountID;
          this.BankAccountNumber = bankAccountNumber;
          this.Created = created;
          this.Status = status;
          this.SortCode = sortCode;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public global::System.Guid OrganisationBankAccountID { get; set; }

        [DataMember]
        public string BankAccountNumber { get; set; }

        [DataMember]
        public global::System.DateTime Created { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string SortCode { get; set; }

        #endregion
    }

}
