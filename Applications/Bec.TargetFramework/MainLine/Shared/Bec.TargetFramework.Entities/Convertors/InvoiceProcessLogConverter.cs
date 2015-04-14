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

    public static partial class InvoiceProcessLogConverter
    {

        public static InvoiceProcessLogDTO ToDto(this Bec.TargetFramework.Data.InvoiceProcessLog source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static InvoiceProcessLogDTO ToDtoWithRelated(this Bec.TargetFramework.Data.InvoiceProcessLog source, int level)
        {
            if (source == null)
              return null;

            var target = new InvoiceProcessLogDTO();

            // Properties
            target.InvoiceID = source.InvoiceID;
            target.CreatedOn = source.CreatedOn;
            target.NotificationID = source.NotificationID;
            target.InvoiceStatusDetail = source.InvoiceStatusDetail;
            target.PaidOn = source.PaidOn;
            target.IsInvoiceProcessed = source.IsInvoiceProcessed;
            target.IsPaid = source.IsPaid;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.IsClosed = source.IsClosed;
            target.ClosedOn = source.ClosedOn;
            target.InvoiceAccountingStatusID = source.InvoiceAccountingStatusID;

            // Navigation Properties
            if (level > 0) {
              target.Invoice = source.Invoice.ToDtoWithRelated(level - 1);
              target.Notification = source.Notification.ToDtoWithRelated(level - 1);
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.StatusTypeValue = source.StatusTypeValue.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.InvoiceProcessLog ToEntity(this InvoiceProcessLogDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.InvoiceProcessLog();

            // Properties
            target.InvoiceID = source.InvoiceID;
            target.CreatedOn = source.CreatedOn;
            target.NotificationID = source.NotificationID;
            target.InvoiceStatusDetail = source.InvoiceStatusDetail;
            target.PaidOn = source.PaidOn;
            target.IsInvoiceProcessed = source.IsInvoiceProcessed;
            target.IsPaid = source.IsPaid;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.IsClosed = source.IsClosed;
            target.ClosedOn = source.ClosedOn;
            target.InvoiceAccountingStatusID = source.InvoiceAccountingStatusID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<InvoiceProcessLogDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.InvoiceProcessLog> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<InvoiceProcessLogDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.InvoiceProcessLog> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.InvoiceProcessLog> ToEntities(this IEnumerable<InvoiceProcessLogDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.InvoiceProcessLog source, InvoiceProcessLogDTO target);

        static partial void OnEntityCreating(InvoiceProcessLogDTO source, Bec.TargetFramework.Data.InvoiceProcessLog target);

    }

}
