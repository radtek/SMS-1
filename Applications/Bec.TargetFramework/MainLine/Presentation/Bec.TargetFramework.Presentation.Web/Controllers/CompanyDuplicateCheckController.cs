﻿using Bec.TargetFramework.Business.Client.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class CompanyDuplicateCheckController : Controller
    {
        public IOrganisationLogicClient OrganisationClient { get; set; }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Check(string regulatorNumber)
        {
            // todo: ZM use settings to get the number
            var isInSystem = await OrganisationClient.IsOrganisationInSystemAsync(regulatorNumber);
            if (isInSystem)
                return Json("The organisation with above SRA ID/MIS Number is already registered in the Safe Move Scheme. Call us at 020 3598 0150 if this concerns you.", JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}