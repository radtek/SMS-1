using Bec.TargetFramework.Presentation.Web.App_Helpers;
using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Event;
using Bec.TargetFramework.Entities.DTO.Notification;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Buyer.Controllers
{
    [ClaimsRequired("View", "MyTransactions", Order = 1000)]
    public class SafeBuyerController : ApplicationControllerBase
    {
        public IAddressLogicClient AddressClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }
        public IOrganisationLogicClient OrganisationClient { get; set; }
        public IBankAccountLogicClient BankAccountClient { get; set; }

        public async Task<ActionResult> Index(Guid? selectedTransactionId)
        {
            if (selectedTransactionId.HasValue)
            {
                var model = await GetUaots(selectedTransactionId.Value);
                var uaot = model.FirstOrDefault();
                ViewBag.OrganisationSafeSendEnabled = await OrganisationClient.IsSafeSendEnabledAsync(uaot.SmsTransaction.OrganisationID);
                ViewBag.canEditBirthDate = await CanEditBirthDate(uaot.UserAccountOrganisationID, selectedTransactionId.Value);
                var modelWithUpdates = await uaot.GetFieldUpdates(HttpContext, ActivityType.SmsTransaction, selectedTransactionId.Value, QueryClient);
                return View(modelWithUpdates);
            }
            else
            {
                var uaots = await GetUaots(null);
                var uaotsCount = uaots.Count();
                if (uaotsCount > 0)
                {
                    return View("IndexSelectTransaction", uaots);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        public async Task<ActionResult> ViewCheckBankAccount(Guid txID)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                CompanyNames = x.SmsTransaction.Organisation.OrganisationDetails.Select(y => new { y.Name }),
                x.SmsUserAccountOrganisationTransactionID,
                x.SmsTransaction.InvoiceID
            });

            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.UserAccountOrganisationID == uaoID && x.SmsTransactionID == txID);
            var res = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            var model = res.First();

            if (model.SmsTransaction.InvoiceID.HasValue)
            {
                await EnsureCanCheckBankAccount(model.SmsUserAccountOrganisationTransactionID, uaoID, QueryClient);
                return PartialView("_CheckBankAccount", model);
            }
            else
            {
                await EnsureCanPurchaseProduct(txID, uaoID, QueryClient);
                var cartPricing = await OrganisationClient.EnsureCartAsync(txID, uaoID, PaymentCardTypeIDEnum.Visa_Credit, PaymentMethodTypeIDEnum.Credit_Card);

                if (await OrganisationClient.SmsTransactionQualifiesFreeAsync(txID))
                {
                    return PartialView("_CheckBankAccount", model);
                }
                else
                {
                    ViewBag.txID = txID;
                    ViewBag.cartPricing = cartPricing;
                    ViewBag.ConveyancerName = model.SmsTransaction.Organisation.OrganisationDetails.First().Name;
                    return PartialView("_PurchaseProduct");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckBankAccount(Guid smsUserAccountOrganisationTransactionID, string accountNumber, string sortCode)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                CompanyNames = x.SmsTransaction.Organisation.OrganisationDetails.Select(y => new { y.Name }),
                x.SmsUserAccountOrganisationTransactionID,
                x.SmsTransaction.InvoiceID,
                x.SmsTransactionID
            });

            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.SmsUserAccountOrganisationTransactionID == smsUserAccountOrganisationTransactionID);
            var res = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            var model = res.First();

            if (!model.SmsTransaction.InvoiceID.HasValue)
            {
                if (await OrganisationClient.SmsTransactionQualifiesFreeAsync(model.SmsTransactionID))
                {
                    await EnsureCanPurchaseProduct(model.SmsTransactionID, uaoID, QueryClient);
                    var purchaseProductResult = await OrganisationClient.PurchaseSafeBuyerProductAsync(model.SmsTransactionID, PaymentCardTypeIDEnum.Visa_Credit, PaymentMethodTypeIDEnum.Credit_Card, true, null);
                }
                else
                {
                    return Json(new { failed = true }, JsonRequestBehavior.AllowGet);
                }
            }
            var txOrgID = await EnsureCanCheckBankAccount(smsUserAccountOrganisationTransactionID, uaoID, QueryClient);

            //check bank account
            var isMatch = await BankAccountClient.CheckBankAccountAsync(txOrgID, uaoID, smsUserAccountOrganisationTransactionID, accountNumber, sortCode);
            return Json(new { result = isMatch, accountNumber = accountNumber, sortCode = sortCode }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NotifyOrganisationNoMatch(Guid smsUserAccountOrganisationTransactionID, string accountNumber, string sortCode)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await BankAccountClient.WriteCheckAuditAsync(uaoID, smsUserAccountOrganisationTransactionID, accountNumber, sortCode, false);
            await BankAccountClient.PublishCheckNoMatchNotificationAsync(uaoID, smsUserAccountOrganisationTransactionID, accountNumber, sortCode);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public async Task<ActionResult> GetAudit(Guid uaotxID)
        {
            //check for ownership via the uao
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            var aSelect = ODataHelper.Select<SmsBankAccountCheckDTO>(a => new { a.CheckedOn, a.IsMatch, a.BankAccountNumber, a.SortCode, a.SmsUserAccountOrganisationTransaction_SmsUserAccountOrganisationTransactionID.SmsTransaction.OrganisationID });
            var aFilter = ODataHelper.Filter<SmsBankAccountCheckDTO>(x => x.SmsUserAccountOrganisationTransactionID == uaotxID && x.SmsUserAccountOrganisationTransaction_SmsUserAccountOrganisationTransactionID.UserAccountOrganisationID == uaoID);
            var aOrderBy = ODataHelper.OrderBy<SmsBankAccountCheckDTO>(x => new { x.CheckedOn }) +" desc";

            List<VOrganisationBankAccountsWithStatusDTO> orgBankAccounts = null;
            var r = new List<object>();
            foreach (var res in await QueryClient.QueryAsync<SmsBankAccountCheckDTO>("SmsBankAccountChecks", aSelect + aFilter + aOrderBy))
            {
                //only one org for one tx:
                if (orgBankAccounts == null) 
                    orgBankAccounts = await BankAccountClient.GetOrganisationBankAccountsAsync(res.SmsUserAccountOrganisationTransaction_SmsUserAccountOrganisationTransactionID.SmsTransaction.OrganisationID);

                var result = "nomatch";

                if (res.IsMatch)
                {
                    result = "warn";
                    var ba = orgBankAccounts.SingleOrDefault(x => x.BankAccountNumber == res.BankAccountNumber && x.SortCode == res.SortCode);
                    if (ba != null && ba.IsActive && ba.Status == "Safe")
                        result = "match";
                }
                r.Add(new { date = res.CheckedOn, accountNumber = res.BankAccountNumber, sortCode = res.SortCode, result = result });
            }
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewNoMatch(Guid smsUserAccountOrganisationTransactionID, string accountNumber, string sortCode)
        {
            ViewBag.smsUserAccountOrganisationTransactionID = smsUserAccountOrganisationTransactionID;
            ViewBag.accountNumber = accountNumber;
            ViewBag.sortCode = sortCode;

            return PartialView("_NoMatch");
        }

        public ActionResult ViewMatch(Guid smsUserAccountOrganisationTransactionID, string accountNumber, string sortCode, string companyName)
        {
            ViewBag.smsUserAccountOrganisationTransactionID = smsUserAccountOrganisationTransactionID;
            ViewBag.accountNumber = accountNumber;
            ViewBag.sortCode = sortCode;
            ViewBag.companyName = companyName;

            return PartialView("_Match");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PurchaseProduct(Guid txID, PaymentCardTypeIDEnum cardType, PaymentMethodTypeIDEnum methodType, OrderRequestDTO orderRequest, string accountNumber, string sortCode)
        {
            var currentUserUaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await EnsureCanPurchaseProduct(txID, currentUserUaoId, QueryClient);

            var purchaseProductResult = await OrganisationClient.PurchaseSafeBuyerProductAsync(txID, PaymentCardTypeIDEnum.Visa_Credit, PaymentMethodTypeIDEnum.Credit_Card, false, orderRequest);
            if (purchaseProductResult.IsPaymentSuccessful)
            {
                TempData["PaymentSuccessful"] = true;

                var model = (await GetUaots(txID)).FirstOrDefault();
               
                //check bank account
                var isMatch = await BankAccountClient.CheckBankAccountAsync(model.SmsTransaction.OrganisationID, currentUserUaoId, model.SmsUserAccountOrganisationTransactionID, accountNumber, sortCode);
                return Json(new { paymentresult = true, matchresult = isMatch, accountNumber = accountNumber, sortCode = sortCode }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    paymentresult = false,
                    title = "Payment Unsuccessful",
                    message = purchaseProductResult.ErrorMessage
                }, JsonRequestBehavior.AllowGet);
            }
        }

        private async Task<IEnumerable<SmsUserAccountOrganisationTransactionDTO>> GetUaots(Guid? txId)
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
                x.Contact.Salutation,
                x.Contact.FirstName,
                x.Contact.LastName,
                x.Contact.BirthDate,
                x.CreatedOn,
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
                x.SmsTransaction.InvoiceID,
                x.SmsTransaction.IsProductAdvised,
                x.SmsTransaction.ProductDeclinedOn,
                x.SmsTransaction.ProductAcceptedOn,
                x.SmsUserAccountOrganisationTransactionTypeID,
                x.SmsUserAccountOrganisationTransactionID,
                Names = x.SmsTransaction.Organisation.OrganisationDetails.Select(y => new { y.Name }),
                Status = x.SmsTransaction.Organisation.OrganisationStatus.Select(z => new { z.Notes, z.StatusTypeValue.Name }),
                BankAccounts = x.SmsSrcFundsBankAccounts.Select(b => new { b.SortCode, b.AccountNumber })
            });
            var filter = ODataHelper.Expression<SmsUserAccountOrganisationTransactionDTO>(x => x.UserAccountOrganisationID == uaoID);
            if (txId.HasValue)
            {
                filter = Expression.And(filter, ODataHelper.Expression<SmsUserAccountOrganisationTransactionDTO>(x => x.SmsTransactionID == txId));
            }
            var order = ODataHelper.OrderBy<SmsUserAccountOrganisationTransactionDTO>(x => new { x.CreatedOn });
            var orderByDesc = order + " desc";
            var data = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + ODataHelper.Filter(filter) + orderByDesc);
            return data;
        }

        private async Task<bool> CanEditBirthDate(Guid uaoID, Guid currentSmsTransactionID)
        {
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new { x.SmsUserAccountOrganisationTransactionID });
            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.UserAccountOrganisationID == uaoID && x.SmsTransactionID != currentSmsTransactionID);
            var res = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            return !res.Any();
        }

        internal static async Task EnsureCanPurchaseProduct(Guid txID, Guid uaoID, IQueryLogicClient queryClient)
        {
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new { x.SmsUserAccountOrganisationTransactionID });
            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x =>
                x.UserAccountOrganisationID == uaoID && // uao has transaction
                x.SmsTransactionID == txID && 
                x.SmsTransaction.InvoiceID == null); // it was not purchased yet

            var res = await queryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            var model = res.FirstOrDefault();
            if (model == null)
            {
                throw new AccessViolationException("Operation failed");
            }
        }

        internal static async Task<Guid> EnsureCanCheckBankAccount(Guid uaoTxID, Guid uaoID, IQueryLogicClient queryClient)
        {
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new { x.SmsUserAccountOrganisationTransactionID, x.SmsTransaction.OrganisationID });
            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x =>
                x.UserAccountOrganisationID == uaoID && // uao has transaction
                x.SmsUserAccountOrganisationTransactionID == uaoTxID &&
                x.SmsTransaction.InvoiceID != null); // it was purchased

            var res = await queryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            var model = res.FirstOrDefault();
            if (model == null)
            {
                throw new AccessViolationException("Operation failed");
            }
            return model.SmsTransaction.OrganisationID;
        }

        public async Task<ActionResult> ViewDeclineProduct(Guid txID)
        {
            var currentUserUaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await EnsureCanPurchaseProduct(txID, currentUserUaoId, QueryClient);
            ViewBag.txID = txID;
            return PartialView("_DeclineProduct");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeclineProduct(Guid txID)
        {
            var currentUserUaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await EnsureCanPurchaseProduct(txID, currentUserUaoId, QueryClient);

            var filter = ODataHelper.Filter<SmsTransactionDTO>(x => x.SmsTransactionID == txID);
            await QueryClient.UpdateGraphAsync("SmsTransactions", JObject.FromObject(new { ProductDeclinedOn = DateTime.Now }), filter);

            return RedirectToAction("Index", "SafeBuyer", new { area = "Buyer", selectedTransactionId = txID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AcceptProduct(Guid txID)
        {
            var currentUserUaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await EnsureCanPurchaseProduct(txID, currentUserUaoId, QueryClient);

            var filter = ODataHelper.Filter<SmsTransactionDTO>(x => x.SmsTransactionID == txID);
            await QueryClient.UpdateGraphAsync("SmsTransactions", JObject.FromObject(new { ProductAcceptedOn = DateTime.Now }), filter);

            return RedirectToAction("Index", "SafeBuyer", new { area = "Buyer", selectedTransactionId = txID });
        }
    }
}