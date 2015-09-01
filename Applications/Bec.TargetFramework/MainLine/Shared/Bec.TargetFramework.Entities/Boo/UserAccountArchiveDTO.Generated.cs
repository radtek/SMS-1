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
    public partial class UserAccountArchiveDTO
    {
        #region Constructors
  
        public UserAccountArchiveDTO() {
        }

        public UserAccountArchiveDTO(global::System.Guid userAccountArchiveID, global::System.DateTime userAccountArchiveCreatedOn, int userAccountArchiveTypeID, int userAccountArchiveCategoryID, string userAccountArchiveData, int userAccountArchiveVersionID, global::System.DateTime userAccountArchiveStartDate, global::System.Nullable<System.DateTime> userAccountArchiveEndDate, global::System.Guid userID, UserAccountDTO userAccount, ClassificationTypeDTO classificationType, ClassificationTypeCategoryDTO classificationTypeCategory) {

          this.UserAccountArchiveID = userAccountArchiveID;
          this.UserAccountArchiveCreatedOn = userAccountArchiveCreatedOn;
          this.UserAccountArchiveTypeID = userAccountArchiveTypeID;
          this.UserAccountArchiveCategoryID = userAccountArchiveCategoryID;
          this.UserAccountArchiveData = userAccountArchiveData;
          this.UserAccountArchiveVersionID = userAccountArchiveVersionID;
          this.UserAccountArchiveStartDate = userAccountArchiveStartDate;
          this.UserAccountArchiveEndDate = userAccountArchiveEndDate;
          this.UserID = userID;
          this.UserAccount = userAccount;
          this.ClassificationType = classificationType;
          this.ClassificationTypeCategory = classificationTypeCategory;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserAccountArchiveID { get; set; }

        [DataMember]
        public global::System.DateTime UserAccountArchiveCreatedOn { get; set; }

        [DataMember]
        public int UserAccountArchiveTypeID { get; set; }

        [DataMember]
        public int UserAccountArchiveCategoryID { get; set; }

        [DataMember]
        public string UserAccountArchiveData { get; set; }

        [DataMember]
        public int UserAccountArchiveVersionID { get; set; }

        [DataMember]
        public global::System.DateTime UserAccountArchiveStartDate { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> UserAccountArchiveEndDate { get; set; }

        [DataMember]
        public global::System.Guid UserID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public UserAccountDTO UserAccount { get; set; }

        [DataMember]
        public ClassificationTypeDTO ClassificationType { get; set; }

        [DataMember]
        public ClassificationTypeCategoryDTO ClassificationTypeCategory { get; set; }

        #endregion
    }

}