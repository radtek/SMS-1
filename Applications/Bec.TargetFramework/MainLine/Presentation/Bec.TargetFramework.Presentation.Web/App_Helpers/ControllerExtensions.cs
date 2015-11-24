using Bec.TargetFramework.Presentation.Web.Models.ToastrNotification;
using System.Web.Mvc;
namespace Bec.TargetFramework.Presentation.Web
{
    public static class ControllerExtensions
    {
        public static ToastMessage AddToastMessage(this Controller controller, string title, string message, ToastType toastType = ToastType.Info, bool isSticky = false)
        {
            Toastr toastr = controller.TempData["Toastr"] as Toastr;
            toastr = toastr ?? new Toastr();

            var toastMessage = toastr.AddToastMessage(title, message, toastType, isSticky);
            controller.TempData["Toastr"] = toastr;
            return toastMessage;
        }
    }
}