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
    /// There are no comments for Bec.TargetFramework.Data.VConversation in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VConversation    {

        public VConversation()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for UserAccountOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid UserAccountOrganisationID
        {
            get;
            set;
        }

    
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
        /// There are no comments for MostRecentDate in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> MostRecentDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MostRecentMessage in the schema.
        /// </summary>
        public virtual string MostRecentMessage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MostRecentEmail in the schema.
        /// </summary>
        public virtual string MostRecentEmail
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FirstUnreadDate in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> FirstUnreadDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FirstUnreadMessage in the schema.
        /// </summary>
        public virtual string FirstUnreadMessage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FirstUnreadEmail in the schema.
        /// </summary>
        public virtual string FirstUnreadEmail
        {
            get;
            set;
        }


        #endregion
    }

}
