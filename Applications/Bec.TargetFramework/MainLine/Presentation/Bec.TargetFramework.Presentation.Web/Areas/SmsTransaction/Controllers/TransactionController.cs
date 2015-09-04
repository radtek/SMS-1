using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
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

        public ActionResult Index(Guid? selectedTransactionID)
        {
            if (selectedTransactionID.HasValue)
            {
                TempData["SmsTransactionID"] = selectedTransactionID;
            }
            return View();
        }

        public async Task<ActionResult> GetSmsTransactions(string search)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                x.SmsTransaction.SmsTransactionID,
                x.SmsTransaction.Reference,
                x.SmsTransaction.Address.Line1,
                x.SmsTransaction.Address.Line2,
                x.SmsTransaction.Address.Town,
                x.SmsTransaction.Address.County,
                x.SmsTransaction.Address.PostalCode,
                x.SmsTransaction.Address.AdditionalAddressInformation,
                x.SmsTransaction.CreatedOn,
                x.UserAccountOrganisation.Contact.Salutation,
                x.UserAccountOrganisation.Contact.FirstName,
                x.UserAccountOrganisation.Contact.LastName,
                x.UserAccountOrganisation.Contact.BirthDate,
                x.UserAccountOrganisation.UserAccount.Email,
                x.UserAccountOrganisation.UserAccount.IsTemporaryAccount,
                Addresses = x.UserAccountOrganisation.Contact.Addresses.Select(a =>
                    new
                    {
                        a.Line1,
                        a.Line2,
                        a.Town,
                        a.County,
                        a.PostalCode,
                        a.AdditionalAddressInformation,
                        a.IsPrimaryAddress
                    })
            });

            var buyerTypeId = UserAccountOrganisationTransactionType.Buyer.GetIntValue();
            var sellerTypeId = UserAccountOrganisationTransactionType.Seller.GetIntValue();
            var where = ODataHelper.Expression<SmsUserAccountOrganisationTransactionDTO>(x =>
                x.SmsTransaction.OrganisationID == orgID &&
                (
                    x.SmsUserAccountOrganisationTransactionTypeId == buyerTypeId ||
                    x.SmsUserAccountOrganisationTransactionTypeId == sellerTypeId
                ));

            if (!string.IsNullOrEmpty(search))
            {
                where = Expression.And(where, ODataHelper.Expression<SmsUserAccountOrganisationTransactionDTO>(x =>
                    x.SmsTransaction.Reference.ToLower().Contains(search) ||
                    x.SmsTransaction.Address.Line1.ToLower().Contains(search) ||
                    x.SmsTransaction.Address.PostalCode.ToLower().Contains(search)
                    ));
            }
            var filter = ODataHelper.Filter(where);

            JObject res = await queryClient.QueryAsync("SmsUserAccountOrganisationTransactions", Request.QueryString + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public async Task<ActionResult> ViewEditSmsTransaction(Guid txID, Guid uaoID)
        {
            ViewBag.txId = txID;
            ViewBag.uaoId = uaoID;
            var select = ODataHelper.Select<UserAccountOrganisationDTO>(x => new
            {
                x.UserAccountOrganisationID,
                x.Contact.Salutation,
                x.Contact.FirstName,
                x.Contact.LastName,
                x.UserAccount.Email,
                x.UserAccount.IsTemporaryAccount
            }, true);

            var filter = ODataHelper.Filter<UserAccountOrganisationDTO>(x =>
                x.UserAccountOrganisationID == uaoID);

            var res = await queryClient.QueryAsync<UserAccountOrganisationDTO>("UserAccountOrganisations", select + filter);
            var model = res.First();
            ViewBag.IsTemporaryUser = model.UserAccount.IsTemporaryAccount;

            return PartialView("_EditSmsTransaction", Edit.MakeModel(model));
        }

        [HttpPost]
        public async Task<ActionResult> EditSmsTransaction(Guid txID, Guid uaoID)
        {
            var filter = ODataHelper.Filter<UserAccountOrganisationDTO>(x => x.UserAccountOrganisationID == uaoID);
            var data = Edit.fromD(Request.Form);

            await queryClient.UpdateGraphAsync("UserAccountOrganisations", data, filter);
            return RedirectToAction("Index", new { selectedTransactionID = txID });
        }

        public async Task<ActionResult> ViewResendLogins(Guid txID, string label)
        {
            var buyerTypeId = UserAccountOrganisationTransactionType.Buyer.GetIntValue();
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new { x.UserAccountOrganisationId });
            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => 
                x.SmsTransactionId == txID &&
                x.SmsUserAccountOrganisationTransactionTypeId == buyerTypeId);
            var res = await queryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);

            ViewBag.txID = txID;
            ViewBag.uaoId = res.First().UserAccountOrganisationId;
            ViewBag.label = label;
            ViewBag.RedirectAction = "ResendLogins";
            ViewBag.RedirectController = "Transaction";
            ViewBag.RedirectArea = "SmsTransaction";
            return PartialView("_ResendLogins");
        }

        [HttpPost]
        public async Task<ActionResult> ResendLogins(Guid uaoId, Guid txID)
        {
            await userClient.ResendLoginsAsync(uaoId);
            TempData["SmsTransactionID"] = txID;
            return RedirectToAction("Index");
        }
    }
}