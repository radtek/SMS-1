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
    /// There are no comments for Bec.TargetFramework.Data.BusEventBusEventMessageSubscriber in the schema.
    /// </summary>
    [System.Serializable]
    public partial class BusEventBusEventMessageSubscriber    {

        public BusEventBusEventMessageSubscriber()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for BusEventID in the schema.
        /// </summary>
        public virtual global::System.Guid BusEventID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusEventMessageSubscriberID in the schema.
        /// </summary>
        public virtual global::System.Guid BusEventMessageSubscriberID
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
        /// There are no comments for BusEventMessageSubscriberFilter in the schema.
        /// </summary>
        public virtual string BusEventMessageSubscriberFilter
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for BusEvent in the schema.
        /// </summary>
        public virtual BusEvent BusEvent
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BusEventMessageSubscriber in the schema.
        /// </summary>
        public virtual BusEventMessageSubscriber BusEventMessageSubscriber
        {
            get;
            set;
        }

        #endregion
    }

}
