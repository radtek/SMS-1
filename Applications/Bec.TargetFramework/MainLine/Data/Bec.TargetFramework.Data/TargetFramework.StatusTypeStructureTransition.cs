﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 26/03/2015 16:14:57
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
    /// There are no comments for Bec.TargetFramework.Data.StatusTypeStructureTransition in the schema.
    /// </summary>
    [System.Serializable]
    public partial class StatusTypeStructureTransition    {

        public StatusTypeStructureTransition()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for StatusTypeStructureTransitionID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeStructureTransitionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrentStatusTypeStructureID in the schema.
        /// </summary>
        public virtual global::System.Guid CurrentStatusTypeStructureID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NextStatusTypeStructureID in the schema.
        /// </summary>
        public virtual global::System.Guid NextStatusTypeStructureID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for StatusTypeStructure_NextStatusTypeStructureID in the schema.
        /// </summary>
        public virtual StatusTypeStructure StatusTypeStructure_NextStatusTypeStructureID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeStructure_CurrentStatusTypeStructureID in the schema.
        /// </summary>
        public virtual StatusTypeStructure StatusTypeStructure_CurrentStatusTypeStructureID
        {
            get;
            set;
        }

        #endregion
    }

}
