using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.SB.Client.Interfaces;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.Security;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public OrganisationLogicController()
        {
        }

        public async Task ExpireTemporaryLoginsAsync(int days, int hours, int minutes)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var exp = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Verified.GetStringValue());

                foreach (var uao in scope.DbContext.UserAccountOrganisations.Where(x => x.UserAccount.IsTemporaryAccount && x.PinCreated != null))
                {
                    var testDate = uao.PinCreated.Value.AddDays(days).AddHours(hours).AddMinutes(minutes);
                    if (testDate < DateTime.Now)
                    {
                        uao.UserAccount.IsLoginAllowed = false;
                        uao.PinCode = null;

                        if (uao.Organisation != null)
                        {
                            var status = uao.Organisation.OrganisationStatus.OrderByDescending(s => s.StatusChangedOn).FirstOrDefault();
                            if (status != null && status.StatusTypeValueID == exp.StatusTypeValueID)
                                await ExpireOrganisationAsync(uao.OrganisationID);
                        }
                    }
                }

                await scope.SaveAsync();
            }
        }

        public List<VOrganisationWithStatusAndAdminDTO> FindDuplicateOrganisations(bool manual, string line1, string line2, string town, string county, string postalCode)
        {
            Ensure.That(postalCode).IsNotNullOrWhiteSpace();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var query = scope.DbContext.VOrganisationWithStatusAndAdmins.Where(item => item.PostalCode == postalCode);
                if (!manual)
                {
                    if (!string.IsNullOrWhiteSpace(line1)) query = query.Where(item => item.Line1 == line1);
                    if (!string.IsNullOrWhiteSpace(line2)) query = query.Where(item => item.Line2 == line2);
                    if (!string.IsNullOrWhiteSpace(town)) query = query.Where(item => item.Town == town);
                    if (!string.IsNullOrWhiteSpace(county)) query = query.Where(item => item.County == county);
                }
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
            // get status type for professional organisation
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                // get professional default organisation template
                defaultOrganisation = scope.DbContext.DefaultOrganisations.Single(s => s.Name.Equals("Professional Organisation"));
            }

            Ensure.That(defaultOrganisation).IsNotNull();

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

            await AddNewUserToOrganisationAsync(organisationID, userContactDto, UserTypeEnum.OrganisationAdministrator, randomUsername, randomPassword, true, true);

            return organisationID;
        }

        public async Task<UserAccountOrganisationDTO> AddNewUserToOrganisationAsync(Guid organisationID, ContactDTO userContactDto, UserTypeEnum userTypeValue, string username, string password, bool isTemporary, bool sendEmail)
        {
            UserAccountOrganisationDTO uaoDto;
            Guid? userOrgID;
            var ua = await UserLogic.CreateAccountAsync(username, password, userContactDto.EmailAddress1, isTemporary, Guid.NewGuid());
            Ensure.That(ua).IsNotNull();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                Logger.Trace(string.Format("new user: {0} password: {1}", username, password));

                // add user to organisation
                userOrgID = scope.DbContext.FnAddUserToOrganisation(ua.ID, organisationID, userTypeValue.GetGuidValue(), organisationID);
                Ensure.That(userOrgID).IsNotNull();

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
                    dto.Name,
                    "",
                    UserNameService.UserName);

                ////    if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());

                ////}

                ////// perform other operations
                ////using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
                ////{

                // ensure guid has a value
                Ensure.That(organisationID).IsNotNull();

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
                    RegulatorOtherName = dto.RegulatorOther
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

        public List<VUserAccountOrganisationDTO> GetUsers(Guid organisationID, bool temporary, bool loginAllowed, bool hasPin)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                //if (hasPin)
                    return scope.DbContext.VUserAccountOrganisations.Where(x => x.OrganisationID == organisationID && x.IsTemporaryAccount == temporary && x.IsLoginAllowed == loginAllowed && x.PinCreated.HasValue == hasPin).ToDtos();
                //else
                    //return scope.DbContext.VUserAccountOrganisations.Where(x => x.OrganisationID == organisationID && x.IsTemporaryAccount == temporary && x.IsLoginAllowed == loginAllowed).ToDtos();
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

        public List<SmsTransactionDTO> GetSmsTransactions(Guid orgID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                return scope.DbContext.SmsTransactions.Where(x => x.OrganisationID == orgID).ToDtosWithRelated(1);
            }
        }

        public async Task<Guid> AddSmsTransaction(Guid orgID, SmsTransactionDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var txID = Guid.NewGuid();
                var addressID = await FindOrCreateAddress(dto.Address, txID);
                SmsTransaction tx = new SmsTransaction
                {
                    SmsTransactionID = txID,
                    AddressID = addressID,
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

        private async Task<Guid> FindOrCreateAddress(AddressDTO addressDTO, Guid parentID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var existing = scope.DbContext.Addresses.FirstOrDefault(x =>
                    x.Line1 == addressDTO.Line1 &&
                    x.Line2 == addressDTO.Line2 &&
                    x.Town == addressDTO.Town &&
                    x.County == addressDTO.County &&
                    x.PostalCode == addressDTO.PostalCode);

                if (existing == null)
                {
                    existing = addressDTO.ToEntity();
                    existing.AddressID = Guid.NewGuid();
                    existing.AddressTypeID = AddressTypeIDEnum.Work.GetIntValue();
                    existing.Name = String.Empty;
                    existing.ParentID = parentID;
                    scope.DbContext.Addresses.Add(existing);
                }
                //have to call svae regardless
                await scope.SaveAsync();
                return existing.AddressID;
            }
        }
    }
}
