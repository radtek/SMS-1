using Bec.TargetFramework.Business.Client.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Settings;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class CompanyDuplicateCheckController : Controller
    {
        public IOrganisationLogicClient OrganisationClient { get; set; }
        public ITFSettingsLogicClient SettingsClient { get; set; }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Check(Guid? orgID, string regulatorNumber)
        {
            // todo: ZM use settings to get the number
            var isInSystem = await OrganisationClient.IsOrganisationInSystemAsync(orgID, regulatorNumber);
            var settings = SettingsClient.GetSettings().AsSettings<CommonSettings>();
            if (isInSystem)
                return Json("The organisation with above SRA ID/MIS Number is already registered in the Safe Move Scheme." + (orgID.HasValue ? "": " Call us at " + settings.SupportTelephoneNumber + " if this concerns you."), JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}