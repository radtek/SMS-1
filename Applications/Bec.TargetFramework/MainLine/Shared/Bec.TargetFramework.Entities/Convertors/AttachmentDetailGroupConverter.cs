﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class AttachmentDetailGroupConverter
    {

        public static AttachmentDetailGroupDTO ToDto(this Bec.TargetFramework.Data.AttachmentDetailGroup source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static AttachmentDetailGroupDTO ToDtoWithRelated(this Bec.TargetFramework.Data.AttachmentDetailGroup source, int level)
        {
            if (source == null)
              return null;

            var target = new AttachmentDetailGroupDTO();

            // Properties
            target.AttachmentDetailGroupID = source.AttachmentDetailGroupID;
            target.AttachmentDetailID = source.AttachmentDetailID;
            target.OrganisationGroupID = source.OrganisationGroupID;
            target.OrganisationExternalGroupID = source.OrganisationExternalGroupID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.AttachmentDetail = source.AttachmentDetail.ToDtoWithRelated(level - 1);
              target.OrganisationGroup = source.OrganisationGroup.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.AttachmentDetailGroup ToEntity(this AttachmentDetailGroupDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.AttachmentDetailGroup();

            // Properties
            target.AttachmentDetailGroupID = source.AttachmentDetailGroupID;
            target.AttachmentDetailID = source.AttachmentDetailID;
            target.OrganisationGroupID = source.OrganisationGroupID;
            target.OrganisationExternalGroupID = source.OrganisationExternalGroupID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<AttachmentDetailGroupDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.AttachmentDetailGroup> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<AttachmentDetailGroupDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.AttachmentDetailGroup> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.AttachmentDetailGroup> ToEntities(this IEnumerable<AttachmentDetailGroupDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.AttachmentDetailGroup source, AttachmentDetailGroupDTO target);

        static partial void OnEntityCreating(AttachmentDetailGroupDTO source, Bec.TargetFramework.Data.AttachmentDetailGroup target);

    }

}
