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
    /// There are no comments for Bec.TargetFramework.Data.ConversationSafeSendGroupParticipant in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ConversationSafeSendGroupParticipant    {

        public ConversationSafeSendGroupParticipant()
        {
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
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SafeSendGroupID in the schema.
        /// </summary>
        public virtual global::System.Guid SafeSendGroupID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Added in the schema.
        /// </summary>
        public virtual global::System.DateTime Added
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Conversation in the schema.
        /// </summary>
        public virtual Conversation Conversation
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Organisation in the schema.
        /// </summary>
        public virtual Organisation Organisation
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SafeSendGroup in the schema.
        /// </summary>
        public virtual SafeSendGroup SafeSendGroup
        {
            get;
            set;
        }

        #endregion
    }

}