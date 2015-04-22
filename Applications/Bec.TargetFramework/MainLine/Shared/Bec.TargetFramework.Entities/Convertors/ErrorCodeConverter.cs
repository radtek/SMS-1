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

    public static partial class ErrorCodeConverter
    {

        public static ErrorCodeDTO ToDto(this Bec.TargetFramework.Data.ErrorCode source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ErrorCodeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ErrorCode source, int level)
        {
            if (source == null)
              return null;

            var target = new ErrorCodeDTO();

            // Properties
            target.ErrorCodeID = source.ErrorCodeID;
            target.ErrorCode1 = source.ErrorCode1;
            target.Explanation = source.Explanation;
            target.ErrorMessage = source.ErrorMessage;
            target.ErrorMapping = source.ErrorMapping;
            target.Notes = source.Notes;
            target.ErrorCodeTypeID = source.ErrorCodeTypeID;
            target.ErrorCodeCategoryID = source.ErrorCodeCategoryID;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ErrorCode ToEntity(this ErrorCodeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ErrorCode();

            // Properties
            target.ErrorCodeID = source.ErrorCodeID;
            target.ErrorCode1 = source.ErrorCode1;
            target.Explanation = source.Explanation;
            target.ErrorMessage = source.ErrorMessage;
            target.ErrorMapping = source.ErrorMapping;
            target.Notes = source.Notes;
            target.ErrorCodeTypeID = source.ErrorCodeTypeID;
            target.ErrorCodeCategoryID = source.ErrorCodeCategoryID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ErrorCodeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ErrorCode> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ErrorCodeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ErrorCode> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ErrorCode> ToEntities(this IEnumerable<ErrorCodeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ErrorCode source, ErrorCodeDTO target);

        static partial void OnEntityCreating(ErrorCodeDTO source, Bec.TargetFramework.Data.ErrorCode target);

    }

}
