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
    /// There are no comments for Bec.TargetFramework.Data.TFEventType in the schema.
    /// </summary>
    [System.Serializable]
    public partial class TFEventType    {

        public TFEventType()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for TFEventTypeID in the schema.
        /// </summary>
        public virtual global::System.Guid TFEventTypeID
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
