using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.ProOrganisation.Controllers
{
    [ClaimsRequired("Add", "ProUsers", Order = 1000)]
    public class UsersController : ApplicationControllerBase
    {
        public IOrganisationLogicClient orgClient { get; set; }
        public IUserLogicClient userClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }

        // GET: ProOrganisation/Users
        public ActionResult Invited()
        {
            return View();
        }

        public ActionResult Registered()
        {
            return View();
        }

        public async Task<ActionResult> GetUsers(bool temporary, bool loginAllowed, bool hasPin)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            JObject res = await queryClient.GetAsync("UserAccountOrganisations", Request.QueryString + "&$select=UserAccountOrganisationID,UserID,PinCode,PinCreated&$expand=UserAccount($select=ID,Email,Username),Contact($select=Salutation,FirstName,LastName)&$filter=UserAccount/IsTemporaryAccount eq " + temporary.ToString().ToLower() + " and UserAccount/IsLoginAllowed eq " + loginAllowed.ToString().ToLower() + " and PinCode " + (hasPin ? "ne" : "eq") + " null");
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public ActionResult ViewAddUser()
        {
            return PartialView("_AddUser");
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(ContactDTO contact)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            var uao = await orgClient.AddNewUserToOrganisationAsync(orgID, Entities.Enums.UserTypeEnum.User, RandomPasswordGenerator.GenerateRandomName(), RandomPasswordGenerator.Generate(), true, true, contact);
            
            TempData["UserId"] = uao.UserID;
            return RedirectToAction("Invited");
        }

        public ActionResult ViewResendLogins(Guid uaoId, string label)
        {
            ViewBag.uaoId = uaoId;
            ViewBag.label = label;
            ViewBag.RedirectAction = "ResendLogins";
            ViewBag.RedirectController = "Users";
            ViewBag.RedirectArea = "ProOrganisation";
            return PartialView("_ResendLogins");
        }

        [HttpPost]
        public async Task<ActionResult> ResendLogins(Guid uaoId)
        {
            var uao = await userClient.ResendLoginsAsync(uaoId);

            TempData["UserId"] = uao.UserID;
            TempData["tabIndex"] = 1;
            return RedirectToAction("Invited");
        }

        public ActionResult ViewRevokeInvite(Guid userId, string label)
        {
            ViewBag.userId = userId;
            ViewBag.label = label;
            return PartialView("_RevokeInvite");
        }

        [HttpPost]
        public async Task<ActionResult> RevokeInvite(Guid userId)
        {
            await userClient.LockUserTemporaryAccountAsync(userId);
            return RedirectToAction("Invited");
        }

        public ActionResult ViewGeneratePin(Guid uaoId, Guid userId, string label)
        {
            ViewBag.uaoId = uaoId;
            ViewBag.userId = userId;
            ViewBag.fullName = label;
            return PartialView("_GenerateUserPin");
        }

        [HttpPost]
        public async Task<ActionResult> GeneratePin(Guid uaoId, Guid userId)
        {
            await userClient.GeneratePinAsync(uaoId);

            TempData["UserId"] = userId;
            TempData["tabIndex"] = 1;
            return RedirectToAction("Invited");
        }
    }
}