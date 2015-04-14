﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VAttachmentConverter
    {

        public static VAttachmentDTO ToDto(this Bec.TargetFramework.Data.VAttachment source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VAttachmentDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VAttachment source, int level)
        {
            if (source == null)
              return null;

            var target = new VAttachmentDTO();

            // Properties
            target.AttachmentDetailID = source.AttachmentDetailID;
            target.OrganisationID = source.OrganisationID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.FileName = source.FileName;
            target.RepositoryStructureID = source.RepositoryStructureID;
            target.Subject = source.Subject;
            target.MimeType = source.MimeType;
            target.Body = source.Body;
            target.FileSize = source.FileSize;
            target.RepositoryName = source.RepositoryName;
            target.AttachmentID = source.AttachmentID;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VAttachment ToEntity(this VAttachmentDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VAttachment();

            // Properties
            target.AttachmentDetailID = source.AttachmentDetailID;
            target.OrganisationID = source.OrganisationID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.FileName = source.FileName;
            target.RepositoryStructureID = source.RepositoryStructureID;
            target.Subject = source.Subject;
            target.MimeType = source.MimeType;
            target.Body = source.Body;
            target.FileSize = source.FileSize;
            target.RepositoryName = source.RepositoryName;
            target.AttachmentID = source.AttachmentID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VAttachmentDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VAttachment> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VAttachmentDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VAttachment> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VAttachment> ToEntities(this IEnumerable<VAttachmentDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VAttachment source, VAttachmentDTO target);

        static partial void OnEntityCreating(VAttachmentDTO source, Bec.TargetFramework.Data.VAttachment target);

    }

}
