
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using Bec.TargetFramework.Hosts.Infrastructure;

namespace Bec.TargetFramework.Hosts.Infrastructure.Interfaces
{
    //Bec.TargetFramework.Entities

    [ServiceContract(Namespace = BecTargetFrameworkFileServiceNamespaces.FileNamespace + "FileProcessService")]
    public interface IFileProcessService
    {
        [OperationContract]
        string ScanByteArrayForVirus(byte[] data);
    }
}
