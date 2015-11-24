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

        const string adminRole = "Organisation Administrator";
        const string sroType = "Organisation Administrator";

        // GET: ProOrganisation/Users
        public ActionResult Invited()
        {
            return View();
        }

        public ActionResult Registered()
        {
            return View();
        }

        public async Task<ActionResult> GetUsers(bool temporary, bool loginAllowed)
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
                x.UserAccount.Created,
                x.Contact.Salutation,
                x.Contact.FirstName,
                x.Contact.LastName
            }, true);

            var filter = ODataHelper.Filter<UserAccountOrganisationDTO>(x =>
                !x.UserAccount.IsDeleted &&
                x.OrganisationID == orgID &&
                x.UserAccount.IsTemporaryAccount == temporary &&
                x.UserAccount.IsLoginAllowed == loginAllowed);

            JObject res = await queryClient.QueryAsync("UserAccountOrganisations", ODataHelper.RemoveParameters(Request) + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public async Task<ActionResult> ViewAddUser()
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var select = ODataHelper.Select<OrganisationRoleDTO>(x => new { x.OrganisationRoleID, x.RoleDescription });
            var filter = ODataHelper.Filter<OrganisationRoleDTO>(x => x.OrganisationID == orgID && x.IsDefault == false);
            var orderby = ODataHelper.OrderBy<OrganisationRoleDTO>(x => new { x.RoleDescription });
            var allRoles = (await queryClient.QueryAsync<OrganisationRoleDTO>("OrganisationRoles", select + filter + orderby)).ToList();

            ViewBag.roles = allRoles;
            return PartialView("_AddUser");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(ContactDTO contact)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            
            var defaultRoles = await GetDefaultRoles(orgID);

            var roles = Edit.ReadFormValues(Request,"role-", s => Guid.Parse(s), v => v == "on")
                .Where(x => x.Value)
                .Select(x => x.Key).ToArray();

            var uao = await orgClient.AddNewUserToOrganisationAsync(orgID, Entities.Enums.UserTypeEnum.User, false, defaultRoles.Concat(roles).ToArray(), contact);
            await userClient.GeneratePinAsync(uao.UserAccountOrganisationID, false, false, false);

            TempData["UserId"] = uao.UserID;
            return RedirectToAction("Invited");
        }

        public ActionResult ViewRevokeInvite(Guid uaoId, string label)
        {
            ViewBag.uaoId = uaoId;
            ViewBag.label = label;
            return PartialView("_RevokeInvite");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RevokeInvite(Guid uaoId)
        {
            await EnsureUserInOrg(uaoId, WebUserHelper.GetWebUserObject(HttpContext).OrganisationID, queryClient);
            await orgClient.ExpireUserAccountOrganisationAsync(uaoId);
            return RedirectToAction("Invited");
        }

        public ActionResult ViewReinstate(Guid uaoId, Guid userId, string label)
        {
            ViewBag.uaoId = uaoId;
            ViewBag.userId = userId;
            ViewBag.fullName = label;
            return PartialView("_Reinstate");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Reinstate(Guid uaoId, Guid userId)
        {
            await EnsureUserInOrg(uaoId, WebUserHelper.GetWebUserObject(HttpContext).OrganisationID, queryClient);
            await userClient.GeneratePinAsync(uaoId, false, true, false);
            TempData["UserId"] = userId;
            TempData["tabIndex"] = 0;
            return RedirectToAction("Invited");
        }

        public async Task<ActionResult> ViewEditUser(Guid uaoID)
        {
            ViewBag.uaoID = uaoID;
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            var select = ODataHelper.Select<UserAccountOrganisationDTO>(x => new
            {
                x.UserAccountOrganisationID,
                x.Contact.Salutation,
                x.Contact.FirstName,
                x.Contact.LastName,
                x.UserAccount.IsActive,
                x.UserType.Name,
                rv1 = x.RowVersion,
                rv2 = x.Contact.RowVersion,
                rv3 = x.UserAccount.RowVersion
            });
            var filter = ODataHelper.Filter<UserAccountOrganisationDTO>(x => x.UserAccountOrganisationID == uaoID);
            var res = await queryClient.QueryAsync<UserAccountOrganisationDTO>("UserAccountOrganisations", select + filter);
            var uao = res.First();

            var userIsSRO = uao.UserType.Name == sroType;

            var rselect = ODataHelper.Select<OrganisationRoleDTO>(x => new { x.OrganisationRoleID, x.RoleName, x.RoleDescription, a = x.UserAccountOrganisationRoles.Select(y => new { y.UserAccountOrganisationID, y.UserAccountOrganisation.UserAccount.IsTemporaryAccount }) });
            var rfilter = ODataHelper.Filter<OrganisationRoleDTO>(x => x.OrganisationID == orgID && x.IsDefault == false);
            var rorderby = ODataHelper.OrderBy<OrganisationRoleDTO>(x => new { x.RoleDescription });
            var allRoles = (await queryClient.QueryAsync<OrganisationRoleDTO>("OrganisationRoles", rselect + rfilter + rorderby)).ToList();

            var userRoles = userClient.GetRoles(uaoID, 0);

            var r = new List<Tuple<int, string, string, Guid, string>>();
            for (int i = 0; i < allRoles.Count; i++)
            {
                var v = allRoles[i];
                bool check = userRoles.Any(u => u.OrganisationRoleID == v.OrganisationRoleID);
                bool disabled = userIsSRO || (v.RoleName == adminRole && check && v.UserAccountOrganisationRoles.Where(a => !a.UserAccountOrganisation.UserAccount.IsTemporaryAccount).Count() == 1);
                if (disabled) v.RoleDescription += " (locked)";

                r.Add(Tuple.Create(i, check ? "checked" : "", disabled ? "onclick=ignore(event)" : "", v.OrganisationRoleID, v.RoleDescription));
            }
            ViewBag.UserIsSRO = userIsSRO;
            ViewBag.Roles = r;
            

            return PartialView("_EditUser", Edit.MakeModel(uao));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(Guid uaoID)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var defaultRoles = await GetDefaultRoles(orgID);
            await EnsureUserInOrg(uaoID, orgID, queryClient);
            var select = ODataHelper.Select<UserAccountOrganisationDTO>(x => new { x.UserType.Name });
            var filter = ODataHelper.Filter<UserAccountOrganisationDTO>(x => x.UserAccountOrganisationID == uaoID);
            var data = Edit.fromD(Request.Form,
                "Contact.Salutation",
                "Contact.FirstName",
                "Contact.LastName",
                "Contact.RowVersion",
                "UserAccount.IsActive",
                "UserAccount.RowVersion",
                "UserAccountOrganisationRoles[].Selected",
                "UserAccountOrganisationRoles[].OrganisationRoleID");

            var rselect = ODataHelper.Select<OrganisationRoleDTO>(x => new { x.OrganisationRoleID });
            var rfilter = ODataHelper.Filter<OrganisationRoleDTO>(x => x.OrganisationID == orgID && x.RoleName == adminRole);
            var allRoles = (await queryClient.QueryAsync<OrganisationRoleDTO>("OrganisationRoles", rselect + rfilter)).ToList();
            var ar = allRoles.FirstOrDefault();
            var res = await queryClient.QueryAsync<UserAccountOrganisationDTO>("UserAccountOrganisations", select + filter);
            var uao = res.FirstOrDefault();

            //manipulate collection of roles to include only selected ones
            var array = data["UserAccountOrganisationRoles"] as JArray;
            var toRemove = array.Where(x => x["Selected"] == null).ToList();
            foreach (var r in toRemove) array.Remove(r);
            foreach (var r in defaultRoles) array.Add(JObject.FromObject(new { OrganisationRoleID = r, Selected = "on" }));

            if (ar != null && uao != null && uao.UserType.Name == sroType)
            {
                //ensure IsActive && adminRole for SRO Anas.
                data["UserAccount"]["IsActive"] = "true,false";
                if (!array.Any(x => (Guid)x["OrganisationRoleID"] == ar.OrganisationRoleID)) array.Add(JObject.FromObject(new { OrganisationRoleID = ar.OrganisationRoleID, Selected = "on" }));
            }

            await queryClient.UpdateGraphAsync("UserAccountOrganisations", data, filter);

            return RedirectToAction("Registered");
        }

        internal static async Task EnsureUserInOrg(Guid uaoID, Guid orgID, IQueryLogicClient client)
        {
            var select = ODataHelper.Select<UserAccountOrganisationDTO>(x => new { x.OrganisationID });
            var filter = ODataHelper.Filter<UserAccountOrganisationDTO>(x => x.UserAccountOrganisationID == uaoID);
            dynamic ret = await client.QueryAsync("UserAccountOrganisations", select + filter);
            if (ret.Items.First.OrganisationID != orgID) throw new AccessViolationException("Operation failed");
        }

        private async Task<IEnumerable<Guid>> GetDefaultRoles(Guid orgID)
        {
            var rselect = ODataHelper.Select<OrganisationRoleDTO>(x => new { x.OrganisationRoleID });
            var rfilter = ODataHelper.Filter<OrganisationRoleDTO>(x => x.OrganisationID == orgID && x.IsDefault == true);
            var defaultRoles = await queryClient.QueryAsync<OrganisationRoleDTO>("OrganisationRoles", rselect + rfilter);
            return defaultRoles.Select(r => r.OrganisationRoleID);
        }
    }
}