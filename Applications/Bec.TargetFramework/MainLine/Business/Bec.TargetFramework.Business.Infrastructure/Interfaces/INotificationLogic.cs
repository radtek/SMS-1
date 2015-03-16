using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using Bec.TargetFramework.Data;
    using Bec.TargetFramework.Entities;
    using System.ServiceModel;

    //Bec.TargetFramework.Entities

     [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/NotificationLogic")]

    public interface INotificationLogic : IBusinessLogicService
     {

         [OperationContract]
         bool HasNotificationAlreadyBeenSentInTheLastTimePeriod(Guid? uaoID, Guid? organisationId,
             Guid notifcationConstructID,
             int notificationConstructVersion, Guid? parentID, bool isRead, TimeSpan sentInLast);

         [OperationContract]
         List<VNotificationConstructGroupDTO> GetNotificationGroupConstructs(Guid userTypeID,
             int organisationTypeID, NotificationGroupTypeIDEnum enumValue);


        [OperationContract]
         bool SaveNotification(NotificationDTO dto);

         [OperationContract]
        NotificationConstructDTO GetNotificationConstruct(Guid organisationNotificationConstructID, int version);
         [OperationContract]
         List<VDefaultEmailAddressDTO> GetRecipientAddressDetails(List<NotificationRecipientDTO> recipients );
          [OperationContract]
         VNotificationConstructDTO GetNotificationConstructViewData(Guid organisationNotificationConstructID, int versionNumber);
          [OperationContract]
         NotificationConstructDTO GetLatestNotificationConstructIdFromName(string name);

          [OperationContract]
          List<VNotificationWithUAOVerificationCodeDTO> GetAllUserNotificationsForUserWithNotificationGroupNotAccepted(
             Guid userAccountOrganisationID, Guid userTypeID, int organisationTypeId, NotificationGroupTypeIDEnum groupEnumValue);
    }
}
