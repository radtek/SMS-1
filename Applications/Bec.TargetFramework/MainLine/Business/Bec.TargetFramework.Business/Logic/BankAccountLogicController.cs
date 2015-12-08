using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Notification;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.SB.Client.Interfaces;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.Security;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class BankAccountLogicController : LogicBase
    {
        public UserLogicController UserLogic { get; set; }
        public IEventPublishLogicClient EventPublishClient { get; set; }

        public async Task<bool> HasOrganisationAnySafeBankAccount(Guid organisationID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var safeBankAccountStatus = BankAccountStatusEnum.Safe.GetStringValue();
                return scope.DbContexts.Get<TargetFrameworkEntities>().VOrganisationBankAccountsWithStatus
                    .Any(s => s.OrganisationID == organisationID && s.Status == safeBankAccountStatus && s.IsActive);
            }
        }

        public List<VOrganisationBankAccountsWithStatusDTO> GetOrganisationBankAccounts(Guid orgID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var ret = scope.DbContexts.Get<TargetFrameworkEntities>().VOrganisationBankAccountsWithStatus.Where(x => x.OrganisationID == orgID).ToDtos();
                PopulateBankAccountHistory(ret, false);
                return ret;
            }
        }

        public List<VOrganisationBankAccountsWithStatusDTO> GetOutstandingBankAccounts()
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var s = LogicHelper.GetStatusType(scope, StatusTypeEnum.BankAccount.GetStringValue(), BankAccountStatusEnum.PendingValidation.GetStringValue());

                var ret = scope.DbContexts.Get<TargetFrameworkEntities>().VOrganisationBankAccountsWithStatus.Where(x => x.IsActive && x.Status == s.Name).ToDtos();
                PopulateBankAccountHistory(ret, true);
                foreach (var account in ret)
                {
                    account.Duplicates = scope.DbContexts.Get<TargetFrameworkEntities>().VOrganisationBankAccountsWithStatus.Where(x =>
                        x.OrganisationID != account.OrganisationID &&
                        x.BankAccountNumber == account.BankAccountNumber &&
                        x.SortCode == account.SortCode)
                        .ToDtos();
                    PopulateBankAccountHistory(account.Duplicates, true);
                }
                return ret;
            }
        }

        private void PopulateBankAccountHistory(List<VOrganisationBankAccountsWithStatusDTO> accounts, bool includeNotes)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                foreach (var item in accounts)
                {
                    item.History = scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationBankAccountStatus.Where(x => x.OrganisationBankAccountID == item.OrganisationBankAccountID).OrderByDescending(x => x.StatusChangedOn).ToDtos();
                    foreach (var h in item.History)
                    {
                        h.StatusTypeValue = scope.DbContexts.Get<TargetFrameworkEntities>().StatusTypeValues.Single(s => s.StatusTypeValueID == h.StatusTypeValueID).ToDto();
                        if (!includeNotes) h.Notes = "";
                    }
                }
            }
        }

        public async Task<Guid> AddBankAccount(Guid orgID, OrganisationBankAccountDTO accountDTO)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var bankAccountStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.BankAccount.GetStringValue(), BankAccountStatusEnum.PendingValidation.GetStringValue());

                var bankAccount = accountDTO.ToEntity();
                bankAccount.OrganisationBankAccountID = Guid.NewGuid();
                bankAccount.OrganisationID = orgID;
                bankAccount.IsActive = true;
                scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationBankAccounts.Add(bankAccount);

                var bankAccountAddStatus = new OrganisationBankAccountAddStatusDTO
                {
                    OrganisationID = orgID,
                    BankAccountID = bankAccount.OrganisationBankAccountID,
                    BankAccountOrganisationID = orgID,
                    StatusTypeID = bankAccountStatus.StatusTypeID,
                    StatusTypeVersionNumber = bankAccountStatus.StatusTypeVersionNumber,
                    StatusTypeValueID = bankAccountStatus.StatusTypeValueID,
                    Notes = string.Empty,
                    WasActive = true
                };

                await AddStatus(bankAccountAddStatus);
                await scope.SaveChangesAsync();
                return bankAccount.OrganisationBankAccountID;
            }
        }

        public async Task AddBankAccountStatusAsync(OrganisationBankAccountStateChangeDTO bankAccountStatusChangeRequest)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var bankAccount = scope.DbContexts.Get<TargetFrameworkEntities>().VOrganisationBankAccountsWithStatus.Single(x => x.OrganisationBankAccountID == bankAccountStatusChangeRequest.BankAccountID).ToDto();

                var currentStatus = EnumExtensions.GetEnumValue<BankAccountStatusEnum>(bankAccount.Status).Value;
                if (bankAccountStatusChangeRequest.BankAccountStatus == currentStatus) return;
                if (!CheckStatusChange(bankAccountStatusChangeRequest, currentStatus))
                    throw new Exception(string.Format("Cannot change Bank Account status from {0} to {1}, please go back and try again.", currentStatus, bankAccountStatusChangeRequest.BankAccountStatus));

                var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.BankAccount.GetStringValue(), bankAccountStatusChangeRequest.BankAccountStatus.GetStringValue());

                var bankAccountAddStatus = new OrganisationBankAccountAddStatusDTO
                {
                    OrganisationID = bankAccountStatusChangeRequest.RequestedByOrganisationID,
                    BankAccountID = bankAccountStatusChangeRequest.BankAccountID,
                    BankAccountOrganisationID = bankAccount.OrganisationID,
                    StatusTypeID = statusType.StatusTypeID,
                    StatusTypeVersionNumber = statusType.StatusTypeVersionNumber,
                    StatusTypeValueID = statusType.StatusTypeValueID,
                    Notes = bankAccountStatusChangeRequest.Notes,
                    WasActive = bankAccount.IsActive
                };

                await AddStatus(bankAccountAddStatus);

                if (bankAccountStatusChangeRequest.KillDuplicates)
                {
                    statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.BankAccount.GetStringValue(), BankAccountStatusEnum.PotentialFraud.GetStringValue());
                    foreach (var dupe in scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationBankAccounts.Where(x => x.BankAccountNumber == bankAccount.BankAccountNumber && x.SortCode == bankAccount.SortCode && x.OrganisationBankAccountID != bankAccountStatusChangeRequest.BankAccountID))
                    {
                        var dupeBankAccountAddStatus = new OrganisationBankAccountAddStatusDTO
                        {
                            OrganisationID = bankAccountStatusChangeRequest.RequestedByOrganisationID,
                            BankAccountID = dupe.OrganisationBankAccountID,
                            BankAccountOrganisationID = dupe.OrganisationID,
                            StatusTypeID = statusType.StatusTypeID,
                            StatusTypeVersionNumber = statusType.StatusTypeVersionNumber,
                            StatusTypeValueID = statusType.StatusTypeValueID,
                            Notes = "Pre-existing duplicate",
                            WasActive = dupe.IsActive
                        };
                        await AddStatus(dupeBankAccountAddStatus);
                    }
                }

                await scope.SaveChangesAsync();
                await AdditionalOperationForStatusChange(bankAccount, bankAccountStatusChangeRequest);
            }
        }

        public async Task<bool> CheckBankAccount(Guid orgID, Guid uaoID, Guid smsUserAccountOrganisationTransactionId, string accountNumber, string sortCode)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                string safe = BankAccountStatusEnum.Safe.GetStringValue();
                var isMatch = scope.DbContexts.Get<TargetFrameworkEntities>().VOrganisationBankAccountsWithStatus
                    .Where(x =>
                        x.BankAccountNumber == accountNumber &&
                        x.SortCode == sortCode &&
                        x.Status == safe &&
                        x.OrganisationID == orgID)
                    .Any();
                if (isMatch) await WriteCheckAudit(uaoID, smsUserAccountOrganisationTransactionId, accountNumber, sortCode, true);
                await scope.SaveChangesAsync();
                return isMatch;
            }
        }

        public async Task WriteCheckAudit(Guid uaoID, Guid smsUserAccountOrganisationTransactionId, string accountNumber, string sortCode, bool isMatch)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                //check for ownership via uao ID
                var uaot = scope.DbContexts.Get<TargetFrameworkEntities>().SmsUserAccountOrganisationTransactions.Single(s => s.SmsUserAccountOrganisationTransactionID == smsUserAccountOrganisationTransactionId && s.UserAccountOrganisationID == uaoID);
                if (uaot != null)
                {
                    var smsBankAccountCheck = new SmsBankAccountCheck
                    {
                        SmsBankAccountCheckID = Guid.NewGuid(),
                        CheckedOn = DateTime.Now,
                        IsMatch = isMatch,
                        SmsUserAccountOrganisationTransactionID = smsUserAccountOrganisationTransactionId,
                        BankAccountNumber = accountNumber,
                        SortCode = sortCode
                    };
                    scope.DbContexts.Get<TargetFrameworkEntities>().SmsBankAccountChecks.Add(smsBankAccountCheck);

                    uaot.LatestBankAccountCheckID = smsBankAccountCheck.SmsBankAccountCheckID;
                    uaot.ModifiedOn = DateTime.Now;
                    uaot.ModifiedBy = UserNameService.UserName;
                }
                await scope.SaveChangesAsync();
            }
        }

        private static bool CheckStatusChange(OrganisationBankAccountStateChangeDTO change, BankAccountStatusEnum currentStatus)
        {
            switch (currentStatus)
            {
                case BankAccountStatusEnum.Safe:
                    if (change.BankAccountStatus == BankAccountStatusEnum.FraudSuspicion ||
                        change.BankAccountStatus == BankAccountStatusEnum.PotentialFraud) return true;
                    break;
                case BankAccountStatusEnum.FraudSuspicion:
                case BankAccountStatusEnum.PendingValidation:
                    if (change.BankAccountStatus == BankAccountStatusEnum.Safe ||
                        change.BankAccountStatus == BankAccountStatusEnum.PotentialFraud) return true;
                    break;
            }
            return false;
        }

        private async Task AdditionalOperationForStatusChange(VOrganisationBankAccountsWithStatusDTO bankAccount, OrganisationBankAccountStateChangeDTO bankAccountStatusChangeRequest)
        {
            switch (bankAccountStatusChangeRequest.BankAccountStatus)
            {
                case BankAccountStatusEnum.PendingValidation:
                    break;
                case BankAccountStatusEnum.Safe:
                    await PublishBankAccountStateChangeNotification<BankAccountMarkedAsSafeNotificationDTO>(NotificationConstructEnum.BankAccountMarkedAsSafe.GetStringValue(), bankAccount, bankAccountStatusChangeRequest);
                    break;
                case BankAccountStatusEnum.FraudSuspicion:
                    await PublishBankAccountStateChangeNotification<BankAccountMarkedAsFraudSuspiciousNotificationDTO>(NotificationConstructEnum.BankAccountMarkedAsFraudSuspicious.GetStringValue(), bankAccount, bankAccountStatusChangeRequest);
                    break;
                case BankAccountStatusEnum.PotentialFraud:
                    break;
            }
        }



        private async Task PublishBankAccountStateChangeNotification<TNotification>(string eventName, VOrganisationBankAccountsWithStatusDTO bankAccount, OrganisationBankAccountStateChangeDTO bankAccountStatusChangeRequest)
            where TNotification : BankAccountStateChangeNotificationDTO, new()
        {
            var financeAdministratorRoleName = OrganisationRoleName.FinanceAdministrator.GetStringValue();
            var roles = await UserLogic.GetRoles(bankAccountStatusChangeRequest.ChangedByUserAccountOrganisationID, 1);
            var isFinanceAdmin = roles.Any(r => r.OrganisationRole.RoleName == financeAdministratorRoleName);
            string markedBy;
            if (isFinanceAdmin)
            {
                markedBy = Constants.FinanceTeamName;
            }
            else
            {
                var markedByUser = UserLogic.GetUserAccountOrganisationPrimaryContact(bankAccountStatusChangeRequest.ChangedByUserAccountOrganisationID);
                markedBy = markedByUser.FullName;
            }

            var notificationDto = new TNotification
            {
                OrganisationBankAccountID = bankAccount.OrganisationBankAccountID,
                OrganisationId = bankAccount.OrganisationID,
                AccountNumber = bankAccount.BankAccountNumber,
                SortCode = bankAccount.SortCode,
                MarkedBy = markedBy,
                Reason = bankAccountStatusChangeRequest.Notes,
                DetailsUrl = bankAccountStatusChangeRequest.DetailsUrl,
            };
            string payLoad = JsonHelper.SerializeData(new object[] { notificationDto });

            var dto = new EventPayloadDTO
            {
                EventName = eventName,
                EventSource = AppDomain.CurrentDomain.FriendlyName,
                EventReference = "0003",
                PayloadAsJson = payLoad
            };

            await EventPublishClient.PublishEventAsync(dto);
        }

        public async Task ToggleBankAccountActive(Guid orgID, Guid baID, bool active, string notes)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var bankAccount = scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationBankAccounts
                    .Single(x => x.OrganisationBankAccountID == baID && x.OrganisationID == orgID);
                var accountStatus = scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationBankAccountStatus
                    .Where(x => x.OrganisationBankAccountID == baID)
                    .OrderByDescending(x => x.StatusChangedOn)
                    .First();

                bankAccount.IsActive = active;

                var bankAccountAddStatus = new OrganisationBankAccountAddStatusDTO
                {
                    OrganisationID = orgID,
                    BankAccountID = baID,
                    BankAccountOrganisationID = bankAccount.OrganisationID,
                    StatusTypeID = accountStatus.StatusTypeID,
                    StatusTypeVersionNumber = accountStatus.StatusTypeVersionNumber,
                    StatusTypeValueID = accountStatus.StatusTypeValueID,
                    Notes = notes,
                    WasActive = bankAccount.IsActive
                };

                await AddStatus(bankAccountAddStatus);
                await scope.SaveChangesAsync();
            }
        }

        private async Task AddStatus(OrganisationBankAccountAddStatusDTO bankAccountAddStatus)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                string updatedBy = UserNameService.UserName;
                if (bankAccountAddStatus.BankAccountOrganisationID != bankAccountAddStatus.OrganisationID)
                {
                    var org = scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationDetails.Single(x => x.OrganisationID == bankAccountAddStatus.OrganisationID);
                    if (org.Organisation.OrganisationType.Name == "Administration")
                        updatedBy = Constants.SmsTeamName;
                    else
                        updatedBy = org.Name;
                }

                scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationBankAccountStatus.Add(new OrganisationBankAccountStatus
                {
                    OrganisationBankAccountID = bankAccountAddStatus.BankAccountID,
                    StatusTypeID = bankAccountAddStatus.StatusTypeID,
                    StatusTypeVersionNumber = bankAccountAddStatus.StatusTypeVersionNumber,
                    StatusTypeValueID = bankAccountAddStatus.StatusTypeValueID,
                    StatusChangedOn = DateTime.Now,
                    StatusChangedBy = updatedBy,
                    Notes = bankAccountAddStatus.Notes,
                    WasActive = bankAccountAddStatus.WasActive
                });
                await scope.SaveChangesAsync();
            }
        }

        public async Task PublishCheckNoMatchNotification(Guid uaoID, Guid uaotxID, string accountNumber, string sortCode)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var usertx = scope.DbContexts.Get<TargetFrameworkEntities>().SmsUserAccountOrganisationTransactions.Single(x => x.SmsUserAccountOrganisationTransactionID == uaotxID && x.UserAccountOrganisationID == uaoID);
                if (usertx == null) throw new Exception("User and transaction combination not found");

                var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == uaoID);
                var c = scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.FirstOrDefault(x => x.ParentID == uaoID);
                
                string details = "";
                if (c != null) details = c.FirstName + " " + c.LastName + Environment.NewLine + Environment.NewLine;
                if (usertx.SmsTransaction.Address != null) details += string.Join(Environment.NewLine, usertx.SmsTransaction.Address.Line1, usertx.SmsTransaction.Address.Town, usertx.SmsTransaction.Address.County, usertx.SmsTransaction.Address.PostalCode);
                
                var notificationDto = new BankAccountCheckNoMatchNotificationDTO
                {
                    TransactionId = usertx.SmsTransactionID,
                    OrganisationId = usertx.SmsTransaction.OrganisationID,
                    AccountNumber = accountNumber,
                    SortCode = sortCode,
                    MarkedBy = uao.UserAccount.Email,
                    Reason = details
                };
                string payLoad = JsonHelper.SerializeData(new object[] { notificationDto });

                var dto = new EventPayloadDTO
                {
                    EventName = NotificationConstructEnum.BankAccountCheckNoMatch.GetStringValue(),
                    EventSource = AppDomain.CurrentDomain.FriendlyName,
                    EventReference = "0005",
                    PayloadAsJson = payLoad
                };

                await EventPublishClient.PublishEventAsync(dto);
            }
        }
    }
}
