﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 16:15:16
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
    /// There are no comments for Bec.TargetFramework.Data.VUserAccountNotLoggedIn in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VUserAccountNotLoggedIn    {

        public VUserAccountNotLoggedIn()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ID in the schema.
        /// </summary>
        public virtual global::System.Guid ID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Username in the schema.
        /// </summary>
        public virtual string Username
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Email in the schema.
        /// </summary>
        public virtual string Email
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsTemporaryAccount in the schema.
        /// </summary>
        public virtual bool IsTemporaryAccount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Created in the schema.
        /// </summary>
        public virtual global::System.DateTime Created
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DaysSinceCreation in the schema.
        /// </summary>
        public virtual global::System.Nullable<double> DaysSinceCreation
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HoursSinceCreation in the schema.
        /// </summary>
        public virtual global::System.Nullable<double> HoursSinceCreation
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Between7and14DaysNotLoggedIn in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> Between7and14DaysNotLoggedIn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Between14and21DaysNotLoggedIn in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> Between14and21DaysNotLoggedIn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Between0and7DaysNotLoggedIn in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> Between0and7DaysNotLoggedIn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GreaterThan21DaysNotLoggedIn in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> GreaterThan21DaysNotLoggedIn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotLoggedIn in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> NotLoggedIn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for COLPRemindersNotReadEver in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> COLPRemindersNotReadEver
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for COLPRegistrationsNotReadEver in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> COLPRegistrationsNotReadEver
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for COLPRemindersNotReadBetween7and14Days in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> COLPRemindersNotReadBetween7and14Days
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for COLPRemindersNotReadBetween14and21Days in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> COLPRemindersNotReadBetween14and21Days
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for COLPRemindersNotReadBetween0and7Days in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> COLPRemindersNotReadBetween0and7Days
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LoginWorkflowDataContent in the schema.
        /// </summary>
        public virtual string LoginWorkflowDataContent
        {
            get;
            set;
        }


        #endregion
    }

}
