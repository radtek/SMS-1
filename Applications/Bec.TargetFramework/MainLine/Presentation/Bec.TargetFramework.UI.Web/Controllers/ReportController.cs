using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.SB.NotificationServices.Report;
using Fabrik.Common;
using ServiceStack.Text;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;

namespace Bec.TargetFramework.UI.Web.Controllers
{
    public class ReportController : Controller
    {
        private INotificationDataService m_NotificationDataService;
        //private INotificationLogic m_NotificationLogic;

        public ReportController(INotificationDataService dataService)//, INotificationLogic logic)
        {
            m_NotificationDataService = dataService;
           // m_NotificationLogic = logic;
        }

        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetReportSnapshot()
        {
            StiReport report = new StiReport();
            // report.Load(Server.MapPath("~/Content/SimpleList.mdc"));

            var dto =
                m_NotificationDataService.GenerateNotificationNotCompiledOutputFromNotificationID(Guid.Parse("0049dc2b-784d-4830-a27b-feeb40bbd9fa"));

            string reportPath = Server.MapPath("Report");

            // save report if not exists
            string filename = reportPath + "\\" + "0049dc2b-784d-4830-a27b-feeb40bbd9fa.mrt";

            if (!Directory.Exists(reportPath))
                Directory.CreateDirectory(reportPath);

            if (System.IO.File.Exists(filename))
                System.IO.File.Delete(filename);

            System.IO.File.WriteAllBytes(filename, dto.ReportTemplate);

            report.Load(filename);

            report.Compile();

            if (dto.BusinessObjects != null)
            {
                dto.BusinessObjects.ForEach(item =>
                {
                    object obj = ByteArrayToObject(item.BusinessObjectContent);

                    report.RegBusinessObject(item.BusinessObjectCategoryName, item.BusinessObjectName, obj);
                });
            }

            report.Render();

            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext,
            report);
        }
        public ActionResult ViewerEvent()
        {
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


    }
}