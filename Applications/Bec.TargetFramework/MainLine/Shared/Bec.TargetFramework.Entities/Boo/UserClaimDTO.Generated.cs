﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:50
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
    public partial class UserClaimDTO
    {
        #region Constructors
  
        public UserClaimDTO() {
        }

        public UserClaimDTO(global::System.Guid userAccountID, string type, string value, bool isActive, bool isDeleted, UserAccountDTO userAccount) {

          this.UserAccountID = userAccountID;
          this.Type = type;
          this.Value = value;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.UserAccount = userAccount;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserAccountID { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public UserAccountDTO UserAccount { get; set; }

        #endregion
    }

}
