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
    /// There are no comments for Bec.TargetFramework.Data.PackageProductRelationship in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PackageProductRelationship    {

        public PackageProductRelationship()
        {
          this.IsMandatory = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for PackageProductRelationshipID in the schema.
        /// </summary>
        public virtual global::System.Guid PackageProductRelationshipID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentProductID in the schema.
        /// </summary>
        public virtual global::System.Guid ParentProductID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ChildProductID in the schema.
        /// </summary>
        public virtual global::System.Guid ChildProductID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductRelationshipTypeID in the schema.
        /// </summary>
        public virtual int ProductRelationshipTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsMandatory in the schema.
        /// </summary>
        public virtual bool IsMandatory
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
        /// There are no comments for PackageProductID in the schema.
        /// </summary>
        public virtual global::System.Guid PackageProductID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentProductVersionID in the schema.
        /// </summary>
        public virtual int ParentProductVersionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ChildProductVersionID in the schema.
        /// </summary>
        public virtual int ChildProductVersionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PackageID in the schema.
        /// </summary>
        public virtual global::System.Guid PackageID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PackageVersionNumber in the schema.
        /// </summary>
        public virtual int PackageVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Product_ParentProductID_ParentProductVersionID in the schema.
        /// </summary>
        public virtual Product Product_ParentProductID_ParentProductVersionID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Product_ChildProductID_ChildProductVersionID in the schema.
        /// </summary>
        public virtual Product Product_ChildProductID_ChildProductVersionID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PackageProduct in the schema.
        /// </summary>
        public virtual PackageProduct PackageProduct
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PackageProductRelationshipBlueprints in the schema.
        /// </summary>
        public virtual ICollection<PackageProductRelationshipBlueprint> PackageProductRelationshipBlueprints
        {
            get;
            set;
        }

        #endregion
    }

}
