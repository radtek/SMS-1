using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bec.TargetFramework.Infrastructure.WCF
{
    public class NetTcpBindingConfiguration
    {
        public static NetTcpBinding GetDefaultNetTcpBinding()
        {
            return new NetTcpBinding
            {
                Name = "NetBinding"
                ,
                ReaderQuotas = new XmlDictionaryReaderQuotas{MaxArrayLength = 65536,MaxDepth = 32,MaxStringContentLength = 2147483647,MaxBytesPerRead = 4096},
                CloseTimeout = new TimeSpan(0, 5, 0)
                ,
                MaxConnections = 100
                ,
                ListenBacklog = 200
                ,
                PortSharingEnabled = true
                ,
                OpenTimeout = new TimeSpan(0, 5, 0)
                ,
                ReceiveTimeout = new TimeSpan(0, 5, 0)
                ,
                SendTimeout = new TimeSpan(0, 5, 0)
                ,
                TransactionFlow = false
                ,
                TransferMode = TransferMode.Buffered
                ,
                TransactionProtocol = TransactionProtocol.OleTransactions
                ,
                HostNameComparisonMode = HostNameComparisonMode.StrongWildcard
                ,
                MaxBufferPoolSize = 2000000000
                ,
                MaxBufferSize = 2000000000
                ,
                MaxReceivedMessageSize = 2000000000,

                Security = new NetTcpSecurity { Mode = SecurityMode.None} 
                ,
                ReliableSession = new OptionalReliableSession { InactivityTimeout = new TimeSpan(0, 10, 0), Ordered = true }
            };
        }
    }
}
