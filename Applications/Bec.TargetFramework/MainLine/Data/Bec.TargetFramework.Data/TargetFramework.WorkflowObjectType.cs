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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowObjectType in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowObjectType    {

        public WorkflowObjectType()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowObjectTypeID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowObjectTypeID
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
        /// There are no comments for ObjectTypeName in the schema.
        /// </summary>
        public virtual string ObjectTypeName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectTypeNameSpace in the schema.
        /// </summary>
        public virtual string ObjectTypeNameSpace
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectTypeAssembly in the schema.
        /// </summary>
        public virtual string ObjectTypeAssembly
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowVersionNumber in the schema.
        /// </summary>
        public virtual int WorkflowVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for WorkflowActions in the schema.
        /// </summary>
        public virtual ICollection<WorkflowAction> WorkflowActions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowCommands in the schema.
        /// </summary>
        public virtual ICollection<WorkflowCommand> WorkflowCommands
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisions in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecision> WorkflowDecisions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Workflow in the schema.
        /// </summary>
        public virtual Workflow Workflow
        {
            get;
            set;
        }

        #endregion
    }

}
