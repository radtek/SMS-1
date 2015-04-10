﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VUserAccountNotLoggedInConverter
    {

        public static VUserAccountNotLoggedInDTO ToDto(this Bec.TargetFramework.Data.VUserAccountNotLoggedIn source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VUserAccountNotLoggedInDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VUserAccountNotLoggedIn source, int level)
        {
            if (source == null)
              return null;

            var target = new VUserAccountNotLoggedInDTO();

            // Properties
            target.ID = source.ID;
            target.Username = source.Username;
            target.Email = source.Email;
            target.IsTemporaryAccount = source.IsTemporaryAccount;
            target.Created = source.Created;
            target.DaysSinceCreation = source.DaysSinceCreation;
            target.HoursSinceCreation = source.HoursSinceCreation;
            target.Between7and14DaysNotLoggedIn = source.Between7and14DaysNotLoggedIn;
            target.Between14and21DaysNotLoggedIn = source.Between14and21DaysNotLoggedIn;
            target.Between0and7DaysNotLoggedIn = source.Between0and7DaysNotLoggedIn;
            target.GreaterThan21DaysNotLoggedIn = source.GreaterThan21DaysNotLoggedIn;
            target.NotLoggedIn = source.NotLoggedIn;
            target.COLPRemindersNotReadEver = source.COLPRemindersNotReadEver;
            target.COLPRegistrationsNotReadEver = source.COLPRegistrationsNotReadEver;
            target.COLPRemindersNotReadBetween7and14Days = source.COLPRemindersNotReadBetween7and14Days;
            target.COLPRemindersNotReadBetween14and21Days = source.COLPRemindersNotReadBetween14and21Days;
            target.COLPRemindersNotReadBetween0and7Days = source.COLPRemindersNotReadBetween0and7Days;
            target.LoginWorkflowDataContent = source.LoginWorkflowDataContent;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VUserAccountNotLoggedIn ToEntity(this VUserAccountNotLoggedInDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VUserAccountNotLoggedIn();

            // Properties
            target.ID = source.ID;
            target.Username = source.Username;
            target.Email = source.Email;
            target.IsTemporaryAccount = source.IsTemporaryAccount;
            target.Created = source.Created;
            target.DaysSinceCreation = source.DaysSinceCreation;
            target.HoursSinceCreation = source.HoursSinceCreation;
            target.Between7and14DaysNotLoggedIn = source.Between7and14DaysNotLoggedIn;
            target.Between14and21DaysNotLoggedIn = source.Between14and21DaysNotLoggedIn;
            target.Between0and7DaysNotLoggedIn = source.Between0and7DaysNotLoggedIn;
            target.GreaterThan21DaysNotLoggedIn = source.GreaterThan21DaysNotLoggedIn;
            target.NotLoggedIn = source.NotLoggedIn;
            target.COLPRemindersNotReadEver = source.COLPRemindersNotReadEver;
            target.COLPRegistrationsNotReadEver = source.COLPRegistrationsNotReadEver;
            target.COLPRemindersNotReadBetween7and14Days = source.COLPRemindersNotReadBetween7and14Days;
            target.COLPRemindersNotReadBetween14and21Days = source.COLPRemindersNotReadBetween14and21Days;
            target.COLPRemindersNotReadBetween0and7Days = source.COLPRemindersNotReadBetween0and7Days;
            target.LoginWorkflowDataContent = source.LoginWorkflowDataContent;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VUserAccountNotLoggedInDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VUserAccountNotLoggedIn> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VUserAccountNotLoggedInDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VUserAccountNotLoggedIn> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VUserAccountNotLoggedIn> ToEntities(this IEnumerable<VUserAccountNotLoggedInDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VUserAccountNotLoggedIn source, VUserAccountNotLoggedInDTO target);

        static partial void OnEntityCreating(VUserAccountNotLoggedInDTO source, Bec.TargetFramework.Data.VUserAccountNotLoggedIn target);

    }

}
