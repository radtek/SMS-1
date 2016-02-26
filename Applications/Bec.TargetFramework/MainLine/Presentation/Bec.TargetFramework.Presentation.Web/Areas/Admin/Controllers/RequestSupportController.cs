using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Areas.Admin.Models;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Bec.TargetFramework.Presentation.Web.Models.ToastrNotification;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    [ClaimsRequired("Add", "SupportFunctions", Order = 1000)]
    public class RequestSupportController : ApplicationControllerBase
    {
        public IQueryLogicClient queryClient { get; set; }
        public IHelpLogicClient helpClient { get; set; }
        public async Task<ActionResult> Index()
        {
            //ViewBag.roles = await GetRoles();
            return View();
        }

        public async Task<ActionResult> GetRequestSupports()
        {
            JObject res = await GetRequests(false);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public async Task<ActionResult> GetClosedRequestSupports()
        {
            JObject res = await GetRequests(true);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        private async Task<JObject> GetRequests(bool isClosed)
        {
            var select = ODataHelper.Select<RequestSupportDTO>(x => new
            {
                x.RequestSupportID,
                x.Title,
                x.Description,
                x.CreatedOn,
                x.CreatedBy,
                x.IsClosed,
                x.TicketNumber,
                x.Reason,
                x.ClosedOn,
                x.ClosedBy,
                x.RequestType,
                x.UserAccountOrganisationID,
                x.Telephone,
                x.UserAccountOrganisation.UserAccount.Email,
                x.UserAccountOrganisation.Contact.Salutation,
                x.UserAccountOrganisation.Contact.FirstName,
                x.UserAccountOrganisation.Contact.LastName
            }, false);

            var where = ODataHelper.Expression<RequestSupportDTO>(x => x.IsClosed == isClosed);
            var filter = ODataHelper.Filter(where);
            return await queryClient.QueryAsync("RequestSupports", ODataHelper.RemoveParameters(Request) + select + filter);
        }

        public ActionResult ViewAddRequestSupport(RequestSupportDTO requestSupport)
        {
            ViewBag.Email = WebUserHelper.GetWebUserObject(HttpContext).Email;
            ViewBag.UserName = WebUserHelper.GetWebUserObject(HttpContext).UserName; 
            return PartialView("_AddRequestSupport", requestSupport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddRequestSupport(RequestSupportDTO requestSupport)
        {
            requestSupport.UserAccountOrganisationID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            requestSupport.CreatedBy = WebUserHelper.GetWebUserObject(HttpContext).Email;
            await helpClient.CreateRequestSupportAsync(requestSupport);
            this.AddToastMessage("Request Message", "The request message sent successfully!", ToastType.Success, false);
            return Json(new { result = true }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ViewCloseRequestSupport(Guid RequestSupportId, int pageNumber = 1)
        {
            ViewBag.RequestSupportId = RequestSupportId;
            ViewBag.pageNumber = pageNumber;
            var select = ODataHelper.Select<RequestSupportDTO>(x => new
            {
                x.RequestSupportID,
                x.Title,
                x.Reason,
            });
            var filter = ODataHelper.Filter<RequestSupportDTO>(x => x.RequestSupportID == RequestSupportId);
            var res = await queryClient.QueryAsync<RequestSupportDTO>("RequestSupports", select + filter);
            var requestSupport = res.First();
            return PartialView("_CloseRequestSupport", Edit.MakeModel(requestSupport));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CloseRequestSupport(Guid requestSupportId, int pageNumber = 1)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            try
            {
                var filter = ODataHelper.Filter<RequestSupportDTO>(x => x.RequestSupportID == requestSupportId);
                var data = Edit.fromD(Request.Form,
                    "Reason"                   
                  );
                data.Add("IsClosed", "true");
                data.Add("ClosedBy", WebUserHelper.GetWebUserObject(HttpContext).Email);
                data.Add("ClosedOn", DateTime.Now);
                await queryClient.UpdateGraphAsync("RequestSupports", data, filter);
                TempData["pageNumber"] = pageNumber;
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    title = "Close Request Support Failed",
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

       
    }
}