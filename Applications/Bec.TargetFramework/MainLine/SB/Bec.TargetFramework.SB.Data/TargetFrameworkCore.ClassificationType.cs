﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/06/2015 16:32:47
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Bec.TargetFramework.SB.Data
{

    /// <summary>
    /// There are no comments for Bec.TargetFramework.SB.Data.ClassificationType in the schema.
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [System.Runtime.Serialization.KnownType(typeof(ClassificationTypeCategory))]
    public partial class ClassificationType    {

        public ClassificationType()
        {
          this.IsActive = true;
          this.IsDeleted = false;
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for ClassificationTypeID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual int ClassificationTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClassificationTypeCategoryID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual int ClassificationTypeCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentClassificationTypeCategoryID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Nullable<int> ParentClassificationTypeCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool IsDeleted
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ClassificationTypeCategory_ParentClassificationTypeCategoryID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual ClassificationTypeCategory ClassificationTypeCategory_ParentClassificationTypeCategoryID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ClassificationTypeCategory_ClassificationTypeCategoryID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual ClassificationTypeCategory ClassificationTypeCategory_ClassificationTypeCategoryID
        {
            get;
            set;
        }

        #endregion
    
        #region Extensibility Method Definitions
        partial void OnCreated();
        #endregion
    }

}