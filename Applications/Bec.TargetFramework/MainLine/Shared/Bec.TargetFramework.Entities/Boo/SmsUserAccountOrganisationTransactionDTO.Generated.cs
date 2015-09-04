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
    public partial class SmsUserAccountOrganisationTransactionDTO
    {
        #region Constructors
  
        public SmsUserAccountOrganisationTransactionDTO() {
        }

        public SmsUserAccountOrganisationTransactionDTO(global::System.Guid smsUserAccountOrganisationTransactionId, global::System.Guid userAccountOrganisationId, global::System.Guid smsTransactionId, int smsUserAccountOrganisationTransactionTypeId, SmsTransactionDTO smsTransaction, SmsUserAccountOrganisationTransactionTypeDTO smsUserAccountOrganisationTransactionType, UserAccountOrganisationDTO userAccountOrganisation) {

          this.SmsUserAccountOrganisationTransactionId = smsUserAccountOrganisationTransactionId;
          this.UserAccountOrganisationId = userAccountOrganisationId;
          this.SmsTransactionId = smsTransactionId;
          this.SmsUserAccountOrganisationTransactionTypeId = smsUserAccountOrganisationTransactionTypeId;
          this.SmsTransaction = smsTransaction;
          this.SmsUserAccountOrganisationTransactionType = smsUserAccountOrganisationTransactionType;
          this.UserAccountOrganisation = userAccountOrganisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid SmsUserAccountOrganisationTransactionId { get; set; }

        [DataMember]
        public global::System.Guid UserAccountOrganisationId { get; set; }

        [DataMember]
        public global::System.Guid SmsTransactionId { get; set; }

        [DataMember]
        public int SmsUserAccountOrganisationTransactionTypeId { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public SmsTransactionDTO SmsTransaction { get; set; }

        [DataMember]
        public SmsUserAccountOrganisationTransactionTypeDTO SmsUserAccountOrganisationTransactionType { get; set; }

        [DataMember]
        public UserAccountOrganisationDTO UserAccountOrganisation { get; set; }

        #endregion
    }

}
