﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 13/04/2015 17:29:36
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
    /// There are no comments for Bec.TargetFramework.Data.NotificationConstructDataTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class NotificationConstructDataTemplate    {

        public NotificationConstructDataTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.UsesBusinessObjects = true;
          this.UsesDataSources = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for NotificationConstructDataTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationConstructDataTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationConstructTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationConstructTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationConstructTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int NotificationConstructTemplateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationData in the schema.
        /// </summary>
        public virtual byte[] NotificationData
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationDataLength in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NotificationDataLength
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationDataMimeType in the schema.
        /// </summary>
        public virtual string NotificationDataMimeType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationDataFileName in the schema.
        /// </summary>
        public virtual string NotificationDataFileName
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
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> CreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UsesBusinessObjects in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> UsesBusinessObjects
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UsesDataSources in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> UsesDataSources
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for NotificationConstructTemplate in the schema.
        /// </summary>
        public virtual NotificationConstructTemplate NotificationConstructTemplate
        {
            get;
            set;
        }

        #endregion
    }

}
