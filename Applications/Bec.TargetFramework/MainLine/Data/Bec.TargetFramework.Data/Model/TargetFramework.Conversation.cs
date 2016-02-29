﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Bec.TargetFramework.Data
{

    /// <summary>
    /// There are no comments for Bec.TargetFramework.Data.Conversation in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Conversation    {

        public Conversation()
        {
          this.IsSystemMessage = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ConversationID in the schema.
        /// </summary>
        public virtual global::System.Guid ConversationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Subject in the schema.
        /// </summary>
        public virtual string Subject
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ActivityType in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ActivityType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ActivityID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ActivityID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsSystemMessage in the schema.
        /// </summary>
        public virtual bool IsSystemMessage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Latest in the schema.
        /// </summary>
        public virtual global::System.DateTime Latest
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ConversationParticipants in the schema.
        /// </summary>
        public virtual ICollection<ConversationParticipant> ConversationParticipants
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Notifications in the schema.
        /// </summary>
        public virtual ICollection<Notification> Notifications
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ConversationSafeSendGroupParticipants in the schema.
        /// </summary>
        public virtual ICollection<ConversationSafeSendGroupParticipant> ConversationSafeSendGroupParticipants
        {
            get;
            set;
        }

        #endregion
    }

}
