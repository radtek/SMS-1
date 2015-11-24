using System;
using System.Collections.Generic;

namespace Bec.TargetFramework.Presentation.Web.Models.ToastrNotification
{
    [Serializable]
    public class Toastr
    {
        public List<ToastMessage> ToastMessages { get; set; }

        public ToastMessage AddToastMessage(string title, string message, ToastType toastType, bool isSticky)
        {
            var toast = new ToastMessage()
            {
                Title = title,
                Message = message,
                ToastType = toastType,
                IsSticky = isSticky
            };
            ToastMessages.Add(toast);
            return toast;
        }

        public Toastr()
        {
            ToastMessages = new List<ToastMessage>();
        }
    }
}