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
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class OrganisationStatusTypeConverter
    {

        public static OrganisationStatusTypeDTO ToDto(this Bec.TargetFramework.Data.OrganisationStatusType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationStatusTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationStatusType source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationStatusTypeDTO();

            // Properties
            target.OrganisationStatusTypeID = source.OrganisationStatusTypeID;
            target.OrganisationID = source.OrganisationID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationStatusType ToEntity(this OrganisationStatusTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationStatusType();

            // Properties
            target.OrganisationStatusTypeID = source.OrganisationStatusTypeID;
            target.OrganisationID = source.OrganisationID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationStatusTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationStatusType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationStatusTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationStatusType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationStatusType> ToEntities(this IEnumerable<OrganisationStatusTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationStatusType source, OrganisationStatusTypeDTO target);

        static partial void OnEntityCreating(OrganisationStatusTypeDTO source, Bec.TargetFramework.Data.OrganisationStatusType target);

    }

}
