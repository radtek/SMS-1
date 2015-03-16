using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Notification;
using Bec.TargetFramework.SB.Notifications.Base;
using EnsureThat;

namespace Bec.TargetFramework.SB.Notifications.Mutators
{
    public sealed class OnlinePaymentReceiptMutator : BaseNotificationMutator
    {
        private IUserLogic m_UserLogic;
        private IInvoiceLogic m_InvoiceLogic;

        public override NotificationDictionaryDTO MutateNotification()
        {
            var invoiceDto =
                NotificationDictionary.NotificationDictionary["InvoiceDTO"] as InvoiceDTO;

            var paymentProviderDetail = m_InvoiceLogic.GetPaymentProviderOrganisationDetail();

            var invoiceDetail = m_InvoiceLogic.GetInvoiceWithCurrentTransactionOrderStatus(invoiceDto.InvoiceID);

            NotificationDictionary.NotificationDictionary.TryAdd("VOrganisationDetailDTO", paymentProviderDetail);

            NotificationDictionary.NotificationDictionary.TryAdd("VInvoiceWithCurrentTransactionOrderStatusDTO", invoiceDetail);

            return NotificationDictionary;
        }

        public override void InitialiseMutator()
        {
            m_UserLogic = IocContainer.Resolve<IUserLogic>();
            m_InvoiceLogic = IocContainer.Resolve<IInvoiceLogic>();
        }
    }
}
