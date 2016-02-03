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

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    [ClaimsRequired("Configure", "BankAccount", Order = 1000)]
    public class FinanceController : ApplicationControllerBase
    {
        public IQueryLogicClient queryClient { get; set; }
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
    }
}