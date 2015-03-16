using Bec.TargetFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ServiceStack.Text;
using BrockAllen.MembershipReboot;

namespace Bec.TargetFramework.Entities.Validators
{
    public class vAttachmentDTOValidator  : AbstractValidator<vAttachmentDTO>
    {
        private List<string> _types;
        private List<vAttachmentDTO> m_AttachmentList;

          public vAttachmentDTOValidator(
            List<vAttachmentDTO> attachmentList)
        {
            m_AttachmentList = attachmentList;

          /*  RuleFor(file => file.Subject).NotNull()
                .Must(IsTheAttachmentNameUnique)
                .WithMessage("The attachment name already exists, please enter another");*/
            RuleFor(file => file.FileName).NotNull()
                .Must(IsFileValid)
                .WithMessage("Image must be in .gif,.png,.bmp,.jpg,.jpeg format");
            RuleFor(file => file.FileSize).NotNull()
                .Must(IsFileSizeValid)
                .WithMessage("File size should not exceed 10 KB");
        }

        private bool IsTheAttachmentNameUnique(vAttachmentDTO attachment, string name)
        {
            return !m_AttachmentList.Any(it => !it.AttachmentDetailID.Equals(attachment.AttachmentDetailID) && it.FileName.Equals(name));
        }

        public bool IsFileValid(string filename)
        {
            string types = "gif,png,bmp,jpg,jpeg";
            _types = types.Split(',').ToList();
            var fileExt = System.IO.Path.GetExtension(filename).Substring(1);
            return _types.Contains(fileExt, StringComparer.OrdinalIgnoreCase);
        }
        public bool IsFileSizeValid(int filesize)
        {
            return (filesize < 10240);
        }
    }
}
