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

    public static partial class UserAccountOrganisationFunctionConverter
    {

        public static UserAccountOrganisationFunctionDTO ToDto(this Bec.TargetFramework.Data.UserAccountOrganisationFunction source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static UserAccountOrganisationFunctionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.UserAccountOrganisationFunction source, int level)
        {
            if (source == null)
              return null;

            var target = new UserAccountOrganisationFunctionDTO();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.FunctionID = source.FunctionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.UserAccountOrganisation = source.UserAccountOrganisation.ToDtoWithRelated(level - 1);
              target.Function = source.Function.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.UserAccountOrganisationFunction ToEntity(this UserAccountOrganisationFunctionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.UserAccountOrganisationFunction();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.FunctionID = source.FunctionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<UserAccountOrganisationFunctionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.UserAccountOrganisationFunction> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<UserAccountOrganisationFunctionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.UserAccountOrganisationFunction> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.UserAccountOrganisationFunction> ToEntities(this IEnumerable<UserAccountOrganisationFunctionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.UserAccountOrganisationFunction source, UserAccountOrganisationFunctionDTO target);

        static partial void OnEntityCreating(UserAccountOrganisationFunctionDTO source, Bec.TargetFramework.Data.UserAccountOrganisationFunction target);

    }

}
