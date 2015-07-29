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

namespace Bec.TargetFramework.Presentation.Web.Areas.BankAccount.Controllers
{
    [ClaimsRequired("View", "BankAccount", Order = 1000)]
    public class AccountController : ApplicationControllerBase
    {
        public IOrganisationLogicClient orgClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetBankAccounts()
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            //var select = ODataHelper.Select<OrganisationBankAccountDTO>(x => new { x.OrganisationBankAccountID, x.BankAccountNumber, x.SortCode, x.Created });
            //var filter = ODataHelper.Filter<OrganisationBankAccountDTO>(x => x.OrganisationID == orgID);

            //JObject res = await queryClient.QueryAsync("OrganisationBankAccounts", Request.QueryString + select + filter);
            //return Content(res.ToString(Formatting.None), "application/json");

            var list = await orgClient.GetOrganisationBankAccountsAsync(orgID);
            
            var jsonData = new { total = list.Count, list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewAddBankAccount()
        {
            return PartialView("_AddBankAccount");
        }

        [HttpPost]
        [ClaimsRequired("Add", "BankAccount", Order = 1000)]
        public async Task<ActionResult> AddBankAccount(OrganisationBankAccountDTO dto)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            TempData["OrganisationBankAccountID"] = await orgClient.AddBankAccountAsync(orgID, dto);
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
        public async Task<ActionResult> AddStatus(Guid baID, BankAccountStatusEnum status)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            await orgClient.AddBankAccountStatusAsync(baID, status);
            TempData["OrganisationBankAccountID"] = baID;
            return RedirectToAction("Index");
        }
    }
}