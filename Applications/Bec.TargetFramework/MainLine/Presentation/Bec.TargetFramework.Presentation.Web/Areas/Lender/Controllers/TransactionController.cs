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

        public async Task<ActionResult> GetSmsTransactions(string search, SmsTransactionNoMatchEnum noMatchFilter)
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
                x.LenderName,
                x.MortgageApplicationNumber,
                x.Price,
                x.IsProductAdvised,
                x.ProductAdvisedOn,
                OrgNames = x.Organisation.OrganisationDetails.Select(y => new { y.Name }),
                PurchasedOn = x.Invoice.CreatedOn,
                PurchasedBySalutation = x.Invoice.UserAccountOrganisation.Contact.Salutation,
                PurchasedByFirstName = x.Invoice.UserAccountOrganisation.Contact.FirstName,
                PurchasedByLastName = x.Invoice.UserAccountOrganisation.Contact.LastName,
                ppl = x.SmsUserAccountOrganisationTransactions.Select(y => new
                {
                    y.SmsUserAccountOrganisationTransactionTypeID,
                    y.SmsUserAccountOrganisationTransactionType.Description,
                    y.ProductAcceptedOn,
                    y.ProductDeclinedOn,
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
                    })
                })
            });

            Expression where = null;
            foreach (var name in tradingNames)
            {
                var ex = ODataHelper.Expression<SmsTransactionDTO>(x => x.LenderName == name);
                if (where == null)
                    where = ex;
                else
                    where = Expression.Or(where, ex);
            }
            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim().ToLower();
                where = Expression.And(where, ODataHelper.Expression<SmsTransactionDTO>(x =>
                    x.Reference.ToLower().Contains(search) ||
                    x.Address.Line1.ToLower().Contains(search) ||
                    x.Address.PostalCode.ToLower().Contains(search) ||
                    x.MortgageApplicationNumber.ToLower().Contains(search) ||
                    x.Organisation.OrganisationDetails.Any(y => y.Name.ToLower().Contains(search)) ||
                    x.SmsUserAccountOrganisationTransactions.Any(y => y.Contact.FirstName.ToLower().Contains(search) || y.Contact.LastName.ToLower().Contains(search))
                    ));
            }

            switch (noMatchFilter)
            {
                case SmsTransactionNoMatchEnum.None:
                    where = Expression.And(where, ODataHelper.Expression<SmsTransactionDTO>(x => !x.SmsUserAccountOrganisationTransactions.Any(y => y.SmsBankAccountChecks.Any(z => !z.IsMatch))));
                    break;
                case SmsTransactionNoMatchEnum.Present:
                    where = Expression.And(where, ODataHelper.Expression<SmsTransactionDTO>(x => x.SmsUserAccountOrganisationTransactions.Any(y => y.SmsBankAccountChecks.Any(z => !z.IsMatch))));
                    break;
            }

            var filter = ODataHelper.Filter(where);

            JObject res = await QueryClient.QueryAsync("SmsTransactions", ODataHelper.RemoveParameters(Request) + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }
    }
}