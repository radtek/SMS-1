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

    public static partial class ArtefactSubscriptionTemplateConverter
    {

        public static ArtefactSubscriptionTemplateDTO ToDto(this Bec.TargetFramework.Data.ArtefactSubscriptionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ArtefactSubscriptionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ArtefactSubscriptionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ArtefactSubscriptionTemplateDTO();

            // Properties
            target.ArtefactSubscriptionTemplateID = source.ArtefactSubscriptionTemplateID;
            target.ArtefactTemplateID = source.ArtefactTemplateID;
            target.ArtefactTemplateVersionNumber = source.ArtefactTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PlanSubscriptionTemplateID = source.PlanSubscriptionTemplateID;
            target.PlanSubscriptionTemplateVersionNumber = source.PlanSubscriptionTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.ArtefactTemplate = source.ArtefactTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ArtefactSubscriptionTemplate ToEntity(this ArtefactSubscriptionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ArtefactSubscriptionTemplate();

            // Properties
            target.ArtefactSubscriptionTemplateID = source.ArtefactSubscriptionTemplateID;
            target.ArtefactTemplateID = source.ArtefactTemplateID;
            target.ArtefactTemplateVersionNumber = source.ArtefactTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PlanSubscriptionTemplateID = source.PlanSubscriptionTemplateID;
            target.PlanSubscriptionTemplateVersionNumber = source.PlanSubscriptionTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ArtefactSubscriptionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ArtefactSubscriptionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ArtefactSubscriptionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ArtefactSubscriptionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ArtefactSubscriptionTemplate> ToEntities(this IEnumerable<ArtefactSubscriptionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ArtefactSubscriptionTemplate source, ArtefactSubscriptionTemplateDTO target);

        static partial void OnEntityCreating(ArtefactSubscriptionTemplateDTO source, Bec.TargetFramework.Data.ArtefactSubscriptionTemplate target);

    }

}