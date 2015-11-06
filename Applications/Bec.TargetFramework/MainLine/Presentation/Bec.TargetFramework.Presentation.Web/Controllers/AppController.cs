﻿using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Bec.TargetFramework.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class AppController : ApplicationControllerBase
    {
        public IAddressLogicClient AddressClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }

        public ActionResult Index()
        {
            TempData["WelcomeMessage"] = TempData["JustRegistered"];
            TempData["JustRegistered"] = false;

            if (ClaimsHelper.UserHasClaim("Add", "SmsTransaction"))
            {
                return RedirectToAction("Index", "Transaction", new {area = "SmsTransaction"});
            }
            else if (ClaimsHelper.UserHasClaim("Configure", "BankAccount"))
            {
                return RedirectToAction("OutstandingBankAccounts", "Finance", new { area = "Admin" });
            }
            else if (ClaimsHelper.UserHasClaim("Add", "Company"))
            {
                return RedirectToAction("Provisional", "Company", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "SafeBuyer", new { area = "Buyer" });
            }
        }

        public ActionResult Denied()
        {
            return View("Denied");
        }

        public ActionResult ViewCancel()
        {
            return PartialView("_Cancel");
        }

        public async Task<ActionResult> FindAddress(string postcode)
        {
            var list = await AddressClient.FindAddressesByPostCodeAsync(postcode, null);

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CheckEmail(string email, Guid? uaoID)
        {
            string select = ODataHelper.Select<UserAccountOrganisationDTO>(x => new { x.UserAccountOrganisationID });
            Expression filter;
            if (uaoID.HasValue)
            {
                var selectUao = ODataHelper.Select<UserAccountOrganisationDTO>(x => new { x.UserAccount.Email });
                var filterUao = ODataHelper.Expression<UserAccountOrganisationDTO>(x => x.UserAccountOrganisationID == uaoID);
                var uaoAsync = await QueryClient.QueryAsync<UserAccountOrganisationDTO>("UserAccountOrganisations", selectUao + ODataHelper.Filter(filterUao));
                var uao = uaoAsync.FirstOrDefault();
                var uaoEmail = uao.UserAccount.Email;

                var exp1 = ODataHelper.Expression<UserAccountOrganisationDTO>(x => x.UserAccountOrganisationID != uaoID);
                var exp2 = ODataHelper.Expression<UserAccountOrganisationDTO>(GetNotUaoWithEmail(uaoEmail));
                var exp3 = ODataHelper.Expression<UserAccountOrganisationDTO>(GetUaoWithEmail(email));

                filter = Expression.AndAlso(Expression.AndAlso(exp1, exp2), exp3);
            }
            else
            {
                filter = ODataHelper.Expression<UserAccountOrganisationDTO>(GetUaoWithEmail(email));
            }

            var res = await QueryClient.QueryAsync<UserAccountOrganisationDTO>("UserAccountOrganisations", select + ODataHelper.Filter(filter));

            if (res.Any())
                return Json("This email address has already been used", JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTemplate(string view)
        {
            return PartialView(view);
        }

        public async Task<ActionResult> SearchLenders(string search)
        {
            search = search.ToLower().Trim();
            if (string.IsNullOrWhiteSpace(search)) return null;
            var select = ODataHelper.Select<LenderDTO>(x => new { x.Name });
            var filter = ODataHelper.Filter<LenderDTO>(x => x.Name.ToLower().Contains(search));
            JObject res = await QueryClient.QueryAsync("Lenders", select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        private Expression<Func<UserAccountOrganisationDTO, bool>> GetUaoWithEmail(string email)
        {
            return p => p.UserAccount.Email.ToLower() == email.Trim().ToLower();
        }

        private Expression<Func<UserAccountOrganisationDTO, bool>> GetNotUaoWithEmail(string email)
        {
            return p => p.UserAccount.Email.ToLower() != email.Trim().ToLower();
        }
    }
}