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

    public static partial class VNotificationConstructGroupNotificationConstructConverter
    {

        public static VNotificationConstructGroupNotificationConstructDTO ToDto(this Bec.TargetFramework.Data.VNotificationConstructGroupNotificationConstruct source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VNotificationConstructGroupNotificationConstructDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VNotificationConstructGroupNotificationConstruct source, int level)
        {
            if (source == null)
              return null;

            var target = new VNotificationConstructGroupNotificationConstructDTO();

            // Properties
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.NotificationConstructGroupID = source.NotificationConstructGroupID;
            target.NotificationConstructGroupVersion = source.NotificationConstructGroupVersion;
            target.Name = source.Name;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationType = source.OrganisationType;
            target.UserTypeID = source.UserTypeID;
            target.UserType = source.UserType;
            target.ConditionString = source.ConditionString;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VNotificationConstructGroupNotificationConstruct ToEntity(this VNotificationConstructGroupNotificationConstructDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VNotificationConstructGroupNotificationConstruct();

            // Properties
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.NotificationConstructGroupID = source.NotificationConstructGroupID;
            target.NotificationConstructGroupVersion = source.NotificationConstructGroupVersion;
            target.Name = source.Name;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationType = source.OrganisationType;
            target.UserTypeID = source.UserTypeID;
            target.UserType = source.UserType;
            target.ConditionString = source.ConditionString;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VNotificationConstructGroupNotificationConstructDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VNotificationConstructGroupNotificationConstruct> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VNotificationConstructGroupNotificationConstructDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VNotificationConstructGroupNotificationConstruct> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VNotificationConstructGroupNotificationConstruct> ToEntities(this IEnumerable<VNotificationConstructGroupNotificationConstructDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VNotificationConstructGroupNotificationConstruct source, VNotificationConstructGroupNotificationConstructDTO target);

        static partial void OnEntityCreating(VNotificationConstructGroupNotificationConstructDTO source, Bec.TargetFramework.Data.VNotificationConstructGroupNotificationConstruct target);

    }

}