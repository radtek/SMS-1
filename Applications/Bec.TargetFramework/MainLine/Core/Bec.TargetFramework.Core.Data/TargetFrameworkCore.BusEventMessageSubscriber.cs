﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 09:00:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace TargetFrameworkCoreModel
{

    /// <summary>
    /// There are no comments for TargetFrameworkCoreModel.BusEventMessageSubscriber in the schema.
    /// </summary>
    public partial class BusEventMessageSubscriber    {

        public BusEventMessageSubscriber()
        {
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for BusEventMessageSubscriberID in the schema.
        /// </summary>
        public virtual global::System.Guid BusEventMessageSubscriberID
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
        /// There are no comments for ObjectName in the schema.
        /// </summary>
        public virtual string ObjectName
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
        /// There are no comments for DefaultMessageSubscriberFilter in the schema.
        /// </summary>
        public virtual string DefaultMessageSubscriberFilter
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for BusEventBusEventMessageSubscribers in the schema.
        /// </summary>
        public virtual ICollection<BusEventBusEventMessageSubscriber> BusEventBusEventMessageSubscribers
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
