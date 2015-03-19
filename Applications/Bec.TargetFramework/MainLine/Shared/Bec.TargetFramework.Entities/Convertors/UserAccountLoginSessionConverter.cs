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

    public static partial class UserAccountLoginSessionConverter
    {

        public static UserAccountLoginSessionDTO ToDto(this Bec.TargetFramework.Data.UserAccountLoginSession source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static UserAccountLoginSessionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.UserAccountLoginSession source, int level)
        {
            if (source == null)
              return null;

            var target = new UserAccountLoginSessionDTO();

            // Properties
            target.UserAccountID = source.UserAccountID;
            target.UserSessionID = source.UserSessionID;
            target.UserIPAddress = source.UserIPAddress;
            target.UserHostAddress = source.UserHostAddress;
            target.UserLocation = source.UserLocation;
            target.UserLoginDate = source.UserLoginDate;
            target.UserLogoutDate = source.UserLogoutDate;
            target.UserHasLoggedOut = source.UserHasLoggedOut;

            // Navigation Properties
            if (level > 0) {
              target.UserAccountLoginSessionData = source.UserAccountLoginSessionData.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.UserAccountLoginSession ToEntity(this UserAccountLoginSessionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.UserAccountLoginSession();

            // Properties
            target.UserAccountID = source.UserAccountID;
            target.UserSessionID = source.UserSessionID;
            target.UserIPAddress = source.UserIPAddress;
            target.UserHostAddress = source.UserHostAddress;
            target.UserLocation = source.UserLocation;
            target.UserLoginDate = source.UserLoginDate;
            target.UserLogoutDate = source.UserLogoutDate;
            target.UserHasLoggedOut = source.UserHasLoggedOut;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<UserAccountLoginSessionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.UserAccountLoginSession> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<UserAccountLoginSessionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.UserAccountLoginSession> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.UserAccountLoginSession> ToEntities(this IEnumerable<UserAccountLoginSessionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.UserAccountLoginSession source, UserAccountLoginSessionDTO target);

        static partial void OnEntityCreating(UserAccountLoginSessionDTO source, Bec.TargetFramework.Data.UserAccountLoginSession target);

    }

}
