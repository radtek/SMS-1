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
    /// There are no comments for Bec.TargetFramework.Data.TFEvent in the schema.
    /// </summary>
    [System.Serializable]
    public partial class TFEvent    {

        public TFEvent()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for TFEventID in the schema.
        /// </summary>
        public virtual global::System.Guid TFEventID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TFEventName in the schema.
        /// </summary>
        public virtual string TFEventName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TFEventDescription in the schema.
        /// </summary>
        public virtual string TFEventDescription
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TFEventTypeID in the schema.
        /// </summary>
        public virtual global::System.Guid TFEventTypeID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for TFEventType in the schema.
        /// </summary>
        public virtual TFEventType TFEventType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for TFEventMessageSubscribers in the schema.
        /// </summary>
        public virtual ICollection<TFEventMessageSubscriber> TFEventMessageSubscribers
        {
            get;
            set;
        }

        #endregion
    }

}
