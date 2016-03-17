using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.Extensions;
using Bec.TargetFramework.Business.Product.Processor;
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
using Bec.TargetFramework.Transfer.Client.Interfaces;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class SmsTransactionLogicController : LogicBase
    {
        public TFSettingsLogicController Settings { get; set; }
        public OrganisationLogicController OrganisationLogic { get; set; }
        public UserLogicController UserLogic { get; set; }
        public PaymentLogicController PaymentLogic { get; set; }
        public InvoiceLogicController InvoiceLogic { get; set; }
        public ShoppingCartLogicController ShoppingCartLogic { get; set; }
        public ProductLogicController ProductLogic { get; set; }
        public TransactionOrderLogicController TransactionOrderLogic { get; set; }
        public NotificationLogicController NotificationLogic { get; set; }
        public IEventPublishLogicClient EventPublishClient { get; set; }
        public ITransferInterfaceLogicClient SiraTransferClient { get; set; }

        public async Task<Guid> AddSmsTransaction(AddSmsTransactionDTO dto, Guid orgID, Guid uaoID)
        {
            var transactionId = await SaveSmsTransaction(dto.SmsTransactionDTO, orgID, uaoID);

            var assignBuyerPartyToTransactionDto = new AssignBuyerPartyToTransactionDTO
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
            await AssignBuyerPartyToTransaction(assignBuyerPartyToTransactionDto);
            return transactionId;
        }

        private async Task<Guid> SaveSmsTransaction(SmsTransactionDTO dto, Guid orgID, Guid uaoID)
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
                    CreatedByUserAccountOrganisationID = uaoID
                };

                scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.Add(tx);

                await scope.SaveChangesAsync();
                return tx.SmsTransactionID;
            }
        }

        public async Task EditSmsTransaction(EditSmsTransactionDTO editSmsTransactionDto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var storedTx = scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.Single(x => x.SmsTransactionID == editSmsTransactionDto.TxID && x.OrganisationID == editSmsTransactionDto.OrgID);
                storedTx.LenderName = editSmsTransactionDto.Dto.LenderName;
                storedTx.MortgageApplicationNumber = editSmsTransactionDto.Dto.MortgageApplicationNumber;
                storedTx.Price = editSmsTransactionDto.Dto.Price;
                storedTx.Reference = editSmsTransactionDto.Dto.Reference;

                if (editSmsTransactionDto.Dto.Address.AreAllMandatoryFieldsSet())
                {
                    storedTx.Address = GetAddressWithUpdates(storedTx.Address, editSmsTransactionDto.Dto.Address, editSmsTransactionDto.TxID);
                }
                else if (storedTx.Address != null)
                {
                    ClearAddressDataFields(storedTx.Address);
                }

                await RemovePendingUpdates(editSmsTransactionDto.FieldUpdates ?? Enumerable.Empty<FieldUpdateDTO>());
                await scope.SaveChangesAsync();
            }
        }

        public async Task AssignBuyerPartyToTransaction(AssignBuyerPartyToTransactionDTO assignBuyerPartyToTransactionDTO)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var transaction = scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.FirstOrDefault(x => x.SmsTransactionID == assignBuyerPartyToTransactionDTO.TransactionID);
                Ensure.That(transaction).IsNotNull();
                if (transaction.OrganisationID != assignBuyerPartyToTransactionDTO.AssigningByOrganisationID)
                {
                    Logger.Fatal("The organisation with id: {0} is trying to assign sms client to the transaction with id: {1}",
                        assignBuyerPartyToTransactionDTO.AssigningByOrganisationID, assignBuyerPartyToTransactionDTO.TransactionID);
                    throw new InvalidOperationException("The transaction does not belong to the current user's organisation.");
                }
            }

            var res = await AddBuyerParty(
                assignBuyerPartyToTransactionDTO.Salutation,
                assignBuyerPartyToTransactionDTO.FirstName,
                assignBuyerPartyToTransactionDTO.LastName,
                assignBuyerPartyToTransactionDTO.Email,
                assignBuyerPartyToTransactionDTO.PhoneNumber,
                assignBuyerPartyToTransactionDTO.BirthDate);

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
                    SmsTransactionID = assignBuyerPartyToTransactionDTO.TransactionID,
                    UserAccountOrganisationID = buyerUaoID,
                    SmsUserAccountOrganisationTransactionTypeID = assignBuyerPartyToTransactionDTO.UserAccountOrganisationTransactionType.GetIntValue(),
                    Address = GetNewAddress(assignBuyerPartyToTransactionDTO.RegisteredHomeAddress, uaoTxID),
                    ContactID = contactId,
                    CreatedBy = UserNameService.UserName
                };
                scope.DbContexts.Get<TargetFrameworkEntities>().SmsUserAccountOrganisationTransactions.Add(uaot);
                await AddSrcFundsBankAccounts(assignBuyerPartyToTransactionDTO.SmsSrcFundsBankAccounts, uaoTxID);
                await scope.SaveChangesAsync();
            }
        }

        private Address GetNewAddress(AddressDTO addressDTO, Guid parentID)
        {
            return new Address
            {
                AddressID = Guid.NewGuid(),
                ParentID = parentID,
                Line1 = addressDTO.Line1 ?? string.Empty,
                Line2 = addressDTO.Line2 ?? string.Empty,
                Town = addressDTO.Town ?? string.Empty,
                County = addressDTO.County ?? string.Empty,
                PostalCode = addressDTO.PostalCode ?? string.Empty,
                AddressTypeID = AddressTypeIDEnum.Work.GetIntValue(),
                Name = string.Empty,
                IsPrimaryAddress = true,
                CreatedOn = DateTime.Now,
                CreatedBy = UserNameService.UserName
            };
        }

        private async Task<Tuple<Guid, Guid>> AddBuyerParty(string salutation, string firstName, string lastName, string email, string phoneNumber, DateTime birthDate)
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
                var personalOrgID = await OrganisationLogic.AddOrganisationAsync(defaultOrganisation, companyDTO);
                var addNewUserDto = new AddNewUserToOrganisationDTO
                {
                    OrganisationID = personalOrgID.Value,
                    ContactDTO = contactDTO,
                    UserType = UserTypeEnum.User,
                    AddDefaultRoles = true,
                    SafeSendGroups = Enumerable.Empty<Guid>(),
                    Roles = Enumerable.Empty<Guid>()
                };
                var buyerUaoDto = await OrganisationLogic.AddNewUserToOrganisationAsync(addNewUserDto);
                await UserLogic.GeneratePinAsync(buyerUaoDto.UserAccountOrganisationID, false, false, true);

                return Tuple.Create(buyerUaoDto.UserAccountOrganisationID, buyerUaoDto.PrimaryContactID.Value);
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

        public async Task EditBuyerParty(EditBuyerPartyDTO editBuyerPartyDto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var storedUaotx = scope.DbContexts.Get<TargetFrameworkEntities>().SmsUserAccountOrganisationTransactions.Single(x => x.SmsTransactionID == editBuyerPartyDto.TxID && x.UserAccountOrganisationID == editBuyerPartyDto.UaoID);
                storedUaotx.Contact.Salutation = editBuyerPartyDto.Dto.Contact.Salutation;
                storedUaotx.Contact.FirstName = editBuyerPartyDto.Dto.Contact.FirstName;
                storedUaotx.Contact.LastName = editBuyerPartyDto.Dto.Contact.LastName;

                if (editBuyerPartyDto.Dto.Contact.BirthDate.HasValue)
                {
                    storedUaotx.Contact.BirthDate = editBuyerPartyDto.Dto.Contact.BirthDate;
                }

                if (editBuyerPartyDto.Dto.Address.AreAllMandatoryFieldsSet())
                {
                    storedUaotx.Address = GetAddressWithUpdates(storedUaotx.Address, editBuyerPartyDto.Dto.Address, storedUaotx.SmsUserAccountOrganisationTransactionID);
                }
                else if (storedUaotx.Address != null)
                {
                    ClearAddressDataFields(storedUaotx.Address);
                }

                await RemovePendingUpdates(editBuyerPartyDto.FieldUpdates ?? Enumerable.Empty<FieldUpdateDTO>());

                var isUserRegistered = UserLogic.IsUserAccountRegistered(editBuyerPartyDto.UaoID);
                if (!isUserRegistered)
                {
                    if (string.IsNullOrWhiteSpace(editBuyerPartyDto.Dto.UserAccountOrganisation.UserAccount.Email))
                    {
                        throw new InvalidOperationException("The email cannot be empty.");
                    }
                    if (!UserLogic.CanEmailBeUsedAsProfessional(editBuyerPartyDto.Dto.UserAccountOrganisation.UserAccount.Email, editBuyerPartyDto.UaoID))
                    {
                        throw new InvalidOperationException("The email cannot be changed.");
                    }
                    storedUaotx.UserAccountOrganisation.UserAccount.Email = editBuyerPartyDto.Dto.UserAccountOrganisation.UserAccount.Email;
                    await UserLogic.ChangeUsernameAndEmail(editBuyerPartyDto.UaoID, editBuyerPartyDto.Dto.UserAccountOrganisation.UserAccount.Email);
                }

                await scope.SaveChangesAsync();
            }
        }

        private Address GetAddressWithUpdates(Address targetAddress, AddressDTO updatedAddressDto, Guid parentID)
        {
            if (targetAddress == null)
            {
                targetAddress = new Address
                {
                    AddressID = Guid.NewGuid(),
                    ParentID = parentID,
                    AddressTypeID = AddressTypeIDEnum.Home.GetIntValue(),
                    Name = string.Empty
                };
            }
            targetAddress.Line1 = updatedAddressDto.Line1;
            targetAddress.Line2 = updatedAddressDto.Line2;
            targetAddress.Town = updatedAddressDto.Town;
            targetAddress.County = updatedAddressDto.County;
            targetAddress.PostalCode = updatedAddressDto.PostalCode;

            return targetAddress;
        }

        private async Task RemovePendingUpdates(IEnumerable<FieldUpdateDTO> updates)
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

        private void ClearAddressDataFields(Address address)
        {
            address.Name = string.Empty;
            address.Line1 = string.Empty;
            address.Line2 = string.Empty;
            address.Town = string.Empty;
            address.County = string.Empty;
            address.PostalCode = string.Empty;
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

        public int GetSmsTransactionRank(Guid orgID, Guid txID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().FnSmsTransactionRank(orgID, txID).Value;
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

        public IEnumerable<SmsTransactionPendingUpdateCountDTO> SmsTransactionPendingUpdateCount(IEnumerable<Guid> ids)
        {
            var activityTypeID = ActivityType.SmsTransaction.GetIntValue();
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().FieldUpdates
                    .Where(x => x.ActivityType == activityTypeID && ids.Contains(x.ActivityID))
                    .GroupBy(x => x.ActivityID)
                    .Select(x => new SmsTransactionPendingUpdateCountDTO { SmsTransactionID = x.Key, PendingChangesCount = x.Count() }).ToList();
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
                var resolved = SmsTransactionHelper.ResolveSmsTransactionUpdates(scope, approved, uaoID, DateTime.Now, updates);

                if (resolved.Count > 0)
                {
                    var notificationConstruct = NotificationLogic.GetLatestNotificationConstructIdFromName("Message");
                    var message = ConstructMessageFromUpdates(resolved);
                    var notificationDto = new NotificationDTO
                    {
                        CreatedByUserAccountOrganisationID = uaoID,
                        DateSent = DateTime.Now,
                        NotificationConstructID = notificationConstruct.NotificationConstructID,
                        NotificationConstructVersionNumber = notificationConstruct.NotificationConstructVersionNumber,
                        NotificationData = JsonHelper.SerializeData(new { Message = message }),
                        NotificationRecipients = new List<NotificationRecipientDTO> { new NotificationRecipientDTO { UserAccountOrganisationID = approved.CreatedByUserAccountOrganisationID } }
                    };
                    await NotificationLogic.SaveNotificationConversationAsync(notificationDto, txID, ActivityType.SmsTransaction, "Pending Changes", false);
                }
                await scope.SaveChangesAsync();
            }
        }

        private string ConstructMessageFromUpdates(List<ResolvedUpdate> updates)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The following changes have been requested:");
            foreach (var update in updates)
            {
                sb.AppendLine();
                sb.AppendFormat("{0}: {1}", update.Source, update.NewValue.ValueOr("[Removed]"));
            }
            return sb.ToString();
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
                var primaryBuyer = tx.SmsUserAccountOrganisationTransactions.Where(x => x.SmsUserAccountOrganisationTransactionType.Name == "Buyer").Single();

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
    }
}
