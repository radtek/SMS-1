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

        public ActionResult Index(Guid? selectedTransactionId)
        {
            if (selectedTransactionId.HasValue)
            {
                TempData["SmsTransactionID"] = selectedTransactionId;
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
                x.UserAccountOrganisation.Contact.Salutation,
                x.UserAccountOrganisation.Contact.FirstName,
                x.UserAccountOrganisation.Contact.LastName,
                x.UserAccountOrganisation.UserAccount.Email,
                x.UserAccountOrganisation.UserAccount.IsTemporaryAccount,
                x.SmsTransaction.CreatedOn
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

        public async Task<ActionResult> ViewEditSmsTransaction(Guid txID)
        {
            ViewBag.txID = txID;
            var select = ODataHelper.Select<SmsTransactionDTO>(x => new
            {
                x.SmsTransactionID,
                x.UserAccountOrganisationID,
                x.UserAccountOrganisation.Contact.Salutation,
                x.UserAccountOrganisation.Contact.FirstName,
                x.UserAccountOrganisation.Contact.LastName,
                x.UserAccountOrganisation.UserAccount.Email,
                x.UserAccountOrganisation.UserAccount.IsTemporaryAccount
            }, true);
            var filter = ODataHelper.Filter<SmsTransactionDTO>(x => x.SmsTransactionID == txID);
            var res = await queryClient.QueryAsync<SmsTransactionDTO>("SmsTransactions", select + filter);
            var model = res.First();
            ViewBag.IsTemporaryUser = model.UserAccountOrganisation.UserAccount.IsTemporaryAccount;

            return PartialView("_EditSmsTransaction", Edit.MakeModel(model));
        }

        [HttpPost]
        public async Task<ActionResult> EditSmsTransaction(Guid txID)
        {
            var filter = ODataHelper.Filter<SmsTransactionDTO>(x => x.SmsTransactionID == txID);
            var data = Edit.fromD(Request.Form);

            await queryClient.UpdateGraphAsync("SmsTransactions", data, filter);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ViewResendLogins(Guid txID, string label)
        {
            var select = ODataHelper.Select<SmsTransactionDTO>(x => new { x.UserAccountOrganisationID });
            var filter = ODataHelper.Filter<SmsTransactionDTO>(x => x.SmsTransactionID == txID);
            var res = await queryClient.QueryAsync<SmsTransactionDTO>("SmsTransactions", select + filter);

            ViewBag.txID = txID;
            ViewBag.uaoId = res.First().UserAccountOrganisationID;
            ViewBag.label = label;
            ViewBag.RedirectAction = "ResendLogins";
            ViewBag.RedirectController = "Transaction";
            ViewBag.RedirectArea = "SmsTransaction";
            return PartialView("_ResendLogins");
        }

        [HttpPost]
        public async Task<ActionResult> ResendLogins(Guid uaoId, Guid txID)
        {
            var uao = await userClient.ResendLoginsAsync(uaoId);
            TempData["SmsTransactionID"] = txID;
            return RedirectToAction("Index");
        }
    }
}