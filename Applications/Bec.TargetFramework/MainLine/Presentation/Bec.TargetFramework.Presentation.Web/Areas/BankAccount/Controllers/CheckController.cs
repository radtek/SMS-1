using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Presentation.Web.Helpers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.BankAccount.Controllers
{
    [AllowAnonymous]
    public class CheckController : Controller
    {
        public IQueryLogicClient queryClient { get; set; }

        // GET: BankAccount/Check
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> PerformCheck(string accountNumber, string sortCode, Guid? orgID = null)
        {
            string safe = BankAccountStatusEnum.Safe.GetStringValue();
            var select = ODataHelper.Select<VOrganisationBankAccountsWithStatusDTO>(x => new { x.OrganisationBankAccountID }, false);
            Expression where = ODataHelper.Expression<VOrganisationBankAccountsWithStatusDTO>(x => x.BankAccountNumber == accountNumber && x.SortCode == sortCode && x.Status == safe);
            if (orgID != null) where = Expression.And(where, ODataHelper.Expression<VOrganisationBankAccountsWithStatusDTO>(x => x.OrganisationID == orgID));
            var filter = ODataHelper.Filter(where);

            var matches = await queryClient.QueryAsync<VOrganisationBankAccountsWithStatusDTO>("VOrganisationBankAccountsWithStatus", select + filter);
            return Json(new { result = matches.Any() }, JsonRequestBehavior.AllowGet);
        }
    }
}