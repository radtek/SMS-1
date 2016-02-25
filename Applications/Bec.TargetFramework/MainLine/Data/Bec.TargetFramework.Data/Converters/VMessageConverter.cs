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

    public static partial class VMessageConverter
    {

        public static VMessageDTO ToDto(this Bec.TargetFramework.Data.VMessage source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VMessageDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VMessage source, int level)
        {
            if (source == null)
              return null;

            var target = new VMessageDTO();

            // Properties
            target.ConversationID = source.ConversationID;
            target.NotificationID = source.NotificationID;
            target.CreatedByUserAccountOrganisationID = source.CreatedByUserAccountOrganisationID;
            target.DateSent = source.DateSent;
            target.NotificationData = source.NotificationData;
            target.Email = source.Email;
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.OrganisationName = source.OrganisationName;
            target.UserType = source.UserType;
            target.OrganisationType = source.OrganisationType;
            target.NotificationConstructName = source.NotificationConstructName;
            target.SafeSendGroupName = source.SafeSendGroupName;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VMessage ToEntity(this VMessageDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VMessage();

            // Properties
            target.ConversationID = source.ConversationID;
            target.NotificationID = source.NotificationID;
            target.CreatedByUserAccountOrganisationID = source.CreatedByUserAccountOrganisationID;
            target.DateSent = source.DateSent;
            target.NotificationData = source.NotificationData;
            target.Email = source.Email;
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.OrganisationName = source.OrganisationName;
            target.UserType = source.UserType;
            target.OrganisationType = source.OrganisationType;
            target.NotificationConstructName = source.NotificationConstructName;
            target.SafeSendGroupName = source.SafeSendGroupName;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VMessageDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VMessage> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VMessageDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VMessage> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VMessage> ToEntities(this IEnumerable<VMessageDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VMessage source, VMessageDTO target);

        static partial void OnEntityCreating(VMessageDTO source, Bec.TargetFramework.Data.VMessage target);

    }

}
