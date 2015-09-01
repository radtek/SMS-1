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

    public static partial class OrganisationStatusConverter
    {

        public static OrganisationStatusDTO ToDto(this Bec.TargetFramework.Data.OrganisationStatus source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationStatusDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationStatus source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationStatusDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusChangedOn = source.StatusChangedOn;
            target.StatusChangedBy = source.StatusChangedBy;
            target.ParentID = source.ParentID;
            target.ReasonID = source.ReasonID;
            target.Notes = source.Notes;

            // Navigation Properties
            if (level > 0) {
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.StatusTypeValue = source.StatusTypeValue.ToDtoWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationStatus ToEntity(this OrganisationStatusDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationStatus();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusChangedOn = source.StatusChangedOn;
            target.StatusChangedBy = source.StatusChangedBy;
            target.ParentID = source.ParentID;
            target.ReasonID = source.ReasonID;
            target.Notes = source.Notes;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationStatusDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationStatus> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationStatusDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationStatus> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationStatus> ToEntities(this IEnumerable<OrganisationStatusDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationStatus source, OrganisationStatusDTO target);

        static partial void OnEntityCreating(OrganisationStatusDTO source, Bec.TargetFramework.Data.OrganisationStatus target);

    }

}