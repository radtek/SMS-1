using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bec.TargetFramework.SB.Interfaces
{
    //Bec.TargetFramework.Entities

    [ServiceContract(Namespace = BecTargetFrameworkSBServiceNamespaces.NotificationServiceNamespace + "/NotificationProcessService")]
    public interface INotificationProcessService
    {
        [OperationContract]
        void GenerateNotificationDataForWebViewer();
    }
}
