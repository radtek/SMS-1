using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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

        public async Task<ActionResult> PerformCheck(string accountNumber, string sortCode)
        {
            var select = ODataHelper.Select<OrganisationBankAccountDTO>(x => new { x.OrganisationID }, false);
            var filter = ODataHelper.Filter<OrganisationBankAccountDTO>(x => x.BankAccountNumber == accountNumber && x.SortCode == sortCode);

            var matches = await queryClient.QueryAsync<OrganisationBankAccountDTO>("OrganisationBankAccounts", select + filter);
            return Json(new { result = matches.Any() }, JsonRequestBehavior.AllowGet);
        }
    }
}