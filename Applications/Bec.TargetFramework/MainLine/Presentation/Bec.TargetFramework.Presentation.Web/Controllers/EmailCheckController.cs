using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Helpers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class EmailCheckController : Controller
    {
        public IQueryLogicClient QueryClient { get; set; }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Check(string email, Guid? uaoID)
        {
            email = email.ToLower();
            string select = ODataHelper.Select<UserAccountOrganisationDTO>(x => new { x.UserAccountOrganisationID });
            Expression filter;
            if (uaoID.HasValue)
            {
                var selectUao = ODataHelper.Select<UserAccountOrganisationDTO>(x => new { x.UserAccount.Email });
                var filterUao = ODataHelper.Expression<UserAccountOrganisationDTO>(x => x.UserAccountOrganisationID == uaoID);
                var uaoAsync = await QueryClient.QueryAsync<UserAccountOrganisationDTO>("UserAccountOrganisations", selectUao + ODataHelper.Filter(filterUao));
                var uao = uaoAsync.FirstOrDefault();
                var uaoEmail = uao.UserAccount.Email;

                filter = ODataHelper.Expression<UserAccountOrganisationDTO>(x =>
                    x.UserAccount.Email != uaoEmail &&
                    x.UserAccountOrganisationID != uaoID &&
                    x.UserAccount.Email.ToLower() == email);
            }
            else
            {
                filter = ODataHelper.Expression<UserAccountOrganisationDTO>(x => x.UserAccount.Email.ToLower() == email);
            }

            var res = await QueryClient.QueryAsync<UserAccountOrganisationDTO>("UserAccountOrganisations", select + ODataHelper.Filter(filter));

            if (res.Any())
                return Json("This email address has already been used", JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}