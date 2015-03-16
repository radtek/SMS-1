using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using System;
using System.ServiceModel;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/PaymentLogic")]
    public interface IPaymentLogic : IBusinessLogicService
    {
        [OperationContract]
        TransactionOrderPaymentDTO ProcessPaymentTransaction(VUserAccountOrganisationDTO clientUaoDto,
            TransactionOrderDTO transactionOrderDto, OrderRequestDTO request);
        [OperationContract]
        bool DoesASuccessfulOrderPaymentExistForTransactionOrder(Guid transactionOrderId);

        [OperationContract]
        TransactionOrderPaymentDTO GetTheSuccessfulOrderPaymentForTransactionOrder(Guid transactionOrderId);
    }
}
