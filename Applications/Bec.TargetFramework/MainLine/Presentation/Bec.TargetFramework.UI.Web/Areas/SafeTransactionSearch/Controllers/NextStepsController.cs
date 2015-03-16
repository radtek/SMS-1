using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using Bec.TargetFramework.Entities.DTO.Notification;
using Bec.TargetFramework.Entities;
using System.Text;
using System.Net;
using Ext.Net.MVC;
using Ext.Net;
using Bec.TargetFramework.Workflow.Interfaces;
using Bec.TargetFramework.UI.Web.Helpers;
using Bec.TargetFramework.Infrastructure.Extensions;
namespace Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch.Controllers
{
    [DirectController(AreaName = "SafeTransactionSearch")]
    public class NextStepsController : Controller
    {

        private IWorkflowProcessService m_WorkflowProcessLogic;
         private INotificationDataService m_NotificationService ;
         private NextStepsDTO dto;
         public NextStepsController(ILogger logger, INotificationDataService service, IWorkflowProcessService logic)
             //: base(logger) after taking base controller from applicationbasecontroller
        {
           this.m_NotificationService = service;
           m_WorkflowProcessLogic = logic;
        }

        // GET: SafeTransactionSearch/NextSteps
        public ActionResult Index()
        {
            var sessionWorkflowTempAccountData = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<TemporaryAccountDTO>(WorkflowDataEnum.TemporaryAccountData.GetStringValue());
            dto = new NextStepsDTO() { isExternalInvite = sessionWorkflowTempAccountData.IsSearchInvite, isCO = sessionWorkflowTempAccountData.IsColp };// this data gets filled from the WF session helper
           
            //this NotificationConstructId and version should come from session and in taht acse this if elseloop will not be required
            // loadNextSteps(NotificationConstructId, NotificationVersionNumber, sessionWorkflowTempAccountData.IsColp);
            if(sessionWorkflowTempAccountData.IsColp)
            {
                loadUserNextSteps(); //loadNextSteps(Guid.Parse("36149692-3e90-11e4-9c84-d7289f4b389c"), 1, sessionWorkflowTempAccountData.IsColp); //
            }
            else
            {
                loadUserNextSteps(); //loadNextSteps(Guid.Parse("1c03a4b2-4266-11e4-a5a5-ffb43cafcbd0"), 1, sessionWorkflowTempAccountData.IsColp);
            }
            
           // loadCONextSteps(); // from  workflow sesion data we need to write the logic which method to call loadconextsteps or loadUsernextsteps

           Ext.Net.MessageBus.Default.Publish("TreeStructureReload");
            return View(dto);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Next(NextStepsDTO model)
        {
            if (ModelState.IsValid)
            {
                WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<NextStepsDTO>(WorkflowDataEnum.NextStepsData.GetStringValue(), model);
                var state = WorkflowSessionHelper.GetWorkflowStateFromSession();
                
                object oValue1 = new object();
                var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "true");
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NSClicked", (key) => "true");
                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(state.InstanceID.Value, state);
                currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NSClicked", out oValue1);
                currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                WorkflowSessionHelper.AddOrReplaceWorkflowStateToSession(currentState.WorkflowState);
                
                return RedirectToAction(
                    currentState.CurrentActionDTO.ActionName,
                    currentState.CurrentActionDTO.ControllerName,
                new
                {
                    area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
                });
            }
            return View(model);
        }
            

        public ActionResult STSData()
        {
          
            dto = new NextStepsDTO() { isExternalInvite = false, isCO = true };
            Window win = this.GetCmp<Window>("STSandYourDataWindow");
            win.Show();
            return View("Index", dto);
        }

        [DirectMethod]
        public ActionResult LoadNextSteps(string value)
        {
            var dto = new NextStepsDTO();
            if (value == "1")
                loadUserNextSteps();
            else
                loadUserNextSteps();
                
            return this.Direct(dto);
        }

        private void loadCONextSteps()
        {

            UrlHelper u = new UrlHelper(this.ControllerContext.RequestContext);
            string url = u.Action("STSData", "NextSteps", new {area="SafeTransactionSearch"});

            //TODO: get this data from productblueprint and populate the correctDTO and load correctNotificationConstruct
            ConcurrentDictionary<string, object> data = new ConcurrentDictionary<string, object>();
            data.TryAdd("ColpNextSteps", new ColpNextStepsNotificationDTO { SafeTransactionSearchPublicProductPrice = 30.0M, FirmCheckProductPrice = 10.0M, IDCheckProductPrice = 5.0M, TitleDocumentProductPrice = 20.0M, STSandDataLink = url });


            byte[] reportData = m_NotificationService.GenericNotificationtOutputFromNotificationConstruct(Guid.Parse("dd2cb066-5ec7-11e4-8c11-77b67ddee257"), 1,
               new NotificationDictionaryDTO { NotificationDictionary = data }, NotificationExportFormatIDEnum.HTML5);

            string reportPath = Server.MapPath(@"/Areas/SafeTransactionSearch/Views/NextSteps");

            // save report if not exists
            string filename = reportPath + "\\" + "NextSteps.cshtml";

            if (!Directory.Exists(reportPath))
                Directory.CreateDirectory(reportPath);

            if (System.IO.File.Exists(filename))
                System.IO.File.Delete(filename);

            System.IO.File.WriteAllBytes(filename, reportData);

        }

        private void loadUserNextSteps()
        {
            UrlHelper u = new UrlHelper(this.ControllerContext.RequestContext);
            string url = u.Action("STSData", "NextSteps", new { area = "SafeTransactionSearch" });

            //TODO: get this data from productblueprint and populate the correctDTO and load correctNotificationConstruct
            ConcurrentDictionary<string, object> data = new ConcurrentDictionary<string, object>();
            data.TryAdd("UserNextSteps", new UserNextStepsNotificationDTO { IDCheckProductPrice = 5.0M, TitleDocumentProductPrice = 20.0M, STSandDataLink = url });

            byte[] reportData = m_NotificationService.GenericNotificationtOutputFromNotificationConstruct(Guid.Parse("dd2cb066-5ec7-11e4-8c11-77b67ddee257"), 1,
               new NotificationDictionaryDTO { NotificationDictionary = data }, NotificationExportFormatIDEnum.HTML5);

            string reportPath = Server.MapPath(@"/Areas/SafeTransactionSearch/Views/NextSteps");

            // save report if not exists
            string filename = reportPath + "\\" + "NextSteps.cshtml";

            if (!Directory.Exists(reportPath))
                Directory.CreateDirectory(reportPath);

            if (System.IO.File.Exists(filename))
                System.IO.File.Delete(filename);

            System.IO.File.WriteAllBytes(filename, reportData);          
        }


        private void loadNextSteps(Guid NotificationConstructId, int NotificationVersionNumber, bool isCo)
        {
            UrlHelper u = new UrlHelper(this.ControllerContext.RequestContext);
            string url = u.Action("STSData", "NextSteps", new { area = "SafeTransactionSearch" });

            ConcurrentDictionary<string, object> data = new ConcurrentDictionary<string, object>();
            //TODO: get this data from productblueprint and populate the correctDTO and load correctNotificationConstruct
            if (isCo) 
                     data.TryAdd("ColpNextSteps", new ColpNextStepsNotificationDTO { SafeTransactionSearchPublicProductPrice = 30.0M, FirmCheckProductPrice = 10.0M, IDCheckProductPrice = 5.0M, TitleDocumentProductPrice = 20.0M, STSandDataLink = url });
            else
                  data.TryAdd("UserNextSteps", new UserNextStepsNotificationDTO { IDCheckProductPrice = 5.0M, TitleDocumentProductPrice = 20.0M, STSandDataLink = url });
            //TODO: get this data from productblueprint and populate the correctDTO and load correctNotificationConstruct

            byte[] reportData = m_NotificationService.GenericNotificationtOutputFromNotificationConstruct(NotificationConstructId, NotificationVersionNumber,
               new NotificationDictionaryDTO { NotificationDictionary = data }, NotificationExportFormatIDEnum.HTML5);

            string reportPath = Server.MapPath(@"~/Areas/SafeTransactionSearch/Views/NextSteps");

            // save report if not exists
            string filename = reportPath + "\\" + "NextSteps.cshtml";

            if (!Directory.Exists(reportPath))
                Directory.CreateDirectory(reportPath);

            if (System.IO.File.Exists(filename))
                System.IO.File.Delete(filename);

            System.IO.File.WriteAllBytes(filename, reportData);
        }
    }
}