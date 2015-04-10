﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class StatusTypeStructureTransitionTemplateConverter
    {

        public static StatusTypeStructureTransitionTemplateDTO ToDto(this Bec.TargetFramework.Data.StatusTypeStructureTransitionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StatusTypeStructureTransitionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.StatusTypeStructureTransitionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new StatusTypeStructureTransitionTemplateDTO();

            // Properties
            target.StatusTypeStructureTransitionTemplateID = source.StatusTypeStructureTransitionTemplateID;
            target.CurrentStatusTypeStructureTemplateID = source.CurrentStatusTypeStructureTemplateID;
            target.NextStatusTypeStructureTemplateID = source.NextStatusTypeStructureTemplateID;

            // Navigation Properties
            if (level > 0) {
              target.StatusTypeStructureTemplate_NextStatusTypeStructureTemplateID = source.StatusTypeStructureTemplate_NextStatusTypeStructureTemplateID.ToDtoWithRelated(level - 1);
              target.StatusTypeStructureTemplate_CurrentStatusTypeStructureTemplateID = source.StatusTypeStructureTemplate_CurrentStatusTypeStructureTemplateID.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.StatusTypeStructureTransitionTemplate ToEntity(this StatusTypeStructureTransitionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.StatusTypeStructureTransitionTemplate();

            // Properties
            target.StatusTypeStructureTransitionTemplateID = source.StatusTypeStructureTransitionTemplateID;
            target.CurrentStatusTypeStructureTemplateID = source.CurrentStatusTypeStructureTemplateID;
            target.NextStatusTypeStructureTemplateID = source.NextStatusTypeStructureTemplateID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StatusTypeStructureTransitionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.StatusTypeStructureTransitionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StatusTypeStructureTransitionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.StatusTypeStructureTransitionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.StatusTypeStructureTransitionTemplate> ToEntities(this IEnumerable<StatusTypeStructureTransitionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.StatusTypeStructureTransitionTemplate source, StatusTypeStructureTransitionTemplateDTO target);

        static partial void OnEntityCreating(StatusTypeStructureTransitionTemplateDTO source, Bec.TargetFramework.Data.StatusTypeStructureTransitionTemplate target);

    }

}
