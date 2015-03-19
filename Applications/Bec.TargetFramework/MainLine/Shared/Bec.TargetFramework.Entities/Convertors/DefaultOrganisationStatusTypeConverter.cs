﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationStatusTypeConverter
    {

        public static DefaultOrganisationStatusTypeDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationStatusType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationStatusTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationStatusType source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationStatusTypeDTO();

            // Properties
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.DefaultStatusTypeValueID = source.DefaultStatusTypeValueID;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisation = source.DefaultOrganisation.ToDtoWithRelated(level - 1);
              target.StatusTypeValue = source.StatusTypeValue.ToDtoWithRelated(level - 1);
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.DefaultOrganisationTargets = source.DefaultOrganisationTargets.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationUserTargets = source.DefaultOrganisationUserTargets.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationStatusType ToEntity(this DefaultOrganisationStatusTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationStatusType();

            // Properties
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.DefaultStatusTypeValueID = source.DefaultStatusTypeValueID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationStatusTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationStatusType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationStatusTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationStatusType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationStatusType> ToEntities(this IEnumerable<DefaultOrganisationStatusTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationStatusType source, DefaultOrganisationStatusTypeDTO target);

        static partial void OnEntityCreating(DefaultOrganisationStatusTypeDTO source, Bec.TargetFramework.Data.DefaultOrganisationStatusType target);

    }

}
