﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:38
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
    public partial class TimeoutentityDTO
    {
        #region Constructors
  
        public TimeoutentityDTO() {
        }

        public TimeoutentityDTO(global::System.Guid id, string destination, global::System.Nullable<System.Guid> sagaid, byte[] state, global::System.Nullable<System.DateTime> time, string correlationid, string headers, string endpoint) {

          this.Id = id;
          this.Destination = destination;
          this.Sagaid = sagaid;
          this.State = state;
          this.Time = time;
          this.Correlationid = correlationid;
          this.Headers = headers;
          this.Endpoint = endpoint;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid Id { get; set; }

        [DataMember]
        public string Destination { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> Sagaid { get; set; }

        [DataMember]
        public byte[] State { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> Time { get; set; }

        [DataMember]
        public string Correlationid { get; set; }

        [DataMember]
        public string Headers { get; set; }

        [DataMember]
        public string Endpoint { get; set; }

        #endregion
    }

}
