﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationTargetConverter
    {

        public static DefaultOrganisationTargetDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationTarget source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationTargetDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationTarget source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationTargetDTO();

            // Properties
            target.DefaultOrganisationTargetID = source.DefaultOrganisationTargetID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationSubTypeID = source.OrganisationSubTypeID;
            target.OrganisationCategoryID = source.OrganisationCategoryID;
            target.OrganisationSubCategoryID = source.OrganisationSubCategoryID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisation = source.DefaultOrganisation.ToDtoWithRelated(level - 1);
              target.DefaultOrganisationStatusType = source.DefaultOrganisationStatusType.ToDtoWithRelated(level - 1);
              target.OrganisationType = source.OrganisationType.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationTarget ToEntity(this DefaultOrganisationTargetDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationTarget();

            // Properties
            target.DefaultOrganisationTargetID = source.DefaultOrganisationTargetID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationSubTypeID = source.OrganisationSubTypeID;
            target.OrganisationCategoryID = source.OrganisationCategoryID;
            target.OrganisationSubCategoryID = source.OrganisationSubCategoryID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationTargetDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationTarget> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationTargetDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationTarget> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationTarget> ToEntities(this IEnumerable<DefaultOrganisationTargetDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationTarget source, DefaultOrganisationTargetDTO target);

        static partial void OnEntityCreating(DefaultOrganisationTargetDTO source, Bec.TargetFramework.Data.DefaultOrganisationTarget target);

    }

}
