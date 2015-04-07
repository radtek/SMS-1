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

    public static partial class VOrganisationUserTypeConverter
    {

        public static VOrganisationUserTypeDTO ToDto(this Bec.TargetFramework.Data.VOrganisationUserType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VOrganisationUserTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VOrganisationUserType source, int level)
        {
            if (source == null)
              return null;

            var target = new VOrganisationUserTypeDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.Organisationbranchid = source.Organisationbranchid;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.Name = source.Name;
            target.UserTypeID = source.UserTypeID;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VOrganisationUserType ToEntity(this VOrganisationUserTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VOrganisationUserType();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.Organisationbranchid = source.Organisationbranchid;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.Name = source.Name;
            target.UserTypeID = source.UserTypeID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VOrganisationUserTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VOrganisationUserType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VOrganisationUserTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VOrganisationUserType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VOrganisationUserType> ToEntities(this IEnumerable<VOrganisationUserTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VOrganisationUserType source, VOrganisationUserTypeDTO target);

        static partial void OnEntityCreating(VOrganisationUserTypeDTO source, Bec.TargetFramework.Data.VOrganisationUserType target);

    }

}
