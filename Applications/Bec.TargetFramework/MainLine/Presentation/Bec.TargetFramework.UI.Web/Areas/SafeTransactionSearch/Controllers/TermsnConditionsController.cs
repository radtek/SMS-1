using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.UI.Web.Helpers;
using Bec.TargetFramework.Workflow.Interfaces;
using Ext.Net;
using Ext.Net.MVC;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
namespace Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch.Controllers
{
    [DirectController(AreaName = "SafeTransactionSearch")]
    public class TermsnConditionsController : Controller
    {
        private INotificationDataService m_NotificationDataService;
        private INotificationLogic m_NotificationLogic;
        private Guid m_NotificationtoOpen {get; set;}
        private IWorkflowProcessService m_WorkflowProcessLogic;
        private IUserLogic m_UserLogic;
        public TermsnConditionsController(INotificationDataService dataService, IWorkflowProcessService logic, INotificationLogic notificationLogic, IUserLogic userLogic)
        {
            m_NotificationDataService = dataService;
            m_WorkflowProcessLogic = logic;
            m_NotificationLogic = notificationLogic;
            m_UserLogic = userLogic;
        }

        // GET: SafeTransactionSearch/TermsnConditions
        public ActionResult TAndC()
        {

            //var TnCList = new List<VNotificationWithUAOVerificationCodeDTO>();
            //TnCList.Add(new VNotificationWithUAOVerificationCodeDTO() { NotificationID = Guid.Parse("038b546e-181c-420a-b187-060f865632e9"), NotificationConstructName = "Just sample 1", NotificationVerificationCode = "RandVerCode1" });
            //TnCList.Add(new VNotificationWithUAOVerificationCodeDTO() { NotificationID = Guid.Parse("f132ce8c-47ee-11e4-992f-bfdbc99590e1"), NotificationConstructName = "Just sample 2", NotificationVerificationCode = "RandVerCode1" });
            //TnCList.Add(new VNotificationWithUAOVerificationCodeDTO() { NotificationID = Guid.Parse("3eb58426-47ed-11e4-a150-c773e2de32a6"), NotificationConstructName = "Just sample 3", NotificationVerificationCode = "RandVerCode1" });
            //WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey("TnCs", TnCList);

            Ext.Net.MessageBus.Default.Publish("TreeStructureReload");
            return View("Index");
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Next()
        {
            if (ModelState.IsValid)
            {
                var state = WorkflowSessionHelper.GetWorkflowStateFromSession();
                object oValue1 = new object();
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "true");
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("TCClicked", (key) => "true");
                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(state.InstanceID.Value, state);
                currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("TCClicked", out oValue1);
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
            
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Previous()
        {
            var state = WorkflowSessionHelper.GetWorkflowStateFromSession();

            object oValue1 = new object();
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("TCClicked", (key) => "true");
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "false");
            var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(state.InstanceID.Value, state);
            currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("TCClicked", out oValue1);
            currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
            WorkflowSessionHelper.AddOrReplaceWorkflowStateToSession(currentState.WorkflowState);

            if (currentState != null)
                return RedirectToAction(
                    currentState.CurrentActionDTO.ActionName,
                    currentState.CurrentActionDTO.ControllerName,
                new
                {
                    area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
                });

            return View();
        }


        public virtual ActionResult OpenTNC(Guid id)
        {
            Session["NotificationtoOpen"] = id;

            //Window window = new Window.Builder()
            //  .ID("TnCWindow")
            //  .Title("Terms & Conditions")
            //  .AutoRender(true)
            //  .Width(800)
            //  .Height(800)
            //  .CloseAction(CloseAction.Destroy)
            //  .BodyPadding(5)
            //  .Modal(true)
            //  .Items(Html.X().Container().Content(a => RenderViewToStringInternal("ReportViewer", true)));//a => Html.Partial(a,"ReportViewer")));

            //// System.Web.Mvc.Html.PartialExtensions.Partial()

            //window.Render(RenderMode.AddTo, "TermsnConditionsForm");

            //window.Show();

            Window win = this.GetCmp<Window>("TnCWindow");
            win.Show();

            return this.Direct();
        }


        //used for reportviewer opening from backend
        protected string RenderViewToStringInternal(string viewPath, bool partial = false)
        {
            var Context = this.ControllerContext;
            // first find the ViewEngine for this view
            ViewEngineResult viewEngineResult = null;
            if (partial)
                viewEngineResult = ViewEngines.Engines.FindPartialView(Context, viewPath);
            else
                viewEngineResult = ViewEngines.Engines.FindView(Context, viewPath, null);

            //if (viewEngineResult == null)
            //    throw;// new //FileNotFoundException();//(Resources.ViewCouldNotBeFound);

            // get the view and attach the model to view data
            var view = viewEngineResult.View;
            //if(model != null)
            //Context.Controller.ViewData.Model = model;

            string result = null;

            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(Context, view,
                                            Context.Controller.ViewData,
                                            Context.Controller.TempData,
                                            sw);
                view.Render(ctx, sw);
                result = sw.ToString();
            }

            return result;
        }


        //public ActionResult GetReportSnapshot()
        //{
        //    StiReport report = new StiReport();
        //    var dto = m_NotificationDataService.GenerateNotificationNotCompiledOutputFromNotificationID(Guid.Parse("75d0fec1-900f-4413-89a4-46ea6efb0ee5"));

        //    string reportPath = Server.MapPath("Report");

        //    string filename = reportPath + "\\" + "TermsAndConditions.mrt";


        //    // to get data from the session for which T&C to open 
        //    /* 
        //   var notificationid1 = Session["NotificationtoOpen"];
        //   var notificationid = Guid.Parse(notificationid1.ToString());
        //   var dto = m_NotificationDataService.GenerateNotificationNotCompiledOutputFromNotificationID(notificationid);
        //   string reportPath = Server.MapPath("Report");
        //   string filename = reportPath + "\\" + notificationid.ToString() + ".mrt";*/

        //    if (!Directory.Exists(reportPath))
        //        Directory.CreateDirectory(reportPath);

        //    if (System.IO.File.Exists(filename))
        //        System.IO.File.Delete(filename);

        //    System.IO.File.WriteAllBytes(filename, dto.ReportTemplate);

        //    report.Load(filename);

        //    report.Compile();

        //    if (dto.BusinessObjects != null)
        //    {
        //        dto.BusinessObjects.ForEach(item =>
        //        {
        //            object obj = ByteArrayToObject(item.BusinessObjectContent);

        //            report.RegBusinessObject(item.BusinessObjectCategoryName, item.BusinessObjectName, obj);
        //        });
        //    }

        //    report.Render();

        //    return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, report);
        //    //return View();
        //}
        public ActionResult ViewerEvent()
        {
            //return View();
            return StiMvcViewer.ViewerEventResult(this.HttpContext);
        }

        private Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }


        public StoreResult GetAlltermsandConditions()
        {

            List<VNotificationWithUAOVerificationCodeDTO> AllTnCs = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<VNotificationWithUAOVerificationCodeDTO>>("TnCs");

            var state = WorkflowSessionHelper.GetWorkflowStateFromSession();
            object oValue1 = new object();
            if (state.WorkflowDictionaryDto.WorkflowDictionary.ContainsKey(WorkflowDataEnum.PermanentAccountData.GetStringValue()))
            {
                state.WorkflowDictionaryDto.WorkflowDictionary.TryGetValue(WorkflowDataEnum.PermanentAccountData.GetStringValue(), out oValue1);
                PermanentAccountDTO permanentAcc = (PermanentAccountDTO)oValue1;
                VUserAccountOrganisationDTO uao = m_UserLogic.GetVUserAccountOrganisation(permanentAcc.UserID);
                AllTnCs = m_NotificationLogic.GetAllUserNotificationsForUserWithNotificationGroupNotAccepted(uao.UserAccountOrganisationID, uao.UserTypeID.Value, uao.OrganisationTypeID.Value, NotificationGroupTypeIDEnum.TermsConditions);
                WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey("TnCs", AllTnCs);
            }
             return this.Store(AllTnCs);
        }

    }
}