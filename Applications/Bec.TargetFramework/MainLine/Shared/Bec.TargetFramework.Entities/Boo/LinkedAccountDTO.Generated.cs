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
    public partial class LinkedAccountDTO
    {
        #region Constructors
  
        public LinkedAccountDTO() {
        }

        public LinkedAccountDTO(global::System.Guid userAccountID, string providerName, string providerAccountID, global::System.DateTime lastLogin, bool isActive, bool isDeleted, UserAccountDTO userAccount, List<LinkedAccountClaimDTO> linkedAccountClaims) {

          this.UserAccountID = userAccountID;
          this.ProviderName = providerName;
          this.ProviderAccountID = providerAccountID;
          this.LastLogin = lastLogin;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.UserAccount = userAccount;
          this.LinkedAccountClaims = linkedAccountClaims;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserAccountID { get; set; }

        [DataMember]
        public string ProviderName { get; set; }

        [DataMember]
        public string ProviderAccountID { get; set; }

        [DataMember]
        public global::System.DateTime LastLogin { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public UserAccountDTO UserAccount { get; set; }

        [DataMember]
        public List<LinkedAccountClaimDTO> LinkedAccountClaims { get; set; }

        #endregion
    }

}
