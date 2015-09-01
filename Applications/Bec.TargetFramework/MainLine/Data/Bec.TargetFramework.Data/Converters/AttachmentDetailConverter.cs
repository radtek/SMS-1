﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class AttachmentDetailConverter
    {

        public static AttachmentDetailDTO ToDto(this Bec.TargetFramework.Data.AttachmentDetail source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static AttachmentDetailDTO ToDtoWithRelated(this Bec.TargetFramework.Data.AttachmentDetail source, int level)
        {
            if (source == null)
              return null;

            var target = new AttachmentDetailDTO();

            // Properties
            target.AttachmentDetailID = source.AttachmentDetailID;
            target.OrganisationID = source.OrganisationID;
            target.AttachmentTypeID = source.AttachmentTypeID;
            target.AttachmentSubTypeID = source.AttachmentSubTypeID;
            target.AttachmentCategoryID = source.AttachmentCategoryID;
            target.RepositoryStructureID = source.RepositoryStructureID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;

            // Navigation Properties
            if (level > 0) {
              target.AttachmentDetailRoles = source.AttachmentDetailRoles.ToDtosWithRelated(level - 1);
              target.RepositoryStructure = source.RepositoryStructure.ToDtoWithRelated(level - 1);
              target.OrganisationDetails = source.OrganisationDetails.ToDtosWithRelated(level - 1);
              target.Attachments = source.Attachments.ToDtosWithRelated(level - 1);
              target.AttachmentDetailGroups = source.AttachmentDetailGroups.ToDtosWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.AttachmentDetail ToEntity(this AttachmentDetailDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.AttachmentDetail();

            // Properties
            target.AttachmentDetailID = source.AttachmentDetailID;
            target.OrganisationID = source.OrganisationID;
            target.AttachmentTypeID = source.AttachmentTypeID;
            target.AttachmentSubTypeID = source.AttachmentSubTypeID;
            target.AttachmentCategoryID = source.AttachmentCategoryID;
            target.RepositoryStructureID = source.RepositoryStructureID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<AttachmentDetailDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.AttachmentDetail> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<AttachmentDetailDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.AttachmentDetail> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.AttachmentDetail> ToEntities(this IEnumerable<AttachmentDetailDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.AttachmentDetail source, AttachmentDetailDTO target);

        static partial void OnEntityCreating(AttachmentDetailDTO source, Bec.TargetFramework.Data.AttachmentDetail target);

    }

}