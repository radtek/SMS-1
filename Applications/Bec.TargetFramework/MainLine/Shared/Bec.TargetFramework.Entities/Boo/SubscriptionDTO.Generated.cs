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
    public partial class SubscriptionDTO
    {
        #region Constructors
  
        public SubscriptionDTO() {
        }

        public SubscriptionDTO(string subscriberendpoint, string messagetype, string version, string typename) {

          this.Subscriberendpoint = subscriberendpoint;
          this.Messagetype = messagetype;
          this.Version = version;
          this.Typename = typename;
        }

        #endregion

        #region Properties

        [DataMember]
        public string Subscriberendpoint { get; set; }

        [DataMember]
        public string Messagetype { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public string Typename { get; set; }

        #endregion
    }

}