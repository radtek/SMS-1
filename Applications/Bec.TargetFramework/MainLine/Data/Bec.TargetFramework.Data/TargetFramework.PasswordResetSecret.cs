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
    /// There are no comments for Bec.TargetFramework.Data.PasswordResetSecret in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PasswordResetSecret    {

        public PasswordResetSecret()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for PasswordResetSecretID in the schema.
        /// </summary>
        public virtual global::System.Guid PasswordResetSecretID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for QuestionID in the schema.
        /// </summary>
        public virtual int QuestionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Answer in the schema.
        /// </summary>
        public virtual string Answer
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
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual bool IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual bool IsDeleted
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for UserAccount in the schema.
        /// </summary>
        public virtual UserAccount UserAccount
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ClassificationType in the schema.
        /// </summary>
        public virtual ClassificationType ClassificationType
        {
            get;
            set;
        }

        #endregion
    }

}
