﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
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
    /// There are no comments for Bec.TargetFramework.Data.File in the schema.
    /// </summary>
    [System.Serializable]
    public partial class File    {

        public File()
        {
          this.Temporary = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for FileID in the schema.
        /// </summary>
        public virtual global::System.Guid FileID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Guid ParentID
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
        /// There are no comments for Data in the schema.
        /// </summary>
        public virtual byte[] Data
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Type in the schema.
        /// </summary>
        public virtual string Type
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserAccountOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> UserAccountOrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Temporary in the schema.
        /// </summary>
        public virtual bool Temporary
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for UserAccountOrganisation in the schema.
        /// </summary>
        public virtual UserAccountOrganisation UserAccountOrganisation
        {
            get;
            set;
        }

        #endregion
    }

}
