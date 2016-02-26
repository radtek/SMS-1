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

    public static partial class RequestSupportConverter
    {

        public static RequestSupportDTO ToDto(this Bec.TargetFramework.Data.RequestSupport source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static RequestSupportDTO ToDtoWithRelated(this Bec.TargetFramework.Data.RequestSupport source, int level)
        {
            if (source == null)
              return null;

            var target = new RequestSupportDTO();

            // Properties
            target.RequestSupportID = source.RequestSupportID;
            target.TicketNumber = source.TicketNumber;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.Telephone = source.Telephone;
            target.RequestType = source.RequestType;
            target.Title = source.Title;
            target.Description = source.Description;
            target.IsClosed = source.IsClosed;
            target.Reason = source.Reason;
            target.CreatedOn = source.CreatedOn;
            target.ClosedOn = source.ClosedOn;
            target.CreatedBy = source.CreatedBy;
            target.ClosedBy = source.ClosedBy;
            target.IsDeleted = source.IsDeleted;
            target.IsActive = source.IsActive;

            // Navigation Properties
            if (level > 0) {
              target.UserAccountOrganisation = source.UserAccountOrganisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.RequestSupport ToEntity(this RequestSupportDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.RequestSupport();

            // Properties
            target.RequestSupportID = source.RequestSupportID;
            target.TicketNumber = source.TicketNumber;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.Telephone = source.Telephone;
            target.RequestType = source.RequestType;
            target.Title = source.Title;
            target.Description = source.Description;
            target.IsClosed = source.IsClosed;
            target.Reason = source.Reason;
            target.CreatedOn = source.CreatedOn;
            target.ClosedOn = source.ClosedOn;
            target.CreatedBy = source.CreatedBy;
            target.ClosedBy = source.ClosedBy;
            target.IsDeleted = source.IsDeleted;
            target.IsActive = source.IsActive;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<RequestSupportDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.RequestSupport> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<RequestSupportDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.RequestSupport> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.RequestSupport> ToEntities(this IEnumerable<RequestSupportDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.RequestSupport source, RequestSupportDTO target);

        static partial void OnEntityCreating(RequestSupportDTO source, Bec.TargetFramework.Data.RequestSupport target);

    }

}
