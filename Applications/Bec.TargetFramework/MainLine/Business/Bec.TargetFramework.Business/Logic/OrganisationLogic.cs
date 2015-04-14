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
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
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
    public class OrganisationLogic : LogicBase, IOrganisationLogic
    {
        private BrockAllen.MembershipReboot.UserAccountService m_UaService;
        private BrockAllen.MembershipReboot.AuthenticationService m_AuthSvc;
        private readonly CommonSettings m_CommonSettings;
        private IUserLogic m_UserLogic;
        private IDataLogic m_DataLogic;
        private IEventPublishClient m_EventPublishClient;
        public OrganisationLogic(BrockAllen.MembershipReboot.UserAccountService uaService, BrockAllen.MembershipReboot.AuthenticationService authSvc, ILogger logger, ICacheProvider cacheProvider, CommonSettings commonSettings
            , IUserLogic uLogic, IDataLogic dLogic, IEventPublishClient eventPublishClient)
            : base(logger, cacheProvider)
        {
             this.m_CommonSettings = commonSettings;
            m_UaService = uaService;
            m_AuthSvc = authSvc;
            m_UserLogic = uLogic;
            m_DataLogic = dLogic;
            m_EventPublishClient = eventPublishClient;
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
                    StatusChangedBy = "System"
                });

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
            }
        }

        public void GeneratePin(GeneratePinDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var org = scope.DbContext.Organisations.Single(o => o.OrganisationID == dto.OrganisationId);
                org.CompanyPinCode = createPin(4);
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
                    StatusChangedBy = "System"
                });

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
            }
        }

        private string createPin(int length)
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
            } while (pinExists(pin.ToString()));
            return pin.ToString();
        }

        private bool pinExists(string pin)
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

            var userAccountOrganisationID = AddNewUserToOrganisation(organisationID.Value, new ContactDTO
            {
                Telephone1 = dto.OrganisationAdminTelephone,
                FirstName = dto.OrganisationAdminFirstName,
                LastName = dto.OrganisationAdminLastName,
                EmailAddress1 = dto.OrganisationAdminEmail,
                Salutation = dto.OrganisationAdminSalutation
            }, UserTypeEnum.OrganisationAdministrator);

            return organisationID.Value;
        }

        private Guid AddNewUserToOrganisation(Guid organisationID,ContactDTO userContactDto,UserTypeEnum userTypeValue)
        {
            Guid uaoID;
            BrockAllen.MembershipReboot.UserAccount ua;
            var randomPassword = RandomPasswordGenerator.Generate(10);
            var randomUsername = m_DataLogic.GenerateRandomName();

            var userId = Guid.NewGuid();
            Guid? userOrgID;

            ua = m_UserLogic.CreateAccount(randomUsername, randomPassword, userContactDto.EmailAddress1, false, userId);

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                Logger.Trace(string.Format("new user: {0} password: {1}", randomUsername, randomPassword));

                // add user to organisation
                userOrgID = scope.DbContext.FnAddUserToOrganisation(ua.ID, organisationID, userTypeValue.GetGuidValue(), organisationID);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
                  
            }

            Ensure.That(userOrgID).IsNotNull();
            SendNewUserEmail(randomUsername, randomPassword, userOrgID.Value, userContactDto);

            Ensure.That(ua).IsNotNull();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {

                var userTypeGuid = userTypeValue.GetGuidValue();

                // get uao
                var uao = scope.DbContext.UserAccountOrganisations.Single(s => s.UserID.Equals(ua.ID) && s.OrganisationID.Equals(organisationID)
                    && s.UserTypeID.Equals(userTypeGuid));

                // create contact
                var contact = new Contact
                {
                    ContactID = Guid.NewGuid(),
                    ParentID = uao.UserAccountOrganisationID,
                    ContactName = "",
                    IsPrimaryContact = true,
                    Telephone1 = userContactDto.Telephone1,
                    FirstName = userContactDto.FirstName,
                    LastName = userContactDto.LastName,
                    EmailAddress1 = userContactDto.EmailAddress1,
                    Salutation = userContactDto.Salutation
                };

                scope.DbContext.Contacts.Add(contact);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());

                uaoID = uao.UserAccountOrganisationID;
            }

            return uaoID;
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
                    "");

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

        public List<vOrganisationDTO> GetAllOrganisationDetailDTO(string searchText)
        {

            var dtoList = new List<vOrganisationDTO>();
            vOrganisationDTO vOrgDTO = new vOrganisationDTO();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {

                //if(!string.IsNullOrEmpty(searchText))
                //{
                //    vOrgDTO.SearchQuery = searchText;
                //    vOrgDTO.SearchQueryTargetProperties = new List<PropertyInfo>();
                //    vOrgDTO.RowObject.GetType().GetProperties().Where(item => item.Name.Equals("Name") || item.Name.Equals("Description"))
                //                .ToList().ForEach(pi => vOrgDTO.SearchQueryTargetProperties.Add(pi));
                //}

                var repos = scope.GetGenericRepositoryNoTracking<VOrganisation, Guid>();

                var predicate = LinqHelpers.BuildPredicate<VOrganisation,
                           vOrganisationDTO>(vOrgDTO);

                scope.DbContext.VOrganisations.Where(predicate).ToList().ForEach(item =>
                {
                    var dto = new vOrganisationDTO();
                    if (!(item.IsBranch) && !(item.IsDeleted))
                    {
                        dto.InjectFrom<NullableInjection>(item);
                        dtoList.Add(dto);
                    }
                });
            }

            return dtoList;
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

        public void ActivateDeactivateOrDeleteOrganisation(Guid id, bool delete = false)
        {
            Ensure.That(id).IsNot(Guid.Empty);

            bool active = true;
            var organisation = new Organisation();
            var organisationDetail = new OrganisationDetail();
            var organisationStructure = new OrganisationStructure();
            var organisationUnit = new List<OrganisationUnit>();
            var organisationUsers = new List<UserAccountOrganisation>();
            var organisationLogos = new List<AttachmentDetail>();
            List<VBranch> branchOrganisations = new List<VBranch>();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var organisationRepos = scope.GetGenericRepository<Organisation, Guid>();
                organisation = organisationRepos.Get(id);

                if (organisation.IsActive)
                    active = false;
                else
                    active = true;

                var organisationDetailRepos = scope.GetGenericRepository<OrganisationDetail, Guid>();
                organisationDetail = scope.DbContext.OrganisationDetails.Single(item => item.OrganisationID == id);

                var organisationStructureRepos = scope.GetGenericRepository<OrganisationStructure, Guid>();
                organisationStructure = scope.DbContext.OrganisationStructures.Single(item => item.OrganisationID == id);

                var organisationUnitRepos = scope.GetGenericRepository<OrganisationUnit, Guid>();
                organisationUnit = scope.DbContext.OrganisationUnits.Where(item => item.OrganisationID == id).ToList();
                if (organisationUnit.Count > 0)
                {
                    organisationUnit.ForEach(item =>
                    {
                        if (delete)
                            item.IsDeleted = true;
                        else
                            item.IsActive = active;
                        organisationUnitRepos.Update(item);
                    });
                }

                var organisationUserRepos = scope.GetGenericRepository<UserAccountOrganisation, Guid>();
                //organisationUsers = scope.DbContext.UserAccountOrganisationUnits.Where(item => item.OrganisationID == id).ToList();
                //if (organisationUsers.Count > 0)
                //{
                //    organisationUsers.ForEach(user =>
                //        {
                //            var userAccountDetail = new UserAccountDetail();
                //            var userAccountDetailRepos = scope.GetGenericRepository<UserAccountDetail, Guid>();
                //            userAccountDetail = scope.DbContext.UserAccountDetails.Single(item => item.UserID == user.UserID);

                //            var userAccount = new Bec.TargetFramework.Data.UserAccount();
                //            var userAccountRepos = scope.GetGenericRepository<Bec.TargetFramework.Data.UserAccount, Guid>();
                //            userAccount = scope.DbContext.UserAccounts.Single(item => item.ID == userAccountDetail.UserID);

                //            if (delete)
                //            {
                //                user.IsDeleted = true;
                //                userAccountDetail.IsDeleted = true;
                //                userAccount.IsDeleted = true;
                //            }
                //            else
                //            {
                //                user.IsActive = active;
                //                userAccountDetail.IsActive = active;
                //                userAccount.IsActive = active;
                //            }
                //            organisationUserRepos.Update(user);
                //            userAccountDetailRepos.Update(userAccountDetail);
                //            userAccountRepos.Update(userAccount);
                //        });
                //}

                var logoRepos = scope.GetGenericRepository<AttachmentDetail, Guid>();
                organisationLogos = scope.DbContext.AttachmentDetails.Where(item => item.OrganisationID == id).ToList();
                if (organisationLogos.Count > 0)
                {
                    organisationLogos.ForEach(logo =>
                        {
                            var logoDetail = new Attachment();
                            var logoDetailRepos = scope.GetGenericRepository<Attachment, Guid>();
                            logoDetail = scope.DbContext.Attachments.Single(item => item.AttachmentDetailID == logo.AttachmentDetailID);

                            if (delete)
                            {
                                logo.IsDeleted = true;
                                logoDetail.IsDeleted = true;
                            }
                            else
                            {
                                logo.IsActive = active;
                                logoDetail.IsActive = active;
                            }
                            logoRepos.Update(logo);
                            logoDetailRepos.Update(logoDetail);
                        });
                }

                var branchOrganisationRepos = scope.GetGenericRepository<VBranch, Guid>();
                branchOrganisations = scope.DbContext.VBranches.Where(items => items.ParentOrganisationID == id).ToList();
                if (branchOrganisations.Count > 0)
                {
                    branchOrganisations.ForEach(branch =>
                    {
                        var branchorganisation = new Organisation();
                        var branchorganisationDetail = new OrganisationDetail();
                        var branchorganisationStructure = new OrganisationStructure();
                        var contact = new Contact();
                        var address = new List<Address>();

                        var branchOrganisationRepo = scope.GetGenericRepository<Organisation, Guid>();
                        var branchOrganisationDetailRepos = scope.GetGenericRepository<OrganisationDetail, Guid>();
                        var branchOrganisationStructureRepos = scope.GetGenericRepository<OrganisationStructure, Guid>();
                        var contactRepos = scope.GetGenericRepository<Contact, Guid>();
                        var addressRepos = scope.GetGenericRepository<Address, Guid>();

                        branchorganisation = branchOrganisationRepo.Get(branch.BranchOrganisationID.Value);
                        branchorganisationDetail = scope.DbContext.OrganisationDetails.Single(item => item.OrganisationID == branch.BranchOrganisationID);
                        branchorganisationStructure = scope.DbContext.OrganisationStructures.Single(item => item.OrganisationID == branch.BranchOrganisationID);
                        contact = contactRepos.Get(branch.ContactID);

                        if (delete)
                        {
                            branchorganisation.IsDeleted = true;
                            branchorganisationDetail.IsDeleted = true;
                            branchorganisationStructure.IsDeleted = true;
                            contact.IsDeleted = true;
                        }
                        else
                        {
                            branchorganisation.IsActive = active;
                            branchorganisationDetail.IsActive = active;
                            branchorganisationStructure.IsActive = active;
                            contact.IsActive = active;
                        }

                        branchOrganisationRepo.Update(branchorganisation);
                        branchOrganisationDetailRepos.Update(branchorganisationDetail);
                        branchOrganisationStructureRepos.Update(branchorganisationStructure);
                        contactRepos.Update(contact);

                        address = scope.DbContext.Addresses.Where(item => item.ParentID == branch.ContactID).ToList();
                        if (address.Count > 0)
                        {
                            address.ForEach(item =>
                            {
                                if (delete)
                                    item.IsDeleted = true;
                                else
                                    item.IsActive = active;
                                addressRepos.Update(item);
                            });
                        }
                    });
                }

                if (delete)
                {
                    organisation.IsDeleted = true;
                    organisationDetail.IsDeleted = true;
                    organisationStructure.IsDeleted = true;
                }
                else
                {
                    organisation.IsActive = active;
                    organisationDetail.IsActive = active;
                    organisationStructure.IsActive = active;
                }
                organisationRepos.Update(organisation);
                organisationDetailRepos.Update(organisationDetail);
                organisationStructureRepos.Update(organisationStructure);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        
        public void AddNewOrganisationFromWizard(OrganisationDTO dto)
        {
            //Ensure.That(dto);

            //OrganisationStructure organisationStructure = null;
            //List<OrganisationUnit> organisationUnits = new List<OrganisationUnit>();
            //Guid OrganisationID = Guid.Empty;
            //try
            //{
            //    // Create organisation with global, default and module specific roles, groups, external roles and groups
            //    OrganisationID = AddNewOrganisation(dto.Detail.OrganisationTypeID.Value, dto.Detail.OrganisationTemplate);
            //    using (TransactionScope tscope = new TransactionScope())
            //    {
            //        using (

            //            var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing,
            //                this.Logger,
            //                false))
            //        {


            //            // create structure
            //            var organStructureRepos = scope.GetGenericRepository<OrganisationStructure, Guid>();
            //            organisationStructure = new OrganisationStructure();

            //            organisationStructure.OrganisationStructureID = System.Guid.NewGuid();
            //            organisationStructure.OrganisationID = OrganisationID;
            //            organisationStructure.IsLeafNode = false;
            //            organisationStructure.Name = dto.Detail.Name;

            //            //SetAuditFields<OrganisationStructure>(organisationStructure, true);
            //            organStructureRepos.Add(organisationStructure);


            //            var organDetailRepos = scope.GetGenericRepository<OrganisationDetail, Guid>();
            //            var detail = new OrganisationDetail();

            //            detail.InjectFrom(dto.Detail);
            //            detail.OrganisationID = OrganisationID;
            //            detail.OrganisationDetailID = System.Guid.NewGuid();

            //            //SetAuditFields<OrganisationDetail>(detail, true);
            //            organDetailRepos.Add(detail);

            //            // create units
            //            var organUnitRepos = scope.GetGenericRepository<OrganisationUnit, Guid>();

            //            if (dto.Units != null)
            //                dto.Units.ForEach(it =>
            //                {
            //                    var unit = new OrganisationUnit();

            //                    unit.InjectFrom(it);

            //                    unit.OrganisationID = OrganisationID;

            //                    //SetAuditFields<OrganisationUnit>(unit, true);
            //                    organUnitRepos.Add(unit);
            //                });

            //            if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;

            //            // process branches
            //            var contactRepos = scope.GetGenericRepository<Contact, Guid>();
            //            var addressRepos = scope.GetGenericRepository<Address, Guid>();
            //            var organRepos = scope.GetGenericRepository<Organisation, Guid>();
            //            //Adding default branch only for the personal organisation.
            //            if (m_CommonSettings.PersonalOrganisationType == dto.Detail.OrganisationTypeID)
            //            {
            //                //Add default organisation branch
            //                var defaultbranch = new Contact();

            //                defaultbranch.ContactID = System.Guid.NewGuid();
            //                defaultbranch.IsActive = true;

            //                // create organisation for branch
                           
            //                var defaultbranchOrganisation = new Organisation();

            //                defaultbranchOrganisation.IsHeadOffice = false;
            //                defaultbranchOrganisation.IsBranch = true;
            //                defaultbranchOrganisation.IsActive = true;
            //                defaultbranchOrganisation.IsDeleted = false;
            //                defaultbranchOrganisation.OrganisationTypeID = 1006; // branch
            //                defaultbranchOrganisation.OrganisationID = System.Guid.NewGuid();

            //                defaultbranch.ParentID = defaultbranchOrganisation.OrganisationID;
            //                defaultbranch.IsPrimaryContact = false;
            //                defaultbranch.IsActive = true;
            //                defaultbranch.IsDeleted = false;
            //                defaultbranch.ContactName = dto.Detail.Name;

            //                //SetAuditFields<Contact>(defaultbranch, true);
            //                contactRepos.Add(defaultbranch);

            //                //SetAuditFields<Organisation>(defaultbranchOrganisation, true);
            //                organRepos.Add(defaultbranchOrganisation);

            //                var defaultbranchDetail = new OrganisationDetail();

            //                defaultbranchDetail.OrganisationDetailID = System.Guid.NewGuid();
            //                defaultbranchDetail.OrganisationID = defaultbranchOrganisation.OrganisationID;
            //                defaultbranchDetail.Name = defaultbranch.ContactName;
            //                defaultbranchDetail.IsActive = true;
            //                defaultbranchDetail.IsDeleted = false;

            //                //SetAuditFields<OrganisationDetail>(defaultbranchDetail, true);
            //                organDetailRepos.Add(defaultbranchDetail);

            //                // create structure
            //                var defaultbranchOrganisationStructure = new OrganisationStructure();

            //                defaultbranchOrganisationStructure.OrganisationStructureID = System.Guid.NewGuid();
            //                defaultbranchOrganisationStructure.OrganisationID = defaultbranchOrganisation.OrganisationID;
            //                defaultbranchOrganisationStructure.IsLeafNode = true;
            //                defaultbranchOrganisationStructure.IsActive = true;
            //                defaultbranchOrganisationStructure.IsDeleted = false;
            //                defaultbranchOrganisationStructure.Name = defaultbranch.ContactName;
            //                defaultbranchOrganisationStructure.ParentOrganisationStructureID =
            //                    organisationStructure.OrganisationStructureID;

            //                //SetAuditFields<OrganisationStructure>(defaultbranchOrganisationStructure, true);
            //                organStructureRepos.Add(defaultbranchOrganisationStructure);
            //            }
            //            if (dto.Branches != null)
            //                dto.Branches.ForEach(it =>
            //                {
            //                    var branch = new Contact();

            //                    branch.InjectFrom(it);
            //                    branch.ContactID = System.Guid.NewGuid();

            //                    // create organisation for branch
            //                    var branchOrganisation = new Organisation();

            //                    branchOrganisation.IsHeadOffice = it.IsHeadOffice;
            //                    branchOrganisation.OrganisationTypeID = 1006; // branch
            //                    branchOrganisation.OrganisationID = System.Guid.NewGuid();

            //                    branch.ParentID = branchOrganisation.OrganisationID;
            //                    branch.IsPrimaryContact = it.IsPrimaryContact;

            //                    //SetAuditFields<Contact>(branch, true);
            //                    contactRepos.Add(branch);

            //                    branchOrganisation.IsHeadOffice = it.IsHeadOffice;
            //                    branchOrganisation.IsBranch = true;

            //                    //SetAuditFields<Organisation>(branchOrganisation, true);
            //                    organRepos.Add(branchOrganisation);

            //                    var branchDetail = new OrganisationDetail();

            //                    branchDetail.OrganisationDetailID = System.Guid.NewGuid();
            //                    branchDetail.OrganisationID = branchOrganisation.OrganisationID;
            //                    branchDetail.Name = branch.ContactName;

            //                    //SetAuditFields<OrganisationDetail>(branchDetail, true);
            //                    organDetailRepos.Add(branchDetail);

            //                    // create structure
            //                    var branchOrganisationStructure = new OrganisationStructure();

            //                    branchOrganisationStructure.OrganisationStructureID = System.Guid.NewGuid();
            //                    branchOrganisationStructure.OrganisationID = branchOrganisation.OrganisationID;
            //                    branchOrganisationStructure.IsLeafNode = true;
            //                    branchOrganisationStructure.Name = branch.ContactName;
            //                    branchOrganisationStructure.ParentOrganisationStructureID =
            //                        organisationStructure.OrganisationStructureID;

            //                    //SetAuditFields<OrganisationStructure>(branchOrganisationStructure, true);
            //                    organStructureRepos.Add(branchOrganisationStructure);

            //                    // create contact addresses
            //                    if (it.Addresses != null)
            //                        it.Addresses.ForEach(ad =>
            //                        {
            //                            var address = new Address();

            //                            address.InjectFrom(ad);
            //                            address.ParentID = branch.ContactID;
            //                            address.AddressID = System.Guid.NewGuid();
            //                            //SetAuditFields<Address>(address, true);
            //                            addressRepos.Add(address);
            //                        });
            //                });

            //            if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            //        }

            //        tscope.Complete();
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}

            //// now add the users
            //using (
            //    var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing,
            //        this.Logger,
            //        true))
            //{
            //    var organRepos = scope.GetGenericRepository<Organisation, Guid>();
            //    var organStructureRepos = scope.GetGenericRepository<OrganisationStructure, Guid>();
            //    var organDetailRepos = scope.GetGenericRepository<OrganisationDetail, Guid>();
            //    var organUnitRepos = scope.GetGenericRepository<OrganisationUnit, Guid>();
            //    var contactRepos = scope.GetGenericRepository<Contact, Guid>();
            //    var addressRepos = scope.GetGenericRepository<Address, Guid>();

            //    Ensure.That(OrganisationID);

            //    organisationUnits =
            //        organUnitRepos.FindAll(
            //            item =>
            //                item.OrganisationID.HasValue &&
            //                item.OrganisationID.Value.Equals(OrganisationID))
            //            .ToList();

            //    var mainOrganisationStructure =
            //        organStructureRepos.Find(
            //            it => it.OrganisationID.HasValue && it.OrganisationID.Value.Equals(OrganisationID));

            //    var organStructures =
            //        organStructureRepos.FindAll(
            //            it =>
            //                it.ParentOrganisationStructureID.HasValue &&
            //                it.ParentOrganisationStructureID.Value.Equals(
            //                    mainOrganisationStructure.OrganisationStructureID))
            //            .ToList();


            //    var userAccountDetailRepos = scope.GetGenericRepository<UserAccountDetail, Guid>();
            //    var userOrganisationUnitRepos =
            //        scope.GetGenericRepository<UserAccountOrganisation, Guid, int>();

            //    if (dto.Users != null)
            //        dto.Users.ForEach(it =>
            //        {
            //            // create user
            //            // TBD
            //            var uaccount = m_UaService.CreateAccount(it.ContactName, RandomPasswordGenerator.Generate(10),
            //                it.EmailAddress1, true, Guid.NewGuid());

            //            var userContact = new Contact();
            //            userContact.InjectFrom(it);
            //            userContact.ContactID = Guid.NewGuid();
            //            userContact.ParentID = uaccount.ID;

            //            //SetAuditFields<Contact>(userContact, true);
            //            contactRepos.Add(userContact);

            //            // create user detail
            //            var userDetail = new UserAccountDetail();

            //            userDetail.UserID = uaccount.ID;
            //            userDetail.UserDetailID = Guid.NewGuid();

            //            //SetAuditFields<UserAccountDetail>(userDetail, true);
            //            userAccountDetailRepos.Add(userDetail);



            //            var userBranch = organStructures.Single(ub => ub.Name.Equals(it.OrganisationBranchID));
            //            var userOUnit = organisationUnits.Single(uu => uu.Name.Equals(it.OrganisationUnitID));

            //            // user organisationunit
            //            //var userUnit = new UserAccountOrganisationUnit();
            //            //userUnit.InternalEmailAddress = it.EmailAddress1;
            //            //userUnit.JobTitle = it.JobTitle;
            //            //userUnit.NickName = it.NickName;
            //            //userUnit.OrganisationID = userBranch.OrganisationID.Value;
            //            //userUnit.OrganisationUnitID = userOUnit.OrganisationUnitID;
            //            //userUnit.UserID = uaccount.ID;
            //            //userUnit.UserDetailID = userDetail.UserDetailID;
            //            //SetAuditFields<UserAccountOrganisationUnit>(userUnit, true);
            //            //userOrganisationUnitRepos.Add(userUnit);

            //            // create contact addresses
            //            if (it.Addresses != null)
            //                it.Addresses.ForEach(ad =>
            //                {
            //                    var address = new Address();

            //                    address.InjectFrom(ad);
            //                    address.ParentID = userContact.ContactID;
            //                    address.AddressID = Guid.NewGuid();
            //                    //SetAuditFields<Address>(address, true);
            //                    addressRepos.Add(address);
            //                });
            //        });

            //    if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            //}

        }

        public void SaveOrganisationDetail(OrganisationDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var organDetailRepos = scope.GetGenericRepository<OrganisationDetail, Guid>();
                var organDetail = new OrganisationDetail();

                if (!dto.OrganisationID.Equals(Guid.Empty))
                {
                    organDetail =
                        scope.DbContext.OrganisationDetails
                            .SingleOrDefault(item => item.OrganisationID.Equals(dto.OrganisationID));

                    //Save Organisation details
                    organDetail.Name = dto.Detail.Name;
                    organDetail.Description = dto.Detail.Description;
                    organDetailRepos.Update(organDetail);

                    //Save modified roles, groups, external roles and external groups

                    var organRoleRopos = scope.GetGenericRepository<OrganisationRole, Guid>();
                    var organRoleClaimRopos = scope.GetGenericRepository<OrganisationRoleClaim, Guid>();

                    var organGroupRopos = scope.GetGenericRepository<OrganisationGroup, Guid>();
                    var organGroupRoleRopos = scope.GetGenericRepository<OrganisationGroupRole, int>();
                    var existinggrps = scope.DbContext.OrganisationGroups.Where(orgGrp => orgGrp.OrganisationID.Equals(dto.OrganisationID)).ToList();

                    // deleting group if unselected
                    existinggrps.ForEach(grp =>
                    {
                        var grpfound = dto.SelectedGroups.Find(item => item.GroupID == grp.OrganisationGroupID);
                        if (grpfound == null)
                        {
                            organGroupRopos.FindAll(item => item.OrganisationGroupID == grp.OrganisationGroupID)
                            .ToList().ForEach(ite =>
                            {
                                organGroupRoleRopos.FindAll(item => item.OrganisationGroupID.Equals(ite.OrganisationGroupID))
                                .ToList().ForEach(grpRoles =>
                                {
                                    organGroupRoleRopos.Delete(grpRoles);
                                });
                                organGroupRopos.Delete(ite);
                            });
                        }
                    });
                    //Adding groups
                    if (dto.SelectedGroups != null && dto.SelectedGroups.Count > 0)
                    {
                        if (dto.SelectedGroups != null)
                            dto.SelectedGroups.ForEach(it =>
                            {
                                var grpexists = existinggrps.Find(grp => grp.OrganisationGroupID == it.GroupID);
                                if (grpexists == null)
                                {
                                    if (it.GroupID != null)
                                    {
                                        //var Group = scope.DbContext.Groups.Include("GroupRoles").Single(s => s.ID.Equals(it.ID));

                                        //var organGroup = new OrganisationGroup();

                                        //organGroup.InjectFrom<NullableInjection>(Group);
                                        //organGroup.OrganisationGroupID = System.Guid.NewGuid();
                                        //organGroup.OrganisationID = dto.OrganisationID;
                                        //organGroup.IsActive = true;
                                        //organGroup.GroupName = Group.Name;
                                        //SetAuditFields<OrganisationGroup>(organGroup, true);
                                        //organGroupRopos.Add(organGroup);

                                        //Group.GroupRoles.ToList().ForEach(gtr =>
                                        //{
                                        //    var organisationGroupRole = new OrganisationGroupRole();
                                        //    organisationGroupRole.InjectFrom(gtr);
                                        //    var roleTemp = organRoleRopos.FindAll(role => role.OrganisationRoleID == gtr.RoleID).ToList();
                                        //    if (roleTemp.Count > 0)
                                        //        organisationGroupRole.OrganisationRoleID = roleTemp.First().OrganisationRoleID;
                                        //    else
                                        //    {
                                        //        var Role = scope.DbContext.Roles
                                        //                 .Include("RoleClaims").Single(s => s.RoleID.Equals(gtr.RoleID));

                                        //        var organRoleTemp = new OrganisationRole();
                                        //        organRoleTemp.InjectFrom<NullableInjection>(Role);
                                        //        organRoleTemp.OrganisationID = dto.OrganisationID;
                                        //        organRoleTemp.OrganisationRoleID = Guid.NewGuid();
                                        //        organRoleTemp.IsActive = true;
                                        //        organRoleTemp.RoleName = Role.RoleName;

                                        //        SetAuditFields<OrganisationRole>(organRoleTemp, true);
                                        //        organRoleRopos.Add(organRoleTemp);
                                        //        organisationGroupRole.OrganisationRoleID = organRoleTemp.OrganisationRoleID;
                                        //    }

                                        //    organisationGroupRole.OrganisationGroupID = organGroup.OrganisationGroupID;
                                        //    organisationGroupRole.IsActive = true;
                                        //    organisationGroupRole.IsDeleted = false;
                                        //    SetAuditFields<OrganisationGroupRole>(organisationGroupRole, true);
                                        //    organGroupRoleRopos.Add(organisationGroupRole);
                                        //});
                                    }
                                }
                            });

                    }

                    

                    var existingroles = scope.DbContext.OrganisationRoles.Where(orgRole => orgRole.OrganisationID.Equals(dto.OrganisationID)).ToList();
                    // deleting role if unselected
                    existingroles.ForEach(role =>
                    {
                        var rolefound = dto.SelectedRoles.Find(item => item.RoleID == role.OrganisationRoleID);
                        if (rolefound == null)
                        {
                            organRoleRopos.FindAll(item => item.OrganisationRoleID == role.OrganisationRoleID)
                            .ToList().ForEach(ite =>
                            {
                                organRoleClaimRopos.FindAll(item => item.OrganisationRoleID.Equals(ite.OrganisationRoleID))
                                    .ToList().ForEach(claim =>
                                    {
                                        organRoleClaimRopos.Delete(claim);
                                    });
                                organRoleRopos.Delete(ite);
                            });
                        }
                    });
                    //Adding roles
                    if (dto.SelectedRoles != null && dto.SelectedRoles.Count > 0)
                    {
                        if (dto.SelectedRoles != null)
                            dto.SelectedRoles.ForEach(it =>
                            {
                                var roleexists = existingroles.Find(role => role.OrganisationRoleID == it.RoleID);
                                if (roleexists == null)
                                {
                                    var Role = scope.DbContext.Roles
                                        .Include("RoleClaims").Single(s => s.RoleID.Equals(it.RoleID));

                                    var organRole = new OrganisationRole();
                                    organRole.InjectFrom<NullableInjection>(Role);
                                    organRole.OrganisationID = dto.OrganisationID;
                                    organRole.OrganisationRoleID = Guid.NewGuid();
                                    organRole.IsActive = true;
                                    organRole.RoleName = Role.RoleName;

                                    SetAuditFields<OrganisationRole>(organRole, true);
                                    organRoleRopos.Add(organRole);

                                    Role.RoleClaims.ToList().ForEach(rtc =>
                                    {
                                        var organisationRoleClaim = new OrganisationRoleClaim();
                                        organisationRoleClaim.InjectFrom<NullableInjection>(rtc);
                                        organisationRoleClaim.OrganisationRoleID = organRole.OrganisationRoleID;
                                        organisationRoleClaim.IsActive = true;
                                        SetAuditFields<OrganisationRoleClaim>(organisationRoleClaim, true);
                                        organRoleClaimRopos.Add(organisationRoleClaim);
                                    });
                                }
                            });
                    }

                    

            }
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public bool DoesOrganisationNameExist(string Name)
        {
            Ensure.That(Name).IsNotNullOrEmpty();

            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
                            this.Logger,
                            false))
            {
                var repos = scope.GetGenericRepository<OrganisationDetail,Guid>();

                exists = repos.Exists(it => it.Name.Equals(Name));
            }

            return exists;
        }

        public bool DoesOrganisationBranchExist(string name)
        {
            Ensure.That(name).IsNotNullOrEmpty();

            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
                            this.Logger,
                            false))
            {
                var repos = scope.GetGenericRepository<OrganisationStructure, Guid>();

                exists = repos.Exists(it => it.Name.Equals(name));
            }

            return exists;
        }

        public bool DoesOrganisationLogoExist(string Name)
        {
            Ensure.That(Name).IsNotNullOrEmpty();

            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
                            this.Logger,
                            false))
            {
                var repos = scope.GetGenericRepository<Attachment, Guid>();

                exists = repos.Exists(it => it.Subject.Equals(Name));
            }

            return exists;
        }

        public bool DoesOrganisationUnitExist(string Name)
        {
            Ensure.That(Name).IsNotNullOrEmpty();

            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
                            this.Logger,
                            false))
            {
                var repos = scope.GetGenericRepository<OrganisationUnit, Guid>();

                exists = repos.Exists(it => it.Name.Equals(Name));
            }

            return exists;
        }

        //Get all roles and groups that are not already existing for the organisation
        public List<RoleDTO> GetOrgRoles(Guid orgId)
        {
            var list = new List<RoleDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var roles = scope.DbContext.Roles.ToList();
                var orgRoles = scope.DbContext.OrganisationRoles.Where(item => item.OrganisationID.Equals(orgId)).ToList();
                roles.ToList().ForEach(item =>
                {
                    var existingRole = orgRoles.FindAll(role => role.OrganisationRoleID.Equals(item.RoleID));
                    if (existingRole.Count == 0)
                    {
                        RoleDTO li = new RoleDTO();
                        li.InjectFrom<NullableInjection>(item);
                        list.Add(li);
                    }
                });
            }
            return list;
        }

        public List<GroupDTO> GetOrgGroups(Guid orgId)
        {
            var list = new List<GroupDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var groups = scope.DbContext.Groups.ToList();
                var orgGroups = scope.DbContext.OrganisationGroups.Where(item => item.OrganisationID.Equals(orgId)).ToList();
                groups.ToList().ForEach(item =>
                {
                    var existingGroup = orgGroups.FindAll(group => group.OrganisationGroupID.Equals(item.GroupID));
                    if (existingGroup.Count == 0)
                    {
                        GroupDTO li = new GroupDTO();
                        li.InjectFrom<NullableInjection>(item);
                        list.Add(li);
                    }
                });
            }
            return list;
        }


        //Get all roles and groups that are associated for the organisation
        public List<RoleDTO> GetOrgRolesforOrgId(Guid orgId)
        {
            var list = new List<RoleDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var roles = scope.DbContext.Roles.ToList();
                var orgRoles = scope.DbContext.OrganisationRoles.Where(item => item.OrganisationID.Equals(orgId)).ToList();
                roles.ToList().ForEach(item =>
                {
                    var existingRole = orgRoles.FindAll(role => role.OrganisationRoleID.Equals(item.RoleID));
                    if (existingRole.Count > 0)
                    {
                        RoleDTO li = new RoleDTO();
                        li.InjectFrom<NullableInjection>(item);
                        list.Add(li);
                    }
                });
            }
            return list;
        }

        public List<GroupDTO> GetOrgGroupsforOrgId(Guid orgId)
        {
            var list = new List<GroupDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var groups = scope.DbContext.Groups.ToList();
                var orgGroups = scope.DbContext.OrganisationGroups.Where(item => item.OrganisationID.Equals(orgId)).ToList();
                groups.ToList().ForEach(item =>
                {
                    var existingGroup = orgGroups.FindAll(role => role.OrganisationGroupID.Equals(item.GroupID));
                    if (existingGroup.Count > 0)
                    {
                        GroupDTO li = new GroupDTO();
                        li.InjectFrom<NullableInjection>(item);
                        list.Add(li);
                    }
                });
            }
            return list;
        }


        #region Organisation Logos
        public List<vAttachmentDTO> GetOrganisationLogos(Guid orgId)
        {
            var logosList = new List<vAttachmentDTO>();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                //var logos = scope.DbContext.vAttachments.Where(item => item.OrganisationID.HasValue && item.OrganisationID.Value == orgId && !(item.IsDeleted)).ToList();
                //if (logos.Count > 0)
                //{
                //    logos.ForEach(item =>
                //    {
                //        vAttachmentDTO li = new vAttachmentDTO();
                //        li.InjectFrom<NullableInjection>(item);
                //        logosList.Add(li);
                //    });
                //}
            }
            return logosList;
        }
        public vAttachmentDTO GetOrganisationLogo(Guid attachmentDetailID)
        {
            var logo = new vAttachmentDTO();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var LogoRespository = scope.GetGenericRepository<VAttachment, Guid>();

                var item = LogoRespository.Get(attachmentDetailID);

                logo.InjectFrom<NullableInjection>(item);
            }
            return logo;
        }
        public void SaveOrganisationLogo(vAttachmentDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var attachmentRepos = scope.GetGenericRepository<Attachment, Guid>();
                var attachmentDetailRepos = scope.GetGenericRepository<AttachmentDetail, Guid>();
                var attachment = new Attachment();
                var attachmentDetail = new AttachmentDetail();

                var repositoryStructure = scope.DbContext.RepositoryStructures.Single(item => item.Name.Equals("Organisation"));

                if (dto.AttachmentDetailID != Guid.Empty)
                {
                    attachment.InjectFrom<NullableInjection>(dto);
                    attachment.IsActive = true;
                    attachmentRepos.Update(attachment);
                }
                else
                {
                    attachment.InjectFrom<NullableInjection>(new IgnoreProps("OrganisationID"), dto);
                    attachmentDetail.InjectFrom<NullableInjection>(new IgnoreProps("AttachmentDetailsID"), dto);

                    attachmentDetail.AttachmentDetailID = Guid.NewGuid();
                    attachmentDetail.RepositoryStructureID = repositoryStructure.RepositoryStructureID;
                    attachment.AttachmentDetailID = attachmentDetail.AttachmentDetailID;
                    attachment.AttachmentID = Guid.NewGuid();
                    attachment.IsActive = true;
                    attachmentDetail.IsActive = true;
                    attachmentDetailRepos.Add(attachmentDetail);
                    attachmentRepos.Add(attachment);
                }
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public void ActivateOrDeactivateOrganisationLogo(Guid attachmentDetailID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var logoRepos = scope.GetGenericRepository<AttachmentDetail, Guid>();
                var orgLogo = new AttachmentDetail();

                if (attachmentDetailID !=null)
                {
                    orgLogo = scope.DbContext.AttachmentDetails.Single(item => item.AttachmentDetailID == attachmentDetailID);
                    if (orgLogo.IsActive)
                        orgLogo.IsActive = false;
                    else
                        orgLogo.IsActive = true;
                    logoRepos.Update(orgLogo);
                }
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public void DefaultOrganisationLogo(Guid organisationID, Guid attachmentDetailID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var orgDetRepo = scope.GetGenericRepository<OrganisationDetail, Guid>();
                var orgDefaultLogo = new OrganisationDetail();
                var logoRepos = scope.GetGenericRepository<AttachmentDetail, Guid>();
                var attachmentDet = new AttachmentDetail();
                if (organisationID != null)
                {
                    orgDefaultLogo = scope.DbContext.OrganisationDetails.Single(item => item.OrganisationID == organisationID);
                    orgDefaultLogo.OrganisationDefaultLogoID = attachmentDetailID;
                    orgDetRepo.Update(orgDefaultLogo);

                    //Making the logo active if its maked as default logo
                    attachmentDet = scope.DbContext.AttachmentDetails.Single(item => item.AttachmentDetailID == attachmentDetailID);
                    attachmentDet.IsActive = true;
                    logoRepos.Update(attachmentDet);
                }
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        #endregion
        #region Organisation Units
        
        public void SaveOrganisationUnit(OrganisationUnitDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var unitRepos = scope.GetGenericRepository<OrganisationUnit, int>();
                var orgUnit = new OrganisationUnit();

                if (dto.OrganisationUnitID > 0)
                {
                    orgUnit = unitRepos.Get(dto.OrganisationUnitID);
                    dto.OrganisationID = orgUnit.OrganisationID.Value;
                }
                else
                    orgUnit.IsActive = true;

                orgUnit.InjectFrom<NullableInjection>(new IgnoreProps("OrganisationID"), dto);
                if (dto.OrganisationUnitID > 0)
                    unitRepos.Update(orgUnit);
                else
                    unitRepos.Add(orgUnit);
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        public OrganisationUnitDTO GetOrganisationUnit(int unitID)
        {
            var unit = new OrganisationUnitDTO();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var unitRespository = scope.GetGenericRepository<OrganisationUnit, int>();

                var item = unitRespository.Get(unitID);

                unit.InjectFrom<NullableInjection>(item);
            }
            return unit;
        }

        public void DeleteOrganisationUnit(int unitID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var unitRepos = scope.GetGenericRepository<OrganisationUnit, int>();
                var orgUnit = new OrganisationUnit();

                if (unitID > 0)
                {
                    orgUnit = scope.DbContext.OrganisationUnits.Single(item => item.OrganisationUnitID == unitID);
                    orgUnit.IsDeleted = true;
                }
                orgUnit.InjectFrom<NullableInjection>(new IgnoreProps("OrganisationID"), orgUnit);
                if (unitID > 0)
                    unitRepos.Update(orgUnit);
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        #endregion
    
        #region Organisation Branch

        public List<OrganisationDTO> GetOrgansationBranchDTOs(Guid orgId)
        {
            var branchesList = new List<OrganisationDTO>();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                branchesList = OrganisationConverter.ToDtos( scope.DbContext.Organisations.Where(item => item.ParentOrganisationID == orgId && item.IsBranch == true && item.IsActive == true && item.IsDeleted == false));
            }
            return branchesList;
        }

        public List<vBranchDTO> GetOrganisationBranches(Guid orgId)
        {
            var branchesList = new List<vBranchDTO>();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var branches = scope.DbContext.VBranches.Where(item => item.ParentOrganisationID == orgId && !(item.IsDeleted)).ToList();
                if (branches.Count > 0)
                {
                    branches.ForEach(item =>
                    {
                        vBranchDTO li = new vBranchDTO();
                        li.InjectFrom<NullableInjection>(item);
                        branchesList.Add(li);
                    });
                }
            }
            return branchesList;
        }
        public List<ContactDTO> GetAllBranches(Guid orgId)
        {
            var contactlist = new List<ContactDTO>();
            var branches = GetOrganisationBranches(orgId);
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
            if (branches.Count > 0)
                branches.ForEach(branch =>
                    {
                        var contact = new Contact();
                        contact = scope.DbContext.Contacts.Single(item => item.ContactID == branch.ContactID);
                        if(contact != null)
                        {
                            ContactDTO con = new ContactDTO();
                            con.InjectFrom<NullableInjection>(contact);
                            con.OrganisationBranchID = branch.BranchOrganisationID.ToString();
                            con.IsHeadOffice = branch.IsHeadOffice;
                            contactlist.Add(con);
                        }
                    });
            }
            return contactlist;
        }
          public void SaveOrganisationBranch(ContactDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var organRepos = scope.GetGenericRepository<Organisation, Guid>();
                var organStructureRepos = scope.GetGenericRepository<OrganisationStructure, Guid>();
                var organDetailRepos = scope.GetGenericRepository<OrganisationDetail, Guid>();
                var contactRepos = scope.GetGenericRepository<Contact, Guid>();
                var addressRepos = scope.GetGenericRepository<Address, Guid>();

                var organisation = new Organisation();
                var orgStructure = new OrganisationStructure();

                var branchOrganisationStructure = new OrganisationStructure();
                var branchDetail = new OrganisationDetail();
                var branch = new Contact();
                var branchOrganisation = new Organisation();
                if (dto != null && !string.IsNullOrEmpty(dto.OrganisationID))
                {
                    Guid OrganisationId = Guid.Parse(dto.OrganisationID);

                    organisation = organRepos.Get(OrganisationId);
                    orgStructure = scope.DbContext.OrganisationStructures.Single(items => items.OrganisationID == OrganisationId);

                    branch = contactRepos.Get(dto.ContactID);

                    if (branch == null)
                    {
                        var contact = new Contact();
                        contact.InjectFrom<NullableInjection>(dto);
                        contact.ContactID = System.Guid.NewGuid();

                        // create organisation for branch
                        branchOrganisation.IsHeadOffice = dto.IsHeadOffice;
                        branchOrganisation.OrganisationTypeID = 1006; // branch
                        branchOrganisation.OrganisationID = System.Guid.NewGuid();

                        contact.ParentID = branchOrganisation.OrganisationID;
                        contact.IsPrimaryContact = dto.IsPrimaryContact;
                        contact.ContactName = dto.ContactName;

                        SetAuditFields<Contact>(contact, true);
                        contactRepos.Add(contact);

                        if (dto.IsHeadOffice)
                            branchOrganisation.IsBranch = false;
                        else
                            branchOrganisation.IsBranch = true;

                        SetAuditFields<Organisation>(branchOrganisation, true);
                        organRepos.Add(branchOrganisation);

                        branchDetail.OrganisationDetailID = System.Guid.NewGuid();
                        branchDetail.OrganisationID = branchOrganisation.OrganisationID;
                        branchDetail.Name = contact.ContactName;

                        SetAuditFields<OrganisationDetail>(branchDetail, true);
                        organDetailRepos.Add(branchDetail);

                        // create structure
                        branchOrganisationStructure.OrganisationStructureID = System.Guid.NewGuid();
                        branchOrganisationStructure.OrganisationID = branchOrganisation.OrganisationID;
                        branchOrganisationStructure.IsLeafNode = true;
                        branchOrganisationStructure.Name = contact.ContactName;
                        branchOrganisationStructure.ParentOrganisationStructureID = orgStructure.OrganisationStructureID;

                        SetAuditFields<OrganisationStructure>(branchOrganisationStructure, true);
                        organStructureRepos.Add(branchOrganisationStructure);

                        // create contact addresses
                        if (dto.Addresses != null)
                            dto.Addresses.ForEach(ad =>
                            {
                                var address = new Address();
                                address.InjectFrom(ad);
                                address.ParentID = contact.ContactID;
                                address.AddressID = System.Guid.NewGuid();
                                SetAuditFields<Address>(address, true);
                                addressRepos.Add(address);
                            });

                    }
                    else
                    {
                        organisation = organRepos.Get(branch.ParentID);
                        // update organisation for branch
                        branchOrganisation = organRepos.Get(organisation.OrganisationID);
                        branchOrganisation.IsHeadOffice = dto.IsHeadOffice;

                        branch = scope.DbContext.Contacts.Single(item => item.ParentID == organisation.OrganisationID);
                        branch.ContactName = dto.ContactName;
                        branch.IsPrimaryContact = dto.IsPrimaryContact;

                        SetAuditFields<Contact>(branch, true);
                        contactRepos.Update(branch);

                        if (dto.IsHeadOffice)
                            branchOrganisation.IsBranch = false;
                        else
                            branchOrganisation.IsBranch = true;

                        SetAuditFields<Organisation>(branchOrganisation, true);
                        organRepos.Update(branchOrganisation);

                        branchDetail = scope.DbContext.OrganisationDetails.Single(item => item.OrganisationID == organisation.OrganisationID);
                        branchDetail.Name = branch.ContactName;

                        SetAuditFields<OrganisationDetail>(branchDetail, true);
                        organDetailRepos.Update(branchDetail);

                        // update structure
                        branchOrganisationStructure = scope.DbContext.OrganisationStructures.Single(item => item.OrganisationID == organisation.OrganisationID);
                        branchOrganisationStructure.Name = branch.ContactName;

                        SetAuditFields<OrganisationStructure>(branchOrganisationStructure, true);
                        organStructureRepos.Update(branchOrganisationStructure);

                        // create contact addresses
                        if (dto.Addresses != null)
                            dto.Addresses.ForEach(ad =>
                            {
                                var address = new Address();
                                address = addressRepos.Get(ad.AddressID);
                                if(address != null)
                                {
                                    address.InjectFrom<NullableInjection>(ad);
                                    address.ParentID = branch.ContactID;
                                    addressRepos.Update(address);
                                }
                                else
                                {
                                    Address add = new Address();
                                    add.InjectFrom<NullableInjection>(ad);
                                    add.ParentID = branch.ContactID;
                                    add.AddressID = System.Guid.NewGuid();
                                    SetAuditFields<Address>(address, true);
                                    addressRepos.Add(add);
                                }
                            });
                    }
                }
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        public vBranchDTO GetOrganisationBranch(int branchID)
        {
            var branch = new vBranchDTO();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                //var branchRespository = scope.GetGenericRepository<vBranch, int>();

                //var item = branchRespository.Get(branchID);

                //branch.InjectFrom<NullableInjection>(item);
            }
            return branch;
        }

        public void DeleteOrganisationBranch(Guid contactID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var organRepos = scope.GetGenericRepository<Organisation, Guid>();
                var organStructureRepos = scope.GetGenericRepository<OrganisationStructure, Guid>();
                var organDetailRepos = scope.GetGenericRepository<OrganisationDetail, Guid>();
                var contactRepos = scope.GetGenericRepository<Contact, Guid>();
                var addressRepos = scope.GetGenericRepository<Address, Guid>();

                var branchOrganisationStructure = new OrganisationStructure();
                var branchDetail = new OrganisationDetail();
                var branch = new Contact();
                var branchOrganisation = new Organisation();
                var address = new List<Address>();

                if (contactID != Guid.Empty)
                {
                    branch = contactRepos.Get(contactID);
                    branch.IsDeleted = true;

                    branchOrganisation = scope.DbContext.Organisations.Single(item => item.OrganisationID == branch.ParentID);
                    branchOrganisation.IsDeleted = true;
                    
                    branchDetail = scope.DbContext.OrganisationDetails.Single(item => item.OrganisationID == branchOrganisation.OrganisationID);
                    branchDetail.IsDeleted = true;

                    branchOrganisationStructure = scope.DbContext.OrganisationStructures.Single(item => item.OrganisationID == branchOrganisation.OrganisationID);
                    branchOrganisationStructure.IsDeleted = true;

                    address = scope.DbContext.Addresses.Where(item => item.ParentID == contactID).ToList();
                    address.ForEach(ad =>
                    {
                        ad.IsDeleted = true;
                        SetAuditFields<Address>(ad, true);
                        addressRepos.Update(ad);
                    });

                    contactRepos.Update(branch);
                    organStructureRepos.Update(branchOrganisationStructure);
                    organDetailRepos.Update(branchDetail);
                    organRepos.Update(branchOrganisation);
                }

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        public List<AddressDTO> GetAllBranchAddresses(Guid id)
        {
            List<AddressDTO> addressList = new List<AddressDTO>();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var addresses = scope.DbContext.Addresses.Where(item => item.ParentID == id).ToList();
                if (addresses.Count > 0)
                {
                    addresses.ForEach(item =>
                    {
                        AddressDTO li = new AddressDTO();
                        li.InjectFrom<NullableInjection>(item);
                        addressList.Add(li);
                    });
                }
                return addressList;
            }
        }

        #endregion

        /// <summary>
        /// Gets the organisation details.
        /// </summary>
        /// <returns>List of OrganisationDetailDTO</returns>
        public List<OrganisationDetailDTO> GetOrganisationDetails()
        {
            var dtoList = new List<OrganisationDetailDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var repos = scope.GetGenericRepositoryNoTracking<OrganisationDetail, Guid>();

                repos.GetAll().ToList().ForEach(item =>
                {
                    var dto = new OrganisationDetailDTO();

                    dto.InjectFrom(item);

                    dtoList.Add(dto);
                });
            }

            return dtoList.OrderBy(item=>item.Name).ToList();
        }

        /// <summary>
        /// Gets the organisation details including its branch organisations.
        /// </summary>
        /// <returns>List of OrganisationDetailDTO</returns>
        public List<OrganisationDetailDTO> GetOrganisationDetailsIncludingBranches(string id)
        {
            var dtoList = new List<OrganisationDetailDTO>();
            var organisation = new OrganisationDetail();
            var orgStructure = new OrganisationStructure();
            var branchOrgStructure = new List<OrganisationStructure>();
            var org = new OrganisationDetailDTO();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                //Get organisation details
                var repos = scope.GetGenericRepositoryNoTracking<OrganisationDetail, Guid>();
                Guid organisationId = Guid.Parse(id);
                organisation = scope.DbContext.OrganisationDetails.Single(item => item.OrganisationID == organisationId);
                org.InjectFrom(organisation);
                dtoList.Add(org);

                //Get organisation structure id 
                var orgStructureRepos = scope.GetGenericRepositoryNoTracking<OrganisationStructure, Guid>();
                orgStructure = scope.DbContext.OrganisationStructures.Single(item => item.OrganisationID == organisation.OrganisationID);

                //Get branches using organisation structure id
                branchOrgStructure = scope.DbContext.OrganisationStructures.Where(item => item.ParentOrganisationStructureID == orgStructure.OrganisationStructureID).ToList();

                if(branchOrgStructure.Count > 0)
                {
                    branchOrgStructure.ForEach(branch =>
                        {
                            var dto = new OrganisationDetailDTO();
                            organisation = scope.DbContext.OrganisationDetails.Single(item => item.OrganisationID == branch.OrganisationID.Value);
                            dto.InjectFrom(organisation);
                            dtoList.Add(dto);
                        });
                }
            }
            return dtoList.OrderBy(item => item.Name).ToList();
        }

        /// <summary>
        /// Gets the organisation units.
        /// </summary>
        /// <param name="orgId">The organisation guid.</param>
        /// <returns>list of OrganisationUnitDTO</returns>
        public List<OrganisationUnitDTO> GetOrganisationUnits(Guid orgId)
        {
            Ensure.That(orgId).IsNot(Guid.Empty);

            var dtoList = new List<OrganisationUnitDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var orgUnits = scope.DbContext.OrganisationUnits.Where(item => item.OrganisationID.HasValue && item.OrganisationID.Value.Equals(orgId) && !(item.IsDeleted)).OrderBy(item => item.Name).ToList();

                orgUnits.ToList().ForEach(item =>
                 {
                     var dtoUnits = new OrganisationUnitDTO();
                     dtoUnits.InjectFrom<NullableInjection>(item);
                     dtoList.Add(dtoUnits);
                 });

            }

            return dtoList;
        }


        /// <summary>
        /// Gets the organisation templates for the provided organisation type.
        /// </summary>
        /// <param name="typeId">The organisation type id.</param>
        /// <returns>list of VOrganisationTemplateDTO</returns>
        public List<VOrganisationTemplateDTO> GetOrganisationTemplatesforOrganisationType(int typeId)
        {
           
            var dtoList = new List<VOrganisationTemplateDTO>();

            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            //{
            //    var orgTemplates = scope.DbContext.VOrganisationTemplates.Where(item => item.OrganisationTypeID == typeId && !(item.IsDeleted) && item.IsActive).OrderBy(item => item.Name).ToList();

            //    orgTemplates.ToList().ForEach(item =>
            //    {
            //        var dtoTemplate = new VOrganisationTemplateDTO();
            //        dtoTemplate.InjectFrom<NullableInjection>(item);
            //        dtoList.Add(dtoTemplate);
            //    });

            //}

            return dtoList;
        }
    }
}
