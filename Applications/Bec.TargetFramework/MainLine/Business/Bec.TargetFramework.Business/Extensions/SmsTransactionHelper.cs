using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using Mehdime.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Extensions
{
    public static class SmsTransactionHelper
    {
        public static void ApplyUpdatesToSmsTransaction(SmsTransaction tx, IEnumerable<FieldUpdate> updates)
        {
            foreach (var update in updates)
            {
                if (update.ActivityID != tx.SmsTransactionID) throw new Exception();
                UpdateSmsTransactionProperty(tx, update);
            }
        }

        public static void UpdateSmsTransactionProperty(SmsTransaction tx, FieldUpdate update)
        {
            SmsUserAccountOrganisationTransaction uaotx;

            switch ((FieldUpdateParentType)update.ParentType)
            {
                case FieldUpdateParentType.SmsTransaction:
                    CommonHelper.SetProperty(tx, update.FieldName, update.Value);
                    break;
                case FieldUpdateParentType.SmsTransactionAddress:
                    if (tx.Address == null)
                    {
                        tx.Address = new Address();
                    }
                    CommonHelper.SetProperty(tx.Address, update.FieldName, update.Value);
                    break;
                case FieldUpdateParentType.RegisteredHomeAddress:
                    uaotx = tx.SmsUserAccountOrganisationTransactions.Single(x => x.SmsUserAccountOrganisationTransactionID == update.ParentID);
                    if (uaotx.Address == null)
                    {
                        uaotx.Address = new Address();
                    }
                    CommonHelper.SetProperty(uaotx.Address, update.FieldName, update.Value);
                    break;
                case FieldUpdateParentType.Contact:
                    uaotx = tx.SmsUserAccountOrganisationTransactions.Single(x => x.SmsUserAccountOrganisationTransactionID == update.ParentID);
                    CommonHelper.SetProperty(uaotx.Contact, update.FieldName, update.Value);
                    break;
                default: 
                    throw new Exception();
            }
        }

        public static void ResolveSmsTransactionUpdates(IDbContextScope scope, SmsTransaction tx, Guid uaoID, DateTime dateTime, List<FieldUpdateDTO> updates)
        {
            SmsUserAccountOrganisationTransaction uaotx;

            foreach (var update in updates)
            {
                if (update.ActivityID != tx.SmsTransactionID) throw new Exception();
                switch ((FieldUpdateParentType)update.ParentType)
                {
                    case FieldUpdateParentType.SmsTransaction:
                        ResolveProperty(scope, tx, uaoID, dateTime, update);
                        break;
                    case FieldUpdateParentType.SmsTransactionAddress:
                        ResolveProperty(scope, tx.Address, uaoID, dateTime, update);
                        break;
                    case FieldUpdateParentType.RegisteredHomeAddress:
                        uaotx = tx.SmsUserAccountOrganisationTransactions.Single(x => x.SmsUserAccountOrganisationTransactionID == update.ParentID);
                        ResolveProperty(scope, uaotx == null ? null : uaotx.Address, uaoID, dateTime, update);
                        break;
                    case FieldUpdateParentType.Contact:
                        uaotx = tx.SmsUserAccountOrganisationTransactions.Single(x => x.SmsUserAccountOrganisationTransactionID == update.ParentID);
                        ResolveProperty(scope, uaotx == null ? null : uaotx.Contact, uaoID, dateTime, update);
                        break;
                    default:
                        throw new Exception();
                }
            }
        }

        private static void ResolveProperty(IDbContextScope scope, object approved, Guid uaoID, DateTime dateTime, FieldUpdateDTO update)
        {
            var approvedValue = approved == null ? null : approved.GetType().GetProperty(update.FieldName).GetValue(approved);
            var approvedStringValue = approvedValue == null ? null : approvedValue.ToString();
            var existingUpdate = scope.DbContexts.Get<TargetFrameworkEntities>().FieldUpdates.SingleOrDefault(x =>
                x.ActivityID == update.ActivityID &&
                x.ActivityType == update.ActivityType &&
                x.ParentType == update.ParentType &&
                x.ParentID == update.ParentID &&
                x.FieldName == update.FieldName);

            if (approvedStringValue != update.Value)
            {
                if (existingUpdate != null)
                {
                    if (existingUpdate.Value != update.Value)
                    {
                        existingUpdate.UserAccountOrganisationID = uaoID;
                        existingUpdate.ModifiedOn = dateTime;
                        existingUpdate.Value = update.Value;
                    }
                }
                else
                {
                    update.UserAccountOrganisationID = uaoID;
                    update.ModifiedOn = dateTime;
                    scope.DbContexts.Get<TargetFrameworkEntities>().FieldUpdates.Add(update.ToEntity());
                }
            }
            else
            {
                if (existingUpdate != null) scope.DbContexts.Get<TargetFrameworkEntities>().FieldUpdates.Remove(existingUpdate);
            }
        }
    }
}
