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
        public DataLogicController DataLogic { get; set; }
        public IEventPublishLogicClient EventPublishClient { get; set; }
        public NotificationLogicController NotificationLogic { get; set; }

        public OrganisationLogicController()
        {
        }

        public async Task ExpireOrganisationsAsync(int days, int hours, int minutes)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var status = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Verified.GetStringValue());

                foreach (var org in scope.DbContext.VOrganisationWithStatusAndAdmins.Where(org => org.StatusTypeValueID == status.StatusTypeValueID && org.OrganisationPinCreated != null))
                {
                    var testDate = org.OrganisationPinCreated.Value.AddDays(days).AddHours(hours).AddMinutes(minutes);
                    if (testDate < DateTime.Now) await ExpireOrganisationAsync(org.OrganisationID);
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

                var status = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Rejected.GetStringValue());
                Ensure.That(status);

                scope.DbContext.OrganisationStatus.Add(new OrganisationStatus
                {
                    OrganisationID = dto.OrganisationId,
                    ReasonID = dto.Reason,
                    Notes = dto.Notes,
                    StatusTypeID = status.StatusTypeID,
                    StatusTypeVersionNumber = status.StatusTypeVersionNumber,
                    StatusTypeValueID = status.StatusTypeValueID,
                    StatusChangedOn = DateTime.Now,
                    StatusChangedBy = GetUserName()
                });

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

                var status = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Active.GetStringValue());
                Ensure.That(status);

                scope.DbContext.OrganisationStatus.Add(new OrganisationStatus
                {
                    OrganisationID = organisationID,
                    StatusTypeID = status.StatusTypeID,
                    StatusTypeVersionNumber = status.StatusTypeVersionNumber,
                    StatusTypeValueID = status.StatusTypeValueID,
                    StatusChangedOn = DateTime.Now,
                    StatusChangedBy = GetUserName()
                });

                await scope.SaveAsync();
            }
        }

        public async Task GeneratePinAsync(GeneratePinDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var checkStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Unverified.GetStringValue());
                var orgSA = scope.DbContext.VOrganisationWithStatusAndAdmins.Single(c => c.OrganisationID == dto.OrganisationId);
                if (orgSA.StatusTypeValueID != checkStatus.StatusTypeValueID) throw new Exception(string.Format("Cannot generate pin for a company of status '{0}'. Please go back and try again.", orgSA.StatusValueName));

                var org = scope.DbContext.Organisations.Single(o => o.OrganisationID == dto.OrganisationId);
                org.CompanyPinCode = CreatePin(4);
                org.CompanyPinCreated = DateTime.Now;
                org.IsCompanyPinCreated = true;

                var status = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Verified.GetStringValue());
                Ensure.That(status);

                scope.DbContext.OrganisationStatus.Add(new OrganisationStatus
                {
                    OrganisationID = dto.OrganisationId,
                    Notes = dto.ContactedTelephoneNumber,
                    StatusTypeID = status.StatusTypeID,
                    StatusTypeVersionNumber = status.StatusTypeVersionNumber,
                    StatusTypeValueID = status.StatusTypeValueID,
                    StatusChangedOn = DateTime.Now,
                    StatusChangedBy = GetUserName()
                });

                //enable temp logins now the pin has been set
                foreach (var uao in scope.DbContext.UserAccountOrganisations.Where(x => x.OrganisationID == dto.OrganisationId))
                {
                    var user = scope.DbContext.UserAccounts.Single(x => x.ID == uao.UserID);
                    user.IsLoginAllowed = true;
                }

                await scope.SaveAsync();
            }
        }

        private string CreatePin(int length)
        {
            Random r = new Random();
            StringBuilder pin = new StringBuilder(length);
            int thisNum;
            int? prevNum = null;
            do
            {
                for (int i = 0; i < length; i++)
                {
                    do
                    {
                        thisNum = r.Next(0, 36);
                    } while (prevNum.HasValue && (thisNum == prevNum || thisNum == prevNum - 1 || thisNum == prevNum + 1)); //avoid repeated or consecutive characters
                    prevNum = thisNum;
                    pin.Append((char)(thisNum > 9 ? thisNum + 55 : thisNum + 48)); //convert to 0-9 A-Z
                }
            } while (PinExists(pin.ToString()));
            return pin.ToString();
        }

        private bool PinExists(string pin)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                return scope.DbContext.Organisations.Any(o => o.CompanyPinCode == pin);
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

            var randomUsername = DataLogic.GenerateRandomName();
            var randomPassword = RandomPasswordGenerator.Generate(10);
            var userContactDto = new ContactDTO
            {
                Telephone1 = dto.OrganisationAdminTelephone,
                FirstName = dto.OrganisationAdminFirstName,
                LastName = dto.OrganisationAdminLastName,
                EmailAddress1 = dto.OrganisationAdminEmail,
                Salutation = dto.OrganisationAdminSalutation
            };

            var userAccountOrganisation = await AddNewUserToOrganisationAsync(organisationID, userContactDto, UserTypeEnum.OrganisationAdministrator, randomUsername, randomPassword, true);
            await SendNewUserEmailAsync(randomUsername, randomPassword, userAccountOrganisation.UserAccountOrganisationID, userContactDto, organisationID);

            return organisationID;
        }

        public async Task<UserAccountOrganisationDTO> AddNewUserToOrganisationAsync(Guid organisationID, ContactDTO userContactDto, UserTypeEnum userTypeValue, string username, string password, bool isTemporary)
        {
            UserAccountOrganisationDTO uao;
            Guid? userOrgID;
            var ua = UserLogic.CreateAccount(username, password, userContactDto.EmailAddress1, isTemporary, Guid.NewGuid());
            Ensure.That(ua).IsNotNull();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                Logger.Trace(string.Format("new user: {0} password: {1}", username, password));

                // add user to organisation
                userOrgID = scope.DbContext.FnAddUserToOrganisation(ua.ID, organisationID, userTypeValue.GetGuidValue(), organisationID);
                Ensure.That(userOrgID).IsNotNull();

                uao = UserAccountOrganisationConverter.ToDto(scope.DbContext.UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == userOrgID.Value));

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
                }
                else
                {
                    var existingUserContact = scope.DbContext.Contacts.Single(c => c.ContactID == userContactDto.ContactID);
                    existingUserContact.ParentID = userOrgID.Value;
                }

                await scope.SaveAsync();
            }

            //create Ts & Cs notification
            if (!isTemporary) await CreateTsAndCsNotificationAsync(userOrgID.Value);

            return uao;
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

        private async Task SendNewUserEmailAsync(string username, string password, Guid userAccountOrganisationID, ContactDTO contact, Guid organisationID)
        {
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

            string payLoad = JsonHelper.SerializeData(new object[] { tempDto });

            //add entry to EventStatus table
            EventStatus es;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                es = new EventStatus()
                {
                    EventStatusID = Guid.NewGuid(),
                    EventName = "TestEvent",
                    EventReference = organisationID.ToString(),
                    Status = "Pending",
                    Created = DateTime.Now
                };
                scope.DbContext.EventStatus.Add(es);
                await scope.SaveAsync();
            }

            var dto = new Bec.TargetFramework.SB.Entities.EventPayloadDTO
            {
                EventName = "TestEvent",
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
                    GetUserName());

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

        public async Task<bool> IncrementInvalidPINAsync(Guid organisationID)
        {
            bool ret = false;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var org = scope.DbContext.Organisations.Single(x => x.OrganisationID == organisationID);
                org.PinAttempts++;
                if (org.PinAttempts >= 3)
                {
                    await ExpireOrganisationAsync(organisationID);
                    ret = true;
                }
                await scope.SaveAsync();
            }
            return ret;
        }

        private async Task ExpireOrganisationAsync(Guid organisationID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var expStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Expired.GetStringValue());

                Logger.Trace("expiring " + organisationID.ToString());
                scope.DbContext.OrganisationStatus.Add(new OrganisationStatus
                {
                    OrganisationID = organisationID,
                    Notes = "Automatic expiry",
                    StatusTypeID = expStatus.StatusTypeID,
                    StatusTypeVersionNumber = expStatus.StatusTypeVersionNumber,
                    StatusTypeValueID = expStatus.StatusTypeValueID,
                    StatusChangedOn = DateTime.Now,
                    StatusChangedBy = GetUserName()
                });

                foreach (var uao in scope.DbContext.UserAccountOrganisations.Where(r => r.OrganisationID == organisationID))
                {
                    var user = scope.DbContext.UserAccounts.Single(u => u.ID == uao.UserID);
                    user.IsLoginAllowed = false;
                }
                await scope.SaveAsync();
            }
        }

        public async Task ResendLoginsAsync(Guid organisationId)
        {
            VOrganisationWithStatusAndAdmin orgInfo;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                //get current sys admin details to copy
                orgInfo = scope.DbContext.VOrganisationWithStatusAndAdmins.Single(x => x.OrganisationID == organisationId);

                //check still in verified status
                var checkStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Verified.GetStringValue());
                if (orgInfo.StatusTypeValueID != checkStatus.StatusTypeValueID) throw new Exception(string.Format("Cannot resend logins for a company of status '{0}'. Please go back and try again.", orgInfo.StatusValueName));
            }

                //generate new username & password
                var randomUsername = DataLogic.GenerateRandomName();
                var randomPassword = RandomPasswordGenerator.Generate(10);
                var userContactDto = new ContactDTO
                {
                    Telephone1 = orgInfo.OrganisationAdminTelephone,
                    FirstName = orgInfo.OrganisationAdminFirstName,
                    LastName = orgInfo.OrganisationAdminLastName,
                    EmailAddress1 = orgInfo.OrganisationAdminEmail,
                    Salutation = orgInfo.OrganisationAdminSalutation
                };

                //add new user & email them
                var userAccountOrganisation = await AddNewUserToOrganisationAsync(organisationId, userContactDto, UserTypeEnum.OrganisationAdministrator, randomUsername, randomPassword, true);
                using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
                {
                    var user = scope.DbContext.UserAccounts.Single(x => x.ID == userAccountOrganisation.UserID);
                    user.IsLoginAllowed = true;

                    await scope.SaveAsync();
                }
            await SendNewUserEmailAsync(randomUsername, randomPassword, userAccountOrganisation.UserAccountOrganisationID, userContactDto, organisationId);
            
            
            //disable old temps
            UserLogic.LockUserTemporaryAccount(orgInfo.OrganisationAdminUserID.Value);
        }
    }
}
