using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
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
    public class OrganisationLogicController : LogicBase
    {
        public TFSettingsLogicController Settings { get; set; }
        public UserLogicController UserLogic { get; set; }
        public IEventPublishLogicClient EventPublishClient { get; set; }
        public NotificationLogicController NotificationLogic { get; set; }

        public async Task ExpireTemporaryLoginsAsync(int days, int hours, int minutes)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                foreach (var uao in scope.DbContext.UserAccountOrganisations.Where(x => x.UserAccount.IsTemporaryAccount && x.PinCreated != null))
                {
                    var testDate = uao.PinCreated.Value.AddDays(days).AddHours(hours).AddMinutes(minutes);
                    if (testDate < DateTime.Now) await ExpireUserAccountOrganisationAsync(uao.UserAccountOrganisationID);
                }

                await scope.SaveAsync();
            }
        }

        public async Task ExpireUserAccountOrganisationAsync(Guid uaoID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var uao = scope.DbContext.UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == uaoID);
                var verifiedStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Verified.GetStringValue());

                uao.UserAccount.IsLoginAllowed = false;
                uao.PinCode = null;

                if (uao.Organisation != null)
                {
                    var status = uao.Organisation.OrganisationStatus.OrderByDescending(s => s.StatusChangedOn).FirstOrDefault();
                    if (status != null && status.StatusTypeValueID == verifiedStatus.StatusTypeValueID)
                        await ExpireOrganisationAsync(uao.OrganisationID);
                }
                await scope.SaveAsync();
            }
        }

        public List<VOrganisationWithStatusAndAdminDTO> FindDuplicateOrganisations(string companyName, string postalCode)
        {
            Ensure.That(postalCode).IsNotNullOrWhiteSpace();

            using (new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var query = GetDuplicateOrganisations(companyName, postalCode);
                return query.OrderBy(c => c.Name).ThenBy(c => c.CreatedOn).ToDtos();
            }
        }

        public async Task RejectOrganisationAsync(RejectCompanyDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var checkStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Unverified.GetStringValue());
                var org = scope.DbContext.VOrganisationWithStatusAndAdmins.Single(c => c.OrganisationID == dto.OrganisationId);
                if (org.StatusTypeValueID != checkStatus.StatusTypeValueID) throw new Exception(string.Format("Cannot reject a company of status '{0}'. Please go back and try again.", org.StatusValueName));

                await AddOrganisationStatusAsync(dto.OrganisationId, StatusTypeEnum.ProfessionalOrganisation, ProfessionalOrganisationStatusEnum.Rejected, dto.Reason, dto.Notes);

                await scope.SaveAsync();
            }
        }

        public async Task ActivateOrganisationAsync(Guid organisationID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var checkStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Verified.GetStringValue());
                var org = scope.DbContext.VOrganisationWithStatusAndAdmins.Single(c => c.OrganisationID == organisationID);
                if (org.StatusTypeValueID != checkStatus.StatusTypeValueID) throw new Exception(string.Format("Cannot activate a company of status '{0}'. Please go back and try again.", org.StatusValueName));

                await AddOrganisationStatusAsync(organisationID, StatusTypeEnum.ProfessionalOrganisation, ProfessionalOrganisationStatusEnum.Active, null, null);

                await scope.SaveAsync();
            }
        }

        public List<Bec.TargetFramework.Entities.VOrganisationWithStatusAndAdminDTO> GetCompanies(ProfessionalOrganisationStatusEnum orgStatus)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var status = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), orgStatus.GetStringValue());
                return scope.DbContext.VOrganisationWithStatusAndAdmins.Where(item => item.StatusTypeValueID == status.StatusTypeValueID).ToDtos();
            }
        }



        public async Task<Guid> AddNewUnverifiedOrganisationAndAdministratorAsync(OrganisationTypeEnum organisationType, Bec.TargetFramework.Entities.AddCompanyDTO dto)
        {
            DefaultOrganisation defaultOrganisation = null;
            Guid orgRoleID;
            // get status type for professional organisation
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                // get professional default organisation template
                defaultOrganisation = scope.DbContext.DefaultOrganisations.Single(s => s.Name.Equals("Professional Organisation"));
            }
            Ensure.That(defaultOrganisation).IsNotNull();

            bool isDuplicate = true;
            // check if the organisation is not a duplicate
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                isDuplicate = GetDuplicateOrganisations(dto.CompanyName, dto.PostalCode).Any();
            }
            Ensure.That(isDuplicate).IsFalse();

            // add organisation
            var organisationID = (await AddOrganisationAsync(organisationType.GetIntValue(), defaultOrganisation, dto)).Value;

            var randomUsername = RandomPasswordGenerator.GenerateRandomName();
            var randomPassword = RandomPasswordGenerator.Generate(10);
            var userContactDto = new ContactDTO
            {
                Telephone1 = dto.OrganisationAdminTelephone,
                FirstName = dto.OrganisationAdminFirstName,
                LastName = dto.OrganisationAdminLastName,
                EmailAddress1 = dto.OrganisationAdminEmail,
                Salutation = dto.OrganisationAdminSalutation
            };

            var uaoDto = await AddNewUserToOrganisationAsync(organisationID, userContactDto, UserTypeEnum.OrganisationAdministrator, randomUsername, randomPassword, true, true, true);

            return organisationID;
        }

        public async Task<UserAccountOrganisationDTO> AddNewUserToOrganisationAsync(Guid organisationID, ContactDTO userContactDto, UserTypeEnum userTypeValue, string username, string password, bool isTemporary, bool sendEmail, bool addDefaultRoles, [System.Web.Http.FromUri]params Guid[] roles)
        {
            UserAccountOrganisationDTO uaoDto;
            Guid? userOrgID;
            var ua = await UserLogic.CreateAccountAsync(username, password, userContactDto.EmailAddress1, isTemporary, Guid.NewGuid());
            Ensure.That(ua).IsNotNull();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                Logger.Trace(string.Format("new user: {0} password: {1}", username, password));

                // add user to organisation
                userOrgID = scope.DbContext.FnAddUserToOrganisation(ua.ID, organisationID, userTypeValue.GetGuidValue(), organisationID, addDefaultRoles);
                Ensure.That(userOrgID).IsNotNull();

                foreach (var roleID in roles)
                {
                    scope.DbContext.UserAccountOrganisationRoles.Add(new UserAccountOrganisationRole
                    {
                        UserAccountOrganisationID = userOrgID.Value,
                        OrganisationRoleID = roleID
                    });
                }

                var uao = scope.DbContext.UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == userOrgID.Value);

                // create or update contact
                if (userContactDto.ContactID == Guid.Empty)
                {
                    var contact = new Contact
                    {
                        ContactID = Guid.NewGuid(),
                        ParentID = userOrgID.Value,
                        ContactName = "",
                        IsPrimaryContact = true,
                        Telephone1 = userContactDto.Telephone1,
                        FirstName = userContactDto.FirstName,
                        LastName = userContactDto.LastName,
                        EmailAddress1 = userContactDto.EmailAddress1,
                        Salutation = userContactDto.Salutation
                    };
                    scope.DbContext.Contacts.Add(contact);
                    uao.PrimaryContactID = contact.ContactID;
                }
                else
                {
                    var existingUserContact = scope.DbContext.Contacts.Single(c => c.ContactID == userContactDto.ContactID);
                    existingUserContact.ParentID = userOrgID.Value;

                    uao.PrimaryContactID = existingUserContact.ContactID;
                }
                uaoDto = uao.ToDto();
                await scope.SaveAsync();
            }

            //create Ts & Cs notification
            if (!isTemporary && userTypeValue == UserTypeEnum.OrganisationAdministrator) await CreateTsAndCsNotificationAsync(userOrgID.Value);

            if (sendEmail) await SendNewUserEmailAsync(username, password, uaoDto.UserAccountOrganisationID, userContactDto, organisationID, userTypeValue);

            return uaoDto;
        }

        public async Task CreateTsAndCsNotificationAsync(Guid userOrgID)
        {
            var nc = NotificationLogic.GetLatestNotificationConstructIdFromName("TcPublic");

            var notificationDto = new NotificationDTO();
            notificationDto.NotificationConstructID = nc.NotificationConstructID;
            notificationDto.NotificationConstructVersionNumber = nc.NotificationConstructVersionNumber;
            notificationDto.ParentID = null;
            notificationDto.DateSent = DateTime.Now;
            notificationDto.IsActive = true;
            notificationDto.IsDeleted = false;
            notificationDto.IsVisible = true;
            notificationDto.IsInternal = (nc.DefaultNotificationDeliveryMethodID == NotificationDeliveryMethodIDEnum.System.GetIntValue());
            notificationDto.IsExternal = (nc.DefaultNotificationDeliveryMethodID == NotificationDeliveryMethodIDEnum.Email.GetIntValue());
            notificationDto.NotificationData = "{}";
            notificationDto.NotificationRecipients = new List<NotificationRecipientDTO> { new NotificationRecipientDTO { UserAccountOrganisationID = userOrgID } };

            await NotificationLogic.SaveNotificationAsync(notificationDto);
        }

        private async Task SendNewUserEmailAsync(string username, string password, Guid userAccountOrganisationID, ContactDTO contact, Guid organisationID, UserTypeEnum userType)
        {
            string eventName = "TestEvent";
            switch (userType)
            {
                case UserTypeEnum.User:
                    eventName = "NewUser";
                    break;
            }

            var commonSettings = Settings.GetSettings().AsSettings<CommonSettings>();
            var tempDto = new Bec.TargetFramework.Entities.AddNewCompanyAndAdministratorDTO
            {
                Salutation = contact.Salutation,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Username = username,
                Password = password,
                UserAccountOrganisationID = userAccountOrganisationID,
                ProductName = commonSettings.ProductName,
                WebsiteURL = commonSettings.PublicWebsiteUrl
            };

            //add entry to EventStatus table
            EventStatus es;
            string payLoad;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var executingUao = scope.DbContext.UserAccountOrganisations.SingleOrDefault(x => x.UserAccount.Username == UserNameService.UserName);
                if (executingUao != null && executingUao.Contact != null)
                {
                    tempDto.InviterSalutation = executingUao.Contact.Salutation;
                    tempDto.InviterFirstName = executingUao.Contact.FirstName;
                    tempDto.InviterLastName = executingUao.Contact.LastName;
                }
                payLoad = JsonHelper.SerializeData(new object[] { tempDto });

                es = new EventStatus()
                {
                    EventStatusID = Guid.NewGuid(),
                    EventName = eventName,
                    EventReference = organisationID.ToString(),
                    Status = "Pending",
                    Created = DateTime.Now
                };
                scope.DbContext.EventStatus.Add(es);
                await scope.SaveAsync();
            }

            var dto = new Bec.TargetFramework.SB.Entities.EventPayloadDTO
            {
                EventName = eventName,
                EventSource = AppDomain.CurrentDomain.FriendlyName,
                EventReference = es.EventStatusID.ToString(),
                PayloadAsJson = payLoad
            };

            await EventPublishClient.PublishEventAsync(dto);
        }

        private async Task<Guid?> AddOrganisationAsync(int organisationTypeID, DefaultOrganisation defaultOrg, Bec.TargetFramework.Entities.AddCompanyDTO dto)
        {
            Guid? organisationID = null;

            // create company 
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                // create organisation from do template using stored procedure
                organisationID = scope.DbContext.FnCreateOrganisationFromDefault(
                    organisationTypeID,
                    defaultOrg.DefaultOrganisationID,
                    defaultOrg.DefaultOrganisationVersionNumber,
                    dto.CompanyName,
                    "",
                    UserNameService.UserName);

                // ensure guid has a value
                Ensure.That(organisationID).IsNotNull();
                // TODO ZM: consider validation pattern for dtos
                // Maybe trimming all strings in EF will be a solution http://romiller.com/2014/10/20/ef6-1workaround-trailing-blanks-issue-in-string-joins/
                Ensure.That(dto.RegulatorNumber).IsNotNull();

                // create contact for organisation
                var contact = new Contact
                {
                    ContactID = Guid.NewGuid(),
                    ParentID = organisationID.Value,
                    ContactName = "",
                    IsPrimaryContact = true
                };

                scope.DbContext.Contacts.Add(contact);

                // contact regulator
                var contactRegulator = new ContactRegulator
                {
                    ContactID = contact.ContactID,
                    RegulatorName = dto.Regulator,
                    RegulatorOtherName = dto.RegulatorOther,
                    RegulatorNumber = dto.RegulatorNumber.Trim()
                };

                scope.DbContext.ContactRegulators.Add(contactRegulator);

                //address to contact, organisation to the contact
                var address = new Address
                {
                    AddressID = Guid.NewGuid(),
                    ParentID = contact.ContactID,
                    Line1 = dto.Line1,
                    Line2 = dto.Line2,
                    Town = dto.Town,
                    County = dto.County,
                    PostalCode = dto.PostalCode,
                    AddressTypeID = AddressTypeIDEnum.Work.GetIntValue(),
                    Name = String.Empty,
                    IsPrimaryAddress = true,
                    AdditionalAddressInformation = dto.AdditionalAddressInformation
                };
                scope.DbContext.Addresses.Add(address);

                await scope.SaveAsync();
            }

            return organisationID;
        }

        public Guid? GetTemporaryOrganisationBranchID()
        {
            int temporaryOrgTypeID = OrganisationTypeEnum.Temporary.GetIntValue();

            Guid? orgBranchID = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                // get orgID
                var organisationID = scope.DbContext.Organisations.Single(s => !s.ParentOrganisationID.HasValue && s.OrganisationTypeID == temporaryOrgTypeID).OrganisationID;
                orgBranchID = scope.DbContext.Organisations.Single(s => s.ParentOrganisationID.HasValue && s.ParentOrganisationID == organisationID && s.IsBranch == true).OrganisationID;
            }

            return orgBranchID;
        }

        public VOrganisationDTO GetOrganisationDTO(Guid id)
        {
            Ensure.That(id).IsNot(Guid.Empty);

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                return scope.DbContext.VOrganisations.Single(item => item.OrganisationID == id).ToDto();
            }
        }

        internal async Task ExpireOrganisationAsync(Guid organisationID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                Logger.Trace("Expiring organisation" + organisationID.ToString());
                await AddOrganisationStatusAsync(organisationID, StatusTypeEnum.ProfessionalOrganisation, ProfessionalOrganisationStatusEnum.Expired, null, "Automatic expiry");
                await scope.SaveAsync();
            }
        }

        public async Task AddOrganisationStatusAsync(Guid orgID, StatusTypeEnum enumType, ProfessionalOrganisationStatusEnum status, int? reason, string notes)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var s = LogicHelper.GetStatusType(scope, enumType.GetStringValue(), status.GetStringValue());
                scope.DbContext.OrganisationStatus.Add(new OrganisationStatus
                {
                    OrganisationID = orgID,
                    ReasonID = reason,
                    Notes = notes,
                    StatusTypeID = s.StatusTypeID,
                    StatusTypeVersionNumber = s.StatusTypeVersionNumber,
                    StatusTypeValueID = s.StatusTypeValueID,
                    StatusChangedOn = DateTime.Now,
                    StatusChangedBy = UserNameService.UserName
                });
                await scope.SaveAsync();
            }
        }

        public async Task<Guid> AddSmsTransaction(Guid orgID, SmsTransactionDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var txID = Guid.NewGuid();

                var address = scope.DbContext.Addresses.FirstOrDefault(x =>
                    x.Line1 == dto.Address.Line1 &&
                    x.Line2 == dto.Address.Line2 &&
                    x.Town == dto.Address.Town &&
                    x.County == dto.Address.County &&
                    x.PostalCode == dto.Address.PostalCode);

                if (address == null)
                {
                    address = dto.Address.ToEntity();
                    address.AddressID = Guid.NewGuid();
                    address.AddressTypeID = AddressTypeIDEnum.Work.GetIntValue();
                    address.Name = String.Empty;
                    address.ParentID = txID;
                    scope.DbContext.Addresses.Add(address); // TODO: erm, this doesn't appear to work
                }

                SmsTransaction tx = new SmsTransaction
                {
                    SmsTransactionID = txID,
                    Address = address,
                    Price = dto.Price,
                    Reference = dto.Reference,
                    OrganisationID = orgID,
                    TenureTypeID = dto.TenureTypeID,
                    CreatedOn = DateTime.Now
                };
                scope.DbContext.SmsTransactions.Add(tx);
                await scope.SaveAsync();
                return tx.SmsTransactionID;
            }
        }


        public List<VOrganisationBankAccountsWithStatusDTO> GetOrganisationBankAccounts(Guid orgID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                //TODO: tidy this up when OData sub-queries work
                var ret = scope.DbContext.VOrganisationBankAccountsWithStatus.Where(x => x.OrganisationID == orgID).ToDtos();
                foreach (var item in ret)
                {
                    item.History = scope.DbContext.OrganisationBankAccountStatus.Where(x => x.OrganisationBankAccountID == item.OrganisationBankAccountID).OrderBy(x => x.StatusChangedOn).ToDtos();
                    foreach (var h in item.History) h.StatusName = scope.DbContext.VStatusTypes.Single(s => s.StatusTypeValueID == h.StatusTypeValueID).Name;
                }
                return ret;
            }
        }

        public List<VOrganisationBankAccountsWithStatusDTO> GetOutstandingBankAccounts()
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                //TODO: tidy this up when OData sub-queries work
                var safeStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.BankAccount.GetStringValue(), BankAccountStatusEnum.Safe.GetStringValue());

                var ret = scope.DbContext.VOrganisationBankAccountsWithStatus.Where(x => x.IsActive && x.Status != safeStatus.Name).ToDtos();
                foreach (var item in ret)
                {
                    item.History = scope.DbContext.OrganisationBankAccountStatus.Where(x => x.OrganisationBankAccountID == item.OrganisationBankAccountID).OrderBy(x => x.StatusChangedOn).ToDtos();
                    foreach (var h in item.History) h.StatusName = scope.DbContext.VStatusTypes.Single(s => s.StatusTypeValueID == h.StatusTypeValueID).Name;
                }
                return ret;
            }
        }

        public async Task<Guid> AddBankAccount(Guid orgID, OrganisationBankAccountDTO accountDTO)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var s = LogicHelper.GetStatusType(scope, StatusTypeEnum.BankAccount.GetStringValue(), BankAccountStatusEnum.PendingValidation.GetStringValue());

                var account = accountDTO.ToEntity();
                account.OrganisationBankAccountID = Guid.NewGuid();
                account.OrganisationID = orgID;
                account.IsActive = true;
                scope.DbContext.OrganisationBankAccounts.Add(account);

                await AddStatus(orgID, account.OrganisationBankAccountID, orgID, s.StatusTypeID, s.StatusTypeVersionNumber, s.StatusTypeValueID, "", true);

                await scope.SaveAsync();
                return account.OrganisationBankAccountID;
            }
        }

        public async Task AddBankAccountStatusAsync(Guid currentOrgID, Guid baID, BankAccountStatusEnum status, string notes)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var ba = scope.DbContext.OrganisationBankAccounts.Single(x => x.OrganisationBankAccountID == baID);
                var s = LogicHelper.GetStatusType(scope, StatusTypeEnum.BankAccount.GetStringValue(), status.GetStringValue());

                await AddStatus(currentOrgID, baID, ba.OrganisationID, s.StatusTypeID, s.StatusTypeVersionNumber, s.StatusTypeValueID, notes, ba.IsActive);
                await scope.SaveAsync();
                await AdditionalOperationForStatusChange(currentOrgID, status);
            }
        }

        private async Task AdditionalOperationForStatusChange(Guid organisationId, BankAccountStatusEnum status)
        {
            switch (status)
            {
                case BankAccountStatusEnum.PendingValidation:
                    break;
                case BankAccountStatusEnum.Safe:
                    break;
                case BankAccountStatusEnum.FraudSuspicion:
                    await PublishBankAccountMarkedAsFraudSuspiciousNotification(organisationId);
                    break;
                case BankAccountStatusEnum.PotentialFraud:
                    break;
                default:
                    break;
            }
        }

        private async Task PublishBankAccountMarkedAsFraudSuspiciousNotification(Guid organisationId)
        {
            IEnumerable<Guid> userAccountOrganisationIds;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                userAccountOrganisationIds = scope.DbContext.UserAccountOrganisations
                    .Where(item => item.OrganisationID == organisationId && item.IsActive && !item.IsDeleted)
                    .Select(a => a.UserAccountOrganisationID)
                    .ToList();
            }
            Ensure.That(userAccountOrganisationIds).IsNotNull();
            if (!userAccountOrganisationIds.Any())
            {
                throw new InvalidOperationException(string.Format("There are no user accounts associated to that organisation: {0}", organisationId));
            }

            var notificationDto = new BankAccountMarkedAsFraudSuspiciousNotificationDTO
            {
                UserAccountOrganisationIds = userAccountOrganisationIds,
                AccountNumber = "123",
                SortCode = "321",
                DetailsUrl = "http://test.com/"
            };
            string payLoad = JsonHelper.SerializeData(new object[] { notificationDto });

            var dto = new EventPayloadDTO
            {
                EventName = "BankAccountMarkedAsFraudSuspicious",
                EventSource = AppDomain.CurrentDomain.FriendlyName,
                EventReference = "0003",
                PayloadAsJson = payLoad
            };

            await EventPublishClient.PublishEventAsync(dto);
        }

        public async Task ToggleBankAccountActive(Guid orgID, Guid baID, bool active)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var ba = scope.DbContext.OrganisationBankAccounts.Single(x => x.OrganisationBankAccountID == baID);
                var s = scope.DbContext.OrganisationBankAccountStatus.Where(x => x.OrganisationBankAccountID == baID).OrderByDescending(x => x.StatusChangedOn).First();

                ba.IsActive = active;
                await AddStatus(orgID, baID, ba.OrganisationID, s.StatusTypeID, s.StatusTypeVersionNumber, s.StatusTypeValueID, "", ba.IsActive);
                await scope.SaveAsync();
            }
        }

        private async Task AddStatus(Guid currentOrgID, Guid baID, Guid? baOrgID, Guid statusTypeID, int statusTypeVersionNumber, Guid statusTypeValueID, string notes, bool wasActive)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                string updatedBy;
                if (baOrgID != currentOrgID)
                    updatedBy = scope.DbContext.OrganisationDetails.Single(x => x.OrganisationID == currentOrgID).Name;
                else
                    updatedBy = UserNameService.UserName;

                scope.DbContext.OrganisationBankAccountStatus.Add(new OrganisationBankAccountStatus
                {
                    OrganisationBankAccountID = baID,
                    StatusTypeID = statusTypeID,
                    StatusTypeVersionNumber = statusTypeVersionNumber,
                    StatusTypeValueID = statusTypeValueID,
                    StatusChangedOn = DateTime.Now,
                    StatusChangedBy = updatedBy,
                    Notes = notes,
                    WasActive = wasActive
                });
                await scope.SaveAsync();
            }
        }

        public List<OrganisationRoleDTO> GetAvailableRoles(Guid orgID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                return scope.DbContext.OrganisationRoles.Where(x => x.OrganisationID == orgID).ToDtos();
            }
        }

        private IQueryable<VOrganisationWithStatusAndAdmin> GetDuplicateOrganisations(string companyName, string postalCode)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                // TODO ZM: Consider the change of database collation to do Case Insensitive string comparison
                var query = scope.DbContext.VOrganisationWithStatusAndAdmins
                    .Where(item =>
                        item.PostalCode.ToLower() == postalCode.Trim().ToLower() &&
                        item.Name.ToLower() == companyName.Trim().ToLower());

                return query;
            }
        }
    }
}
