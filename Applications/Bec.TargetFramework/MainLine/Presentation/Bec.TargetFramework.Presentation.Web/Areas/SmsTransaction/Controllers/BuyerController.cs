using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Helpers;
using System;
using Bec.TargetFramework.Entities.Enums;
using System.Linq.Expressions;
using Bec.TargetFramework.Entities.DTO;
using System.Collections.Generic;

namespace Bec.TargetFramework.Presentation.Web.Areas.SmsTransaction.Controllers
{
    public class BuyerController : ApplicationControllerBase
    {
        public IAddressLogicClient AddressClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }

        public IOrganisationLogicClient orgClient { get; set; }

        public async Task<ActionResult> Index()
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                buyerLine1 = x.Address.Line1,
                buyerLine2 = x.Address.Line2,
                buyerTown = x.Address.Town,
                buyerCity = x.Address.City,
                buyerCounty = x.Address.County,
                buyerPostalCode = x.Address.PostalCode,
                x.SmsTransaction.Confirmed,
                x.SmsTransaction.Price,
                x.SmsTransaction.LenderName,
                x.SmsTransaction.MortgageApplicationNumber,
                x.SmsTransaction.OrganisationID,
                x.SmsTransaction.Address.Line1,
                x.SmsTransaction.Address.Line2,
                x.SmsTransaction.Address.Town,
                x.SmsTransaction.Address.City,
                x.SmsTransaction.Address.County,
                x.SmsTransaction.Address.PostalCode,
                Names = x.SmsTransaction.Organisation.OrganisationDetails.Select(y => new { y.Name, y.TradingName })
            });
            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.UserAccountOrganisationID == uaoID);
            var data = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            return View(data);
        }

        public async Task<ActionResult> ViewConfirmDetails(Guid txID, int index)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            ViewBag.index = index;
            ViewBag.txID = txID;

            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                x.SmsTransactionID,
                buyerLine1 = x.Address.Line1,
                buyerLine2 = x.Address.Line2,
                buyerTown = x.Address.Town,
                buyerCity = x.Address.City,
                buyerCounty = x.Address.County,
                buyerPostalCode = x.Address.PostalCode,
                x.SmsTransaction.Confirmed,
                x.SmsTransaction.Price,
                x.SmsTransaction.LenderName,
                x.SmsTransaction.MortgageApplicationNumber,
                x.SmsTransaction.OrganisationID,
                x.SmsTransaction.Address.Line1,
                x.SmsTransaction.Address.Line2,
                x.SmsTransaction.Address.Town,
                x.SmsTransaction.Address.City,
                x.SmsTransaction.Address.County,
                x.SmsTransaction.Address.PostalCode,
                x.SmsUserAccountOrganisationTransactionID,
                x.Contact.Salutation,
                x.Contact.FirstName,
                x.Contact.LastName,
                x.Contact.BirthDate,
                ContactRowVersion = x.Contact.RowVersion,
                TxRowVersion = x.SmsTransaction.RowVersion
            });

            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.UserAccountOrganisationID == uaoID && x.SmsTransactionID == txID);

            var res = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            var model = res.First();

            ViewBag.orgID = model.SmsTransaction.OrganisationID;

            if(model.SmsTransaction.Confirmed)
                return PartialView("_CheckBankAccount");
            else
                return PartialView("_ConfirmDetails", model);
        }

        [HttpPost]
        public async Task<ActionResult> ConfirmDetails(SmsUserAccountOrganisationTransactionDTO dto, string accountNumber, string sortCode, Guid orgID, int index)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            
            //update tx
            await orgClient.UpdateSmsUserAccountOrganisationTransactionAsync(uaoID, accountNumber, sortCode, dto);

            //check bank account
            string safe = BankAccountStatusEnum.Safe.GetStringValue();
            var select2 = ODataHelper.Select<VOrganisationBankAccountsWithStatusDTO>(x => new { x.OrganisationBankAccountID }, false);
            var filter2 = ODataHelper.Filter<VOrganisationBankAccountsWithStatusDTO>(x => x.BankAccountNumber == accountNumber && x.SortCode == sortCode && x.Status == safe && x.OrganisationID == orgID);

            var matches = await QueryClient.QueryAsync<VOrganisationBankAccountsWithStatusDTO>("VOrganisationBankAccountsWithStatus", select2 + filter2);
            return Json(new { result = matches.Any(), index = index, data = dto, accountNumber = accountNumber, sortCode = sortCode }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> CheckBankAccount(string accountNumber, string sortCode, Guid txID, Guid orgID, int index)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            //check bank account
            string safe = BankAccountStatusEnum.Safe.GetStringValue();
            var select2 = ODataHelper.Select<VOrganisationBankAccountsWithStatusDTO>(x => new { x.OrganisationBankAccountID }, false);
            var filter2 = ODataHelper.Filter<VOrganisationBankAccountsWithStatusDTO>(x => x.BankAccountNumber == accountNumber && x.SortCode == sortCode && x.Status == safe && x.OrganisationID == orgID);

            var matches = await QueryClient.QueryAsync<VOrganisationBankAccountsWithStatusDTO>("VOrganisationBankAccountsWithStatus", select2 + filter2);
            return Json(new { result = matches.Any(), index = index, accountNumber = accountNumber, sortCode = sortCode }, JsonRequestBehavior.AllowGet);
        }
    }
}