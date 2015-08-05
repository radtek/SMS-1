using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    [ClaimsRequired("Configure", "BankAccount", Order = 1000)]
    public class FinanceController : ApplicationControllerBase
    {
        public IOrganisationLogicClient orgClient { get; set; }
        
        public ActionResult OutstandingBankAccounts()
        {
            return View();
        }

        public async Task<ActionResult> GetBankAccounts()
        {
            var list = await orgClient.GetOutstandingBankAccountsAsync();

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
        public async Task<ActionResult> AddStatus(Guid baID, BankAccountStatusEnum status, string notes, bool? killDuplicates)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            await orgClient.AddBankAccountStatusAsync(orgID, baID, status, notes, killDuplicates ?? false);
            TempData["OrganisationBankAccountID"] = baID;
            return RedirectToAction("OutstandingBankAccounts");
        }
    }
}