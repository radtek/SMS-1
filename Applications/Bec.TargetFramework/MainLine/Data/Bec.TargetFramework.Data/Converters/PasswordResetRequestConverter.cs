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

    public static partial class PasswordResetRequestConverter
    {

        public static PasswordResetRequestDTO ToDto(this Bec.TargetFramework.Data.PasswordResetRequest source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PasswordResetRequestDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PasswordResetRequest source, int level)
        {
            if (source == null)
              return null;

            var target = new PasswordResetRequestDTO();

            // Properties
            target.RequestID = source.RequestID;
            target.UserID = source.UserID;
            target.CreatedDateTime = source.CreatedDateTime;
            target.Expired = source.Expired;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PasswordResetRequest ToEntity(this PasswordResetRequestDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PasswordResetRequest();

            // Properties
            target.RequestID = source.RequestID;
            target.UserID = source.UserID;
            target.CreatedDateTime = source.CreatedDateTime;
            target.Expired = source.Expired;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PasswordResetRequestDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PasswordResetRequest> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PasswordResetRequestDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PasswordResetRequest> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PasswordResetRequest> ToEntities(this IEnumerable<PasswordResetRequestDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PasswordResetRequest source, PasswordResetRequestDTO target);

        static partial void OnEntityCreating(PasswordResetRequestDTO source, Bec.TargetFramework.Data.PasswordResetRequest target);

    }

}