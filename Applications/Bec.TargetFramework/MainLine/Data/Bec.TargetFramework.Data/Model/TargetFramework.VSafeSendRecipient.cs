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
    /// There are no comments for Bec.TargetFramework.Data.VSafeSendRecipient in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VSafeSendRecipient    {

        public VSafeSendRecipient()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for SmsTransactionID in the schema.
        /// </summary>
        public virtual global::System.Guid SmsTransactionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RelatedID in the schema.
        /// </summary>
        public virtual global::System.Guid RelatedID
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
        /// There are no comments for IsFunction in the schema.
        /// </summary>
        public virtual bool IsFunction
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationTypeName in the schema.
        /// </summary>
        public virtual string OrganisationTypeName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationName in the schema.
        /// </summary>
        public virtual string OrganisationName
        {
            get;
            set;
        }


        #endregion
    }

}
