﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:01
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VInterfacePanelFieldDetailConverter
    {

        public static VInterfacePanelFieldDetailDTO ToDto(this Bec.TargetFramework.Data.VInterfacePanelFieldDetail source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VInterfacePanelFieldDetailDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VInterfacePanelFieldDetail source, int level)
        {
            if (source == null)
              return null;

            var target = new VInterfacePanelFieldDetailDTO();

            // Properties
            target.InterfacePanelID = source.InterfacePanelID;
            target.Panelname = source.Panelname;
            target.FieldDetailID = source.FieldDetailID;
            target.Fieldname = source.Fieldname;
            target.OverrideValidationMessage = source.OverrideValidationMessage;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VInterfacePanelFieldDetail ToEntity(this VInterfacePanelFieldDetailDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VInterfacePanelFieldDetail();

            // Properties
            target.InterfacePanelID = source.InterfacePanelID;
            target.Panelname = source.Panelname;
            target.FieldDetailID = source.FieldDetailID;
            target.Fieldname = source.Fieldname;
            target.OverrideValidationMessage = source.OverrideValidationMessage;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VInterfacePanelFieldDetailDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VInterfacePanelFieldDetail> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VInterfacePanelFieldDetailDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VInterfacePanelFieldDetail> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VInterfacePanelFieldDetail> ToEntities(this IEnumerable<VInterfacePanelFieldDetailDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VInterfacePanelFieldDetail source, VInterfacePanelFieldDetailDTO target);

        static partial void OnEntityCreating(VInterfacePanelFieldDetailDTO source, Bec.TargetFramework.Data.VInterfacePanelFieldDetail target);

    }

}
