﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class NewsArticleDTO
    {
        #region Constructors
  
        public NewsArticleDTO() {
        }

        public NewsArticleDTO(global::System.Guid newsArticleID, string title, global::System.DateTime dateTime, string content) {

          this.NewsArticleID = newsArticleID;
          this.Title = title;
          this.DateTime = dateTime;
          this.Content = content;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NewsArticleID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public global::System.DateTime DateTime { get; set; }

        [DataMember]
        public string Content { get; set; }

        #endregion
    }

}
