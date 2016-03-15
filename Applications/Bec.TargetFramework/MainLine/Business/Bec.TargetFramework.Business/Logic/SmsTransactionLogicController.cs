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
    public class SmsTransactionLogicController : LogicBase
    {
        public UserLogicController UserLogic { get; set; }

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
                    if (!await UserLogic.CanEmailBeUsedAsProfessional(editBuyerPartyDto.Dto.UserAccountOrganisation.UserAccount.Email, editBuyerPartyDto.UaoID))
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

        private void ClearAddressDataFields(Address address)
        {
            address.Name = string.Empty;
            address.Line1 = string.Empty;
            address.Line2 = string.Empty;
            address.Town = string.Empty;
            address.County = string.Empty;
            address.PostalCode = string.Empty;
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

    }
}
