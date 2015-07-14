using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Bec.TargetFramework.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

            var select = ODataHelper.Select<UserAccountOrganisationDTO>(x => new { 
                x.UserAccountOrganisationID, x.UserID, x.PinCode, x.PinCreated, 
                x.UserAccount.ID, x.UserAccount.Email, x.UserAccount.Username,
                x.Contact.Salutation, x.Contact.FirstName, x.Contact.LastName });

            var where = ODataHelper.Expression<UserAccountOrganisationDTO>(x =>
                x.OrganisationID == orgID &&
                x.UserAccount.IsTemporaryAccount == temporary &&
                x.UserAccount.IsLoginAllowed == loginAllowed);

            if (hasPin)
                where = Expression.And(where, ODataHelper.Expression<UserAccountOrganisationDTO>(x => x.PinCode != null));
            else
                where = Expression.And(where, ODataHelper.Expression<UserAccountOrganisationDTO>(x => x.PinCode == null));

            var filter = ODataHelper.Filter(where);

            JObject res = await queryClient.GetAsync("UserAccountOrganisations", Request.QueryString + select + filter);
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