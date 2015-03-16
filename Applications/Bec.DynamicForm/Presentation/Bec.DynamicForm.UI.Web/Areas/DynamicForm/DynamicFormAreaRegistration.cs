using System.Web.Mvc;

namespace Bec.DynamicForm.UI.Web.Areas.DynamicForm
{
    public class DynamicFormAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DynamicForm";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DynamicForm_default",
                "DynamicForm/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}