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
    /// There are no comments for Bec.TargetFramework.Data.ContactRegulator in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ContactRegulator    {

        public ContactRegulator()
        {
          this.IsPrimary = true;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ContactID in the schema.
        /// </summary>
        public virtual global::System.Guid ContactID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RegulatorID in the schema.
        /// </summary>
        public virtual int RegulatorID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RegulatorNumber in the schema.
        /// </summary>
        public virtual string RegulatorNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPrimary in the schema.
        /// </summary>
        public virtual bool IsPrimary
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DateQualified in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> DateQualified
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

    
        /// <summary>
        /// There are no comments for RegulatorName in the schema.
        /// </summary>
        public virtual string RegulatorName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RegulatorOtherName in the schema.
        /// </summary>
        public virtual string RegulatorOtherName
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Contact in the schema.
        /// </summary>
        public virtual Contact Contact
        {
            get;
            set;
        }

        #endregion
    }

}