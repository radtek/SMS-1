using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.NotificationServices.Controllers
{
    using System.Net.Http;
    using System.Web;
    using System.Web.UI;

    using Autofac;

    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.SB.NotificationServices.Report;
    using System.Web.Mvc;

    public class NotificationController : Controller
    {
        private INotificationLogic m_NotificationLogic;
        private ILogger m_Logger;

        //public override HttpResponseMessage RegisterClient()
        //{
        //    return base.RegisterClient();
        //}

        //public NotificationController()
        //{
        //    m_Logger = NotificationService.m_IocContainer.Resolve<ILogger>();
        //    m_NotificationLogic = NotificationService.m_IocContainer.Resolve<INotificationLogic>();
        //}

        //public NotificationController(ILogger logger, INotificationLogic logic)
        //{
        //    m_Logger = logger;
        //    m_NotificationLogic = logic;
        //}

        //public override HttpResponseMessage GetParameters(string clientID, ClientReportSource reportSource)
        //{
        //    var data = base.GetParameters(clientID, reportSource);

        //    var resolver = new NotificationReportResolverApi(m_Logger,m_NotificationLogic);

        //    var rs =  resolver.Resolve(clientID);

        //    reportSource.ParameterValues = new Dictionary<string, object>();

        //    rs.Parameters.ToList().ForEach(
        //        item =>
        //            {
        //                reportSource.ParameterValues.Add(item.Name, item.Value);
        //            })
        //                ;


        //    return base.GetParameters(clientID, reportSource);
        //}

        //protected override IReportResolver CreateReportResolver()
        //{
        //    return new NotificationReportResolverApi(m_Logger,m_NotificationLogic);
        //}

        //protected override ICache CreateCache()
        //{
        //    return Telerik.Reporting.Services.Engine.CacheFactory.CreateFileCache();
        //}

    }
}
