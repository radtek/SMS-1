﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 18/03/2015 19:00:45
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
    /// There are no comments for Bec.TargetFramework.Data.ArtefactSubscription in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ArtefactSubscription    {

        public ArtefactSubscription()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ArtefactSubscriptionID in the schema.
        /// </summary>
        public virtual global::System.Guid ArtefactSubscriptionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ArtefactID in the schema.
        /// </summary>
        public virtual global::System.Guid ArtefactID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ArtefactVersionNumber in the schema.
        /// </summary>
        public virtual int ArtefactVersionNumber
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
        /// There are no comments for PlanSubscriptionID in the schema.
        /// </summary>
        public virtual global::System.Guid PlanSubscriptionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionVersionNumber in the schema.
        /// </summary>
        public virtual int PlanSubscriptionVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Artefact in the schema.
        /// </summary>
        public virtual Artefact Artefact
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanSubscription in the schema.
        /// </summary>
        public virtual PlanSubscription PlanSubscription
        {
            get;
            set;
        }

        #endregion
    }

}
