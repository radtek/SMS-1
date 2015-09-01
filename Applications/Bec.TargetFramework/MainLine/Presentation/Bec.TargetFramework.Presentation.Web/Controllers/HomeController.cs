﻿using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Bec.TargetFramework.Security;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class HomeController : ApplicationControllerBase
    {
        public IAddressLogicClient AddressClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }

        public ActionResult Index()
        {
            if (ClaimsHelper.UserHasClaim("Add", "SmsTransaction"))
            {
                return RedirectToAction("Index", "Transaction", new {area = "SmsTransaction"});
            }
            else if (ClaimsHelper.UserHasClaim("Configure", "BankAccount"))
            {
                return RedirectToAction("OutstandingBankAccounts", "Finance", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "Buyer", new { area = "SmsTransaction" });
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

        public ActionResult ViewMessage(string title, string message, string button)
        {
            ViewBag.title = title;
            ViewBag.message = message;
            ViewBag.button = button;
            return PartialView("_Message");
        }

        public ActionResult ViewResendLogins(Guid uaoId, string label, string redirectAction, string redirectController, string redirectArea)
        {
            ViewBag.orgId = uaoId;
            ViewBag.label = label;
            ViewBag.RedirectAction = redirectAction;
            ViewBag.RedirectController = redirectController;
            ViewBag.RedirectArea = redirectArea;
            return PartialView("_ResendLogins");
        }

        public async Task<ActionResult> FindAddress(string postcode)
        {
            var list = await AddressClient.FindAddressesByPostCodeAsync(postcode, null);

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CheckEmail(string email, Guid? uaoID)
        {
            email = email.ToLower();
            var select = ODataHelper.Select<UserAccountOrganisationDTO>(x => new { x.UserAccountOrganisationID });
            var filter = ODataHelper.Expression<UserAccountOrganisationDTO>(x => x.UserAccount.Email.ToLower() == email);
            if (uaoID.HasValue) filter = Expression.And(filter, ODataHelper.Expression<UserAccountOrganisationDTO>(x => x.UserAccountOrganisationID != uaoID));
            var res = await QueryClient.QueryAsync<UserAccountOrganisationDTO>("UserAccountOrganisations", select + ODataHelper.Filter(filter));

            if (res.Any())
                return Json("This email address has already been used", JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}