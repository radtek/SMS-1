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

namespace Bec.TargetFramework.Presentation.Web.Areas.SmsTransaction.Controllers
{
    [ClaimsRequired("Add", "SmsTransaction", Order = 1000)]
    public class TransactionController : ApplicationControllerBase
    {
        public IOrganisationLogicClient orgClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }
        public IProductLogicClient prodClient { get; set; }
        public IUserLogicClient userClient { get; set; }

        public ActionResult Welcome()
        {
            return PartialView();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Selected(Guid selectedTransactionID, int pageNumber)
        {
            TempData["SmsTransactionID"] = selectedTransactionID;
            TempData["pageNumber"] = pageNumber;
            return RedirectToAction("Index");
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
                x.Confirmed,
                x.Contact.Salutation,
                x.Contact.FirstName,
                x.Contact.LastName,
                x.Contact.BirthDate,
                x.UserAccountOrganisationID,
                x.UserAccountOrganisation.UserAccount.Email,
                x.UserAccountOrganisation.UserAccount.IsTemporaryAccount,
                x.UserAccountOrganisation.UserAccount.Created,
                x.UserAccountOrganisation.PinCode
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
                    await userClient.ChangeUsernameAndEmailAsync(uaoID, Request.Form["Model.UserAccountOrganisation.UserAccount.Email"]);
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

        public ActionResult ViewGeneratePIN(Guid txID, Guid uaoID, string email, int pageNumber)
        {
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

            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new { x.SmsUserAccountOrganisationTransactionID });
            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x =>
                x.UserAccountOrganisationID == uaoID &&
                x.SmsTransactionID == txID &&
                x.UserAccountOrganisation.UserAccount.IsTemporaryAccount == true);

            var res = await queryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            var model = res.FirstOrDefault();
            if (model == null) throw new AccessViolationException("Operation failed");

            await userClient.GeneratePinAsync(uaoID, false, true);

            return RedirectToAction("Index");
        }
    }
}