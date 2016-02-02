using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Presentation.Web.Areas.Account.Models;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Models.ToastrNotification;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
    [Authorize]
    public class MyAccountController : ApplicationControllerBase
    {
        public IUserLogicClient UserLogicClient { get; set; }
        public ActionResult ChangePassword(string returnUrl)
        {
            var model = new ChangePasswordModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordModel model)
        {
            var currentUser = WebUserHelper.GetWebUserObject(HttpContext);

            var uaValidation = await UserLogicClient.AuthenticateUserAsync(currentUser.Email, EncodingHelper.Base64Encode(model.OldPassword));
            if (!uaValidation.valid)
            {
                ModelState.AddModelError("OldPassword", "The Old Password is incorrect.");
                return View(model);
            }

            //change password
            await UserLogicClient.ResetUserPasswordAsync(uaValidation.UserAccount.ID, model.NewPassword, true, string.Empty);

            this.AddToastMessage("Success", "Your password has been changed.", ToastType.Success, true);

            return Redirect(model.ReturnUrl ?? "");
        }
    }
}