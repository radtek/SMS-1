using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Event;
using Bec.TargetFramework.Entities.DTO.Notification;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Buyer.Controllers
{
    public class SafeBuyerController : ApplicationControllerBase
    {
        public IAddressLogicClient AddressClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }
        public IOrganisationLogicClient OrganisationClient { get; set; }
        public IBankAccountLogicClient BankAccountClient { get; set; }

        public async Task<ActionResult> Index()
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                personaLine1 = x.Address.Line1,
                personaLine2 = x.Address.Line2,
                personaTown = x.Address.Town,
                personaCity = x.Address.City,
                personaCounty = x.Address.County,
                personaPostalCode = x.Address.PostalCode,
                x.Contact.BirthDate,
                x.Confirmed,
                x.SmsTransactionID,
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
                x.SmsUserAccountOrganisationTransactionTypeID,
                x.SmsUserAccountOrganisationTransactionID,
                Names = x.SmsTransaction.Organisation.OrganisationDetails.Select(y => new { y.Name }),
                Status = x.SmsTransaction.Organisation.OrganisationStatus.Select(z => new { z.Notes, z.StatusTypeValue.Name }),
                BankAccounts = x.SmsSrcFundsBankAccounts.Select(b => new { b.SortCode, b.AccountNumber })
            });
            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.UserAccountOrganisationID == uaoID);
            var data = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            return View(data);
        }

        public async Task<ActionResult> ViewConfirmDetails(Guid txID, int index)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            ViewBag.index = index;

            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                x.SmsTransactionID,
                buyerLine1 = x.Address.Line1,
                buyerLine2 = x.Address.Line2,
                buyerTown = x.Address.Town,
                buyerCity = x.Address.City,
                buyerCounty = x.Address.County,
                buyerPostalCode = x.Address.PostalCode,
                x.Confirmed,
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
                x.SmsUserAccountOrganisationTransactionTypeID,
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
            ViewBag.smsUserAccountOrganisationTransactionID = model.SmsUserAccountOrganisationTransactionID;
            
            if(model.Confirmed)
                return PartialView("_CheckBankAccount", model);
            else
                return PartialView("_ConfirmDetails", model);
        }

        [HttpPost]
        public async Task<ActionResult> ConfirmDetails(SmsUserAccountOrganisationTransactionDTO dto, string accountNumber, string sortCode, Guid orgID, int index)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            
            //update tx
            await OrganisationClient.UpdateSmsUserAccountOrganisationTransactionAsync(uaoID, accountNumber, sortCode, dto);
            //check bank account
            var isMatch = await BankAccountClient.CheckBankAccountAsync(orgID, uaoID, dto.SmsUserAccountOrganisationTransactionID, accountNumber, sortCode);
            return Json(new { result = isMatch, index = index, data = dto, accountNumber = accountNumber, sortCode = sortCode }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> CheckBankAccount(Guid orgID, Guid smsUserAccountOrganisationTransactionID, string accountNumber, string sortCode, int index)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            //check bank account
            var isMatch = await BankAccountClient.CheckBankAccountAsync(orgID, uaoID, smsUserAccountOrganisationTransactionID, accountNumber, sortCode);
            return Json(new { result = isMatch, index = index, accountNumber = accountNumber, sortCode = sortCode }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> NotifyOrganisationNoMatch(Guid smsUserAccountOrganisationTransactionID, string accountNumber, string sortCode)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await BankAccountClient.WriteCheckAuditAsync(uaoID, smsUserAccountOrganisationTransactionID, accountNumber, sortCode, false);
            await BankAccountClient.PublishCheckNoMatchNotificationAsync(uaoID, smsUserAccountOrganisationTransactionID, accountNumber, sortCode);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public async Task<ActionResult> GetAudit(Guid uaotxID, Guid orgID)
        {
            //check for ownership via the uao
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            var aSelect = ODataHelper.Select<SmsBankAccountCheckDTO>(a => new { a.CheckedOn, a.IsMatch, a.BankAccountNumber, a.SortCode });
            var aFilter = ODataHelper.Filter<SmsBankAccountCheckDTO>(x => x.SmsUserAccountOrganisationTransactionID == uaotxID && x.SmsUserAccountOrganisationTransaction_SmsUserAccountOrganisationTransactionID.UserAccountOrganisationID == uaoID);

            var r = new List<object>();
            foreach (var res in (await QueryClient.QueryAsync<SmsBankAccountCheckDTO>("SmsBankAccountChecks", aSelect + aFilter)).OrderByDescending(x => x.CheckedOn))
            {
                var accountNumber = res.BankAccountNumber;
                var sortCode = res.SortCode;
                var result = "nomatch";

                if (res.IsMatch)
                {
                    result = "warn";
                    var bSelect = ODataHelper.Select<OrganisationBankAccountDTO>(x => new { x.IsActive, Status = x.OrganisationBankAccountStatus.Select(y => new { y.StatusChangedOn, y.StatusTypeValue.Name }) });
                    var bFilter = ODataHelper.Filter<OrganisationBankAccountDTO>(x => x.OrganisationID == orgID && x.BankAccountNumber == accountNumber && x.SortCode == sortCode);
                    var bas = await QueryClient.QueryAsync<OrganisationBankAccountDTO>("OrganisationBankAccounts", bSelect + bFilter);
                    var ba = bas.SingleOrDefault();
                    if (ba != null && ba.IsActive)
                    {
                        var st = ba.OrganisationBankAccountStatus.OrderByDescending(s => s.StatusChangedOn).FirstOrDefault();
                        if (st.StatusTypeValue.Name == "Safe") result = "match";
                    }
                }
                r.Add(new { date = res.CheckedOn, accountNumber = res.BankAccountNumber, sortCode = res.SortCode, result = result });
            }
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewNoMatch(Guid smsUserAccountOrganisationTransactionID, int index, string accountNumber, string sortCode)
        {
            ViewBag.smsUserAccountOrganisationTransactionID = smsUserAccountOrganisationTransactionID;
            ViewBag.index = index;
            ViewBag.accountNumber = accountNumber;
            ViewBag.sortCode = sortCode;

            return PartialView("_NoMatch");
        }

        public ActionResult ViewMatch(Guid smsUserAccountOrganisationTransactionID, int index, string accountNumber, string sortCode, string companyName)
        {
            ViewBag.smsUserAccountOrganisationTransactionID = smsUserAccountOrganisationTransactionID;
            ViewBag.index = index;
            ViewBag.accountNumber = accountNumber;
            ViewBag.sortCode = sortCode;
            ViewBag.companyName = companyName;

            return PartialView("_Match");
        }
    }
}