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
    /// There are no comments for Bec.TargetFramework.Data.NewsArticle in the schema.
    /// </summary>
    [System.Serializable]
    public partial class NewsArticle    {

        public NewsArticle()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for NewsArticleID in the schema.
        /// </summary>
        public virtual global::System.Guid NewsArticleID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Title in the schema.
        /// </summary>
        public virtual string Title
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DateTime in the schema.
        /// </summary>
        public virtual global::System.DateTime DateTime
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Content in the schema.
        /// </summary>
        public virtual string Content
        {
            get;
            set;
        }


        #endregion
    }

}
