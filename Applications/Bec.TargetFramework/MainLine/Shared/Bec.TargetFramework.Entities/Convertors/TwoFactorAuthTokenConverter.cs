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

    public static partial class TwoFactorAuthTokenConverter
    {

        public static TwoFactorAuthTokenDTO ToDto(this Bec.TargetFramework.Data.TwoFactorAuthToken source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static TwoFactorAuthTokenDTO ToDtoWithRelated(this Bec.TargetFramework.Data.TwoFactorAuthToken source, int level)
        {
            if (source == null)
              return null;

            var target = new TwoFactorAuthTokenDTO();

            // Properties
            target.Token = source.Token;
            target.Issued = source.Issued;
            target.UserAccountID = source.UserAccountID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.UserAccount = source.UserAccount.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.TwoFactorAuthToken ToEntity(this TwoFactorAuthTokenDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.TwoFactorAuthToken();

            // Properties
            target.Token = source.Token;
            target.Issued = source.Issued;
            target.UserAccountID = source.UserAccountID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<TwoFactorAuthTokenDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.TwoFactorAuthToken> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<TwoFactorAuthTokenDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.TwoFactorAuthToken> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.TwoFactorAuthToken> ToEntities(this IEnumerable<TwoFactorAuthTokenDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.TwoFactorAuthToken source, TwoFactorAuthTokenDTO target);

        static partial void OnEntityCreating(TwoFactorAuthTokenDTO source, Bec.TargetFramework.Data.TwoFactorAuthToken target);

    }

}
