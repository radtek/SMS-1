using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.BankAccount.Controllers
{
    [ClaimsRequired("View", "BankAccount", Order = 1000)]
    public class AccountController : ApplicationControllerBase
    {
        public IOrganisationLogicClient orgClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }

        public ActionResult Index(Guid? selectedBankAccountId)
        {
            //don't overwrite what already might be in TempData...
            if (selectedBankAccountId.HasValue) TempData["OrganisationBankAccountID"] = selectedBankAccountId;
            return View();
        }

        public async Task<ActionResult> GetBankAccounts()
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var list = await orgClient.GetOrganisationBankAccountsAsync(orgID);
            
            var jsonData = new { total = list.Count, list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewAddBankAccount()
        {
            return PartialView("_AddBankAccount");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsRequired("Add", "BankAccount", Order = 1000)]
        public async Task<ActionResult> AddBankAccount(OrganisationBankAccountDTO dto)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            TempData["OrganisationBankAccountID"] = await orgClient.AddBankAccountAsync(orgID, dto);
            TempData["ShowMessage"] = true;
            return RedirectToAction("Index");
        }

        public ActionResult ViewStatus(Guid baID, string title, string message, BankAccountStatusEnum status)
        {
            ViewBag.OrganisationBankAccountID = baID;
            ViewBag.title = title;
            ViewBag.message = message;
            ViewBag.status = status;
            ViewBag.action = "AddStatus";
            ViewBag.controller = "Account";
            ViewBag.area = "BankAccount";
            return PartialView("_AddStatus");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddStatus(Guid baID, BankAccountStatusEnum status, string notes)
        {
            var currentUser = WebUserHelper.GetWebUserObject(HttpContext);
            var orgID = currentUser.OrganisationID;

            var bankAccountStateChangeDto = new OrganisationBankAccountStateChangeDTO
            {
                OrganisationID = orgID,
                BankAccountID = baID,
                BankAccountStatus = status,
                Notes = notes,
                KillDuplicates = false,
                ChangedByUserAccountOrganisationID = currentUser.UaoID,
                DetailsUrl = Url.Action("Index", "Account", new { area = "BankAccount", selectedBankAccountId = baID }, Request.Url.Scheme)
            };

            await orgClient.AddBankAccountStatusAsync(bankAccountStateChangeDto);
            TempData["OrganisationBankAccountID"] = baID;
            return RedirectToAction("Index");
        }

        public ActionResult ViewToggleActive(Guid baID, string title, string message, bool isactive)
        {
            ViewBag.OrganisationBankAccountID = baID;
            ViewBag.title = title;
            ViewBag.message = message;
            ViewBag.isactive = isactive;
            ViewBag.action = "ToggleActive";
            ViewBag.controller = "Account";
            ViewBag.area = "BankAccount";
            return PartialView("_AddStatus");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ToggleActive(Guid baID, bool isactive, string notes)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            await orgClient.ToggleBankAccountActiveAsync(orgID, baID, isactive, notes);
            TempData["OrganisationBankAccountID"] = baID;
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> CheckBankAccount(string accountNumber, string sortCode)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var select = ODataHelper.Select<OrganisationBankAccountDTO>(x => new { x.OrganisationBankAccountID });
            var filter = ODataHelper.Filter<OrganisationBankAccountDTO>(x => x.OrganisationID == orgID && x.BankAccountNumber == accountNumber && x.SortCode == sortCode);
            var accounts = await queryClient.QueryAsync<OrganisationBankAccountDTO>("OrganisationBankAccounts", select + filter);

            if (accounts.Any())
                return Json("This account number and sort code have already been entered", JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}