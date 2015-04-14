﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class InterfacePanelSettingTemplateConverter
    {

        public static InterfacePanelSettingTemplateDTO ToDto(this Bec.TargetFramework.Data.InterfacePanelSettingTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static InterfacePanelSettingTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.InterfacePanelSettingTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new InterfacePanelSettingTemplateDTO();

            // Properties
            target.InterfacePanelSettingTemplateID = source.InterfacePanelSettingTemplateID;
            target.InterfacePanelTemplateID = source.InterfacePanelTemplateID;
            target.InterfacePanelTemplateVersionNumber = source.InterfacePanelTemplateVersionNumber;
            target.IsVisible = source.IsVisible;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.InterfacePanelTemplate = source.InterfacePanelTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.InterfacePanelSettingTemplate ToEntity(this InterfacePanelSettingTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.InterfacePanelSettingTemplate();

            // Properties
            target.InterfacePanelSettingTemplateID = source.InterfacePanelSettingTemplateID;
            target.InterfacePanelTemplateID = source.InterfacePanelTemplateID;
            target.InterfacePanelTemplateVersionNumber = source.InterfacePanelTemplateVersionNumber;
            target.IsVisible = source.IsVisible;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<InterfacePanelSettingTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelSettingTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<InterfacePanelSettingTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelSettingTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.InterfacePanelSettingTemplate> ToEntities(this IEnumerable<InterfacePanelSettingTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.InterfacePanelSettingTemplate source, InterfacePanelSettingTemplateDTO target);

        static partial void OnEntityCreating(InterfacePanelSettingTemplateDTO source, Bec.TargetFramework.Data.InterfacePanelSettingTemplate target);

    }

}
