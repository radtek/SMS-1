using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.SB.Interfaces.Interfaces
{
    [ServiceContract(Namespace = BecTargetFrameworkSBServiceNamespaces.NotificationServiceNamespace + "/NotificationDataService")]
    public interface ILRDataService
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
