﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:01
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class UserAccountLoginSessionDatumConverter
    {

        public static UserAccountLoginSessionDatumDTO ToDto(this Bec.TargetFramework.Data.UserAccountLoginSessionDatum source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static UserAccountLoginSessionDatumDTO ToDtoWithRelated(this Bec.TargetFramework.Data.UserAccountLoginSessionDatum source, int level)
        {
            if (source == null)
              return null;

            var target = new UserAccountLoginSessionDatumDTO();

            // Properties
            target.UserAccountLoginSessionDataID = source.UserAccountLoginSessionDataID;
            target.UserAccountID = source.UserAccountID;
            target.UserSessionID = source.UserSessionID;
            target.RequestData = source.RequestData;

            // Navigation Properties
            if (level > 0) {
              target.UserAccountLoginSession = source.UserAccountLoginSession.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.UserAccountLoginSessionDatum ToEntity(this UserAccountLoginSessionDatumDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.UserAccountLoginSessionDatum();

            // Properties
            target.UserAccountLoginSessionDataID = source.UserAccountLoginSessionDataID;
            target.UserAccountID = source.UserAccountID;
            target.UserSessionID = source.UserSessionID;
            target.RequestData = source.RequestData;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<UserAccountLoginSessionDatumDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.UserAccountLoginSessionDatum> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<UserAccountLoginSessionDatumDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.UserAccountLoginSessionDatum> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.UserAccountLoginSessionDatum> ToEntities(this IEnumerable<UserAccountLoginSessionDatumDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.UserAccountLoginSessionDatum source, UserAccountLoginSessionDatumDTO target);

        static partial void OnEntityCreating(UserAccountLoginSessionDatumDTO source, Bec.TargetFramework.Data.UserAccountLoginSessionDatum target);

    }

}
