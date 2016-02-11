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

    public static partial class ConversationConverter
    {

        public static ConversationDTO ToDto(this Bec.TargetFramework.Data.Conversation source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ConversationDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Conversation source, int level)
        {
            if (source == null)
              return null;

            var target = new ConversationDTO();

            // Properties
            target.ConversationID = source.ConversationID;
            target.Subject = source.Subject;
            target.ActivityType = source.ActivityType;
            target.ActivityID = source.ActivityID;
            target.IsSystemMessage = source.IsSystemMessage;
            target.Latest = source.Latest;

            // Navigation Properties
            if (level > 0) {
              target.ConversationParticipants = source.ConversationParticipants.ToDtosWithRelated(level - 1);
              target.Notifications = source.Notifications.ToDtosWithRelated(level - 1);
              target.ConversationFunctionParticipants = source.ConversationFunctionParticipants.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Conversation ToEntity(this ConversationDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Conversation();

            // Properties
            target.ConversationID = source.ConversationID;
            target.Subject = source.Subject;
            target.ActivityType = source.ActivityType;
            target.ActivityID = source.ActivityID;
            target.IsSystemMessage = source.IsSystemMessage;
            target.Latest = source.Latest;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ConversationDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Conversation> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ConversationDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Conversation> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Conversation> ToEntities(this IEnumerable<ConversationDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Conversation source, ConversationDTO target);

        static partial void OnEntityCreating(ConversationDTO source, Bec.TargetFramework.Data.Conversation target);

    }

}
