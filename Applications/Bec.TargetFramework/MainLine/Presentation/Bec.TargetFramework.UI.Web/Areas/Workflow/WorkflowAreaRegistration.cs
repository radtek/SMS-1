using System.Web.Mvc;

namespace Bec.TargetFramework.UI.Web.Areas.Workflow
{
    public class WorkflowAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Workflow";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Workflow_default",
                "Workflow/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "Bec.TargetFramework.UI.Web.Areas.Workflow.Controllers" }
            );

 
        }
    }
}