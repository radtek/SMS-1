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
    public partial class UserCertificateDTO
    {
        #region Constructors
  
        public UserCertificateDTO() {
        }

        public UserCertificateDTO(global::System.Guid userAccountID, string thumbprint, string subject, bool isActive, bool isDeleted, UserAccountDTO userAccount) {

          this.UserAccountID = userAccountID;
          this.Thumbprint = thumbprint;
          this.Subject = subject;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.UserAccount = userAccount;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserAccountID { get; set; }

        [DataMember]
        public string Thumbprint { get; set; }

        [DataMember]
        public string Subject { get; set; }

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
