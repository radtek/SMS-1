﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/06/2015 16:32:47
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.SB.Entities
{

    public static partial class SettingConverter
    {

        public static SettingDTO ToDto(this Bec.TargetFramework.SB.Data.Setting source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static SettingDTO ToDtoWithRelated(this Bec.TargetFramework.SB.Data.Setting source, int level)
        {
            if (source == null)
              return null;

            var target = new SettingDTO();

            // Properties
            target.Id = source.Id;
            target.Name = source.Name;
            target.Value = source.Value;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.SB.Data.Setting ToEntity(this SettingDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.SB.Data.Setting();

            // Properties
            target.Id = source.Id;
            target.Name = source.Name;
            target.Value = source.Value;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<SettingDTO> ToDtos(this IEnumerable<Bec.TargetFramework.SB.Data.Setting> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<SettingDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.SB.Data.Setting> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.SB.Data.Setting> ToEntities(this IEnumerable<SettingDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.SB.Data.Setting source, SettingDTO target);

        static partial void OnEntityCreating(SettingDTO source, Bec.TargetFramework.SB.Data.Setting target);

    }

}
