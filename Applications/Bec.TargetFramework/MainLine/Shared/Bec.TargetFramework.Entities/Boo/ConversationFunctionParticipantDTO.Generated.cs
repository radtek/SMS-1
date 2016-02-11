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
    public partial class ConversationFunctionParticipantDTO
    {
        #region Constructors
  
        public ConversationFunctionParticipantDTO() {
        }

        public ConversationFunctionParticipantDTO(global::System.Guid conversationID, global::System.Guid organisationID, global::System.Guid functionID, global::System.DateTime added, ConversationDTO conversation, OrganisationDTO organisation, FunctionDTO function) {

          this.ConversationID = conversationID;
          this.OrganisationID = organisationID;
          this.FunctionID = functionID;
          this.Added = added;
          this.Conversation = conversation;
          this.Organisation = organisation;
          this.Function = function;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ConversationID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.Guid FunctionID { get; set; }

        [DataMember]
        public global::System.DateTime Added { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ConversationDTO Conversation { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        [DataMember]
        public FunctionDTO Function { get; set; }

        #endregion
    }

}
