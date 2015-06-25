using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.ProOrganisation.Controllers
{
    //[ClaimsRequired("Add", "ProUsers", Order = 1000)]
    public class UsersController : ApplicationControllerBase
    {
        public IOrganisationLogicClient orgClient { get; set; }
        public IUserLogicClient userClient { get; set;
        }
        // GET: ProOrganisation/Users
        public ActionResult Invited()
        {
            return View();
        }

        public ActionResult Registered()
        {
            return View();
        }

        public async Task<ActionResult> GetUsers(bool registered)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            var list = await orgClient.GetUsersAsync(orgID, !registered);
            var jsonData = new { total = list.Count, list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
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

            await userClient.GeneratePinAsync(uao.UserAccountOrganisationID);
            
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
    }
}