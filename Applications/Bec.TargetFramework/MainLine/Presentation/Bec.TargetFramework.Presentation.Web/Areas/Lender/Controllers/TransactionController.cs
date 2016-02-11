using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
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

namespace Bec.TargetFramework.Presentation.Web.Areas.Lender.Controllers
{
    [ClaimsRequired("View", "SmsTransactionsOverview")]
    public class TransactionController : ApplicationControllerBase
    {
        public IQueryLogicClient QueryClient { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetSmsTransactions()
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            var selectTradingNames = ODataHelper.Select<LenderDTO>(x => new { x.Name });
            var filterTradingNames = ODataHelper.Filter<LenderDTO>(x => x.OrganisationID == orgID);
            var tradingNames = (await QueryClient.QueryAsync<LenderDTO>("Lenders", selectTradingNames + filterTradingNames)).Select(x => x.Name);

            var select = ODataHelper.Select<SmsTransactionDTO>(x => new
            {
                x.SmsTransactionID,
                x.Address.Line1,
                x.Address.Line2,
                x.Address.Town,
                x.Address.County,
                x.Address.PostalCode,
                x.Address.AdditionalAddressInformation,
                x.CreatedOn,
                x.CreatedBy,
                x.LenderName,
                x.MortgageApplicationNumber,
                x.Price,
                x.IsProductAdvised,
                x.ProductAdvisedOn,
                x.ProductDeclinedOn,
                PurchasedOn = x.Invoice.CreatedOn,
                PurchasedBySalutation = x.Invoice.UserAccountOrganisation.Contact.Salutation,
                PurchasedByFirstName = x.Invoice.UserAccountOrganisation.Contact.FirstName,
                PurchasedByLastName = x.Invoice.UserAccountOrganisation.Contact.LastName,
                ppl = x.SmsUserAccountOrganisationTransactions.Select(y => new {
                    y.SmsUserAccountOrganisationTransactionType.SmsUserAccountOrganisationTransactionTypeID,
                    y.SmsUserAccountOrganisationTransactionType.Description,
                    y.Contact.Salutation,
                    y.Contact.FirstName,
                    y.Contact.LastName,
                    y.Contact.BirthDate,
                    y.Address.Line1,
                    y.Address.Line2,
                    y.Address.Town,
                    y.Address.County,
                    y.Address.PostalCode,
                    y.Address.AdditionalAddressInformation,
                    y.LatestBankAccountCheck.CheckedOn,
                    y.LatestBankAccountCheck.BankAccountNumber,
                    y.LatestBankAccountCheck.SortCode,
                    y.LatestBankAccountCheck.IsMatch
                })
            });

            Expression names = null;
            foreach (var name in tradingNames)
            {
                var ex = ODataHelper.Expression<SmsTransactionDTO>(x => x.LenderName == name);
                if (names == null)
                    names = ex;
                else
                    names = Expression.Or(names, ex);
            }
            var filter = ODataHelper.Filter(names);

            JObject res = await QueryClient.QueryAsync("SmsTransactions", ODataHelper.RemoveParameters(Request) + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }
    }
}