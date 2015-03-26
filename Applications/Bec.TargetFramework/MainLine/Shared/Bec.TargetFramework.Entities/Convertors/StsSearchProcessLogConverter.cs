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

    public static partial class StsSearchProcessLogConverter
    {

        public static StsSearchProcessLogDTO ToDto(this Bec.TargetFramework.Data.StsSearchProcessLog source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StsSearchProcessLogDTO ToDtoWithRelated(this Bec.TargetFramework.Data.StsSearchProcessLog source, int level)
        {
            if (source == null)
              return null;

            var target = new StsSearchProcessLogDTO();

            // Properties
            target.StsSearchID = source.StsSearchID;
            target.CreatedOn = source.CreatedOn;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.IsCancelled = source.IsCancelled;
            target.IsClosed = source.IsClosed;

            // Navigation Properties
            if (level > 0) {
              target.StsSearch = source.StsSearch.ToDtoWithRelated(level - 1);
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.StatusTypeValue = source.StatusTypeValue.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.StsSearchProcessLog ToEntity(this StsSearchProcessLogDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.StsSearchProcessLog();

            // Properties
            target.StsSearchID = source.StsSearchID;
            target.CreatedOn = source.CreatedOn;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.IsCancelled = source.IsCancelled;
            target.IsClosed = source.IsClosed;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StsSearchProcessLogDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.StsSearchProcessLog> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StsSearchProcessLogDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.StsSearchProcessLog> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.StsSearchProcessLog> ToEntities(this IEnumerable<StsSearchProcessLogDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.StsSearchProcessLog source, StsSearchProcessLogDTO target);

        static partial void OnEntityCreating(StsSearchProcessLogDTO source, Bec.TargetFramework.Data.StsSearchProcessLog target);

    }

}
