using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class vAttachmentDTO
    {
        [DataMember]
        public System.Guid AttachmentDetailID { get; set; }

        [DataMember]
        public System.Guid AttachmentID { get; set; }

        [DataMember]
        public Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        [Display(Name = "Name")]
        public string FileName { get; set; }

        [DataMember]
        public string RepositoryName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public Nullable<System.Guid> RepositoryStructureID { get; set; }

        [DataMember]
        [Required]
        public string Subject { get; set; }

        [DataMember]
        public string MimeType { get; set; }

        [DataMember]
        public byte[] Body{ get; set;}
        
        [DataMember]
        public int FileSize { get; set; }

        [DataMember]
        public bool DefaultLogo { get; set; }
    }
}
