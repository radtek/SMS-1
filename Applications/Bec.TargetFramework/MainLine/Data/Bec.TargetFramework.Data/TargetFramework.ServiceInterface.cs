﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 26/03/2015 16:14:58
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
    /// There are no comments for Bec.TargetFramework.Data.ServiceInterface in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ServiceInterface    {

        public ServiceInterface()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ServiceInterfaceID in the schema.
        /// </summary>
        public virtual global::System.Guid ServiceInterfaceID
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
        /// There are no comments for ServiceInterfaceTypeID in the schema.
        /// </summary>
        public virtual int ServiceInterfaceTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ServiceInterfaceCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ServiceInterfaceCategoryID
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ServiceDefinitions in the schema.
        /// </summary>
        public virtual ICollection<ServiceDefinition> ServiceDefinitions
        {
            get;
            set;
        }

        #endregion
    }

}
