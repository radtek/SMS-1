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
    /// There are no comments for Bec.TargetFramework.Data.VSafeSendRecipientSupport in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VSafeSendRecipientSupport    {

        public VSafeSendRecipientSupport()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for SupportItemID in the schema.
        /// </summary>
        public virtual global::System.Guid SupportItemID
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
        /// There are no comments for OrganisationName in the schema.
        /// </summary>
        public virtual string OrganisationName
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
        /// There are no comments for IsSafeSendGroup in the schema.
        /// </summary>
        public virtual bool IsSafeSendGroup
        {
            get;
            set;
        }


        #endregion
    }

}
