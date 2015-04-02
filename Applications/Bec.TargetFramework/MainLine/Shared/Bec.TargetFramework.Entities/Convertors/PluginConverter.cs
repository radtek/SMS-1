﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class PluginConverter
    {

        public static PluginDTO ToDto(this Bec.TargetFramework.Data.Plugin source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PluginDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Plugin source, int level)
        {
            if (source == null)
              return null;

            var target = new PluginDTO();

            // Properties
            target.PluginID = source.PluginID;
            target.PluginVersionNumber = source.PluginVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Version = source.Version;
            target.VersionNumber = source.VersionNumber;
            target.Author = source.Author;
            target.SystemName = source.SystemName;
            target.DisplayOrder = source.DisplayOrder;
            target.PluginFileName = source.PluginFileName;
            target.PluginTemplateID = source.PluginTemplateID;
            target.PluginTemplateVersionNumber = source.PluginTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.PluginTemplate = source.PluginTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Plugin ToEntity(this PluginDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Plugin();

            // Properties
            target.PluginID = source.PluginID;
            target.PluginVersionNumber = source.PluginVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Version = source.Version;
            target.VersionNumber = source.VersionNumber;
            target.Author = source.Author;
            target.SystemName = source.SystemName;
            target.DisplayOrder = source.DisplayOrder;
            target.PluginFileName = source.PluginFileName;
            target.PluginTemplateID = source.PluginTemplateID;
            target.PluginTemplateVersionNumber = source.PluginTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PluginDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Plugin> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PluginDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Plugin> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Plugin> ToEntities(this IEnumerable<PluginDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Plugin source, PluginDTO target);

        static partial void OnEntityCreating(PluginDTO source, Bec.TargetFramework.Data.Plugin target);

    }

}
