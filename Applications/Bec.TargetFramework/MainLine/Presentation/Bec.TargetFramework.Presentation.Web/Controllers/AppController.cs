using Bec.TargetFramework.Business.Client.Interfaces;
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
        public IUserLogicClient UserClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }
        public ICalloutLogicClient calloutClient { get; set; }
        public ISmhLogicClient smhClient { get; set; }

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
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var userID = WebUserHelper.GetWebUserObject(HttpContext).UserID;
            var createDate = WebUserHelper.GetWebUserObject(HttpContext).Created;

            //get viewed callout 
            var selectCua = ODataHelper.Select<CalloutUserAccountDTO>(x => new
            {
                x.CalloutID,
                x.RoleID,
                x.UserID

            }, false);
            var filterCua = ODataHelper.Filter<CalloutUserAccountDTO>(x =>
                !x.IsDeleted && x.UserID == userID
               );
            var allCuas = (await QueryClient.QueryAsync<CalloutUserAccountDTO>("CalloutUserAccounts", selectCua + filterCua)).ToList();
            var filteredCuas = allCuas.ToList();

            var selectUaoRole = ODataHelper.Select<UserAccountOrganisationRoleDTO>(x => new
            {
                x.OrganisationRole.RoleName,
                x.OrganisationRole.RoleTypeID,
                x.OrganisationRole.RoleDescription,
                x.OrganisationRoleID,
                x.UserAccountOrganisationID

            }, false);

            var filterUaoRole = ODataHelper.Filter<UserAccountOrganisationRoleDTO>(x =>
                !x.IsDeleted && x.UserAccountOrganisationID == uaoID
               );
            var allUaoRoles = (await QueryClient.QueryAsync<UserAccountOrganisationRoleDTO>("UserAccountOrganisationRoles", selectUaoRole + filterUaoRole)).ToList();
            var filteredRoles = allUaoRoles.ToList();

            var select = ODataHelper.Select<CalloutDTO>(x => new
            {
                x.CalloutID,
                x.Title,
                x.Description,
                x.Selector,
                x.EffectiveOn,
                x.Position, 
                x.RoleID,
                x.CreatedOn
            }, false);
            var now = DateTime.Now;
            var where2 = ODataHelper.Expression<CalloutDTO>(x => !x.IsDeleted && x.EffectiveOn < now && x.CreatedOn > createDate);
            if (filteredCuas != null && filteredCuas.Any())
            {
                foreach (var cuaItem in filteredCuas)
                {
                    var callOutId = cuaItem.CalloutID;
                    where2 = Expression.And(where2, ODataHelper.Expression<CalloutDTO>(x => x.CalloutID != callOutId));
                }
            }
            var where1 = ODataHelper.Expression<CalloutDTO>(x => false);

            if (filteredRoles != null && filteredRoles.Any())
            {
                foreach (var roleItem in filteredRoles)
                {
                    var roleName = roleItem.OrganisationRole.RoleName.ToLower();
                    where1 = Expression.Or(where1, ODataHelper.Expression<CalloutDTO>(x => x.Role.RoleName.ToLower() == roleName));
                }
            }
            var where = Expression.And(where2, where1);
            var filter = ODataHelper.Filter(where);
            var orderbyCallout = ODataHelper.OrderBy<CalloutDTO>(x => new { x.RoleID, x.DisplayOrder });

            var res = await QueryClient.QueryAsync<CalloutDTO>("Callouts", ODataHelper.RemoveParameters(Request) + select + filter + orderbyCallout);

            //update viewed callout
            var viewedCallouts = res.ToList();
            if (viewedCallouts != null && viewedCallouts.Any())
            {
                foreach (var item in viewedCallouts)
                {
                    var calloutUserAccount = new CalloutUserAccountDTO();
                    calloutUserAccount.CalloutUserAccountID = Guid.NewGuid();
                    calloutUserAccount.CalloutID = item.CalloutID;
                    calloutUserAccount.RoleID = item.RoleID;
                    calloutUserAccount.IsDeleted = false;
                    calloutUserAccount.CreatedOn = DateTime.Now;
                    calloutUserAccount.UserID = userID;
                    await calloutClient.CreateCalloutUserAccountAsync(calloutUserAccount);
                }
            }

            return Json(new { result = true, callOuts = res.Select(x => new { x.Title, x.Description, x.Selector, x.Position }) }, JsonRequestBehavior.AllowGet);
            // return PartialView("_RenderCallout", calloutModel);
        }


        public async Task<ActionResult> GetSmhItemOnPage(string pageUrl)
        {
            var currentUser = WebUserHelper.GetWebUserObject(HttpContext);
            var list = await smhClient.GetItemOnPageForCurrentUserAsync(currentUser.UaoID, currentUser.OrganisationID, pageUrl);
            var res = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(list, Formatting.None));

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetSystemSmhItem()
        {
            string pageUrl = "SMH";
            var currentUser = WebUserHelper.GetWebUserObject(HttpContext);
            var list = await smhClient.GetItemOnPageForCurrentUserAsync(currentUser.UaoID, currentUser.OrganisationID, pageUrl);
            var res = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(list, Formatting.None));

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

        
    }
}