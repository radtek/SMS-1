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
    public partial class UserAccountLoginSessionDatumDTO
    {
        #region Constructors
  
        public UserAccountLoginSessionDatumDTO() {
        }

        public UserAccountLoginSessionDatumDTO(global::System.Guid userAccountLoginSessionDataID, global::System.Guid userAccountID, string userSessionID, string requestData, UserAccountLoginSessionDTO userAccountLoginSession) {

          this.UserAccountLoginSessionDataID = userAccountLoginSessionDataID;
          this.UserAccountID = userAccountID;
          this.UserSessionID = userSessionID;
          this.RequestData = requestData;
          this.UserAccountLoginSession = userAccountLoginSession;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserAccountLoginSessionDataID { get; set; }

        [DataMember]
        public global::System.Guid UserAccountID { get; set; }

        [DataMember]
        public string UserSessionID { get; set; }

        [DataMember]
        public string RequestData { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public UserAccountLoginSessionDTO UserAccountLoginSession { get; set; }

        #endregion
    }

}
