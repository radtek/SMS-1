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

     [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/BusLogic")]

    public interface IBusLogic : IBusinessLogicService
    {
         [OperationContract]
         bool SaveBusMessage(BusMessageDTO messageDto, BusMessageStatusEnum status, string subscriber, string handler, bool isScheduledTask = false);

         [OperationContract]
         bool HasMessageAlreadyBeenProcessed(BusMessageDTO messageDto, string subscriber, string handler);
          [OperationContract]
         List<TFEventMessageSubscriberDTO> GetTFEventSubscribers(Guid tfEventId);
    }
}
