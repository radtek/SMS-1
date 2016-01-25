using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Areas.ProOrganisation.Controllers;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers;
using System.Collections.Generic;

namespace Bec.TargetFramework.Presentation.Web.Areas.SmsTransaction.Controllers
{
    [ClaimsRequired("Add", "SmsTransaction", Order = 1000)]
    public class TransactionController : ApplicationControllerBase
    {
        public IOrganisationLogicClient orgClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }
        public IProductLogicClient prodClient { get; set; }
        public IUserLogicClient userClient { get; set; }
        public INotificationLogicClient nClient { get; set; }

        public ActionResult Welcome()
        {
            return PartialView();
        }

        //jump to given id, reset sort to date
        public async Task<ActionResult> Index(Guid? selectedTransactionID)
        {
            if (selectedTransactionID.HasValue)
            {
                var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
                var pageNumber = await orgClient.GetSmsTransactionRankAsync(orgID, selectedTransactionID.Value);

                TempData["SmsTransactionID"] = selectedTransactionID;
                TempData["rowNumber"] = pageNumber;
                TempData["resetSort"] = true;
            }

            return View();
        }

        //jump to given record, hope it's on the stated page
        public ActionResult Selected(Guid selectedTransactionID, int pageNumber)
        {
            TempData["SmsTransactionID"] = selectedTransactionID;
            TempData["pageNumber"] = pageNumber;
            return View("Index");
        }

        public async Task<ActionResult> GetSmsTransactions(string search)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                x.SmsTransactionID,
                x.SmsTransaction.Reference,
                x.SmsTransaction.Address.Line1,
                x.SmsTransaction.Address.Line2,
                x.SmsTransaction.Address.Town,
                x.SmsTransaction.Address.County,
                x.SmsTransaction.Address.PostalCode,
                x.SmsTransaction.Address.AdditionalAddressInformation,
                x.SmsTransaction.CreatedOn,
                x.SmsTransaction.CreatedBy,
                x.SmsTransaction.LenderName,
                x.SmsTransaction.MortgageApplicationNumber,
                x.SmsTransaction.Price,
                x.SmsTransaction.InvoiceID,
                x.Confirmed,
                x.Contact.Salutation,
                x.Contact.FirstName,
                x.Contact.LastName,
                x.Contact.BirthDate,
                x.UserAccountOrganisationID,
                x.UserAccountOrganisation.UserAccount.Email,
                x.UserAccountOrganisation.UserAccount.IsTemporaryAccount,
                x.UserAccountOrganisation.UserAccount.LastLogin,
                x.UserAccountOrganisation.PinCode,
                x.LatestBankAccountCheck.CheckedOn,
                SmsSrcFundsBankAccounts = x.SmsSrcFundsBankAccounts.Select(s => new { s.AccountNumber, s.SortCode })
            });

            var buyerTypeID = UserAccountOrganisationTransactionType.Buyer.GetIntValue();
            var sellerTypeID = UserAccountOrganisationTransactionType.Seller.GetIntValue();
            var where = ODataHelper.Expression<SmsUserAccountOrganisationTransactionDTO>(x =>
                x.SmsTransaction.OrganisationID == orgID &&
                (
                    x.SmsUserAccountOrganisationTransactionTypeID == buyerTypeID ||
                    x.SmsUserAccountOrganisationTransactionTypeID == sellerTypeID
                ));

            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim().ToLower();
                where = Expression.And(where, ODataHelper.Expression<SmsUserAccountOrganisationTransactionDTO>(x =>
                    x.SmsTransaction.Reference.ToLower().Contains(search) ||
                    x.UserAccountOrganisation.UserAccount.Email.ToLower().Contains(search) ||
                    x.SmsTransaction.Address.Line1.ToLower().Contains(search) ||
                    x.SmsTransaction.Address.PostalCode.ToLower().Contains(search)
                    ));
            }
            var filter = ODataHelper.Filter(where);

            JObject res = await queryClient.QueryAsync("SmsUserAccountOrganisationTransactions", ODataHelper.RemoveParameters(Request) + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public async Task<ActionResult> ViewEditSmsTransaction(Guid txID, Guid uaoID, int pageNumber)
        {
            ViewBag.txId = txID;
            ViewBag.uaoId = uaoID;
            ViewBag.pageNumber = pageNumber;
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                x.SmsTransactionID,
                x.SmsUserAccountOrganisationTransactionID,
                x.Contact.Salutation,
                x.Contact.FirstName,
                x.Contact.LastName,
                x.Contact.BirthDate,
                ContactRowVersion = x.Contact.RowVersion,
                x.UserAccountOrganisation.UserAccount.Email,
                x.UserAccountOrganisation.UserAccount.IsTemporaryAccount,
                UserAccountRowVersion = x.UserAccountOrganisation.UserAccount.RowVersion
            });

            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x =>
                x.UserAccountOrganisationID == uaoID && x.SmsTransactionID == txID);

            var res = await queryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            var model = res.First();
            ViewBag.IsTemporaryUser = model.UserAccountOrganisation.UserAccount.IsTemporaryAccount;

            return PartialView("_EditSmsTransaction", Edit.MakeModel(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditSmsTransaction(Guid txID, Guid uaoID)
        {
            try
            {
                await EnsureSmsTransactionInOrg(txID, WebUserHelper.GetWebUserObject(HttpContext).OrganisationID, queryClient);
                await EnsureSmsTransactionIsNotConfirmed(txID, uaoID, queryClient);
                var modelEmail = Request.Form["Model.UserAccountOrganisation.UserAccount.Email"];
                await EnsureEmailNotInUse(modelEmail, uaoID, userClient);
                
                var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.UserAccountOrganisationID == uaoID && x.SmsTransactionID == txID);
                var data = Edit.fromD(Request.Form,
                    "Contact.Salutation",
                    "Contact.FirstName",
                    "Contact.LastName",
                    "Contact.BirthDate",
                    "Contact.RowVersion",
                    "UserAccountOrganisation.UserAccount.Email",
                    "UserAccountOrganisation.UserAccount.RowVersion");

                await queryClient.UpdateGraphAsync("SmsUserAccountOrganisationTransactions", data, filter);

                var isUserRegistered = await userClient.IsUserAccountRegisteredAsync(uaoID);
                if (!isUserRegistered)
                {
                    await userClient.ChangeUsernameAndEmailAsync(uaoID, modelEmail);
                }

                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    title = "Edit Transaction Failed",
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> ViewGeneratePIN(Guid txID, Guid uaoID, string email, int pageNumber)
        {
            var canGeneratePin = await CanGeneratePin(txID, uaoID, queryClient);
            if (!canGeneratePin)
            {
                ViewBag.title = "Information";
                ViewBag.message = "The PIN cannot be generated for that user. Most probably the user has already logged in to the system. Refresh the page and check the details again.";
                ViewBag.button = "Close";
                
                return PartialView("_Message");
            }

            ViewBag.txID = txID;
            ViewBag.uaoID = uaoID;
            ViewBag.email = email;
            ViewBag.pageNumber = pageNumber;
            return PartialView("_ViewGeneratePIN");
        }

        public async Task<ActionResult> GeneratePIN(Guid txID, Guid uaoID, int pageNumber)
        {
            TempData["SmsTransactionID"] = txID;
            TempData["pageNumber"] = pageNumber;
            await EnsureSmsTransactionInOrg(txID, WebUserHelper.GetWebUserObject(HttpContext).OrganisationID, queryClient);
            await EnsureCanGeneratePin(txID, uaoID, queryClient);

            await userClient.GeneratePinAsync(uaoID, false, true, true);

            return RedirectToAction("Index");
        }

        internal static async Task<bool> CanGeneratePin(Guid txID, Guid uaoID, IQueryLogicClient queryClient)
        {
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new { x.SmsUserAccountOrganisationTransactionID });
            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x =>
                x.UserAccountOrganisationID == uaoID &&
                x.SmsTransactionID == txID &&
                x.UserAccountOrganisation.UserAccount.IsTemporaryAccount == true);

            var res = await queryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            var model = res.FirstOrDefault();

            return model != null;
        }

        internal static async Task EnsureSmsTransactionInOrg(Guid txID, Guid orgID, IQueryLogicClient client)
        {
            var select = ODataHelper.Select<SmsTransactionDTO>(x => new { x.OrganisationID });
            var filter = ODataHelper.Filter<SmsTransactionDTO>(x => x.SmsTransactionID == txID);
            dynamic ret = await client.QueryAsync("SmsTransactions", select + filter);
            if (ret.Items.First.OrganisationID != orgID) throw new AccessViolationException("Operation failed");
        }

        internal static async Task EnsureSmsTransactionIsNotConfirmed(Guid txID, Guid uaoId, IQueryLogicClient client)
        {
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new { x.Confirmed });
            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.SmsTransactionID == txID && x.UserAccountOrganisationID == uaoId);
            dynamic ret = await client.QueryAsync("SmsUserAccountOrganisationTransactions", select + filter);
            if ((bool)ret.Items.First.Confirmed) throw new AccessViolationException("Operation failed");
        }

        internal static async Task EnsureEmailNotInUse(string email, Guid? uaoID, IUserLogicClient userLogic)
        {
            var isEmailAvailable = await userLogic.CanEmailBeUsedAsProfessionalAsync(email, uaoID);
            if (!isEmailAvailable) throw new InvalidOperationException("The e-mail cannot be used.");
        }

        internal static async Task EnsureCanGeneratePin(Guid txID, Guid uaoID, IQueryLogicClient queryClient)
        {
            var canGeneratePin = await CanGeneratePin(txID, uaoID, queryClient);
            if (!canGeneratePin) throw new InvalidOperationException("Cannot generate the PIN.");
        }

        public ActionResult ViewSendQuote(Guid txID)
        {
            ViewBag.txID = txID;
            return PartialView("_ViewSendQuote");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> SendQuote(Guid txID, string message, Guid AttachmentsID)
        {
            var orgID = HttpContext.GetWebUserObject().OrganisationID;
            var uaoID = HttpContext.GetWebUserObject().UaoID;

            var buyerTypeID = UserAccountOrganisationTransactionType.Buyer.GetIntValue();

            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new { x.SmsTransaction.InvoiceID, x.UserAccountOrganisationID });
            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.SmsTransaction.SmsTransactionID == txID && x.SmsTransaction.OrganisationID == orgID && x.SmsUserAccountOrganisationTransactionTypeID == buyerTypeID);
            var utxs = await queryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            var utx = utxs.FirstOrDefault();
            if (utx == null) throw new AccessViolationException("Operation failed");

            await nClient.CreateConversationAsync(orgID, uaoID, AttachmentsID, ActivityType.SmsTransaction, txID, "New Quote", message, new Guid[] { utx.UserAccountOrganisationID });

            return RedirectToAction("Index", new { selectedTransactionID = txID });
        }
    }
}