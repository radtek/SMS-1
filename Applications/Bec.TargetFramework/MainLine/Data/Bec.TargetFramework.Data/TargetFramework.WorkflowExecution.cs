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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowExecution in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowExecution    {

        public WorkflowExecution()
        {
          this.VersionNumber = 0;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowExecutionID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowExecutionID
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
        /// There are no comments for Description in the schema.
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VersionNumber in the schema.
        /// </summary>
        public virtual int VersionNumber
        {
            get;
            set;
        }


        #endregion
    }

}
