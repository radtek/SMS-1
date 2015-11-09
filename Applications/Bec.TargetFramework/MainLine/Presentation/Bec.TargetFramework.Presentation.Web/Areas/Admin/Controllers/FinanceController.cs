using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    [ClaimsRequired("Configure", "BankAccount", Order = 1000)]
    public class FinanceController : ApplicationControllerBase
    {
        public IQueryLogicClient queryClient { get; set; }
        public IOrganisationLogicClient orgClient { get; set; }
        public IShoppingCartLogicClient cartClient { get; set; }
        public IInvoiceLogicClient invoiceClient { get; set; }
        public ITransactionOrderLogicClient txClient { get; set; }
        public IProductLogicClient prodClient { get; set; }
        public IPaymentLogicClient PaymentLogicClient { get; set; }
        public IBankAccountLogicClient BankAccountClient { get; set; }
        
        public ActionResult OutstandingBankAccounts()
        {
            return View();
        }

        public async Task<ActionResult> GetBankAccounts()
        {
            var list = await BankAccountClient.GetOutstandingBankAccountsAsync();

            var jsonData = new { total = list.Count, list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewStatus(Guid baID, string title, string message, BankAccountStatusEnum status, bool? killDuplicates)
        {
            ViewBag.OrganisationBankAccountID = baID;
            ViewBag.title = title;
            ViewBag.message = message;
            ViewBag.status = status;
            ViewBag.killDuplicates = killDuplicates;
            ViewBag.action = "AddStatus";
            ViewBag.controller = "Finance";
            ViewBag.area = "Admin";
            return PartialView("_AddStatus");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddStatus(Guid baID, BankAccountStatusEnum status, string notes, bool? killDuplicates)
        {
            var currentUser = WebUserHelper.GetWebUserObject(HttpContext);
            var orgID = currentUser.OrganisationID;

            var bankAccountStateChangeDto = new OrganisationBankAccountStateChangeDTO
            {
                RequestedByOrganisationID = orgID,
                BankAccountID = baID,
                BankAccountStatus = status,
                Notes = notes,
                KillDuplicates = killDuplicates ?? false,
                ChangedByUserAccountOrganisationID = currentUser.UaoID,
                DetailsUrl = Url.Action("Index", "Account", new { area = "BankAccount", selectedBankAccountId = baID }, Request.Url.Scheme)
            };

            await BankAccountClient.AddBankAccountStatusAsync(bankAccountStateChangeDto);
            TempData["OrganisationBankAccountID"] = baID;
            return RedirectToAction("OutstandingBankAccounts");
        }


        public ActionResult CreditHistory()
        {
            return View();
        }

        public async Task<ActionResult> SearchCompany(string search)
        {
            search = search.ToLower();
            if (string.IsNullOrWhiteSpace(search)) return null;
            var select = ODataHelper.Select<OrganisationDetailDTO>(x => new { x.Name, x.OrganisationID });
            var filter = ODataHelper.Filter<OrganisationDetailDTO>(x => x.Organisation.OrganisationType.Name == "Professional" && x.Name.ToLower().Contains(search));
            JObject res = await queryClient.QueryAsync("OrganisationDetails", ODataHelper.RemoveParameters(Request) + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public async Task<ActionResult> GetStatement(Guid? orgID, DateTime from, DateTime to, bool? creditsOnly)
        {
            if (!orgID.HasValue) return null;

            Guid creditAccountID = await orgClient.GetCreditAccountIdAsync(orgID.Value);
            to = to.Date.AddDays(1); //less than tomorrow

            var select = ODataHelper.Select<VOrganisationLedgerTransactionBalanceDTO>(x => new
            {
                x.InvoiceReference,
                x.Amount,
                x.Balance,
                x.BalanceOn,
                x.CreatedByName
            }, false);

            var filter = ODataHelper.Expression<VOrganisationLedgerTransactionBalanceDTO>(x =>
                x.BalanceOn >= from &&
                x.BalanceOn < to &&
                x.OrganisationLedgerAccountID == creditAccountID);

            if (creditsOnly.HasValue)
            {
                if (creditsOnly.Value)
                    filter = Expression.And(filter, ODataHelper.Expression<VOrganisationLedgerTransactionBalanceDTO>(x => x.Amount > 0));
                else
                    filter = Expression.And(filter, ODataHelper.Expression<VOrganisationLedgerTransactionBalanceDTO>(x => x.Amount < 0));
            }

            JObject res = await queryClient.QueryAsync("VOrganisationLedgerTransactionBalances", ODataHelper.RemoveParameters(Request) + select + ODataHelper.Filter(filter));
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public ActionResult ViewAmendCredit(Guid orgID)
        {
            ViewBag.orgID = orgID;
            return PartialView("_AmendCredit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AmendCredit(Guid orgID, decimal amount, string reason)
        { 
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var creditAdjustment = new CreditAdjustmentDTO
            {
                OrganisationId = orgID,
                UserAccountOrganisationId = uaoID,
                Amount = amount,
                Reason = reason,
                DetailsUrlFormat = Url.Action("Index", "Credit", new { area = "ProOrganisation" }, Request.Url.Scheme) + "?transactionOrderId={0}"
            };
            await PaymentLogicClient.AmendCreditAsync(creditAdjustment);

            return Json(new { result = true }, JsonRequestBehavior.AllowGet);
        }
    }
}