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
    public partial class BusMessageDTO
    {
        #region Constructors
  
        public BusMessageDTO() {
        }

        public BusMessageDTO(global::System.Guid messageId, global::System.Guid correlationId, global::System.Guid busMessageID, global::System.Guid conversationId, global::System.Nullable<System.DateTime> timeSent, string enclosedMessageTypes, string winIdName, string processingMachine, global::System.Nullable<System.DateTime> processingStarted, int busMessageTypeID, string messageSentFrom, string source, global::System.Nullable<System.Guid> parentID, string eventReference, List<BusMessageContentDTO> busMessageContents, List<BusMessageProcessLogDTO> busMessageProcessLogs) {

          this.MessageId = messageId;
          this.CorrelationId = correlationId;
          this.BusMessageID = busMessageID;
          this.ConversationId = conversationId;
          this.TimeSent = timeSent;
          this.EnclosedMessageTypes = enclosedMessageTypes;
          this.WinIdName = winIdName;
          this.ProcessingMachine = processingMachine;
          this.ProcessingStarted = processingStarted;
          this.BusMessageTypeID = busMessageTypeID;
          this.MessageSentFrom = messageSentFrom;
          this.Source = source;
          this.ParentID = parentID;
          this.EventReference = eventReference;
          this.BusMessageContents = busMessageContents;
          this.BusMessageProcessLogs = busMessageProcessLogs;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid MessageId { get; set; }

        [DataMember]
        public global::System.Guid CorrelationId { get; set; }

        [DataMember]
        public global::System.Guid BusMessageID { get; set; }

        [DataMember]
        public global::System.Guid ConversationId { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> TimeSent { get; set; }

        [DataMember]
        public string EnclosedMessageTypes { get; set; }

        [DataMember]
        public string WinIdName { get; set; }

        [DataMember]
        public string ProcessingMachine { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ProcessingStarted { get; set; }

        [DataMember]
        public int BusMessageTypeID { get; set; }

        [DataMember]
        public string MessageSentFrom { get; set; }

        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public string EventReference { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<BusMessageContentDTO> BusMessageContents { get; set; }

        [DataMember]
        public List<BusMessageProcessLogDTO> BusMessageProcessLogs { get; set; }

        #endregion
    }

}
