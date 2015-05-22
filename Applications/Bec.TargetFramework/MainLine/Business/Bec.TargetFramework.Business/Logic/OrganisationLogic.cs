using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Transactions;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Security;

using Omu.ValueInjecter;
using ServiceStack.Text;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Data.Infrastructure.Linq;
using System.Reflection;
using Bec.TargetFramework.Data.Infrastructure.Specifications;
using System.Linq.Expressions;
using System.Data.Entity.Core.Objects;

namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;
    using EnsureThat;
    using System.Text;
    using Bec.TargetFramework.Infrastructure.Settings;
    using Bec.TargetFramework.Infrastructure.Helpers;
    using Bec.TargetFramework.SB.Interfaces;
    //Bec.TargetFramework.Entities

    [Trace(TraceExceptionsOnly = true)]
    public class OrganisationLogic : LogicBase
    {
        private BrockAllen.MembershipReboot.UserAccountService m_UaService;
        private BrockAllen.MembershipReboot.AuthenticationService m_AuthSvc;
        private readonly CommonSettings m_CommonSettings;
        private UserLogic m_UserLogic;
        private DataLogic m_DataLogic;
        private IEventPublishClient m_EventPublishClient;
        public OrganisationLogic(BrockAllen.MembershipReboot.UserAccountService uaService, BrockAllen.MembershipReboot.AuthenticationService authSvc, ILogger logger, ICacheProvider cacheProvider, CommonSettings commonSettings
            , UserLogic uLogic, DataLogic dLogic, IEventPublishClient eventPublishClient)
            : base(logger, cacheProvider)
        {
             this.m_CommonSettings = commonSettings;
            m_UaService = uaService;
            m_AuthSvc = authSvc;
            m_UserLogic = uLogic;
            m_DataLogic = dLogic;
            m_EventPublishClient = eventPublishClient;
        }

        public void ExpireOrganisations(int days, int hours, int minutes)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var status = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Verified.GetStringValue());

                Logger.Trace("expire starting");
                foreach (var org in scope.DbContext.VOrganisationWithStatusAndAdmins.Where(org => org.StatusTypeValueID == status.StatusTypeValueID && org.OrganisationPinCreated != null))
                {
                    var testDate = org.OrganisationPinCreated.Value.AddDays(days).AddHours(hours).AddMinutes(minutes);
                    if (testDate < DateTime.Now) ExpireOrganisation(scope, org.OrganisationID);
                }
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
            }
            Logger.Trace("expire finished");
        }

        public List<PostCodeDTO> FindAddressesByPostCode(string postCode, string buildingNameOrNumber)
        {
            Ensure.That(postCode).IsNotNullOrEmpty();

            var client = new PostcodeAnywhere.PostcodeAnywhere_SoapClient();

            var key = "EN93-RT99-CK59-GP54";
            var userName = "CLEAR11146";
            string building = "";
            if (!string.IsNullOrEmpty(buildingNameOrNumber))
            {
                building = buildingNameOrNumber.ToLowerInvariant();
            }

            var pcTrimmed = postCode.Replace(" ", "").Trim().ToLowerInvariant();

            using (var cacheClient = CacheProvider.CreateCacheClient(Logger))
            {
                string cacheKey = pcTrimmed + "*" + building;
                var cacheResult = cacheClient.Get<List<PostCodeDTO>>(cacheKey);

                if (cacheResult != null)
                    return cacheResult;
                else
                {
                    try
                    {
                        var response = client.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00(key, "", building, "", "", pcTrimmed, userName);

                        var dtos = response.Select(item => new PostCodeDTO
                        {
                            Company = item.Company,
                            County = item.County,
                            Department = item.Department,
                            BuildingName = item.BuildingName,
                            Line1 = item.Line1,
                            Line2 = item.Line2,
                            Line3 = item.Line3,
                            Postcode = item.Postcode,
                            PostTown = item.PostTown,
                            PrimaryStreet = item.PrimaryStreet
                        }).ToList();

                        cacheClient.Set(cacheKey, dtos, TimeSpan.FromDays(1));

                        return dtos;
                    }
                    catch (System.ServiceModel.FaultException)
                    {
                        return null;
                    }
                }
            }
        }

        public List<VOrganisationWithStatusAndAdminDTO> FindDuplicateOrganisations(bool manual, string line1, string line2, string town, string county, string postalCode)
        {
            Ensure.That(postalCode).IsNotNullOrWhiteSpace();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var query = scope.DbContext.VOrganisationWithStatusAndAdmins.Where(item => item.PostalCode == postalCode);
                if(!manual)
                {
                    if(!string.IsNullOrWhiteSpace(line1)) query = query.Where(item => item.Line1 == line1);
                    if(!string.IsNullOrWhiteSpace(line2)) query = query.Where(item => item.Line2 == line2);
                    if(!string.IsNullOrWhiteSpace(town)) query = query.Where(item => item.Town == town);
                    if(!string.IsNullOrWhiteSpace(county)) query = query.Where(item => item.County == county);
                }
                return VOrganisationWithStatusAndAdminConverter.ToDtos(query.OrderBy(c => c.Name).ThenBy(c => c.CreatedOn));
            }
        }

        public void RejectOrganisation(RejectCompanyDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var checkStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Unverified.GetStringValue());
                var org = scope.DbContext.VOrganisationWithStatusAndAdmins.Single(c => c.OrganisationID == dto.OrganisationId);
                if(org.StatusTypeValueID != checkStatus.StatusTypeValueID) throw new Exception(string.Format("Cannot reject a company of status '{0}'. Please go back and try again.", org.StatusValueName));

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

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
            }
        }

        public void ActivateOrganisation(Guid organisationID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var checkStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Verified.GetStringValue());
                var org = scope.DbContext.VOrganisationWithStatusAndAdmins.Single(c => c.OrganisationID == organisationID);
                if (org.StatusTypeValueID != checkStatus.StatusTypeValueID) throw new Exception(string.Format("Cannot reject a company of status '{0}'. Please go back and try again.", org.StatusValueName));

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

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
            }
        }

        public void GeneratePin(GeneratePinDTO dto)
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

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
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

        public GoogleGeoCodeResponse GeoCodePostcode(string postCode)
        {
            Ensure.That(postCode).IsNotNullOrEmpty();

            WebRequest request =
                WebRequest.Create(string.Format("http://maps.googleapis.com/maps/api/geocode/json?address={0}&sensor=false", postCode.Trim().Replace(" ", "")));

            request.Credentials = CredentialCache.DefaultCredentials;

            var result = JsonSerializer.DeserializeResponse<GoogleGeoCodeResponse>(request.GetResponse());

            return result;
        }

        public List<Bec.TargetFramework.Entities.VOrganisationWithStatusAndAdminDTO> GetCompanies(ProfessionalOrganisationStatusEnum orgStatus)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var status = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), orgStatus.GetStringValue());

                return VOrganisationWithStatusAndAdminConverter.ToDtos(
                    scope.DbContext.VOrganisationWithStatusAndAdmins.Where(
                    item => item.StatusTypeValueID.Equals(status.StatusTypeValueID)));
            }
        }

        public Guid AddNewUnverifiedOrganisationAndAdministrator(OrganisationTypeEnum organisationType, Bec.TargetFramework.Entities.AddCompanyDTO dto)
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
            var organisationID = AddOrganisation(organisationType.GetIntValue(), defaultOrganisation, dto);

            var randomUsername = m_DataLogic.GenerateRandomName();
            var randomPassword = RandomPasswordGenerator.Generate(10);
            var userContactDto = new ContactDTO
            {
                Telephone1 = dto.OrganisationAdminTelephone,
                FirstName = dto.OrganisationAdminFirstName,
                LastName = dto.OrganisationAdminLastName,
                EmailAddress1 = dto.OrganisationAdminEmail,
                Salutation = dto.OrganisationAdminSalutation
            };

            var userAccountOrganisation = AddNewUserToOrganisation(organisationID.Value, userContactDto, UserTypeEnum.OrganisationAdministrator, randomUsername, randomPassword, true);
            SendNewUserEmail(randomUsername, randomPassword, userAccountOrganisation.UserAccountOrganisationID, userContactDto);

            return organisationID.Value;
        }

        public UserAccountOrganisationDTO AddNewUserToOrganisation(Guid organisationID, ContactDTO userContactDto, UserTypeEnum userTypeValue, string username, string password, bool isTemporary)
        {
            UserAccountOrganisationDTO uao;

            var ua = m_UserLogic.CreateAccount(username, password, userContactDto.EmailAddress1, isTemporary, Guid.NewGuid());
            Ensure.That(ua).IsNotNull();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                Logger.Trace(string.Format("new user: {0} password: {1}", username, password));

                // add user to organisation
                var userOrgID = scope.DbContext.FnAddUserToOrganisation(ua.ID, organisationID, userTypeValue.GetGuidValue(), organisationID);                

                //if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());

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

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
            }

            return uao;
        }

        private void SendNewUserEmail(string username, string password, Guid userAccountOrganisationID, ContactDTO contact)
        {
            var tempDto = new Bec.TargetFramework.Entities.AddNewCompanyAndAdministratorDTO
            {
                Salutation = contact.Salutation,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Username = username,
                Password = password,
                UserAccountOrganisationID = userAccountOrganisationID,
                ProductName = m_CommonSettings.ProductName,
                WebsiteURL = m_CommonSettings.PublicWebsiteUrl
            };

            string payLoad = JsonHelper.SerializeData(new object[] { tempDto });

            var dto = new Bec.TargetFramework.SB.Entities.EventPayloadDTO
            {
                EventName = "TestEvent",
                EventSource = AppDomain.CurrentDomain.FriendlyName,
                EventReference = "1212",
                PayloadAsJson = payLoad
            };

            m_EventPublishClient.PublishEvent(dto);
        }

        private Guid? AddOrganisation(int organisationTypeID, DefaultOrganisation defaultOrg, Bec.TargetFramework.Entities.AddCompanyDTO dto)
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

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
                   
            }

            // perform other operations
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
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

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
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
                var organisationID =
                    scope.DbContext.Organisations.Single(
                        s => !s.ParentOrganisationID.HasValue && s.OrganisationTypeID.Equals(temporaryOrgTypeID)).OrganisationID;

                orgBranchID =
                    scope.DbContext.Organisations.Single(
                        s => s.ParentOrganisationID.HasValue && s.ParentOrganisationID.Value.Equals(organisationID) && s.IsBranch == true).OrganisationID;
            }

            return orgBranchID;
        }

        public VOrganisationDTO GetOrganisationDTO(Guid id)
        {
            Ensure.That(id).IsNot(Guid.Empty);

            var dto = new VOrganisationDTO();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var organDetail = scope.GetGenericRepository<VOrganisation, Guid>().Find(item => item.OrganisationID.Equals(id));

                dto.InjectFrom<NullableInjection>(organDetail);
            }

            return dto;
        }

        public bool IncrementInvalidPIN(Guid organisationID)
        {
            bool ret = false;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {   
                var org = scope.DbContext.Organisations.Single(x => x.OrganisationID == organisationID);
                org.PinAttempts++;
                if (org.PinAttempts >= 3)
                {
                    ExpireOrganisation(scope, organisationID);
                    ret = true;
                }
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());                
            }
            return ret;
        }

        public void ExpireOrganisation(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid organisationID)
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
        }

        public void ResendLogins(Guid organisationId)
        {
            VOrganisationWithStatusAndAdmin orgInfo;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                //get current sys admin details to copy
                orgInfo = scope.DbContext.VOrganisationWithStatusAndAdmins.Single(x=>x.OrganisationID == organisationId);
            }

            //generate new username & password
            var randomUsername = m_DataLogic.GenerateRandomName();
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
            var userAccountOrganisation = AddNewUserToOrganisation(organisationId, userContactDto, UserTypeEnum.OrganisationAdministrator, randomUsername, randomPassword, true);
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var user = scope.DbContext.UserAccounts.Single(x => x.ID == userAccountOrganisation.UserID);
                user.IsLoginAllowed = true;
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
            }
            SendNewUserEmail(randomUsername, randomPassword, userAccountOrganisation.UserAccountOrganisationID, userContactDto);

            //disable old temps
            m_UserLogic.LockUserTemporaryAccount(orgInfo.OrganisationAdminUserID.Value);
            
        }
    }
}
