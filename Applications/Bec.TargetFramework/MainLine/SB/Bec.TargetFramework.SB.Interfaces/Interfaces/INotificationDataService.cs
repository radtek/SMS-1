using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.SB.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INotificationDataService" in both code and config file together.
    [ServiceContract(Namespace = BecTargetFrameworkSBServiceNamespaces.NotificationServiceNamespace + "/NotificationDataService")]
    public interface INotificationDataService
    {
        [OperationContract]
        byte[] GenerateNotificationOutputFromNotificationID(Guid notificationID);
         [OperationContract]
        NotificationRenderDTO GenerateNotificationNotCompiledOutputFromNotificationID(Guid notificationID);
         [OperationContract]
        byte[] GenericNotificationtOutputFromNotificationConstruct(Guid notificationConstructID,
            int notificationConstructVersionNumber, NotificationDictionaryDTO dto,
            NotificationExportFormatIDEnum exportFormatEnumValue);
    }
}
