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

    public static partial class VConversationUnreadConverter
    {

        public static VConversationUnreadDTO ToDto(this Bec.TargetFramework.Data.VConversationUnread source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VConversationUnreadDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VConversationUnread source, int level)
        {
            if (source == null)
              return null;

            var target = new VConversationUnreadDTO();

            // Properties
            target.ConversationID = source.ConversationID;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.UnreadCount = source.UnreadCount;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VConversationUnread ToEntity(this VConversationUnreadDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VConversationUnread();

            // Properties
            target.ConversationID = source.ConversationID;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.UnreadCount = source.UnreadCount;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VConversationUnreadDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VConversationUnread> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VConversationUnreadDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VConversationUnread> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VConversationUnread> ToEntities(this IEnumerable<VConversationUnreadDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VConversationUnread source, VConversationUnreadDTO target);

        static partial void OnEntityCreating(VConversationUnreadDTO source, Bec.TargetFramework.Data.VConversationUnread target);

    }

}