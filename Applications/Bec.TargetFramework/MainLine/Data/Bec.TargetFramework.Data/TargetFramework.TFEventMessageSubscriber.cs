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
    /// There are no comments for Bec.TargetFramework.Data.TFEventMessageSubscriber in the schema.
    /// </summary>
    [System.Serializable]
    public partial class TFEventMessageSubscriber    {

        public TFEventMessageSubscriber()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for TFEventMessageSubscriberID in the schema.
        /// </summary>
        public virtual global::System.Guid TFEventMessageSubscriberID
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
        /// There are no comments for TFEvents in the schema.
        /// </summary>
        public virtual ICollection<TFEvent> TFEvents
        {
            get;
            set;
        }

        #endregion
    }

}
