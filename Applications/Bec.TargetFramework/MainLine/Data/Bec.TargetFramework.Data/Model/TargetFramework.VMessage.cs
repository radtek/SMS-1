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
    /// There are no comments for Bec.TargetFramework.Data.VMessage in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VMessage    {

        public VMessage()
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
        /// There are no comments for NotificationID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedByUserAccountOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> CreatedByUserAccountOrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DateSent in the schema.
        /// </summary>
        public virtual global::System.DateTime DateSent
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Message in the schema.
        /// </summary>
        public virtual string Message
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Email in the schema.
        /// </summary>
        public virtual string Email
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FirstName in the schema.
        /// </summary>
        public virtual string FirstName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastName in the schema.
        /// </summary>
        public virtual string LastName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserType in the schema.
        /// </summary>
        public virtual string UserType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationType in the schema.
        /// </summary>
        public virtual string OrganisationType
        {
            get;
            set;
        }


        #endregion
    }

}
