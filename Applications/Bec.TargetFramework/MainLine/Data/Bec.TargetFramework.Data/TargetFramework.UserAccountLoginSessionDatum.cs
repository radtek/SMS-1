﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 09/04/2015 12:02:52
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
    /// There are no comments for Bec.TargetFramework.Data.UserAccountLoginSessionDatum in the schema.
    /// </summary>
    [System.Serializable]
    public partial class UserAccountLoginSessionDatum    {

        public UserAccountLoginSessionDatum()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for UserAccountLoginSessionDataID in the schema.
        /// </summary>
        public virtual global::System.Guid UserAccountLoginSessionDataID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserAccountID in the schema.
        /// </summary>
        public virtual global::System.Guid UserAccountID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserSessionID in the schema.
        /// </summary>
        public virtual string UserSessionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RequestData in the schema.
        /// </summary>
        public virtual string RequestData
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for UserAccountLoginSession in the schema.
        /// </summary>
        public virtual UserAccountLoginSession UserAccountLoginSession
        {
            get;
            set;
        }

        #endregion
    }

}
