﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
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
    public partial class VAttachmentDTO
    {
        #region Constructors
  
        public VAttachmentDTO() {
        }

        public VAttachmentDTO(global::System.Guid attachmentDetailID, global::System.Nullable<System.Guid> organisationID, bool isActive, bool isDeleted, string fileName, global::System.Guid repositoryStructureID, string subject, string mimeType, byte[] body, global::System.Nullable<int> fileSize, string repositoryName, global::System.Guid attachmentID) {

          this.AttachmentDetailID = attachmentDetailID;
          this.OrganisationID = organisationID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.FileName = fileName;
          this.RepositoryStructureID = repositoryStructureID;
          this.Subject = subject;
          this.MimeType = mimeType;
          this.Body = body;
          this.FileSize = fileSize;
          this.RepositoryName = repositoryName;
          this.AttachmentID = attachmentID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid AttachmentDetailID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public global::System.Guid RepositoryStructureID { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public string MimeType { get; set; }

        [DataMember]
        public byte[] Body { get; set; }

        [DataMember]
        public global::System.Nullable<int> FileSize { get; set; }

        [DataMember]
        public string RepositoryName { get; set; }

        [DataMember]
        public global::System.Guid AttachmentID { get; set; }

        #endregion
    }

}
