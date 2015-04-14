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

    public static partial class VUserRoleRegulatorDetailConverter
    {

        public static VUserRoleRegulatorDetailDTO ToDto(this Bec.TargetFramework.Data.VUserRoleRegulatorDetail source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VUserRoleRegulatorDetailDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VUserRoleRegulatorDetail source, int level)
        {
            if (source == null)
              return null;

            var target = new VUserRoleRegulatorDetailDTO();

            // Properties
            target.ID = source.ID;
            target.Email = source.Email;
            target.LastName = source.LastName;
            target.FirstName = source.FirstName;
            target.RegulatorID = source.RegulatorID;
            target.Regulator = source.Regulator;
            target.RegulatorNumber = source.RegulatorNumber;
            target.UserRole = source.UserRole;
            target.TradingName = source.TradingName;
            target.CompanyName = source.CompanyName;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VUserRoleRegulatorDetail ToEntity(this VUserRoleRegulatorDetailDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VUserRoleRegulatorDetail();

            // Properties
            target.ID = source.ID;
            target.Email = source.Email;
            target.LastName = source.LastName;
            target.FirstName = source.FirstName;
            target.RegulatorID = source.RegulatorID;
            target.Regulator = source.Regulator;
            target.RegulatorNumber = source.RegulatorNumber;
            target.UserRole = source.UserRole;
            target.TradingName = source.TradingName;
            target.CompanyName = source.CompanyName;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VUserRoleRegulatorDetailDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VUserRoleRegulatorDetail> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VUserRoleRegulatorDetailDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VUserRoleRegulatorDetail> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VUserRoleRegulatorDetail> ToEntities(this IEnumerable<VUserRoleRegulatorDetailDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VUserRoleRegulatorDetail source, VUserRoleRegulatorDetailDTO target);

        static partial void OnEntityCreating(VUserRoleRegulatorDetailDTO source, Bec.TargetFramework.Data.VUserRoleRegulatorDetail target);

    }

}
