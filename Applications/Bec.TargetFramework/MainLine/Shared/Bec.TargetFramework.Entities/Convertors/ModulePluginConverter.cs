﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ModulePluginConverter
    {

        public static ModulePluginDTO ToDto(this Bec.TargetFramework.Data.ModulePlugin source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModulePluginDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModulePlugin source, int level)
        {
            if (source == null)
              return null;

            var target = new ModulePluginDTO();

            // Properties
            target.ModulePluginID = source.ModulePluginID;
            target.ModuleID = source.ModuleID;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.PluginID = source.PluginID;
            target.PluginVersionNumber = source.PluginVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Module = source.Module.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModulePlugin ToEntity(this ModulePluginDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModulePlugin();

            // Properties
            target.ModulePluginID = source.ModulePluginID;
            target.ModuleID = source.ModuleID;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.PluginID = source.PluginID;
            target.PluginVersionNumber = source.PluginVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModulePluginDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModulePlugin> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModulePluginDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModulePlugin> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModulePlugin> ToEntities(this IEnumerable<ModulePluginDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModulePlugin source, ModulePluginDTO target);

        static partial void OnEntityCreating(ModulePluginDTO source, Bec.TargetFramework.Data.ModulePlugin target);

    }

}
