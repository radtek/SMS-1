﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 02/04/2015 16:41:46
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
    /// There are no comments for Bec.TargetFramework.Data.VStatusType in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VStatusType    {

        public VStatusType()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for StatusTypeValueID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeValueID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeVersionNumber in the schema.
        /// </summary>
        public virtual int StatusTypeVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeName in the schema.
        /// </summary>
        public virtual string StatusTypeName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusOrder in the schema.
        /// </summary>
        public virtual int StatusOrder
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsStart in the schema.
        /// </summary>
        public virtual bool IsStart
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsEnd in the schema.
        /// </summary>
        public virtual bool IsEnd
        {
            get;
            set;
        }


        #endregion
    }

}
