﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
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
    public partial class BusMessageContentDTO
    {
        #region Constructors
  
        public BusMessageContentDTO() {
        }

        public BusMessageContentDTO(int busMessageContentID, byte[] busMessageContent1, global::System.Guid busMessageID, string busMessageContentType, string busMessageHeader, BusMessageDTO busMessage) {

          this.BusMessageContentID = busMessageContentID;
          this.BusMessageContent1 = busMessageContent1;
          this.BusMessageID = busMessageID;
          this.BusMessageContentType = busMessageContentType;
          this.BusMessageHeader = busMessageHeader;
          this.BusMessage = busMessage;
        }

        #endregion

        #region Properties

        [DataMember]
        public int BusMessageContentID { get; set; }

        [DataMember]
        public byte[] BusMessageContent1 { get; set; }

        [DataMember]
        public global::System.Guid BusMessageID { get; set; }

        [DataMember]
        public string BusMessageContentType { get; set; }

        [DataMember]
        public string BusMessageHeader { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public BusMessageDTO BusMessage { get; set; }

        #endregion
    }

}
