﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/04/2015 17:09:52
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
    /// There are no comments for Bec.TargetFramework.Data.VUserStatus in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VUserStatus    {

        public VUserStatus()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for UserAccountOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid UserAccountOrganisationID
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
        /// There are no comments for UserID in the schema.
        /// </summary>
        public virtual global::System.Guid UserID
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
        /// There are no comments for UserTypeID in the schema.
        /// </summary>
        public virtual global::System.Guid UserTypeID
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
        /// There are no comments for StatusTypeTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int StatusTypeTemplateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeValueID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeValueID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusValueName in the schema.
        /// </summary>
        public virtual string StatusValueName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusChangedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime StatusChangedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusChangedBy in the schema.
        /// </summary>
        public virtual string StatusChangedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusOrder in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> StatusOrder
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsStart in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsStart
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsEnd in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsEnd
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NextStatusTypeValueID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> NextStatusTypeValueID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NextStatusTypeName in the schema.
        /// </summary>
        public virtual string NextStatusTypeName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NextStatusOrder in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NextStatusOrder
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NextStatusStart in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> NextStatusStart
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NextStatusEnd in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> NextStatusEnd
        {
            get;
            set;
        }


        #endregion
    }

}
