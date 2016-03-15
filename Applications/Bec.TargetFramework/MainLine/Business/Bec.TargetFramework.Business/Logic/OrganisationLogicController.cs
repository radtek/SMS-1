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
using Bec.TargetFramework.Business.Product.Processor;
using Bec.TargetFramework.Business.Extensions;
using Bec.TargetFramework.Transfer.Client.Clients;
using Bec.TargetFramework.Transfer.Client.Interfaces;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class OrganisationLogicController : LogicBase
    {
        public TFSettingsLogicController Settings { get; set; }
        public UserLogicController UserLogic { get; set; }
        public IEventPublishLogicClient EventPublishClient { get; set; }
        public ITransferInterfaceLogicClient SiraTransferClient { get; set; }
        public NotificationLogicController NotificationLogic { get; set; }
        public ClassificationDataLogicController ClassificationLogic { get; set; }
        public ProductLogicController ProductLogic { get; set; }
        public PaymentLogicController PaymentLogic { get; set; }
        public ShoppingCartLogicController ShoppingCartLogic { get; set; }
        public InvoiceLogicController InvoiceLogic { get; set; }
        public TransactionOrderLogicController TransactionOrderLogic { get; set; }

        public async Task ExpireTemporaryLoginsAsync(int days, int hours, int minutes)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                foreach (var uao in scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Where(x => x.UserAccount.IsTemporaryAccount && x.PinCreated != null))
                {
                    var testDate = uao.PinCreated.Value.AddDays(days).AddHours(hours).AddMinutes(minutes);
                    if (testDate < DateTime.Now) await ExpireUserAccountOrganisationAsync(uao.UserAccountOrganisationID);
                }

                await scope.SaveChangesAsync();
            }
        }

        public async Task ExpireUserAccountOrganisationAsync(Guid uaoID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == uaoID);
                if (!uao.UserAccount.IsTemporaryAccount) throw new Exception("Cannot expire an active account.");

                uao.UserAccount.IsLoginAllowed = false;
                uao.PinCode = null;

                if (uao.Organisation != null)
                {
                    var verifiedStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Verified.GetStringValue());
                    var status = uao.Organisation.OrganisationStatus.OrderByDescending(s => s.StatusChangedOn).FirstOrDefault();
                    if (status != null && status.StatusTypeValueID == verifiedStatus.StatusTypeValueID)
                        await ExpireOrganisationAsync(uao.OrganisationID);
                }
                await scope.SaveChangesAsync();
            }
        }

        public async Task<bool> IsOrganisationInSystem(Guid? orgID, string regulatorNumber)
        {
            Ensure.That(regulatorNumber).IsNotNullOrWhiteSpace();

            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var rejectedStatusName = ProfessionalOrganisationStatusEnum.Rejected.GetStringValue();
                var unverifiedStatusName = ProfessionalOrganisationStatusEnum.Unverified.GetStringValue();
                // TODO ZM: Consider the change of database collation to do Case Insensitive string comparison
                var query = scope.DbContexts.Get<TargetFrameworkEntities>().VOrganisationWithStatusAndAdmins
                    .Where(item =>
                        item.RegulatorNumber.ToLower() == regulatorNumber.Trim().ToLower() &&
                        item.StatusValueName != rejectedStatusName &&
                        item.StatusValueName != unverifiedStatusName);
                if (orgID.HasValue) query = query.Where(x => x.OrganisationID != orgID.Value);
                return query.Count() > 0;
            }
        }

        public async Task RejectOrganisationAsync(RejectCompanyDTO dto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var unverified = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Unverified.GetStringValue()).StatusTypeValueID;
                var verified = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Verified.GetStringValue()).StatusTypeValueID;
                var org = scope.DbContexts.Get<TargetFrameworkEntities>().VOrganisationWithStatusAndAdmins.Single(c => c.OrganisationID == dto.OrganisationId);
                if (org.StatusTypeValueID != unverified && org.StatusTypeValueID != verified) throw new Exception(string.Format("Cannot reject a company of status '{0}'. Please go back and try again.", org.StatusValueName));

                await AddOrganisationStatusAsync(dto.OrganisationId, StatusTypeEnum.ProfessionalOrganisation, ProfessionalOrganisationStatusEnum.Rejected, dto.Reason, dto.Notes);

                UserAccount ua = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Single(x => x.Email == org.OrganisationAdminEmail);
                ua.Username = ua.Email = string.Format("Rejected {0}: {1}", DateTime.Now, org.OrganisationAdminEmail);
                await scope.SaveChangesAsync();
            }
        }

        public async Task UnverifyOrganisationAsync(RejectCompanyDTO dto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var verified = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Verified.GetStringValue()).StatusTypeValueID;
                var org = scope.DbContexts.Get<TargetFrameworkEntities>().VOrganisationWithStatusAndAdmins.Single(c => c.OrganisationID == dto.OrganisationId);
                if (org.StatusTypeValueID != verified) throw new Exception(string.Format("Cannot unverify a company of status '{0}'. Please go back and try again.", org.StatusValueName));

                await AddOrganisationStatusAsync(dto.OrganisationId, StatusTypeEnum.ProfessionalOrganisation, ProfessionalOrganisationStatusEnum.Unverified, dto.Reason, dto.Notes);
                await scope.SaveChangesAsync();
            }
        }

        public async Task ActivateOrganisationAsync(Guid organisationID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var checkStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Verified.GetStringValue());
                var org = scope.DbContexts.Get<TargetFrameworkEntities>().VOrganisationWithStatusAndAdmins.First(c => c.OrganisationID == organisationID);
                if (org.StatusTypeValueID != checkStatus.StatusTypeValueID) throw new Exception(string.Format("Cannot activate a company of status '{0}'. Please go back and try again.", org.StatusValueName));

                await AddOrganisationStatusAsync(organisationID, StatusTypeEnum.ProfessionalOrganisation, ProfessionalOrganisationStatusEnum.Active, null, null);

                await scope.SaveChangesAsync();
            }
        }

        public List<Bec.TargetFramework.Entities.VOrganisationWithStatusAndAdminDTO> GetCompanies(ProfessionalOrganisationStatusEnum orgStatus)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var status = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), orgStatus.GetStringValue());
                var ret = scope.DbContexts.Get<TargetFrameworkEntities>().VOrganisationWithStatusAndAdmins.Where(item => item.StatusTypeValueID == status.StatusTypeValueID).ToDtos();
                foreach (var item in ret)
                {
                    if (item.OrganisationRecommendationSourceID.HasValue)
                        item.Referrer = ((OrganisationRecommendationSource)item.OrganisationRecommendationSourceID.Value).GetStringValue();
                    item.TradingNames = scope.DbContexts.Get<TargetFrameworkEntities>().Lenders.Where(x => x.OrganisationID == item.OrganisationID && x.Name != item.Name).Select(x => x.Name).ToList();
                    if (item.BrokerType.HasValue) item.BrokerTypeDescription = ((BrokerTypeEnum)item.BrokerType).GetStringValue();
                    if (item.BrokerBusinessType.HasValue) item.BrokerBusinessTypeDescription = ((BrokerBusinessTypeEnum)item.BrokerBusinessType).GetStringValue();
                    }
                return ret;
            }
        }

        public async Task<Guid> AddNewUnverifiedOrganisationAndAdministratorAsync(Bec.TargetFramework.Entities.AddCompanyDTO dto)
        {
            DefaultOrganisationDTO defaultOrganisation = null;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                // get relevant organisation template
                var orgType = dto.OrganisationType.GetStringValue();
                defaultOrganisation = scope.DbContexts.Get<TargetFrameworkEntities>().DefaultOrganisations.Single(s => s.Name.Equals(orgType)).ToDto();
            }
            Ensure.That(defaultOrganisation).IsNotNull();

            // add organisation
            var organisationID = (await AddOrganisationAsync(defaultOrganisation, dto)).Value;

            var userContactDto = new ContactDTO
            {
                Telephone1 = dto.OrganisationAdminTelephone,
                FirstName = dto.OrganisationAdminFirstName,
                LastName = dto.OrganisationAdminLastName,
                EmailAddress1 = dto.OrganisationAdminEmail,
                Salutation = dto.OrganisationAdminSalutation,
                MobileNumber1 = string.Empty,
                CreatedBy = "System"
            };
            var addNewUserDto = new AddNewUserToOrganisationDTO
            {
                OrganisationID = organisationID,
                ContactDTO = userContactDto,
                UserType = UserTypeEnum.OrganisationAdministrator,
                AddDefaultRoles = true,
                SafeSendGroups = Enumerable.Empty<Guid>(),
                Roles = Enumerable.Empty<Guid>()
            };

            var uaoDto = await AddNewUserToOrganisationAsync(addNewUserDto);

            await UserLogic.LockOrUnlockUserAsync(uaoDto.UserID, true);

            return organisationID;
        }

        public async Task<UserAccountOrganisationDTO> AddNewUserToOrganisationAsync(AddNewUserToOrganisationDTO dto)
        {
            string orgTypeName;
            UserAccountOrganisationDTO uaoDto;
            Guid? userOrgID;
            var ua = await UserLogic.CreateAccountAsync(dto.ContactDTO.EmailAddress1, RandomPasswordGenerator.Generate(10), dto.ContactDTO.EmailAddress1, dto.ContactDTO.MobileNumber1, Guid.NewGuid());
            Ensure.That(ua).IsNotNull();

            using (var scope = DbContextScopeFactory.Create())
            {
                orgTypeName = scope.DbContexts.Get<TargetFrameworkEntities>().Organisations.Single(x => x.OrganisationID == dto.OrganisationID).OrganisationType.Name;

                // add user to organisation
                userOrgID = scope.DbContexts.Get<TargetFrameworkEntities>().FnAddUserToOrganisation(ua.ID, dto.OrganisationID, dto.UserType.GetGuidValue(), dto.OrganisationID, dto.AddDefaultRoles);

                Ensure.That(userOrgID).IsNotNull();

                foreach (var roleID in dto.Roles)
                {
                    scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisationRoles.Add(new UserAccountOrganisationRole
                    {
                        UserAccountOrganisationID = userOrgID.Value,
                        OrganisationRoleID = roleID
                    });
                }

                foreach (var safeSendGroupID in dto.SafeSendGroups)
                {
                    scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisationSafeSendGroups.Add(new UserAccountOrganisationSafeSendGroup
                    {
                        UserAccountOrganisationID = userOrgID.Value,
                        SafeSendGroupID = safeSendGroupID
                    });
                }

                var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == userOrgID.Value);

                // create or update contact
                if (dto.ContactDTO.ContactID == Guid.Empty)
                {
                    var contact = new Contact
                    {
                        ContactID = Guid.NewGuid(),
                        ParentID = userOrgID.Value,
                        ContactName = "",
                        IsPrimaryContact = true,
                        Telephone1 = dto.ContactDTO.Telephone1,
                        FirstName = dto.ContactDTO.FirstName,
                        LastName = dto.ContactDTO.LastName,
                        EmailAddress1 = dto.ContactDTO.EmailAddress1,
                        Salutation = dto.ContactDTO.Salutation,
                        BirthDate = dto.ContactDTO.BirthDate,
                        CreatedBy = UserNameService.UserName
                    };
                    scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Add(contact);
                    uao.PrimaryContactID = contact.ContactID;
                }
                else
                {
                    var existingUserContact = scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Single(c => c.ContactID == dto.ContactDTO.ContactID);
                    existingUserContact.ParentID = userOrgID.Value;

                    uao.PrimaryContactID = existingUserContact.ContactID;
                }
                uaoDto = uao.ToDto();
                await scope.SaveChangesAsync();
            }

            //create Ts & Cs notification
            switch (orgTypeName)
            {
                case "Professional":
                    if (dto.UserType == UserTypeEnum.OrganisationAdministrator) await CreateTsAndCsNotificationAsync(userOrgID.Value, NotificationConstructEnum.TcFirmConveyancing);
                    break;
                case "Personal":
                    await CreateTsAndCsNotificationAsync(userOrgID.Value, NotificationConstructEnum.TcPublic);
                    break;
                case "MortgageBroker":
                    if (dto.UserType == UserTypeEnum.OrganisationAdministrator) await CreateTsAndCsNotificationAsync(userOrgID.Value, NotificationConstructEnum.TcMortgageBroker);
                    break;
                case "Lender":
                    if (dto.UserType == UserTypeEnum.OrganisationAdministrator) await CreateTsAndCsNotificationAsync(userOrgID.Value, NotificationConstructEnum.TcLender);
                    break;
            }

            return uaoDto;
        }

        public async Task AddPersonalDetails(Guid uaoId, AddPersonalDetailsDTO addPersonalDetailsDto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var existingUserContact = scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Single(c => c.ParentID == uaoId);
                existingUserContact.BirthDate = addPersonalDetailsDto.BirthDate;

                var address = new Address
                {
                    AddressID = Guid.NewGuid(),
                    ParentID = existingUserContact.ContactID,
                    Line1 = addPersonalDetailsDto.Line1,
                    Line2 = addPersonalDetailsDto.Line2,
                    Town = addPersonalDetailsDto.Town,
                    County = addPersonalDetailsDto.County,
                    PostalCode = addPersonalDetailsDto.PostalCode,
                    AddressTypeID = AddressTypeIDEnum.Home.GetIntValue(),
                    Name = String.Empty,
                    IsPrimaryAddress = true,
                    CreatedBy = UserNameService.UserName
                };
                scope.DbContexts.Get<TargetFrameworkEntities>().Addresses.Add(address);

                await scope.SaveChangesAsync();
            }
        }

        public async Task<bool> RequiresPersonalDetails(Guid uaoId)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var requiresPersonalDetails = false;

                var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Single(c => c.UserAccountOrganisationID == uaoId);
                Ensure.That(uao).IsNotNull();

                if (uao.Organisation.OrganisationType.Name == "Professional" && uao.UserTypeID == UserTypeEnum.OrganisationAdministrator.GetGuidValue())
                {
                    var existingUserContact = scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.FirstOrDefault(c => c.ParentID == uaoId);
                    Ensure.That(existingUserContact).IsNotNull();
                    var existingAddress = scope.DbContexts.Get<TargetFrameworkEntities>().Addresses.FirstOrDefault(c => c.ParentID == existingUserContact.ContactID);

                    requiresPersonalDetails = existingAddress == null;
                }

                return requiresPersonalDetails;
            }
        }

        public async Task CreateTsAndCsNotificationAsync(Guid userOrgID, NotificationConstructEnum type)
        {
            var nc = NotificationLogic.GetLatestNotificationConstructIdFromName(type.GetStringValue());

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

        private async Task<Guid?> AddOrganisationAsync(DefaultOrganisationDTO defaultOrg, Bec.TargetFramework.Entities.AddCompanyDTO dto)
        {
            Guid? organisationID = null;

            // create company 
            using (var scope = DbContextScopeFactory.Create())
            {
                // create organisation from do template using stored procedure
                organisationID = scope.DbContexts.Get<TargetFrameworkEntities>().FnCreateOrganisationFromDefault(
                    dto.OrganisationType.GetIntValue(),
                    defaultOrg.DefaultOrganisationID,
                    defaultOrg.DefaultOrganisationVersionNumber,
                    dto.CompanyName,
                    dto.CompanyName,
                    "",
                    UserNameService.UserName,
                    dto.OrganisationRecommendationSource.GetIntValueOrNull(),
                    dto.BrokerType.GetIntValueOrNull(),
                    dto.BrokerBusinessType.GetIntValueOrNull());

                // ensure guid has a value
                Ensure.That(organisationID).IsNotNull();
                // TODO ZM: consider validation pattern for dtos
                // Maybe trimming all strings in EF will be a solution http://romiller.com/2014/10/20/ef6-1workaround-trailing-blanks-issue-in-string-joins/

                // create contact for organisation
                var contact = new Contact
                {
                    ContactID = Guid.NewGuid(),
                    ParentID = organisationID.Value,
                    ContactName = "",
                    IsPrimaryContact = true,
                    CreatedBy = UserNameService.UserName,
                    Telephone1 = dto.OrganisationAdminTelephone,
                    FirstName = dto.OrganisationAdminFirstName,
                    LastName = dto.OrganisationAdminLastName,
                    EmailAddress1 = dto.OrganisationAdminEmail,
                    Salutation = dto.OrganisationAdminSalutation,
                };

                scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Add(contact);

                if (dto.OrganisationType == OrganisationTypeEnum.Professional)
                {
                    Ensure.That(dto.RegulatorNumber).IsNotNull();
                    // contact regulator
                    var contactRegulator = new ContactRegulator
                    {
                        ContactID = contact.ContactID,
                        RegulatorName = dto.Regulator,
                        RegulatorOtherName = dto.RegulatorOther,
                        RegulatorNumber = dto.RegulatorNumber.Trim()
                    };

                    scope.DbContexts.Get<TargetFrameworkEntities>().ContactRegulators.Add(contactRegulator);
                }

                if (dto.OrganisationType == OrganisationTypeEnum.Lender)
                {
                    var lendersToAdd = dto.TradingNames
                        .Select(x => x.Trim())
                        .Concat(new string[] { dto.CompanyName })
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Distinct();
                    foreach (var tn in lendersToAdd)
                    {
                        var lender = scope.DbContexts.Get<TargetFrameworkEntities>().Lenders.FirstOrDefault(x => x.Name == tn);
                        if (lender == null)
                            scope.DbContexts.Get<TargetFrameworkEntities>().Lenders.Add(new Lender { LenderID = Guid.NewGuid(), Name = tn, OrganisationID = organisationID.Value });
                        else
                            lender.OrganisationID = organisationID.Value;
                    }
                }
                else
                {
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
                        CreatedBy = UserNameService.UserName
                    };
                    scope.DbContexts.Get<TargetFrameworkEntities>().Addresses.Add(address);
                }
                await scope.SaveChangesAsync();
            }

            return organisationID;
        }

        public Guid? GetTemporaryOrganisationBranchID()
        {
            int temporaryOrgTypeID = OrganisationTypeEnum.Temporary.GetIntValue();

            Guid? orgBranchID = null;

            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                // get orgID
                var organisationID = scope.DbContexts.Get<TargetFrameworkEntities>().Organisations.Single(s => !s.ParentOrganisationID.HasValue && s.OrganisationTypeID == temporaryOrgTypeID).OrganisationID;
                orgBranchID = scope.DbContexts.Get<TargetFrameworkEntities>().Organisations.Single(s => s.ParentOrganisationID.HasValue && s.ParentOrganisationID == organisationID && s.IsBranch == true).OrganisationID;
            }

            return orgBranchID;
        }

        public VOrganisationDTO GetOrganisationDTO(Guid id)
        {
            Ensure.That(id).IsNot(Guid.Empty);

            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().VOrganisations.Single(item => item.OrganisationID == id).ToDto();
            }
        }

        public VOrganisationWithStatusAndAdminDTO GetOrganisationWithStatusAndAdmin(Guid id)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().VOrganisationWithStatusAndAdmins.Single(item => item.OrganisationID == id).ToDto();
            }
        }

        internal async Task ExpireOrganisationAsync(Guid organisationID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                Logger.Trace("Expiring organisation" + organisationID.ToString());
                await AddOrganisationStatusAsync(organisationID, StatusTypeEnum.ProfessionalOrganisation, ProfessionalOrganisationStatusEnum.Expired, null, "Automatic expiry");
                await scope.SaveChangesAsync();
            }
        }

        public async Task AddOrganisationStatusAsync(Guid orgID, StatusTypeEnum enumType, ProfessionalOrganisationStatusEnum status, int? reason, string notes)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var s = LogicHelper.GetStatusType(scope, enumType.GetStringValue(), status.GetStringValue());
                scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationStatus.Add(new OrganisationStatus
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
                await scope.SaveChangesAsync();
            }
        }

        public bool CheckDuplicateUserSmsTransaction(Guid orgID, string email, SmsTransactionDTO dto)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var existingUser = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.FirstOrDefault(x => x.UserAccount.Email.ToLower() == email.ToLower());
                if (existingUser != null && dto.Address != null)
                {
                    var address = scope.DbContexts.Get<TargetFrameworkEntities>().Addresses.FirstOrDefault(x =>
                            x.Line1 == dto.Address.Line1 &&
                            x.Line2 == dto.Address.Line2 &&
                            x.Town == dto.Address.Town &&
                            x.County == dto.Address.County &&
                            x.PostalCode == dto.Address.PostalCode);
                    if (address != null)
                    {
                        var buyerTypeID = UserAccountOrganisationTransactionType.Buyer.GetIntValue();
                        var tx = scope.DbContexts.Get<TargetFrameworkEntities>().SmsUserAccountOrganisationTransactions.FirstOrDefault(x =>
                            x.SmsTransaction.OrganisationID == orgID &&
                            x.SmsTransaction.AddressID == address.AddressID &&
                            x.UserAccountOrganisationID == existingUser.UserAccountOrganisationID &&
                            x.SmsUserAccountOrganisationTransactionTypeID == buyerTypeID);
                        if (tx != null) return true;
                    }
                }
            }
            return false;
        }


        public IEnumerable<Guid> GetSmsTransactionRelatedPartyUaoIds(Guid txID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().SmsUserAccountOrganisationTransactions
                    .Where(x => x.SmsTransactionID == txID)
                    .Select(x => x.UserAccountOrganisationID)
                    .ToList();
            }
        }

        private async Task<Guid> AddNewContact(Guid uaoId, string salutation, string firstName, string lastName, string email, string phoneNumber, DateTime birthDate)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.SingleOrDefault(x => x.UserAccountOrganisationID == uaoId);
                Ensure.That(uao).IsNotNull();

                var primaryContact = scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Where(c => c.ParentID == uaoId && c.IsPrimaryContact == true).FirstOrDefault();
                birthDate = primaryContact.BirthDate ?? birthDate;

                var contact = new Contact
                {
                    ContactID = Guid.NewGuid(),
                    ParentID = uaoId,
                    ContactName = "",
                    Salutation = salutation,
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress1 = email,
                    BirthDate = birthDate,
                    MobileNumber1 = phoneNumber,
                    CreatedBy = UserNameService.UserName
                };
                scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Add(contact);
                await scope.SaveChangesAsync();
                return contact.ContactID;
            }
        }

        public async Task<Guid> AddSmsTransaction(AddSmsTransactionDTO dto, Guid orgID, Guid uaoID)
        {
            var transactionId = await SaveSmsTransaction(dto.SmsTransactionDTO, orgID);
            
            var assignSmsClientToTransactionDto = new AssignSmsClientToTransactionDTO
            {
                Salutation = dto.Salutation, 
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                BirthDate = dto.BirthDate.Value,
                TransactionID = transactionId,
                AssigningByOrganisationID = orgID,
                UserAccountOrganisationTransactionType = UserAccountOrganisationTransactionType.Buyer,
                RegisteredHomeAddress = dto.RegisteredHomeAddressDTO,
                SmsSrcFundsBankAccounts = dto.SmsSrcFundsBankAccounts
            };
            await AssignSmsClientToTransaction(assignSmsClientToTransactionDto);
            return transactionId;
        }

        private async Task<Guid> SaveSmsTransaction(SmsTransactionDTO dto, Guid orgID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var txID = Guid.NewGuid();

                var address = scope.DbContexts.Get<TargetFrameworkEntities>().Addresses.FirstOrDefault(x =>
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
                    address.Name = string.Empty;
                    address.ParentID = txID;

                    // hack: until the address get resolved and will come back to be mandatory
                    if (address.Line1 == null)
                    {
                        address.Line1 = string.Empty;
                    }

                    scope.DbContexts.Get<TargetFrameworkEntities>().Addresses.Add(address);
                }

                SmsTransaction tx = new SmsTransaction
                {
                    SmsTransactionID = txID,
                    Address = address,
                    OrganisationID = orgID,
                    Reference = dto.Reference,
                    Price = dto.Price,
                    LenderName = dto.LenderName,
                    MortgageApplicationNumber = dto.MortgageApplicationNumber,
                    IsProductAdvised = dto.IsProductAdvised,
                    ProductAdvisedOn = dto.IsProductAdvised ? DateTime.Now : (DateTime?)null,
                    CreatedOn = DateTime.Now,
                    CreatedBy = UserNameService.UserName
                };

                scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.Add(tx);

                await scope.SaveChangesAsync();
                return tx.SmsTransactionID;
            }
        }

        public IEnumerable<SmsTransactionPendingUpdateCountDTO> SmsTransactionPendingUpdateCount(IEnumerable<Guid> ids)
        {
            var activityTypeID = ActivityType.SmsTransaction.GetIntValue();
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().FieldUpdates
                    .Where(x => x.ActivityType == activityTypeID && ids.Contains(x.ActivityID))
                    .GroupBy(x => x.ActivityID)
                    .Select(x => new SmsTransactionPendingUpdateCountDTO {SmsTransactionID = x.Key, PendingChangesCount = x.Count() }).ToList();
            }
        }

        public async Task ReplaceSrcFundsBankAccounts(IEnumerable<SmsSrcFundsBankAccountDTO> srcFundsBankAccounts, Guid uaoTxID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var accounts = scope.DbContexts.Get<TargetFrameworkEntities>().SmsSrcFundsBankAccounts.Where(x => x.SmsUserAccountOrganisationTransactionID == uaoTxID);
                scope.DbContexts.Get<TargetFrameworkEntities>().SmsSrcFundsBankAccounts.RemoveRange(accounts);
                await AddSrcFundsBankAccounts(srcFundsBankAccounts, uaoTxID);
                await scope.SaveChangesAsync();
            }
        }

        private async Task AddSrcFundsBankAccounts(IEnumerable<SmsSrcFundsBankAccountDTO> srcFundsBankAccounts, Guid uaoTxID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var bankAccountsToStore = srcFundsBankAccounts.Where(x => !string.IsNullOrWhiteSpace(x.AccountNumber) && !string.IsNullOrWhiteSpace(x.SortCode));
                foreach (var bankAccount in bankAccountsToStore)
                {
                    bankAccount.SmsSrcFundsBankAccountID = Guid.NewGuid();
                    bankAccount.SmsUserAccountOrganisationTransactionID = uaoTxID;
                    scope.DbContexts.Get<TargetFrameworkEntities>().SmsSrcFundsBankAccounts.Add(bankAccount.ToEntity());
                }
                await scope.SaveChangesAsync();
            }
        }

        public async Task AdviseProduct(Guid txID, Guid orgID)
        {
            var requiresNotification = false;
            using (var scope = DbContextScopeFactory.Create())
            {
                var transaction = scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions
                    .SingleOrDefault(s =>
                        s.SmsTransactionID == txID &&
                        s.OrganisationID == orgID &&
                        !s.IsProductAdvised);
                Ensure.That(transaction).IsNotNull();
                transaction.IsProductAdvised = true;
                transaction.ProductAdvisedOn = DateTime.Now;
                transaction.ModifiedOn = DateTime.Now;
                transaction.ModifiedBy = UserNameService.UserName;
                await scope.SaveChangesAsync();
                requiresNotification = transaction.ProductDeclinedOn.HasValue;
            }

            if (requiresNotification)
            {
                await PublishProductAdvisedNotification(txID, orgID);
            }
        }

        private async Task PublishProductAdvisedNotification(Guid txID, Guid orgID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var organisation = scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationDetails.FirstOrDefault(x => x.OrganisationID == orgID);
                Ensure.That(organisation).IsNotNull();
                var notificationDto = new ProductAdvisedNotificationDTO
                {
                    TransactionID = txID,
                    CompanyName = organisation.Name
                };
                string payLoad = JsonHelper.SerializeData(new object[] { notificationDto });
                var dto = new EventPayloadDTO
                {
                    EventName = NotificationConstructEnum.ProductAdvised.GetStringValue(),
                    EventSource = AppDomain.CurrentDomain.FriendlyName,
                    EventReference = "0005",
                    PayloadAsJson = payLoad
                };
                await EventPublishClient.PublishEventAsync(dto);
            }
        }

        public async Task<CartPricingDTO> EnsureCart(Guid txID, Guid uaoID, PaymentCardTypeIDEnum cardTypeEnum = PaymentCardTypeIDEnum.Visa_Credit, PaymentMethodTypeIDEnum paymentTypeEnum = PaymentMethodTypeIDEnum.Credit_Card)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var tx = scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.Where(x => x.SmsTransactionID == txID).FirstOrDefault();
                Ensure.That(tx).IsNotNull();
                if (tx.ShoppingCartID.HasValue) return CartPricingProcessor.CalculateCartPrice(scope, tx.ShoppingCartID.Value);
            }
            
            var product = ProductLogic.GetBankAccountCheckProduct();
            Ensure.That(product).IsNotNull();
            var cartID = (await ShoppingCartLogic.CreateShoppingCartAsync(uaoID, cardTypeEnum, paymentTypeEnum)).ShoppingCartID;
            await ShoppingCartLogic.AddProductToShoppingCartAsync(cartID, product.ProductID, product.ProductVersionID, 1);
            
            using (var scope = DbContextScopeFactory.Create())
            {
                var tx = scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.Where(x => x.SmsTransactionID == txID).FirstOrDefault();
                tx.ShoppingCartID = cartID;
                await scope.SaveChangesAsync();
                return CartPricingProcessor.CalculateCartPrice(scope, cartID);
            }
        }

        public async Task<TransactionOrderPaymentDTO> PurchaseSafeBuyerProduct(OrderRequestDTO orderRequest, Guid smsTransactionID, PaymentCardTypeIDEnum cardType, PaymentMethodTypeIDEnum methodType, bool free)
        {
            Guid? cartID = null;
            using (var scope = DbContextScopeFactory.Create())
            {
                var tx = scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.Where(x => x.SmsTransactionID == smsTransactionID).FirstOrDefault();
                Ensure.That(tx).IsNotNull();
                tx.ShoppingCart.PaymentCardTypeID = cardType.GetIntValue();
                tx.ShoppingCart.PaymentMethodTypeID = methodType.GetIntValue();
                await scope.SaveChangesAsync();
                cartID = tx.ShoppingCartID;
            }
            Ensure.That(cartID).IsNotNull();

            var invoice = await InvoiceLogic.CreateAndSaveInvoiceFromShoppingCartAsync(cartID.Value, "Safe Buyer");
            var transactionOrder = await TransactionOrderLogic.CreateAndSaveTransactionOrderFromShoppingCartDTO(invoice.InvoiceID, TransactionTypeIDEnum.Payment);

            if (free)
            {
                await UpdateTransactionInvoiceID(smsTransactionID, invoice.InvoiceID);
                return new TransactionOrderPaymentDTO { IsPaymentSuccessful = true };
            }
            else
            {
            orderRequest.TransactionOrderID = transactionOrder.TransactionOrderID;
            orderRequest.PaymentChargeType = PaymentChargeTypeEnum.Sale;
            var payment = await PaymentLogic.ProcessPaymentTransaction(orderRequest);
            if (payment.IsPaymentSuccessful)
            {
                await UpdateTransactionInvoiceID(smsTransactionID, invoice.InvoiceID);
            }
                return payment;
        }
        }

        private async Task UpdateTransactionInvoiceID(Guid txID, Guid invoiceID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var smsTransaction = scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.SingleOrDefault(x => x.SmsTransactionID == txID);
                Ensure.That(smsTransaction).IsNotNull();
                smsTransaction.InvoiceID = invoiceID;
                smsTransaction.ModifiedOn = DateTime.Now;
                smsTransaction.ModifiedBy = UserNameService.UserName;
                await scope.SaveChangesAsync();
            }
        }

        private async Task<Address> CompareAndAddAddressIfChanged(Address address, AddressDTO addressDTO, Guid parentID)
        {
            if (address != null &&
                address.Line1 == addressDTO.Line1 &&
                address.Line2 == addressDTO.Line2 &&
                address.Town == addressDTO.Town &&
                address.County == addressDTO.County &&
                address.PostalCode == addressDTO.PostalCode)
                return address;

            if (string.IsNullOrWhiteSpace(addressDTO.Line1))
            {
                return null;
            }
            using (var scope = DbContextScopeFactory.Create())
            {
                var newAdd = new Address
                {
                    AddressID = Guid.NewGuid(),
                    ParentID = parentID,
                    Line1 = addressDTO.Line1,
                    Line2 = addressDTO.Line2,
                    Town = addressDTO.Town,
                    County = addressDTO.County,
                    PostalCode = addressDTO.PostalCode,
                    AddressTypeID = AddressTypeIDEnum.Work.GetIntValue(),
                    Name = string.Empty,
                    IsPrimaryAddress = true,
                    CreatedOn = DateTime.Now,
                    CreatedBy = UserNameService.UserName
                };

                scope.DbContexts.Get<TargetFrameworkEntities>().Addresses.Add(newAdd);
                await scope.SaveChangesAsync();
                return newAdd;
            }
        }

        public async Task AssignSmsClientToTransaction(AssignSmsClientToTransactionDTO assignSmsClientToTransactionDTO)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var transaction = scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.FirstOrDefault(x => x.SmsTransactionID == assignSmsClientToTransactionDTO.TransactionID);
                Ensure.That(transaction).IsNotNull();
                if (transaction.OrganisationID != assignSmsClientToTransactionDTO.AssigningByOrganisationID)
                {
                    Logger.Fatal("The organisation with id: {0} is trying to assign sms client to the transaction with id: {1}",
                        assignSmsClientToTransactionDTO.AssigningByOrganisationID, assignSmsClientToTransactionDTO.TransactionID);
                    throw new InvalidOperationException("The transaction does not belong to the current user's organisation.");
                }
            }

            var res = await AddSmsClient(
                assignSmsClientToTransactionDTO.Salutation,
                assignSmsClientToTransactionDTO.FirstName,
                assignSmsClientToTransactionDTO.LastName,
                assignSmsClientToTransactionDTO.Email,
                assignSmsClientToTransactionDTO.PhoneNumber,
                assignSmsClientToTransactionDTO.BirthDate);

            var buyerUaoID = res.Item1;
            var contactId = res.Item2;

            using (var scope = DbContextScopeFactory.Create())
            {
                var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.FirstOrDefault(x => x.UserAccountOrganisationID == buyerUaoID);
                Ensure.That(uao).IsNotNull();

                var uaoTxID = Guid.NewGuid();
                var uaot = new SmsUserAccountOrganisationTransaction
                {
                    SmsUserAccountOrganisationTransactionID = uaoTxID,
                    SmsTransactionID = assignSmsClientToTransactionDTO.TransactionID,
                    UserAccountOrganisationID = buyerUaoID,
                    SmsUserAccountOrganisationTransactionTypeID = assignSmsClientToTransactionDTO.UserAccountOrganisationTransactionType.GetIntValue(),
                    Address = await CompareAndAddAddressIfChanged(null, assignSmsClientToTransactionDTO.RegisteredHomeAddress, uaoTxID),
                    ContactID = contactId,
                    CreatedBy = UserNameService.UserName
                };
                scope.DbContexts.Get<TargetFrameworkEntities>().SmsUserAccountOrganisationTransactions.Add(uaot);

                await AddSrcFundsBankAccounts(assignSmsClientToTransactionDTO.SmsSrcFundsBankAccounts, uaoTxID);

                await scope.SaveChangesAsync();
            }
        }

        private async Task<Tuple<Guid, Guid>> AddSmsClient(string salutation, string firstName, string lastName, string email, string phoneNumber, DateTime birthDate)
        {
            //add becky personal org & user
            Guid? existingUaoId = null;
            DefaultOrganisationDTO defaultOrganisation;
            var personalOrgTypeId = OrganisationTypeEnum.Personal.GetIntValue();

            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                // get professional default organisation template
                defaultOrganisation = scope.DbContexts.Get<TargetFrameworkEntities>().DefaultOrganisations.Single(s => s.Name.Equals("Personal Organisation")).ToDto();
                Ensure.That(defaultOrganisation).IsNotNull();

                var existingUao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.FirstOrDefault(x => x.UserAccount.Email.ToLower() == email.ToLower());
                if (existingUao != null)
                {
                    if (existingUao.Organisation.OrganisationTypeID != personalOrgTypeId) throw new Exception("The specified email belongs to a system user; this is not currently supported.");
                    existingUaoId = existingUao.UserAccountOrganisationID;
                }
            }

            if (existingUaoId != null)
            {
                var contactID = await AddNewContact(existingUaoId.Value, salutation, firstName, lastName, email, phoneNumber, birthDate);
                return Tuple.Create(existingUaoId.Value, contactID);
            }
            else
            {
                var companyDTO = new AddCompanyDTO
                {
                    OrganisationType = OrganisationTypeEnum.Personal,
                    CompanyName = "Personal Organisation",
                    Line1 = "-",
                    RegulatorNumber = "-",
                    OrganisationAdminFirstName = firstName,
                    OrganisationAdminLastName = lastName,
                    OrganisationAdminEmail = email
                };
                var contactDTO = new ContactDTO
                {
                    Salutation = salutation,
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress1 = email,
                    BirthDate = birthDate,
                    MobileNumber1 = phoneNumber,
                    CreatedBy = UserNameService.UserName
                };
                var personalOrgID = await AddOrganisationAsync(defaultOrganisation, companyDTO);
                var addNewUserDto = new AddNewUserToOrganisationDTO
                {
                    OrganisationID = personalOrgID.Value,
                    ContactDTO = contactDTO,
                    UserType = UserTypeEnum.User,
                    AddDefaultRoles = true,
                    SafeSendGroups = Enumerable.Empty<Guid>(),
                    Roles = Enumerable.Empty<Guid>()
                };
                var buyerUaoDto = await AddNewUserToOrganisationAsync(addNewUserDto);
                await UserLogic.GeneratePinAsync(buyerUaoDto.UserAccountOrganisationID, false, false, true);

                return Tuple.Create(buyerUaoDto.UserAccountOrganisationID, buyerUaoDto.PrimaryContactID.Value);
            }
        }

        public async Task EditBuyerParty(EditBuyerPartyDTO editBuyerPartyDto)
        {
            if (!await UserLogic.CanEmailBeUsedAsProfessional(editBuyerPartyDto.Dto.UserAccountOrganisation.UserAccount.Email, editBuyerPartyDto.UaoID))
            {
                throw new InvalidOperationException("The email cannot be changed.");
            }

            using (var scope = DbContextScopeFactory.Create())
            {
                var storedUaotx = scope.DbContexts.Get<TargetFrameworkEntities>().SmsUserAccountOrganisationTransactions.Single(x => x.SmsTransactionID == editBuyerPartyDto.TxID && x.UserAccountOrganisationID == editBuyerPartyDto.UaoID);
                
                storedUaotx.Contact.Salutation = editBuyerPartyDto.Dto.Contact.Salutation;
                storedUaotx.Contact.FirstName = editBuyerPartyDto.Dto.Contact.FirstName;
                storedUaotx.Contact.LastName = editBuyerPartyDto.Dto.Contact.LastName;
                storedUaotx.Contact.BirthDate = editBuyerPartyDto.Dto.Contact.BirthDate;
                storedUaotx.UserAccountOrganisation.UserAccount.Email = editBuyerPartyDto.Dto.UserAccountOrganisation.UserAccount.Email;

                if (editBuyerPartyDto.Dto.Address.AreAllMandatoryFieldsSet())
                {
                    if (storedUaotx.Address == null)
                    {
                        storedUaotx.Address = new Address
                        {
                            AddressID = Guid.NewGuid(),
                            ParentID = storedUaotx.SmsUserAccountOrganisationTransactionID,
                            AddressTypeID = AddressTypeIDEnum.Home.GetIntValue(),
                            Name = string.Empty
                        };
                    }
                    storedUaotx.Address.Line1 = editBuyerPartyDto.Dto.Address.Line1;
                    storedUaotx.Address.Line2 = editBuyerPartyDto.Dto.Address.Line2;
                    storedUaotx.Address.Town = editBuyerPartyDto.Dto.Address.Town;
                    storedUaotx.Address.County = editBuyerPartyDto.Dto.Address.County;
                    storedUaotx.Address.PostalCode = editBuyerPartyDto.Dto.Address.PostalCode;
                }
                else if (storedUaotx.Address != null)
                {
                    storedUaotx.Address.IsDeleted = true;
                    storedUaotx.AddressID = null;
                }

                await RemovePendingUpdates(editBuyerPartyDto.FieldUpdates ?? Enumerable.Empty<FieldUpdateDTO>());

                var isUserRegistered = UserLogic.IsUserAccountRegistered(editBuyerPartyDto.UaoID);
                if (!isUserRegistered)
                {
                    await UserLogic.ChangeUsernameAndEmail(editBuyerPartyDto.UaoID, editBuyerPartyDto.Dto.UserAccountOrganisation.UserAccount.Email);
                }

                await scope.SaveChangesAsync();
            }
        }

        public async Task AddCreditAsync(Guid orgID, Guid transactionOrderID, Guid uaoID, decimal amount, long? rowVersion = null)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var creditType = ClassificationLogic.GetClassificationDataForTypeName("OrganisationLedgerType", "Credit Account");
                var account = scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationLedgerAccounts.Single(x =>
                    x.OrganisationID == orgID &&
                    x.LedgerAccountTypeID == creditType);
                if (rowVersion.HasValue && account.RowVersion != rowVersion) throw new Exception("The credit account has been updated by another user. Please go back and try again");

                account.OrganisationLedgerTransactions.Add(new OrganisationLedgerTransaction
                {
                    TransactionOrderID = transactionOrderID,
                    BalanceOn = DateTime.Now,
                    Amount = amount,
                    CreatedBy = uaoID
                });
                account.Balance += amount; //using rowversion for concurrency
                account.UpdatedOn = DateTime.Now;
                await scope.SaveChangesAsync();
            }
        }

        public async Task UpdateOrganisationDetails(VerifyCompanyDTO dto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var adminUao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.SingleOrDefault(x => x.UserAccountOrganisationID == dto.UaoID);
                Ensure.That(adminUao).IsNotNull();
                Ensure.That(adminUao.OrganisationID).Is(dto.OrganisationID);

                var org = scope.DbContexts.Get<TargetFrameworkEntities>().Organisations.Single(x => x.OrganisationID == dto.OrganisationID);
                // update the details of professional organisation only (Ana)
                if ((OrganisationTypeEnum)org.OrganisationTypeID != OrganisationTypeEnum.Professional)
                {
                    return;
                }

                var modifiedBy = UserNameService.UserName;
                var modifiedOn = DateTime.Now;
                Contact orgAdminContactDetails;
                if (dto.IsAuthorityDelegated)
                {
                    orgAdminContactDetails = new Contact
                    {
                        Salutation = dto.AuthorityDelegatedToSalutation,
                        FirstName = dto.AuthorityDelegatedToFirstName,
                        LastName = dto.AuthorityDelegatedToLastName,
                        EmailAddress1 = dto.AuthorityDelegatedToEmail
                    };
                    var authorityDelegatedByContact = new Contact
                    {
                        ContactID = Guid.NewGuid(),
                        ContactName = string.Empty,
                        Salutation = dto.Salutation,
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        EmailAddress1 = dto.Email,
                        Description = "Authority Delegated Contact",
                        ParentID = dto.OrganisationID,
                        Telephone1 = string.Empty,
                        MobileNumber1 = string.Empty,
                        CreatedOn = DateTime.Now,
                        CreatedBy = modifiedBy
                    };
                    scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Add(authorityDelegatedByContact);
                    org.AuthorityDelegatedByContactID = authorityDelegatedByContact.ContactID;
                }
                else
                {
                    orgAdminContactDetails = new Contact
                    {
                        Salutation = dto.Salutation,
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        EmailAddress1 = dto.Email
                    };
                    org.AuthorityDelegatedByContactID = null;
                }

                await UserLogic.ChangeUsernameAndEmail(adminUao.UserAccountOrganisationID, orgAdminContactDetails.EmailAddress1);

                org.FilesPerMonth = dto.FilesPerMonth ?? 0;
                org.ModifiedBy = modifiedBy;
                org.ModifiedOn = modifiedOn;
                var detail = org.OrganisationDetails.FirstOrDefault();
                if (detail != null) detail.Name = dto.OrganisationName;

                var orgContact = scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.SingleOrDefault(c => c.ParentID == dto.OrganisationID && c.IsPrimaryContact);
                Ensure.That(orgContact).IsNotNull();
                orgContact.Salutation = orgAdminContactDetails.Salutation;
                orgContact.FirstName = orgAdminContactDetails.FirstName;
                orgContact.LastName = orgAdminContactDetails.LastName;
                orgContact.EmailAddress1 = orgAdminContactDetails.EmailAddress1;
                orgContact.ModifiedBy = modifiedBy;
                orgContact.ModifiedOn = modifiedOn;

                var adminUaoContact = scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.SingleOrDefault(c => c.ParentID == dto.UaoID);
                Ensure.That(adminUaoContact).IsNotNull();
                adminUaoContact.Salutation = orgAdminContactDetails.Salutation;
                adminUaoContact.FirstName = orgAdminContactDetails.FirstName;
                adminUaoContact.LastName = orgAdminContactDetails.LastName;
                adminUaoContact.EmailAddress1 = orgAdminContactDetails.EmailAddress1;
                adminUaoContact.ModifiedBy = modifiedBy;
                adminUaoContact.ModifiedOn = modifiedOn;

                var cReg = orgContact.ContactRegulators.FirstOrDefault();
                if (cReg != null)
                {
                    cReg.RegulatorName = dto.RegulatorName;
                    cReg.RegulatorNumber = dto.RegulatorNumber;
                }

                await scope.SaveChangesAsync();
            }
        }

        public int GetSmsTransactionRank(Guid orgID, Guid txID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().FnSmsTransactionRank(orgID, txID).Value;
            }
        }

        public async Task AddNotes(Guid orgID, Guid uaoID, string notes)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationNotes.Add(new OrganisationNote
                {
                    OrganisationID = orgID,
                    UserAccountOrganisationID = uaoID,
                    Notes = notes,
                    DateTime = DateTime.Now
                });
                await scope.SaveChangesAsync();
            }
        }

        public bool IsSafeSendEnabled(Guid organisationID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var safeSendName = OrganisationSettingName.SafeSendEnabled.ToString();
                var setting = scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationSettings.Where(x => x.OrganisationID == organisationID && x.Name == safeSendName).FirstOrDefault();
                return setting != null && bool.Parse(setting.Value) == true;
            }
        }

        public async Task AddOrUpdateSafeSendEnabled(Guid orgID, bool safeSendEnabled)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var safeSendName = OrganisationSettingName.SafeSendEnabled.ToString();
                var setting = scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationSettings.Where(x => x.OrganisationID == orgID && x.Name == safeSendName).FirstOrDefault();
                if (setting == null)
                {
                    setting = new OrganisationSetting
                    {
                        OrganisationSettingID = Guid.NewGuid(),
                        OrganisationID = orgID,
                        Name = safeSendName,
                        Value = safeSendEnabled.ToString()
                    };
                    scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationSettings.Add(setting);
                }
                else
                {
                    setting.Value = safeSendEnabled.ToString();
                }
                await scope.SaveChangesAsync();
            }
        }

        public SmsTransactionDTO GetSmsTransactionWithPendingUpdates(Guid txID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var activityTypeID = ActivityType.SmsTransaction.GetIntValue();
                var tx = scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.SingleOrDefault(x => x.SmsTransactionID == txID);
                var updates = scope.DbContexts.Get<TargetFrameworkEntities>().FieldUpdates.Where(x => x.ActivityType == activityTypeID && x.ActivityID == txID);

                SmsTransactionHelper.ApplyUpdatesToSmsTransaction(tx, updates);

                var ret = tx.ToDto();

                ret.Address = tx.Address.ToDto();
                ret.Organisation = tx.Organisation.ToDto();
                ret.Organisation.OrganisationDetails = tx.Organisation.OrganisationDetails.ToDtos();
                ret.SmsUserAccountOrganisationTransactions = new List<SmsUserAccountOrganisationTransactionDTO>();
                foreach (var uaot in tx.SmsUserAccountOrganisationTransactions)
                {
                    var uaotDto = uaot.ToDto();
                    uaotDto.SmsTransaction = ret;
                    uaotDto.Address = uaot.Address.ToDto();
                    uaotDto.Contact = uaot.Contact.ToDto();
                    uaotDto.SmsSrcFundsBankAccounts = uaot.SmsSrcFundsBankAccounts.ToDtos();
                    uaotDto.SmsUserAccountOrganisationTransactionType = uaot.SmsUserAccountOrganisationTransactionType.ToDto();
                    ret.SmsUserAccountOrganisationTransactions.Add(uaotDto);
                }

                return ret;
            }
        }

        public async Task ResolveSmsTransactionPendingUpdates(Guid txID, Guid uaoID, List<FieldUpdateDTO> updates)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var approved = scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.SingleOrDefault(x => x.SmsTransactionID == txID);
                SmsTransactionHelper.ResolveSmsTransactionUpdates(scope, approved, uaoID, DateTime.Now, updates);
                await scope.SaveChangesAsync();
            }
        }

        public async Task RemovePendingUpdates(IEnumerable<FieldUpdateDTO> updates)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                foreach (var update in updates)
                {
                    var entity = update.ToEntity();
                    scope.DbContexts.Get<TargetFrameworkEntities>().Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                }
                await scope.SaveChangesAsync();
            }
        }

        public bool IsSafeBuyerPotentiallyFree(Guid txID)
        {
            // That method is not to make any critical decision, i.e. on payment.
            // It temporarily whitelists the lender names which make the Safe Buyer a Free product.
            // The final decision should rely on SIRA Match result.
            var excludedLenderName = Settings.GetSettings().AsSettings<ProductSettings>().SafeBuyerForFreeLenderName;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var result = false;
                var tx = scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.Single(x => x.SmsTransactionID == txID);
                var lenderName = GetValueOrPendingUpdate(ActivityType.SmsTransaction, txID, FieldUpdateParentType.SmsTransaction, txID, "LenderName", tx.LenderName);

                var lender = scope.DbContexts.Get<TargetFrameworkEntities>().Lenders.SingleOrDefault(x => x.Name == lenderName);
                if (lender != null && lender.Organisation != null)
                {
                    result = lender.Organisation.OrganisationDetails.Any(x => x.Name == excludedLenderName);
                }
                return result;
            }
        }

        public bool SmsTransactionQualifiesFree(Guid txID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var tx = scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.Single(x => x.SmsTransactionID == txID);
                var primaryBuyer = tx.SmsUserAccountOrganisationTransactions.Where(x=>x.SmsUserAccountOrganisationTransactionType.Name == "Buyer").Single();

                var firstName = GetValueOrPendingUpdate(ActivityType.SmsTransaction, txID, FieldUpdateParentType.Contact, primaryBuyer.ContactID, "FirstName", primaryBuyer.Contact.FirstName);
                var lastName = GetValueOrPendingUpdate(ActivityType.SmsTransaction, txID, FieldUpdateParentType.Contact, primaryBuyer.ContactID, "LastName", primaryBuyer.Contact.LastName);
                var dob = GetValueOrPendingUpdate(ActivityType.SmsTransaction, txID, FieldUpdateParentType.Contact, primaryBuyer.ContactID, "BirthDate", primaryBuyer.Contact.BirthDate.Value, s => DateTime.Parse(s));
                var lenderName = GetValueOrPendingUpdate(ActivityType.SmsTransaction, txID, FieldUpdateParentType.SmsTransaction, txID, "LenderName", tx.LenderName);
                var appNumber = GetValueOrPendingUpdate(ActivityType.SmsTransaction, txID, FieldUpdateParentType.SmsTransaction, txID, "MortgageApplicationNumber", tx.MortgageApplicationNumber);

                // pass through the transaction based lender name as this mapped directly within the sira db  opposed to the org trading name / registered name which may be different
                return CheckSIRAQualifiesFree(firstName, lastName, dob, lenderName, appNumber);
            }
        }

        private string GetValueOrPendingUpdate(ActivityType activityType, Guid activityID, FieldUpdateParentType parentType, Guid parentID, string fieldName, string approvedValue)
        {
            var pending = GetPendingUpdate(activityType, activityID, parentType, parentID, fieldName);
            return pending ?? approvedValue;
        }

        private T GetValueOrPendingUpdate<T>(ActivityType activityType, Guid activityID, FieldUpdateParentType parentType, Guid parentID, string fieldName, T approvedValue, Func<string, T> formatter)
        {
            var pending = GetPendingUpdate(activityType, activityID, parentType, parentID, fieldName);
            if (pending == null)
                return approvedValue;
            else
                return formatter(pending);
        }

        private string GetPendingUpdate(ActivityType activityType, Guid activityID, FieldUpdateParentType parentType, Guid parentID, string fieldName)
        {
            var activityTypeInt = activityType.GetIntValue();
            var parentTypeInt = parentType.GetIntValue();
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var pending = scope.DbContexts.Get<TargetFrameworkEntities>().FieldUpdates.SingleOrDefault(x =>
                    x.ActivityType == activityTypeInt &&
                    x.ActivityID == activityID &&
                    x.ParentType == parentTypeInt &&
                    x.ParentID == parentID &&
                    x.FieldName == fieldName);

                if (pending != null)
                    return pending.Value;
                else
                    return null;                
            }
        }

        private bool CheckSIRAQualifiesFree(string firstName, string lastName, DateTime dob, string lenderName, string appNumber)
        {
            var resultDto = SiraTransferClient.DoesMortgageApplicationExist(new Transfer.Entities.SiraMortgageApplicationCheckDTO
                {
                    LenderName = lenderName,
                    FirstName = firstName,
                    LastName = lastName,
                    MortgageApplciationNumber = appNumber,
                    DateOfBirth = dob
                });

            return resultDto.SiraMortgageApplicationExists;
        }
    }
}
