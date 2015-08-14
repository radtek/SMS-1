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
using Bec.TargetFramework.Presentation.Web.Helpers;

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

            var select = ODataHelper.Select<UserAccountOrganisationDTO>(x => new
            {
                x.UserAccountOrganisationID,
                x.UserID,
                x.PinCode,
                x.PinCreated,
                x.UserAccount.ID,
                x.UserAccount.Email,
                x.UserAccount.Username,
                x.UserAccount.Created,
                x.Contact.Salutation,
                x.Contact.FirstName,
                x.Contact.LastName
            }, true);

            var where = ODataHelper.Expression<UserAccountOrganisationDTO>(x =>
                !x.UserAccount.IsDeleted &&
                x.OrganisationID == orgID &&
                x.UserAccount.IsTemporaryAccount == temporary &&
                x.UserAccount.IsLoginAllowed == loginAllowed);

            if (hasPin)
                where = Expression.And(where, ODataHelper.Expression<UserAccountOrganisationDTO>(x => x.PinCode != null));
            else
                where = Expression.And(where, ODataHelper.Expression<UserAccountOrganisationDTO>(x => x.PinCode == null));

            var filter = ODataHelper.Filter(where);

            JObject res = await queryClient.QueryAsync("UserAccountOrganisations", ODataHelper.RemoveParameters(Request) + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public async Task<ActionResult> ViewAddUser()
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var select = ODataHelper.Select<OrganisationRoleDTO>(x => new { x.OrganisationRoleID, x.RoleName });
            var filter = ODataHelper.Filter<OrganisationRoleDTO>(x => x.OrganisationID == orgID);
            var orderby = ODataHelper.OrderBy<OrganisationRoleDTO>(x => new { x.RoleName });
            var allRoles = (await queryClient.QueryAsync<OrganisationRoleDTO>("OrganisationRoles", select + filter + orderby)).ToList();

            //remove once multiple admins are allowed:
            var r = new List<Tuple<OrganisationRoleDTO, string>>();
            for (int i = 0; i < allRoles.Count; i++)
            {
                var v = allRoles[i];
                bool disabled = v.RoleName == "Organisation Administrator";
                if (disabled) v.RoleName += " (unavailable)";
                r.Add(Tuple.Create(v, disabled ? "onclick=ignore(event)" : "onclick=countRoles()"));
            }
            ViewBag.roles = r;
            return PartialView("_AddUser");
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(ContactDTO contact)
        {
            var roles = Edit.ReadFormValues(Request,"role-", s => Guid.Parse(s), v => v == "on")
                .Where(x => x.Value)
                .Select(x => x.Key).ToArray();

            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            var uao = await orgClient.AddNewUserToOrganisationAsync(orgID, Entities.Enums.UserTypeEnum.User, RandomPasswordGenerator.GenerateRandomName(), RandomPasswordGenerator.Generate(), true, true, false, roles, contact);

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

        public async Task<ActionResult> ViewEditUser(Guid uaoID)
        {
            ViewBag.uaoID = uaoID;
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            var select = ODataHelper.Select<UserAccountOrganisationDTO>(x => new
            {
                x.UserAccountOrganisationID,
                x.UserAccount.Email,
                x.Contact.Salutation,
                x.Contact.FirstName,
                x.Contact.LastName,
                x.UserAccount.IsActive
            }, true);
            var filter = ODataHelper.Filter<UserAccountOrganisationDTO>(x => x.UserAccountOrganisationID == uaoID);
            var res = await queryClient.QueryAsync<UserAccountOrganisationDTO>("UserAccountOrganisations", Request.QueryString + select + filter);

            var rselect = ODataHelper.Select<OrganisationRoleDTO>(x => new { x.OrganisationRoleID, x.RoleName, a = x.UserAccountOrganisationRoles.Select(y => new { y.UserAccountOrganisationID, y.UserAccountOrganisation.UserAccount.IsTemporaryAccount }) });
            var rfilter = ODataHelper.Filter<OrganisationRoleDTO>(x => x.OrganisationID == orgID);
            var rorderby = ODataHelper.OrderBy<OrganisationRoleDTO>(x => new { x.RoleName });
            var allRoles = (await queryClient.QueryAsync<OrganisationRoleDTO>("OrganisationRoles", rselect + rfilter + rorderby)).ToList();

            var userRoles = userClient.GetRoles(uaoID);

            var r = new List<Tuple<int, string, string, Guid, string>>();
            for (int i = 0; i < allRoles.Count; i++)
            {
                var v = allRoles[i];
                bool check = userRoles.Any(u => u.OrganisationRoleID == v.OrganisationRoleID);
                //reinstate once multiple admins are allowed:
                bool disabled = v.RoleName == "Organisation Administrator";// && check && v.UserAccountOrganisationRoles.Where(a => !a.UserAccountOrganisation.UserAccount.IsTemporaryAccount).Count() == 1;
                if (disabled)
                {
                    if(check)
                        v.RoleName += " (locked)";
                    else
                        v.RoleName += " (unavailable)";
                }
                r.Add(Tuple.Create(i, check ? "checked" : "", disabled ? "onclick=ignore(event)" : "", v.OrganisationRoleID, v.RoleName));
            }
            ViewBag.Roles = r;
            ViewBag.SelectedRoleCount = r.Count(x => x.Item2 == "checked");

            return PartialView("_EditUser", Edit.MakeModel(res.First()));
        }

        [HttpPost]
        public async Task<ActionResult> EditUser(Guid uaoID)
        {
            var filter = ODataHelper.Filter<UserAccountOrganisationDTO>(x => x.UserAccountOrganisationID == uaoID);
            var data = Edit.fromD(Request.Form);
            
            //manipulate collection of roles to include only selected ones
            var array = data["UserAccountOrganisationRoles"] as JArray;
            var toRemove = array.Where(x => x["Selected"] == null).ToList();
            foreach (var r in toRemove) array.Remove(r);

            await queryClient.UpdateGraphAsync("UserAccountOrganisations", data, filter);

            return RedirectToAction("Registered");
        }
    }
}