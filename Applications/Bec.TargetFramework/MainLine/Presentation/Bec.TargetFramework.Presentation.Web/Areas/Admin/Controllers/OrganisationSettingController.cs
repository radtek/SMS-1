using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Areas.Admin.Models;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Bec.TargetFramework.Presentation.Web.Models.ToastrNotification;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    // Just a temporary solution for SRO Ana access control
    [ClaimsRequired("Add", "ProUsers", Order = 1000)]
    [ClaimsRequired("Add", "SmsTransaction", Order = 1001)]
    public class OrganisationSettingController : ApplicationControllerBase
    {
        public IOrganisationLogicClient OrganisationClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }

        public async Task<ActionResult> EditOrganisationSettings()
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var select = ODataHelper.Select<OrganisationSettingDTO>(x => new
            {
                x.Value
            });

            var safeSendName = OrganisationSettingName.SafeSendEnabled.ToString();
            var filter = ODataHelper.Filter<OrganisationSettingDTO>(x => x.OrganisationID == orgID && x.Name == safeSendName);
            var res = await QueryClient.QueryAsync<OrganisationSettingDTO>("OrganisationSettings", select + filter);
            var settingEntry = res.FirstOrDefault();

            var model = new OrganisationSettingsModel
            {
                SafeSendEnabled = settingEntry != null 
                    ? bool.Parse(settingEntry.Value) 
                    : false
            };

            return View("EditOrganisationSettings", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditOrganisationSettings(OrganisationSettingsModel model)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            await OrganisationClient.AddOrUpdateSafeSendEnabledAsync(orgID, model.SafeSendEnabled);

            this.AddToastMessage("Success", "The settings have been updated.", ToastType.Success, true);
            return View(model);
        }
    }
}