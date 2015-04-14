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

    public static partial class VOrganisationConverter
    {

        public static VOrganisationDTO ToDto(this Bec.TargetFramework.Data.VOrganisation source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VOrganisationDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VOrganisation source, int level)
        {
            if (source == null)
              return null;

            var target = new VOrganisationDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.TypeName = source.TypeName;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsBranch = source.IsBranch;
            target.IsHeadOffice = source.IsHeadOffice;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VOrganisation ToEntity(this VOrganisationDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VOrganisation();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.TypeName = source.TypeName;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsBranch = source.IsBranch;
            target.IsHeadOffice = source.IsHeadOffice;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VOrganisationDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VOrganisation> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VOrganisationDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VOrganisation> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VOrganisation> ToEntities(this IEnumerable<VOrganisationDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VOrganisation source, VOrganisationDTO target);

        static partial void OnEntityCreating(VOrganisationDTO source, Bec.TargetFramework.Data.VOrganisation target);

    }

}
