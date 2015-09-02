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
    public class AdditionalBuyerLogicController : LogicBase
    {
        public async Task AddAdditionalBuyer(AddAdditionalBuyerDTO addAdditionalBuyerDTO)
        {
            Guid userId;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var userAccount = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.FirstOrDefault(x => x.UserAccountOrganisationID == addAdditionalBuyerDTO.UaoId);
                Ensure.That(userAccount).IsNotNull();
                userId = userAccount.UserID;
            }
            using (var scope = DbContextScopeFactory.Create())
            {
                var address = new Address
                {
                    AddressID = Guid.NewGuid(),
                    Name = string.Empty,
                    Line1 = addAdditionalBuyerDTO.Line1,
                    Line2 = addAdditionalBuyerDTO.Line2,
                    AdditionalAddressInformation = addAdditionalBuyerDTO.AdditionalAddressInformation,
                    Town = addAdditionalBuyerDTO.Town,
                    County = addAdditionalBuyerDTO.County,
                    PostalCode = addAdditionalBuyerDTO.PostalCode
                };
                scope.DbContexts.Get<TargetFrameworkEntities>().Addresses.Add(address);

                var userAccountAddress = new UserAccountAddress
                {
                    UserAccountAddressId = Guid.NewGuid(),
                    AddressId = address.AddressID,
                    UserAccountId = userId
                };
                scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountAddresses.Add(userAccountAddress);

                var uaot = new SmsUserAccountOrganisationTransaction
                {
                    SmsUserAccountOrganisationTransactionId = Guid.NewGuid(),
                    SmsTransactionId = addAdditionalBuyerDTO.TransactionId,
                    UserAccountOrganisationId = addAdditionalBuyerDTO.UaoId,
                    SmsUserAccountOrganisationTransactionTypeId = UserAccountOrganisationTransactionType.AdditionalBuyer.GetIntValue(),
                    UserAccountAddressId = userAccountAddress.UserAccountAddressId
                };
                scope.DbContexts.Get<TargetFrameworkEntities>().SmsUserAccountOrganisationTransactions.Add(uaot);
               
                await scope.SaveChangesAsync();
            }
        }
    }
}
