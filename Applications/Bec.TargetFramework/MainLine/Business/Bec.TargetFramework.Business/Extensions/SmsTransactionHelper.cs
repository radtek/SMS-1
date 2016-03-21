using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using Mehdime.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static List<ResolvedUpdate> ResolveSmsTransactionUpdates(IDbContextScope scope, SmsTransaction tx, Guid uaoID, DateTime dateTime, List<FieldUpdateDTO> updates)
        {
            List<ResolvedUpdate> ret = new List<ResolvedUpdate>();
            SmsUserAccountOrganisationTransaction uaotx;

            foreach (var update in updates)
            {
                if (update.ActivityID != tx.SmsTransactionID) throw new Exception();
                switch ((FieldUpdateParentType)update.ParentType)
                {
                    case FieldUpdateParentType.SmsTransaction:
                        ret.AddRange(ResolveProperty(scope, tx, uaoID, dateTime, update, ""));
                        break;
                    case FieldUpdateParentType.SmsTransactionAddress:
                        ret.AddRange(ResolveProperty(scope, tx.Address, uaoID, dateTime, update, "Transaction Address"));
                        break;
                    case FieldUpdateParentType.RegisteredHomeAddress:
                        uaotx = tx.SmsUserAccountOrganisationTransactions.Single(x => x.SmsUserAccountOrganisationTransactionID == update.ParentID);
                        ret.AddRange(ResolveProperty(scope, uaotx == null ? null : uaotx.Address, uaoID, dateTime, update, uaotx.SmsUserAccountOrganisationTransactionType.Name + " Registered Home Address"));
                        break;
                    case FieldUpdateParentType.Contact:
                        uaotx = tx.SmsUserAccountOrganisationTransactions.Single(x => x.SmsUserAccountOrganisationTransactionID == update.ParentID);
                        ret.AddRange(ResolveProperty(scope, uaotx == null ? null : uaotx.Contact, uaoID, dateTime, update, uaotx.SmsUserAccountOrganisationTransactionType.Name + " Details"));
                        break;
                    default:
                        throw new Exception();
                }
            }
            return ret;
        }

        private static List<ResolvedUpdate> ResolveProperty(IDbContextScope scope, object approved, Guid uaoID, DateTime dateTime, FieldUpdateDTO update, string descriptionContext)
        {
            List<ResolvedUpdate> ret = new List<ResolvedUpdate>();
            var approvedProperty = approved == null ? null : approved.GetType().GetProperty(update.FieldName);
            var approvedValue = approvedProperty == null ? null : approvedProperty.GetValue(approved);
            string approvedStringValue;
            if (approvedProperty != null && (approvedProperty.PropertyType == typeof(Nullable<DateTime>) || approvedProperty.PropertyType == typeof(DateTime)))
            {
                var approvedDateTime = (DateTime?)approvedValue;
                approvedStringValue = (approvedDateTime == null ? string.Empty : approvedDateTime.Value.ToString("O"));
            }
            else
            {
                approvedStringValue = (approvedValue == null ? string.Empty : approvedValue.ToString()).Trim();
            }

            update.Value = (update.Value ?? string.Empty).Trim();

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
                    if (existingUpdate.Value.Trim() != update.Value)
                    {
                        existingUpdate.UserAccountOrganisationID = uaoID;
                        existingUpdate.ModifiedOn = dateTime;
                        existingUpdate.Value = update.Value;
                        ret.Add(new ResolvedUpdate(update, approvedStringValue, descriptionContext));
                    }
                }
                else
                {
                    update.UserAccountOrganisationID = uaoID;
                    update.ModifiedOn = dateTime;
                    scope.DbContexts.Get<TargetFrameworkEntities>().FieldUpdates.Add(update.ToEntity());
                    ret.Add(new ResolvedUpdate(update, approvedStringValue, descriptionContext));
                }
            }
            else
            {
                if (existingUpdate != null) scope.DbContexts.Get<TargetFrameworkEntities>().FieldUpdates.Remove(existingUpdate);
            }
            return ret;
        }
    }

    public class ResolvedUpdate
    {
        public string Source { get; set; }
        public string OriginalValue { get; set; }
        public string NewValue { get; set; }

        public ResolvedUpdate(FieldUpdateDTO update, string originalValue, string descriptionContext)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(descriptionContext)) sb.AppendFormat("{0} ", descriptionContext);
            sb.Append(Regex.Replace(update.FieldName, "([a-z](?=[A-Z0-9])|[A-Z](?=[A-Z][a-z]))", "$1 "));
            Source = sb.ToString();
            OriginalValue = originalValue;
            NewValue = update.Value;
        }
    }
}
