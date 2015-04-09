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

    public static partial class VTemporaryUsersNotLoggedInConverter
    {

        public static VTemporaryUsersNotLoggedInDTO ToDto(this Bec.TargetFramework.Data.VTemporaryUsersNotLoggedIn source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VTemporaryUsersNotLoggedInDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VTemporaryUsersNotLoggedIn source, int level)
        {
            if (source == null)
              return null;

            var target = new VTemporaryUsersNotLoggedInDTO();

            // Properties
            target.Created = source.Created;
            target.AccountClosed = source.AccountClosed;
            target.Email = source.Email;
            target.FailedLoginCount = source.FailedLoginCount;
            target.FailedPasswordResetCount = source.FailedPasswordResetCount;
            target.ID = source.ID;
            target.IsAccountClosed = source.IsAccountClosed;
            target.IsAccountVerified = source.IsAccountVerified;
            target.IsActive = source.IsActive;
            target.LastLogin = source.LastLogin;
            target.LastFailedPasswordReset = source.LastFailedPasswordReset;
            target.LastUpdated = source.LastUpdated;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VTemporaryUsersNotLoggedIn ToEntity(this VTemporaryUsersNotLoggedInDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VTemporaryUsersNotLoggedIn();

            // Properties
            target.Created = source.Created;
            target.AccountClosed = source.AccountClosed;
            target.Email = source.Email;
            target.FailedLoginCount = source.FailedLoginCount;
            target.FailedPasswordResetCount = source.FailedPasswordResetCount;
            target.ID = source.ID;
            target.IsAccountClosed = source.IsAccountClosed;
            target.IsAccountVerified = source.IsAccountVerified;
            target.IsActive = source.IsActive;
            target.LastLogin = source.LastLogin;
            target.LastFailedPasswordReset = source.LastFailedPasswordReset;
            target.LastUpdated = source.LastUpdated;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VTemporaryUsersNotLoggedInDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VTemporaryUsersNotLoggedIn> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VTemporaryUsersNotLoggedInDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VTemporaryUsersNotLoggedIn> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VTemporaryUsersNotLoggedIn> ToEntities(this IEnumerable<VTemporaryUsersNotLoggedInDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VTemporaryUsersNotLoggedIn source, VTemporaryUsersNotLoggedInDTO target);

        static partial void OnEntityCreating(VTemporaryUsersNotLoggedInDTO source, Bec.TargetFramework.Data.VTemporaryUsersNotLoggedIn target);

    }

}
