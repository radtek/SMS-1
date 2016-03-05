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
using Bec.TargetFramework.Entities.Enums;
using System.Collections.Generic;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class AppController : ApplicationControllerBase
    {
        public IAddressLogicClient AddressClient { get; set; }
        public IUserLogicClient UserClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }
        public IHelpLogicClient helpClient { get; set; }

        public ActionResult Index()
        {
            TempData["WelcomeMessage"] = TempData["JustRegistered"];
            TempData["JustRegistered"] = false;
            var urlReferer = Request.UrlReferrer;
            if (urlReferer != null && urlReferer.AbsoluteUri.ToLower().Contains("account/login"))
            {
                TempData["JustLoggined"] = true;
            }

            if (ClaimsHelper.UserHasClaim("Add", "SmsTransaction"))
            {
                return RedirectToAction("Index", "Transaction", new { area = "SmsTransaction" });
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

        public async Task<ActionResult> CheckEmailProfessional(string email, Guid? uaoID)
        {
            var canEmailBeUsed = await UserClient.CanEmailBeUsedAsProfessionalAsync(email, uaoID);
            if (!canEmailBeUsed)
                return Json("This email address has already been used", JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CheckEmailPersonal(string email, Guid? txId, Guid? uaoID)
        {
            var canEmailBeUsed = await UserClient.CanEmailBeUsedAsPersonalAsync(email, txId, uaoID);
            if (!canEmailBeUsed)
                return Json("This email cannot be used", JsonRequestBehavior.AllowGet);
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

        public async Task<ActionResult> ViewRenderCallout()
        {
            var userID = WebUserHelper.GetWebUserObject(HttpContext).UserID;
            var createdDate = WebUserHelper.GetWebUserObject(HttpContext).Created;
            string dateTime = createdDate.ToString("dd/MM/yyyy");
            DateTime dt = DateTime.Parse(dateTime);
            var helpItems = await helpClient.GetHelpItemsForCalloutAsync(userID, dt);
            return Json(new { result = true, callOuts = helpItems.Select(x => new { x.Title, x.Description, x.Selector, x.Position }) }, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> GetSmhItemOnPage(string pageUrl)
        {
            var list = await helpClient.GetHelpItemsAsync(HelpPageTypeIdEnum.ShowMeHow, pageUrl, Guid.Empty);
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetTourItem()
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var roles = await UserClient.GetRolesAsync(uaoID, 1);
            var roleHiers = await helpClient.GetRoleListsAsync();
            var roleId = SelectRole(roles, roleHiers);
            var list = await helpClient.GetHelpItemsAsync(HelpPageTypeIdEnum.Tour, null, roleId);
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

        private Guid SelectRole(List<UserAccountOrganisationRoleDTO> roles, List<RoleHierarchyDTO> roleHiers)
        {
            if (roles != null && roles.Any() && roleHiers != null && roleHiers.Any())
            {
                var filteredRoles = roleHiers.Where(x => roles.Any(z => z.OrganisationRole.RoleName.ToLower() == x.Role.RoleName.ToLower())).ToList();
                if (filteredRoles != null && filteredRoles.Any())
                {
                    var role = filteredRoles.FirstOrDefault(x => x.Level == 1);
                    if (role == null)
                    {
                        var roleLevel2 = filteredRoles.FirstOrDefault(x => x.Level == 2);
                        if (roleLevel2 != null)
                        {
                            return roleLevel2.RoleID;
                        }
                    }
                    else
                    {
                        return role.RoleID;
                    }
                }
            }
            return Guid.Empty;
        }


    }
}