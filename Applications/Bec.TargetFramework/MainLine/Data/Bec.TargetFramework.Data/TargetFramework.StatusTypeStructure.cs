﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 3/27/2015 9:57:18 AM
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
    /// There are no comments for Bec.TargetFramework.Data.StatusTypeStructure in the schema.
    /// </summary>
    [System.Serializable]
    public partial class StatusTypeStructure    {

        public StatusTypeStructure()
        {
          this.StatusOrder = 0;
          this.IsStart = false;
          this.IsEnd = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for StatusTypeStructureID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeStructureID
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
        /// There are no comments for StatusTypeValueID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> StatusTypeValueID
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

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for StatusType in the schema.
        /// </summary>
        public virtual StatusType StatusType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeValue in the schema.
        /// </summary>
        public virtual StatusTypeValue StatusTypeValue
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeStructureTransitions_NextStatusTypeStructureID in the schema.
        /// </summary>
        public virtual ICollection<StatusTypeStructureTransition> StatusTypeStructureTransitions_NextStatusTypeStructureID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeStructureTransitions_CurrentStatusTypeStructureID in the schema.
        /// </summary>
        public virtual ICollection<StatusTypeStructureTransition> StatusTypeStructureTransitions_CurrentStatusTypeStructureID
        {
            get;
            set;
        }

        #endregion
    }

}
