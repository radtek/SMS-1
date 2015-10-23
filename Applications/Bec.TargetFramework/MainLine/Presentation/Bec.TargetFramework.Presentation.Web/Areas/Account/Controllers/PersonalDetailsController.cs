﻿using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Areas.Account.Models;
using Bec.TargetFramework.Presentation.Web.Filters;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
    [Authorize]
    [SessionExpireFilter]
    public class PersonalDetailsController : Controller
    {
        public IOrganisationLogicClient OrganisationLogicClient { get; set; }
        public async Task<ActionResult> Index()
        {
            var userObject = WebUserHelper.GetWebUserObject(HttpContext);
            var requiresPersonalDetails = await OrganisationLogicClient.RequiresPersonalDetailsAsync(userObject.UaoID);
            if (!requiresPersonalDetails)
            {
                userObject.NeedsPersonalDetails = false;
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> IndexPOST(AddPersonalDetailsDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userObject = WebUserHelper.GetWebUserObject(HttpContext);
            await OrganisationLogicClient.AddPersonalDetailsAsync(userObject.UaoID, model);
            var requiresPersonalDetails = await OrganisationLogicClient.RequiresPersonalDetailsAsync(userObject.UaoID);
            userObject.NeedsPersonalDetails = requiresPersonalDetails;

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}