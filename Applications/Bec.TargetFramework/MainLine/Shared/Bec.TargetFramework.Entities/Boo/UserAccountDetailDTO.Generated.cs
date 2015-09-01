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
    public partial class UserAccountDetailDTO
    {
        #region Constructors
  
        public UserAccountDetailDTO() {
        }

        public UserAccountDetailDTO(global::System.Guid userDetailID, global::System.Guid userID, string salutation, string firstName, string middleName, string lastName, string title, string homePhone, string homeMobile, bool isActive, bool isDeleted, UserAccountDTO userAccount) {

          this.UserDetailID = userDetailID;
          this.UserID = userID;
          this.Salutation = salutation;
          this.FirstName = firstName;
          this.MiddleName = middleName;
          this.LastName = lastName;
          this.Title = title;
          this.HomePhone = homePhone;
          this.HomeMobile = homeMobile;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.UserAccount = userAccount;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserDetailID { get; set; }

        [DataMember]
        public global::System.Guid UserID { get; set; }

        [DataMember]
        public string Salutation { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string HomePhone { get; set; }

        [DataMember]
        public string HomeMobile { get; set; }

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