using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
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
        public NotificationLogicController NotificationLogic { get; set; }

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

        public async Task<Guid?> AddOrganisationAsync(DefaultOrganisationDTO defaultOrg, Bec.TargetFramework.Entities.AddCompanyDTO dto)
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
    }
}
