﻿using Bec.TargetFramework.Business.Client.Interfaces;
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
using Bec.TargetFramework.Presentation.Web.Models;
using System.Net;

namespace Bec.TargetFramework.Presentation.Web.Areas.SmsTransaction.Controllers
{
    [ClaimsRequired("Add", "SmsTransaction", Order = 1000)]
    public class TransactionController : ApplicationControllerBase
    {
        public IOrganisationLogicClient OrganisationClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }
        public IProductLogicClient ProductClient { get; set; }
        public IUserLogicClient UserClient { get; set; }
        public IBankAccountLogicClient BankAccountClient { get; set; }
        public INotificationLogicClient nClient { get; set; }

        public ActionResult Welcome()
        {
            return PartialView();
        }

        public async Task<ActionResult> Index(Guid? selectedTransactionID, int? pageNumber)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            await PrepareIndexTempData(selectedTransactionID, orgID, pageNumber);

            var select = ODataHelper.Select<VOrganisationWithStatusAndAdminDTO>(x => new { x.Name, x.OrganisationAdminSalutation, x.OrganisationAdminFirstName, x.OrganisationAdminLastName });
            var filter = ODataHelper.Filter<VOrganisationWithStatusAndAdminDTO>(x => x.OrganisationID == orgID);
            var orgs = await QueryClient.QueryAsync<VOrganisationWithStatusAndAdminDTO>("VOrganisationWithStatusAndAdmins", select + filter);
            var org = orgs.First();
            ViewBag.OrganisationName = org.Name;
            ViewBag.HasOrganisationAnySafeBankAccounts = BankAccountClient.HasOrganisationAnySafeBankAccount(orgID);

            return View();
        }

        //jump to given id, reset sort to date
        private async Task PrepareIndexTempData(Guid? selectedTransactionID, Guid orgID, int? pageNumber)
        {
            if (selectedTransactionID.HasValue)
            {
                if (pageNumber.HasValue)
                {
                    TempData["pageNumber"] = pageNumber;
                }
                else
                {
                    TempData["rowNumber"] = await OrganisationClient.GetSmsTransactionRankAsync(orgID, selectedTransactionID.Value);
                    TempData["resetSort"] = true;
                }
                TempData["SmsTransactionID"] = selectedTransactionID;
            }
            else
            {
                TempData["resetSort"] = true;
            }
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
                x.SmsTransaction.IsProductAdvised,
                x.SmsTransaction.ProductAdvisedOn,
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
                PurchasedOn = x.SmsTransaction.Invoice.CreatedOn,
                PurchasedBySalutation = x.SmsTransaction.Invoice.UserAccountOrganisation.Contact.Salutation,
                PurchasedByFirstName = x.SmsTransaction.Invoice.UserAccountOrganisation.Contact.FirstName,
                PurchasedByLastName = x.SmsTransaction.Invoice.UserAccountOrganisation.Contact.LastName,
                x.LatestBankAccountCheck.CheckedOn,
                SmsSrcFundsBankAccounts = x.SmsSrcFundsBankAccounts.Select(s => new { s.AccountNumber, s.SortCode }),
                BankAccountChecks = x.SmsTransaction.SmsUserAccountOrganisationTransactions.Select(y => new
                {
                    Check = y.SmsBankAccountChecks.Select(z => new
                    {
                        z.BankAccountNumber,
                        z.SortCode,
                        z.CheckedOn,
                        z.IsMatch
                    }),
                    SrcOfFunds = y.SmsSrcFundsBankAccounts.Select(z => new
                    {
                        z.AccountNumber,
                        z.SortCode
                    }),
                    PersonaSalutation = y.Contact.Salutation,
                    PersonaFirstName = y.Contact.FirstName,
                    PersonaLastName = y.Contact.LastName,
                    PersonaTypeID = y.SmsUserAccountOrganisationTransactionTypeID,
                    PersonaTypeDescription = y.SmsUserAccountOrganisationTransactionType.Description
                }),
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

            JObject res = await QueryClient.QueryAsync("SmsUserAccountOrganisationTransactions", ODataHelper.RemoveParameters(Request) + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        [ClaimsRequired("Add", "SmsTransaction", Order = 1001)]
        public ActionResult ViewAddSmsTransaction()
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var hasOrganisationAnySafeBankAccounts = BankAccountClient.HasOrganisationAnySafeBankAccount(orgID);
            if (!hasOrganisationAnySafeBankAccounts)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            return PartialView("_AddSmsTransaction");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsRequired("Add", "SmsTransaction", Order = 1001)]
        public async Task<ActionResult> AddSmsTransaction(AddSmsTransactionDTO addSmsTransactionDto)
        {
            var orgID = HttpContext.GetWebUserObject().OrganisationID;
            var uaoID = HttpContext.GetWebUserObject().UaoID;
            var transactionID = await OrganisationClient.AddSmsTransactionAsync(orgID, uaoID, addSmsTransactionDto);
            return RedirectToAction("Index", new { selectedTransactionID = transactionID,  area = "SmsTransaction" });
        }

        [ClaimsRequired("Add", "SmsTransaction", Order = 1001)]
        public async Task<ActionResult> CheckDuplicateUserSmsTransaction(SmsTransactionDTO smsTransactionDTO, string email)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            if (await OrganisationClient.CheckDuplicateUserSmsTransactionAsync(orgID, email, smsTransactionDTO))
            {
                ViewBag.title = "Warning";
                ViewBag.message = "A property transaction already exists for this user at this address. Are you sure that you wish to continue?";
                ViewBag.Buttons = new List<ButtonDefinition>
                {
                    new ButtonDefinition
                    {
                        Id = "cancel",
                        Classes = "btn-default",
                        Text = "Cancel"
                    },
                    new ButtonDefinition
                    {
                        Id = "save",
                        Classes = "btn-primary",
                        Text = "Continue"
                    }
                };
                return PartialView("_Message");
            }
            return Json(new { result = "ok" }, JsonRequestBehavior.AllowGet);
        }

        [ClaimsRequired("Edit", "SmsTransaction", Order = 1001)]
        public async Task<ActionResult> ViewEditSmsTransaction(Guid txID, Guid uaoID, int pageNumber)
        {
            await EnsureSmsTransactionInOrg(txID, WebUserHelper.GetWebUserObject(HttpContext).OrganisationID, QueryClient);
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

            var res = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            var model = res.First();
            ViewBag.IsTemporaryUser = model.UserAccountOrganisation.UserAccount.IsTemporaryAccount;

            return PartialView("_EditSmsTransaction", Edit.MakeModel(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsRequired("Edit", "SmsTransaction", Order = 1001)]
        public async Task<ActionResult> EditSmsTransaction(Guid txID, Guid uaoID)
        {
            try
            {
                await EnsureSmsTransactionInOrg(txID, WebUserHelper.GetWebUserObject(HttpContext).OrganisationID, QueryClient);
                await EnsureSmsTransactionIsNotConfirmed(txID, uaoID, QueryClient);
                var modelEmail = Request.Form["Model.UserAccountOrganisation.UserAccount.Email"];
                await EnsureEmailNotInUse(modelEmail, uaoID, UserClient);

                var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.UserAccountOrganisationID == uaoID && x.SmsTransactionID == txID);
                var data = Edit.fromD(Request.Form,
                    "Contact.Salutation",
                    "Contact.FirstName",
                    "Contact.LastName",
                    "Contact.BirthDate",
                    "Contact.RowVersion",
                    "UserAccountOrganisation.UserAccount.Email",
                    "UserAccountOrganisation.UserAccount.RowVersion");

                await QueryClient.UpdateGraphAsync("SmsUserAccountOrganisationTransactions", data, filter);
                var isUserRegistered = await UserClient.IsUserAccountRegisteredAsync(uaoID);
                if (!isUserRegistered)
                {
                    await UserClient.ChangeUsernameAndEmailAsync(uaoID, modelEmail);
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
            var canGeneratePin = await CanGeneratePin(txID, uaoID, QueryClient);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GeneratePIN(Guid txID, Guid uaoID, int pageNumber)
        {
            await EnsureSmsTransactionInOrg(txID, WebUserHelper.GetWebUserObject(HttpContext).OrganisationID, QueryClient);
            await EnsureCanGeneratePin(txID, uaoID, QueryClient);
            await UserClient.GeneratePinAsync(uaoID, false, true, true);
            return RedirectToAction("Index", new { selectedTransactionID = txID, pageNumber = pageNumber });
        }

        [ClaimsRequired("Edit", "SmsTransaction", Order = 1001)]
        public ActionResult ViewAdviseProduct(Guid transactionId, Guid primaryBuyerUaoId, int pageNumber)
        {
            ViewBag.transactionId = transactionId;
            ViewBag.primaryBuyerUaoId = primaryBuyerUaoId;
            ViewBag.pageNumber = pageNumber;
            return PartialView("_AdviseProduct");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsRequired("Edit", "SmsTransaction", Order = 1001)]
        public async Task<ActionResult> AdviseProduct(Guid transactionId, Guid primaryBuyerUaoId, int pageNumber)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            await EnsureSmsTransactionInOrg(transactionId, orgID, QueryClient);
            await EnsureCanAdviseProduct(transactionId, primaryBuyerUaoId, QueryClient);

            await OrganisationClient.AdviseProductAsync(transactionId, orgID, primaryBuyerUaoId);

            return RedirectToAction("Index", new { selectedTransactionID = transactionId, pageNumber = pageNumber });
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
            if (!isEmailAvailable) throw new InvalidOperationException("The email cannot be used.");
        }

        internal static async Task EnsureCanGeneratePin(Guid txID, Guid uaoID, IQueryLogicClient queryClient)
        {
            var canGeneratePin = await CanGeneratePin(txID, uaoID, queryClient);
            if (!canGeneratePin) throw new InvalidOperationException("Cannot generate the PIN.");
        }

        internal static async Task EnsureCanAdviseProduct(Guid txID, Guid primaryBuyerUaoId, IQueryLogicClient queryClient)
        {
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new { x.SmsUserAccountOrganisationTransactionID });
            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x =>
                x.UserAccountOrganisationID == primaryBuyerUaoId &&
                x.SmsTransactionID == txID &&
                !x.SmsTransaction.IsProductAdvised);

            var res = await queryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            var model = res.FirstOrDefault();
            if (model == null)
            {
                throw new AccessViolationException("Operation failed");
            }
        }

        //public ActionResult ViewSendQuote(Guid txID)
        //{
        //    ViewBag.txID = txID;
        //    return PartialView("_ViewSendQuote");
        //}

        //[HttpPost, ValidateAntiForgeryToken]
        //public async Task<ActionResult> SendQuote(Guid txID, string message, Guid AttachmentsID)
        //{
        //    var orgID = HttpContext.GetWebUserObject().OrganisationID;
        //    var uaoID = HttpContext.GetWebUserObject().UaoID;

        //    var buyerTypeID = UserAccountOrganisationTransactionType.Buyer.GetIntValue();

        //    var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new { x.SmsTransaction.InvoiceID, x.UserAccountOrganisationID });
        //    var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.SmsTransaction.SmsTransactionID == txID && x.SmsTransaction.OrganisationID == orgID && x.SmsUserAccountOrganisationTransactionTypeID == buyerTypeID);
        //    var utxs = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
        //    var utx = utxs.FirstOrDefault();
        //    if (utx == null) throw new AccessViolationException("Operation failed");

        //    await nClient.CreateConversationAsync(orgID, uaoID, AttachmentsID, ActivityType.SmsTransaction, txID, "New Quote", message, true, new Guid[] { utx.UserAccountOrganisationID });

        //    return RedirectToAction("Index", new { selectedTransactionID = txID });
        //}
    }
}