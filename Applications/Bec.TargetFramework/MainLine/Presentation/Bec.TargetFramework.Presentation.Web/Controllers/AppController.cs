using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Bec.TargetFramework.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class AppController : ApplicationControllerBase
    {
        public IAddressLogicClient AddressClient { get; set; }
        public IUserLogicClient UserClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }
        public IMiscLogicClient MiscClient { get; set; }

        public ActionResult Index()
        {
            TempData["WelcomeMessage"] = TempData["JustRegistered"];
            TempData["JustRegistered"] = false;

            if (ClaimsHelper.UserHasClaim("Add", "SmsTransaction"))
            {
                return RedirectToAction("Index", "Transaction", new {area = "SmsTransaction"});
            }
            else if (ClaimsHelper.UserHasClaim("View", "SmsTransactionsOverview"))
            {
                return RedirectToAction("Index", "Transaction", new { area = "Lender" });
            }
            else if (ClaimsHelper.UserHasClaim("Configure", "BankAccount"))
            {
                return RedirectToAction("OutstandingBankAccounts", "Finance", new { area = "Admin" });
            }
            else if (ClaimsHelper.UserHasClaim("Add", "Company"))
            {
                return RedirectToAction("Provisional", "Company", new { area = "Admin" });
            }
            else if (ClaimsHelper.UserHasClaim("View", "MyTransactions"))
            {
                return RedirectToAction("Index", "SafeBuyer", new { area = "Buyer" });
            }
            else
            {
                return View();
            }
        }

        public ActionResult Denied()
        {
            return View("Denied");
        }

        public async Task<ActionResult> CheckEmailProfessional(string email, Guid? uaoID)
        {
            var canEmailBeUsed = await UserClient.CanEmailBeUsedAsProfessionalAsync(email, uaoID);
            if (!canEmailBeUsed)
                return Json("This email address has already been used", JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CheckEmailPersonal(string email, Guid? txId, Guid? uaoID)
        {
            var canEmailBeUsed = await UserClient.CanEmailBeUsedAsPersonalAsync(email, txId, uaoID);
            if (!canEmailBeUsed)
                return Json("This email cannot be used", JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTemplate(string view)
        {
            return PartialView(view);
        }

        public async Task<ActionResult> SearchLenders(string search)
        {
            search = search.ToLower().Trim();
            if (string.IsNullOrWhiteSpace(search)) return null;
            var select = ODataHelper.Select<LenderDTO>(x => new { x.Name });
            var filter = ODataHelper.Filter<LenderDTO>(x => x.Name.ToLower().Contains(search));
            JObject res = await QueryClient.QueryAsync("Lenders", select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public async Task<ActionResult> GetFieldUpdates(int activityType, Guid activityID)
        {
            await EnsureCanAccessFieldUpdates(activityType, activityID);
            var select = ODataHelper.Select<FieldUpdateDTO>(x => new { x.FieldName, x.Value, x.ParentID, x.ParentType, x.ModifiedOn, x.UserAccountOrganisation.Contact.FirstName, x.UserAccountOrganisation.Contact.LastName });
            var filter = ODataHelper.Filter<FieldUpdateDTO>(x => x.ActivityType == activityType && x.ActivityID == activityID);
            var res = await QueryClient.QueryAsync("FieldUpdates", select + filter);
            return Content(res["Items"].ToString(Formatting.None), "application/json");
        }

        public async Task<ActionResult> PostFieldUpdate(FieldUpdateDTO dto)
        {
            dto.UserAccountOrganisationID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            dto.ModifiedOn = DateTime.Now;
            try
            {
                await EnsureCanAccessFieldUpdates(dto.ActivityType, dto.ActivityID);
                await MiscClient.AddOrModifyFieldUpdateAsync(dto);
                return Json(new { result = "ok" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { result = "failed" }, JsonRequestBehavior.AllowGet);
            }
        }

        private async Task EnsureCanAccessFieldUpdates(int activityType, Guid activityID)
        {
            var orgId = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            switch ((ActivityType)activityType)
            {
                case ActivityType.SmsTransaction:
                    var selectTx = ODataHelper.Select<SmsTransactionDTO>(x => new { x.OrganisationID, users = x.SmsUserAccountOrganisationTransactions.Select(y => new { y.UserAccountOrganisationID }) });
                    var filterTx = ODataHelper.Filter<SmsTransactionDTO>(x => x.SmsTransactionID == activityID);
                    var resultTx = (await QueryClient.QueryAsync<SmsTransactionDTO>("SmsTransactions", selectTx + filterTx)).Single();
                    if (resultTx.OrganisationID == orgId || resultTx.SmsUserAccountOrganisationTransactions.Any(x => x.UserAccountOrganisationID == uaoId)) 
                        return;
                    break;
            }
            throw new AccessViolationException("Operation failed");
        }
    }
}