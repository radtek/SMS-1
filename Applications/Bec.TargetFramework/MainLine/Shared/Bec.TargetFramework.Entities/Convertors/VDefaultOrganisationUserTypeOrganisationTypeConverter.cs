﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VDefaultOrganisationUserTypeOrganisationTypeConverter
    {

        public static VDefaultOrganisationUserTypeOrganisationTypeDTO ToDto(this Bec.TargetFramework.Data.VDefaultOrganisationUserTypeOrganisationType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VDefaultOrganisationUserTypeOrganisationTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VDefaultOrganisationUserTypeOrganisationType source, int level)
        {
            if (source == null)
              return null;

            var target = new VDefaultOrganisationUserTypeOrganisationTypeDTO();

            // Properties
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.DefaultOrganisationName = source.DefaultOrganisationName;
            target.UserTypeID = source.UserTypeID;
            target.UserTypeName = source.UserTypeName;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationTypeName = source.OrganisationTypeName;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VDefaultOrganisationUserTypeOrganisationType ToEntity(this VDefaultOrganisationUserTypeOrganisationTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VDefaultOrganisationUserTypeOrganisationType();

            // Properties
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.DefaultOrganisationName = source.DefaultOrganisationName;
            target.UserTypeID = source.UserTypeID;
            target.UserTypeName = source.UserTypeName;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationTypeName = source.OrganisationTypeName;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VDefaultOrganisationUserTypeOrganisationTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VDefaultOrganisationUserTypeOrganisationType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VDefaultOrganisationUserTypeOrganisationTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VDefaultOrganisationUserTypeOrganisationType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VDefaultOrganisationUserTypeOrganisationType> ToEntities(this IEnumerable<VDefaultOrganisationUserTypeOrganisationTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VDefaultOrganisationUserTypeOrganisationType source, VDefaultOrganisationUserTypeOrganisationTypeDTO target);

        static partial void OnEntityCreating(VDefaultOrganisationUserTypeOrganisationTypeDTO source, Bec.TargetFramework.Data.VDefaultOrganisationUserTypeOrganisationType target);

    }

}
