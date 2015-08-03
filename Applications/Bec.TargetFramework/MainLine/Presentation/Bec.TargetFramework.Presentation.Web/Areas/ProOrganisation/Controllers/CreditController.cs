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
using System.Threading.Tasks;
using System.Web;
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

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetStatement(DateTime from, DateTime to)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            var select = ODataHelper.Select<OrganisationLedgerTransactionDTO>(x => new
            {
                x.TransactionOrder.Invoice.InvoiceReference,
                x.Balance,
                x.BalanceOn
            }, false);

            var filter = ODataHelper.Filter<OrganisationLedgerTransactionDTO>(x =>
                x.BalanceOn >= from &&
                x.BalanceOn <= to &&
                x.OrganisationLedgerAccount.OrganisationID == orgID);

            JObject res = await queryClient.QueryAsync("OrganisationLedgerTransactions", ODataHelper.RemoveParameters(Request) + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public ActionResult ViewTopUpCredit()
        {
            return PartialView("_TopUpCredit");
        }

        public async Task<ActionResult> TopUpCredit(PaymentCardTypeIDEnum cardType, PaymentMethodTypeIDEnum methodType, OrderRequestDTO details, int amount)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            var prod = await prodClient.GetTopUpProductAsync();
            var cart = await cartClient.CreateShoppingCartAsync(uaoID, cardType, methodType, "UK");
            await cartClient.AddProductToShoppingCartAsync(cart.ShoppingCartID, prod.ProductID, prod.ProductVersionID, 1, amount);
            var invoice = await invoiceClient.CreateAndSaveInvoiceFromShoppingCartAsync(cart.ShoppingCartID);
            var transactionOrder = await txClient.CreateAndSaveTransactionOrderFromShoppingCartDTOAsync(invoice.InvoiceID, TransactionTypeIDEnum.Payment);
            details.TransactionOrderID = transactionOrder.TransactionOrderID;
            details.PaymentChargeType = PaymentChargeTypeEnum.Sale;
            var paymentDto = paymentClient.ProcessPaymentTransaction(details);

            return RedirectToAction("Index");
        }
    }
}