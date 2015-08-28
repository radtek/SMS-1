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

    public static partial class PasswordResetSecretConverter
    {

        public static PasswordResetSecretDTO ToDto(this Bec.TargetFramework.Data.PasswordResetSecret source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PasswordResetSecretDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PasswordResetSecret source, int level)
        {
            if (source == null)
              return null;

            var target = new PasswordResetSecretDTO();

            // Properties
            target.PasswordResetSecretID = source.PasswordResetSecretID;
            target.QuestionID = source.QuestionID;
            target.Answer = source.Answer;
            target.UserAccountID = source.UserAccountID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.UserAccount = source.UserAccount.ToDtoWithRelated(level - 1);
              target.ClassificationType = source.ClassificationType.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PasswordResetSecret ToEntity(this PasswordResetSecretDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PasswordResetSecret();

            // Properties
            target.PasswordResetSecretID = source.PasswordResetSecretID;
            target.QuestionID = source.QuestionID;
            target.Answer = source.Answer;
            target.UserAccountID = source.UserAccountID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PasswordResetSecretDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PasswordResetSecret> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PasswordResetSecretDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PasswordResetSecret> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PasswordResetSecret> ToEntities(this IEnumerable<PasswordResetSecretDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PasswordResetSecret source, PasswordResetSecretDTO target);

        static partial void OnEntityCreating(PasswordResetSecretDTO source, Bec.TargetFramework.Data.PasswordResetSecret target);

    }

}
