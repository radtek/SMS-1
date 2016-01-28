using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.ProOrganisation.Controllers
{
    [ClaimsRequired("View", "Credit", Order = 1000)]
    public class CreditController : ApplicationControllerBase
    {
        public IQueryLogicClient queryClient { get; set; }
        public IShoppingCartLogicClient cartClient { get; set; }
        public IInvoiceLogicClient invoiceClient { get; set; }
        public ITransactionOrderLogicClient txClient { get; set; }
        public IProductLogicClient prodClient { get; set; }
        public IPaymentLogicClient paymentClient { get; set; }
        public IOrganisationLogicClient orgClient { get; set; }

        public ActionResult Index(Guid? transactionOrderId)
        {
            ViewBag.TransactionOrderId = transactionOrderId;
            return View();
        }

        public async Task<decimal> GetBalanceAsAt(DateTime date, bool startOfDay)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            Guid creditAccountID = await orgClient.GetCreditAccountIdAsync(orgID);

            date = startOfDay ? date.Date : date.Date.AddDays(1);
            return await orgClient.GetBalanceAsAtAsync(creditAccountID, date);
        }

        public async Task<ActionResult> GetStatement(DateTime from, DateTime to)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            Guid creditAccountID = await orgClient.GetCreditAccountIdAsync(orgID);
            to = to.Date.AddDays(1); //less than tomorrow

            var select = ODataHelper.Select<VOrganisationLedgerTransactionBalanceDTO>(x => new
            {
                x.TransactionOrderID,
                x.InvoiceReference,
                x.Amount,
                x.Balance,
                x.BalanceOn,
                x.CreatedByName
            }, false);

            var filter = ODataHelper.Filter<VOrganisationLedgerTransactionBalanceDTO>(x =>
                x.BalanceOn >= from &&
                x.BalanceOn < to &&
                x.OrganisationLedgerAccountID == creditAccountID);

            JObject res = await queryClient.QueryAsync("VOrganisationLedgerTransactionBalances", ODataHelper.RemoveParameters(Request) + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public ActionResult ViewTopUpCredit(bool redirect)
        {
            ViewBag.redirect = redirect;
            return PartialView("_TopUpCredit");
        }

        public async Task<ActionResult> TopUpCredit(Guid? txID, PaymentCardTypeIDEnum cardType, PaymentMethodTypeIDEnum methodType, OrderRequestDTO details, int amount)
        {
            if (txID == null)
            {
                var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
                var prod = await prodClient.GetTopUpProductAsync();

                txID = await paymentClient.PurchaseProductAsync(uaoID, prod.ProductID, prod.ProductVersionID, cardType, methodType, "Credit Top Up", amount);
            }

            details.TransactionOrderID = txID.Value;
            details.PaymentChargeType = PaymentChargeTypeEnum.Sale;
            var paymentDto = paymentClient.ProcessPaymentTransaction(details);

            if (paymentDto.IsPaymentSuccessful)
            {
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    result = false,
                    title = "Payment Unsuccessful",
                    message = paymentDto.ErrorMessage,
                    txID = txID.Value
                }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}