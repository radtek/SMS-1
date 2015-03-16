using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO;
using Bec.TargetFramework.Entities.Workflow;
using Bec.TargetFramework.Hosts.FileService.Clam;
using Bec.TargetFramework.Hosts.Infrastructure.Interfaces;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.WCF.Exception;
using EnsureThat;

namespace Bec.TargetFramework.Hosts.FileService.Services
{
    [Trace(TraceExceptionsOnly = true)]
    [WcfGlobalExceptionOperationBehavior(typeof (WcfGlobalErrorHandler))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class FileProcessService : IFileProcessService
    {
        [EnsureArgumentAspect]
        public string ScanByteArrayForVirus(byte[] data)
        {
            string clamServer = ConfigurationManager.AppSettings["ClamAVServer"];
            string clamServerPort = ConfigurationManager.AppSettings["ClamAVServerPort"];

            Ensure.That(clamServerPort).IsNotNullOrEmpty();
            Ensure.That(clamServer).IsNotNullOrEmpty();

            ClamClient cc = new ClamClient(clamServer, Convert.ToInt32(clamServerPort));

            ClamScanResult result = null;

            try
            {
                result = cc.SendAndScanFile(data);
            }
            catch (Exception ex)
            {

                throw;
            }

            return result.RawResult;
        }
    }
}
