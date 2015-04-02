﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:50
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
    public partial class AttachmentDTO
    {
        #region Constructors
  
        public AttachmentDTO() {
        }

        public AttachmentDTO(global::System.Guid attachmentID, string mimeType, byte[] body, string subject, string fileName, global::System.Nullable<int> fileSize, global::System.Guid attachmentDetailID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> parentID, AttachmentDetailDTO attachmentDetail, List<LRDocumentDTO> lRDocuments) {

          this.AttachmentID = attachmentID;
          this.MimeType = mimeType;
          this.Body = body;
          this.Subject = subject;
          this.FileName = fileName;
          this.FileSize = fileSize;
          this.AttachmentDetailID = attachmentDetailID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ParentID = parentID;
          this.AttachmentDetail = attachmentDetail;
          this.LRDocuments = lRDocuments;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid AttachmentID { get; set; }

        [DataMember]
        public string MimeType { get; set; }

        [DataMember]
        public byte[] Body { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public global::System.Nullable<int> FileSize { get; set; }

        [DataMember]
        public global::System.Guid AttachmentDetailID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public AttachmentDetailDTO AttachmentDetail { get; set; }

        [DataMember]
        public List<LRDocumentDTO> LRDocuments { get; set; }

        #endregion
    }

}
