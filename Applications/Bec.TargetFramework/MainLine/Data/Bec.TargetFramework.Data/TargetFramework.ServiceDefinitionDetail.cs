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
    /// There are no comments for Bec.TargetFramework.Data.ServiceDefinitionDetail in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ServiceDefinitionDetail    {

        public ServiceDefinitionDetail()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ServiceDefinitionDetailID in the schema.
        /// </summary>
        public virtual global::System.Guid ServiceDefinitionDetailID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EnvironmentName in the schema.
        /// </summary>
        public virtual string EnvironmentName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ServicePartialURL in the schema.
        /// </summary>
        public virtual string ServicePartialURL
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
        /// There are no comments for ServiceDefinitionID in the schema.
        /// </summary>
        public virtual global::System.Guid ServiceDefinitionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ServerURL in the schema.
        /// </summary>
        public virtual string ServerURL
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ServiceDefinition in the schema.
        /// </summary>
        public virtual ServiceDefinition ServiceDefinition
        {
            get;
            set;
        }

        #endregion
    }

}
