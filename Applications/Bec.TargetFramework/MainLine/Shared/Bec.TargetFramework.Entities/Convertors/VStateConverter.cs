﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VStateConverter
    {

        public static VStateDTO ToDto(this Bec.TargetFramework.Data.VState source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VStateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VState source, int level)
        {
            if (source == null)
              return null;

            var target = new VStateDTO();

            // Properties
            target.StateID = source.StateID;
            target.ParentStateID = source.ParentStateID;
            target.StateItemID = source.StateItemID;
            target.ParentStateItemID = source.ParentStateItemID;
            target.StateName = source.StateName;
            target.StateItemName = source.StateItemName;
            target.StateItemOrder = source.StateItemOrder;
            target.Parentstateitemname = source.Parentstateitemname;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VState ToEntity(this VStateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VState();

            // Properties
            target.StateID = source.StateID;
            target.ParentStateID = source.ParentStateID;
            target.StateItemID = source.StateItemID;
            target.ParentStateItemID = source.ParentStateItemID;
            target.StateName = source.StateName;
            target.StateItemName = source.StateItemName;
            target.StateItemOrder = source.StateItemOrder;
            target.Parentstateitemname = source.Parentstateitemname;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VStateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VState> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VStateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VState> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VState> ToEntities(this IEnumerable<VStateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VState source, VStateDTO target);

        static partial void OnEntityCreating(VStateDTO source, Bec.TargetFramework.Data.VState target);

    }

}
