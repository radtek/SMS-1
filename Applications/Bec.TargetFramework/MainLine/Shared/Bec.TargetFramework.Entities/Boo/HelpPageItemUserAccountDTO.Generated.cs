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
    public partial class HelpPageItemUserAccountDTO
    {
        #region Constructors
  
        public HelpPageItemUserAccountDTO() {
        }

        public HelpPageItemUserAccountDTO(global::System.Guid helpItemUserAccountID, global::System.Guid helpPageItemID, global::System.DateTime createdOn, global::System.Guid userID, global::System.Nullable<bool> visible, HelpPageItemDTO helpPageItem, UserAccountDTO userAccount) {

          this.HelpItemUserAccountID = helpItemUserAccountID;
          this.HelpPageItemID = helpPageItemID;
          this.CreatedOn = createdOn;
          this.UserID = userID;
          this.Visible = visible;
          this.HelpPageItem = helpPageItem;
          this.UserAccount = userAccount;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid HelpItemUserAccountID { get; set; }

        [DataMember]
        public global::System.Guid HelpPageItemID { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public global::System.Guid UserID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> Visible { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public HelpPageItemDTO HelpPageItem { get; set; }

        [DataMember]
        public UserAccountDTO UserAccount { get; set; }

        #endregion
    }

}
