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
    /// There are no comments for Bec.TargetFramework.Data.NotificationConstructParameter in the schema.
    /// </summary>
    [System.Serializable]
    public partial class NotificationConstructParameter    {

        public NotificationConstructParameter()
        {
          this.IsMandatory = true;
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsBusinessObject = true;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for NotificationConstructParameterID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationConstructParameterID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationConstructID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationConstructID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationConstructVersionNumber in the schema.
        /// </summary>
        public virtual int NotificationConstructVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParameterOrBusinessObjectName in the schema.
        /// </summary>
        public virtual string ParameterOrBusinessObjectName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultValue in the schema.
        /// </summary>
        public virtual string DefaultValue
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectType in the schema.
        /// </summary>
        public virtual string ObjectType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectName in the schema.
        /// </summary>
        public virtual string ObjectName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectNameSpace in the schema.
        /// </summary>
        public virtual string ObjectNameSpace
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectAssembly in the schema.
        /// </summary>
        public virtual string ObjectAssembly
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectParentName in the schema.
        /// </summary>
        public virtual string ObjectParentName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectParentNameSpace in the schema.
        /// </summary>
        public virtual string ObjectParentNameSpace
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectParentAssembly in the schema.
        /// </summary>
        public virtual string ObjectParentAssembly
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsMandatory in the schema.
        /// </summary>
        public virtual bool IsMandatory
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
        /// There are no comments for IsBusinessObject in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsBusinessObject
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusinessObjectCategoryName in the schema.
        /// </summary>
        public virtual string BusinessObjectCategoryName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectParentType in the schema.
        /// </summary>
        public virtual string ObjectParentType
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for NotificationConstruct in the schema.
        /// </summary>
        public virtual NotificationConstruct NotificationConstruct
        {
            get;
            set;
        }

        #endregion
    }

}