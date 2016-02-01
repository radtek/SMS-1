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

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class OrganisationLogicController : LogicBase
    {
        public TFSettingsLogicController Settings { get; set; }
        public UserLogicController UserLogic { get; set; }
        public IEventPublishLogicClient EventPublishClient { get; set; }
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
                var checkStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Unverified.GetStringValue());
                var org = scope.DbContexts.Get<TargetFrameworkEntities>().VOrganisationWithStatusAndAdmins.Single(c => c.OrganisationID == dto.OrganisationId);
                if (org.StatusTypeValueID != checkStatus.StatusTypeValueID) throw new Exception(string.Format("Cannot reject a company of status '{0}'. Please go back and try again.", org.StatusValueName));

                await AddOrganisationStatusAsync(dto.OrganisationId, StatusTypeEnum.ProfessionalOrganisation, ProfessionalOrganisationStatusEnum.Rejected, dto.Reason, dto.Notes);

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
                    item.TradingNames = scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationTradingNames.Where(x => x.OrganisationID == item.OrganisationID).Select(x => x.Name).ToList();
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
            var uaoDto = await AddNewUserToOrganisationAsync(organisationID, userContactDto, UserTypeEnum.OrganisationAdministrator, true);

            await UserLogic.LockOrUnlockUserAsync(uaoDto.UserID, true);

            return organisationID;
        }

        public async Task<UserAccountOrganisationDTO> AddNewUserToOrganisationAsync(Guid organisationID, ContactDTO userContactDto, UserTypeEnum userTypeValue, bool addDefaultRoles, [System.Web.Http.FromUri]params Guid[] roles)
        {
            string orgTypeName;
            UserAccountOrganisationDTO uaoDto;
            Guid? userOrgID;
            var ua = await UserLogic.CreateAccountAsync(userContactDto.EmailAddress1, RandomPasswordGenerator.Generate(10), userContactDto.EmailAddress1, userContactDto.MobileNumber1, Guid.NewGuid());
            Ensure.That(ua).IsNotNull();

            using (var scope = DbContextScopeFactory.Create())
            {
                orgTypeName = scope.DbContexts.Get<TargetFrameworkEntities>().Organisations.Single(x => x.OrganisationID == organisationID).OrganisationType.Name;

                // add user to organisation
                userOrgID = scope.DbContexts.Get<TargetFrameworkEntities>().FnAddUserToOrganisation(ua.ID, organisationID, userTypeValue.GetGuidValue(), organisationID, addDefaultRoles);
                Ensure.That(userOrgID).IsNotNull();

                foreach (var roleID in roles)
                {
                    scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisationRoles.Add(new UserAccountOrganisationRole
                    {
                        UserAccountOrganisationID = userOrgID.Value,
                        OrganisationRoleID = roleID
                    });
                }

                var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == userOrgID.Value);

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
                        Salutation = userContactDto.Salutation,
                        BirthDate = userContactDto.BirthDate,
                        CreatedBy = UserNameService.UserName
                    };
                    scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Add(contact);
                    uao.PrimaryContactID = contact.ContactID;
                }
                else
                {
                    var existingUserContact = scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Single(c => c.ContactID == userContactDto.ContactID);
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
                    if (userTypeValue == UserTypeEnum.OrganisationAdministrator) await CreateTsAndCsNotificationAsync(userOrgID.Value, NotificationConstructEnum.TcFirmConveyancing);
                    break;
                case "Personal":
                    await CreateTsAndCsNotificationAsync(userOrgID.Value, NotificationConstructEnum.TcPublic);
                    break;
                case "MortgageBroker":
                    if (userTypeValue == UserTypeEnum.OrganisationAdministrator) await CreateTsAndCsNotificationAsync(userOrgID.Value, NotificationConstructEnum.TcMortgageBroker);
                    break;
                case "Lender":
                    if (userTypeValue == UserTypeEnum.OrganisationAdministrator) await CreateTsAndCsNotificationAsync(userOrgID.Value, NotificationConstructEnum.TcLender);
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
                    foreach (var tn in dto.TradingNames.Where(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationTradingNames.Add(
                            new OrganisationTradingName
                            {
                                OrganisationID = organisationID.Value,
                                Name = tn
                            });
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

        public async Task<Guid> AddSmsClient(Guid orgID, Guid uaoID, string salutation, string firstName, string lastName, string email, string phoneNumber, DateTime birthDate)
        {
            //add becky personal org & user
            UserAccountOrganisationDTO existingUaoDto = null;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var existingUao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.FirstOrDefault(x => x.UserAccount.Email.ToLower() == email.ToLower());
                if (existingUao != null)
                {
                    var personalOrgTypeId = OrganisationTypeEnum.Personal.GetIntValue();
                    if (existingUao.Organisation.OrganisationTypeID != personalOrgTypeId) throw new Exception("The specified email belongs to a system user; this is not currently supported.");
                    existingUaoDto = existingUao.ToDto();
                }
            }
            if (existingUaoDto != null)
            {
                await AddNewContactAndSetAsPrimary(existingUaoDto.UserAccountOrganisationID, salutation, firstName, lastName, email, phoneNumber, birthDate);
                return existingUaoDto.UserAccountOrganisationID;
            }

            DefaultOrganisationDTO defaultOrganisation;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                // get professional default organisation template
                defaultOrganisation = scope.DbContexts.Get<TargetFrameworkEntities>().DefaultOrganisations.Single(s => s.Name.Equals("Personal Organisation")).ToDto();
                Ensure.That(defaultOrganisation).IsNotNull();
            }

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
            var buyerUaoDto = await AddNewUserToOrganisationAsync(personalOrgID.Value, contactDTO, UserTypeEnum.User, true);
            await UserLogic.GeneratePinAsync(buyerUaoDto.UserAccountOrganisationID, false, false, true);
            
            return buyerUaoDto.UserAccountOrganisationID;
        }

        private async Task AddNewContactAndSetAsPrimary(Guid uaoId, string salutation, string firstName, string lastName, string email, string phoneNumber, DateTime birthDate)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.SingleOrDefault(x => x.UserAccountOrganisationID == uaoId);
                Ensure.That(uao).IsNotNull();

                var allContacts = scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Where(c => c.ParentID == uaoId && c.IsPrimaryContact == true);
                foreach (var item in allContacts)
	            {
		            item.IsPrimaryContact = false;
                    birthDate = item.BirthDate ?? birthDate;
	            }

                var contact = new Contact
                {
                    ContactID = Guid.NewGuid(),
                    ParentID = uaoId,
                    IsPrimaryContact = true,
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
                uao.PrimaryContactID = contact.ContactID;

                await scope.SaveChangesAsync();
            }
        }

        public async Task<Guid> AddSmsTransaction(AddSmsTransactionDTO dto, Guid orgID, Guid uaoID)
        {
            if (dto.BuyerUaoID == null)
            {
                dto.BuyerUaoID = await AddSmsClient(orgID, uaoID, dto.Salutation, dto.FirstName, dto.LastName, dto.Email, dto.PhoneNumber, dto.BirthDate.Value);
            }
            var transactionId = await SaveSmsTransaction(dto.SmsTransactionDTO, orgID);
            var assignSmsClientToTransactionDto = new AssignSmsClientToTransactionDTO
            {
                UaoID = dto.BuyerUaoID.Value,
                TransactionID = transactionId,
                AssigningByOrganisationID = orgID,
                UserAccountOrganisationTransactionType = UserAccountOrganisationTransactionType.Buyer
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

        public async Task<SmsUserAccountOrganisationTransactionDTO> UpdateSmsUserAccountOrganisationTransactionAsync(SmsUserAccountOrganisationTransactionDTO dto, Guid uaoID, string accountNumber, string sortCode)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var tx = scope.DbContexts.Get<TargetFrameworkEntities>().SmsUserAccountOrganisationTransactions.Single(x => x.UserAccountOrganisationID == uaoID && x.SmsTransactionID == dto.SmsTransactionID);

                if (tx.SmsTransaction.RowVersion != dto.SmsTransaction.RowVersion || tx.Contact.RowVersion != dto.Contact.RowVersion)
                    throw new Exception("The details have been updated by another user. Please go back and try again");

                tx.Confirmed = true;
                foreach (var bankAccount in dto.SmsSrcFundsBankAccounts)
                {
                    bankAccount.SmsSrcFundsBankAccountID = Guid.NewGuid();
                    bankAccount.SmsUserAccountOrganisationTransactionID = tx.SmsUserAccountOrganisationTransactionID;
                    scope.DbContexts.Get<TargetFrameworkEntities>().SmsSrcFundsBankAccounts.Add(bankAccount.ToEntity());
                }

                if (tx.SmsUserAccountOrganisationTransactionTypeID == UserAccountOrganisationTransactionType.Buyer.GetIntValue())
                {
                    tx.SmsTransaction.Address = await checkAddress(tx.SmsTransaction.Address, dto.SmsTransaction.Address, tx.ContactID);
                    tx.SmsTransaction.Price = dto.SmsTransaction.Price;
                    tx.SmsTransaction.LenderName = dto.SmsTransaction.LenderName;
                    tx.SmsTransaction.MortgageApplicationNumber = dto.SmsTransaction.MortgageApplicationNumber;
                }

                tx.Address = await checkAddress(tx.Address, dto.Address, tx.ContactID);

                tx.Contact.Salutation = dto.Contact.Salutation;
                tx.Contact.FirstName = dto.Contact.FirstName;
                tx.Contact.LastName = dto.Contact.LastName;
                
                var existingContacts = scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Where(x => x.ParentID == uaoID);
                if (existingContacts.Count() <= 1)
                    tx.Contact.BirthDate = dto.Contact.BirthDate;
                else
                    dto.Contact.BirthDate = existingContacts.First().BirthDate;
                tx.ModifiedOn = DateTime.Now;
                tx.ModifiedBy = UserNameService.UserName;

                await scope.SaveChangesAsync();

                return dto;
            }
        }

        public async Task AdviseProduct(Guid txID, Guid orgID, Guid primaryBuyerUaoID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var transaction = scope.DbContexts.Get<TargetFrameworkEntities>().SmsUserAccountOrganisationTransactions
                    .Where(s =>
                        s.SmsTransactionID == txID &&
                        s.SmsTransaction.OrganisationID == orgID &&
                        s.UserAccountOrganisationID == primaryBuyerUaoID)
                    .Select(s => s.SmsTransaction)
                    .SingleOrDefault();
                Ensure.That(transaction).IsNotNull();
                transaction.IsProductAdvised = true;
                transaction.ProductAdvisedOn = DateTime.Now;
                transaction.ModifiedOn = DateTime.Now;
                transaction.ModifiedBy = UserNameService.UserName;
                await scope.SaveChangesAsync();
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

        public async Task<TransactionOrderPaymentDTO> PurchaseSafeBuyerProduct(OrderRequestDTO orderRequest, Guid smsTransactionID, PaymentCardTypeIDEnum cardType, PaymentMethodTypeIDEnum methodType)
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

            orderRequest.TransactionOrderID = transactionOrder.TransactionOrderID;
            orderRequest.PaymentChargeType = PaymentChargeTypeEnum.Sale;
            var payment = await PaymentLogic.ProcessPaymentTransaction(orderRequest);
            if (payment.IsPaymentSuccessful)
            {
                await UpdateTransactionInvoiceID(smsTransactionID, invoice.InvoiceID);
            }
            return payment;
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

        private async Task<Address> checkAddress(Address address, AddressDTO addressDTO, Guid parentID)
        {
            if (address != null &&
                address.Line1 == addressDTO.Line1 &&
                address.Line2 == addressDTO.Line2 &&
                address.Town == addressDTO.Town &&
                address.County == addressDTO.County &&
                address.PostalCode == addressDTO.PostalCode)
                return address;

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
                    Name = String.Empty,
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
                    Logger.Fatal("The organisation with id: {0} is trying to assign sms client to the transaction with id: {1}. Sms Client UaoID: {2}",
                        assignSmsClientToTransactionDTO.AssigningByOrganisationID, assignSmsClientToTransactionDTO.TransactionID, assignSmsClientToTransactionDTO.UaoID);
                    throw new InvalidOperationException("The transaction does not belong to the organisation that the user is part of.");
                }
            }

            using (var scope = DbContextScopeFactory.Create())
            {
                var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.FirstOrDefault(x => x.UserAccountOrganisationID == assignSmsClientToTransactionDTO.UaoID);
                Ensure.That(uao).IsNotNull();

                var uaot = new SmsUserAccountOrganisationTransaction
                {
                    SmsUserAccountOrganisationTransactionID = Guid.NewGuid(),
                    SmsTransactionID = assignSmsClientToTransactionDTO.TransactionID,
                    UserAccountOrganisationID = assignSmsClientToTransactionDTO.UaoID,
                    SmsUserAccountOrganisationTransactionTypeID = assignSmsClientToTransactionDTO.UserAccountOrganisationTransactionType.GetIntValue(),
                    ContactID = uao.Contact.ContactID,
                    CreatedBy = UserNameService.UserName
                };
                scope.DbContexts.Get<TargetFrameworkEntities>().SmsUserAccountOrganisationTransactions.Add(uaot);

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

        public Guid GetCreditAccountId(Guid orgID)
        {
            return GetCreditAccount(orgID).OrganisationLedgerAccountID;
        }

        public OrganisationLedgerAccountDTO GetCreditAccount(Guid orgId)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var creditType = ClassificationLogic.GetClassificationDataForTypeName("OrganisationLedgerType", "Credit Account");
                return scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationLedgerAccounts.Single(x => x.OrganisationID == orgId && x.LedgerAccountTypeID == creditType).ToDto();
            }
        }

        public async Task<decimal> GetBalanceAsAt(Guid accountID, DateTime date)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var record = scope.DbContexts.Get<TargetFrameworkEntities>().VOrganisationLedgerTransactionBalances.Where(x => x.OrganisationLedgerAccountID == accountID && x.BalanceOn < date).OrderByDescending(x => x.BalanceOn).FirstOrDefault();
                if (record == null)
                    return 0;
                else
                    return record.Balance;
            }
        }

        public async Task VerifyOrganisation(Guid orgID, string orgName, int filesPerMonth, string regulatorNumber)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var org = scope.DbContexts.Get<TargetFrameworkEntities>().Organisations.Single(x => x.OrganisationID == orgID);
                org.FilesPerMonth = filesPerMonth;

                var detail = org.OrganisationDetails.FirstOrDefault();
                if (detail != null) detail.Name = orgName;

                var contact = scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.FirstOrDefault(c => c.ParentID == orgID);
                var cReg = contact.ContactRegulators.FirstOrDefault();
                if (cReg != null) cReg.RegulatorNumber = regulatorNumber;

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
    }
}
