using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Workflow;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Framework.Configuration;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Handlers.Base;
using Bec.TargetFramework.SB.Messages.Commands;
using Bec.TargetFramework.SB.TaskHandlers.EventHandlers;
using Bec.TargetFramework.SB.Infrastructure.Extensions;
using Bec.TargetFramework.Security;
using Bec.TargetFramework.Workflow.Interfaces;
using EnsureThat;
using Bec.TargetFramework.SB.Infrastructure;

namespace Bec.TargetFramework.SB.TaskHandlers.CommandHandlers
{
    public class OnlinePaymentHandler : ConcurrentBaseCommandHandler<Bec.TargetFramework.SB.Messages.Commands.OnlinePaymentCommand>
    {
        private IShoppingCartLogic m_ShoppingCartLogic;
        private IInvoiceLogic m_InvoiceLogic;
        private ITransactionOrderLogic m_TransactionOrderLogic;
        private IPaymentLogic m_PaymentLogic;
        private INotificationLogic m_NotificationLogic;
        public OnlinePaymentHandler(ILogger logger,
            IBusLogic busLogic, 
            IClassificationDataLogic dataLogic,
            IShoppingCartLogic sLogic,
            IInvoiceLogic iLogic,
            ITransactionOrderLogic iTrans,
            IPaymentLogic pLogic,
            CommonSettings settings,
            INotificationLogic nLogic)
            : base(logger, busLogic, settings)
        {
            m_ShoppingCartLogic = sLogic;
            m_InvoiceLogic = iLogic;
            m_TransactionOrderLogic = iTrans;
            m_PaymentLogic = pLogic;
            m_NotificationLogic = nLogic;
        }

        private void ValidateEvent(Bec.TargetFramework.SB.Messages.Commands.OnlinePaymentCommand paymentCommand)
        {
            Ensure.That(paymentCommand.ShoppingCartDto).IsNotNull();
            Ensure.That(paymentCommand.OrderRequestDto).IsNotNull();
            Ensure.That(paymentCommand.VUserAccountOrganisationDto).IsNotNull();
            Ensure.That(paymentCommand.ShoppingCartDto.ShoppingCartID.Equals(Guid.Empty)).IsFalse();

        }

        public override void HandleMessage(Bec.TargetFramework.SB.Messages.Commands.OnlinePaymentCommand paymentCommand)
        {
            try
            {
                ValidateEvent(paymentCommand);

                // check whether shopping cart has been saved
                if (!m_ShoppingCartLogic.DoesShoppingCartExist(paymentCommand.ShoppingCartDto.ShoppingCartID))
                    m_ShoppingCartLogic.SaveShoppingCart(paymentCommand.ShoppingCartDto);

                // check whether an invoice exists, if not create otherwise load
                InvoiceDTO invoiceDto = null;

                if (!m_InvoiceLogic.DoesInvoiceExistForShoppingCart(paymentCommand.ShoppingCartDto.ShoppingCartID))
                    invoiceDto = m_InvoiceLogic.CreateAndSaveInvoiceFromShoppingCart(paymentCommand.ShoppingCartDto);
                else
                    invoiceDto =
                        m_InvoiceLogic.GetInvoiceExistForShoppingCart(paymentCommand.ShoppingCartDto.ShoppingCartID);

                // check whether a transactionorder exists, if not create otherwise load
                TransactionOrderDTO transOrderDto = null;

                if (!m_TransactionOrderLogic.DoesTransactionExistForInvoice(invoiceDto.InvoiceID))
                    transOrderDto =
                        m_TransactionOrderLogic.CreateAndSaveTransactionOrderFromShoppingCartDTO(
                            paymentCommand.VUserAccountOrganisationDto,
                            paymentCommand.ShoppingCartDto, invoiceDto, TransactionTypeIDEnum.Payment);
                else
                    transOrderDto = m_TransactionOrderLogic.GetTransactionForInvoice(invoiceDto.InvoiceID);

                // check whether a successful payment exists otherwise try and pay
                TransactionOrderPaymentDTO paymentDto = null;

                if (
                    !m_PaymentLogic.DoesASuccessfulOrderPaymentExistForTransactionOrder(transOrderDto.TransactionOrderID))
                {
                    paymentDto = m_PaymentLogic.ProcessPaymentTransaction(paymentCommand.VUserAccountOrganisationDto,
                        transOrderDto,
                        paymentCommand.OrderRequestDto);
                }
                else
                    paymentDto =
                        m_PaymentLogic.GetTheSuccessfulOrderPaymentForTransactionOrder(transOrderDto.TransactionOrderID);

                // if successful send receipt notification
                if (paymentDto.IsPaymentSuccessful)
                {
                    var dictionary = new ConcurrentDictionary<string, object>();

                    dictionary.TryAdd("InvoiceDTO", invoiceDto);
                    dictionary.TryAdd("VUserOrganisationDTO", paymentCommand.VUserAccountOrganisationDto);
                    dictionary.TryAdd("OrderRequestDTO", paymentCommand.OrderRequestDto);

                    Bus.SendNotificationToUserViaUAO<OnlinePaymentCommand>(m_NotificationLogic, m_CommonSettings,
                        NotificationConstructEnum.OnlinePaymentReceipt.GetStringValue(),
                        paymentCommand.VUserAccountOrganisationDto.UserAccountOrganisationID,
                        new NotificationDictionaryDTO { NotificationDictionary = dictionary }
                        );
                }

                var response = Bus.CreateInstance<OnlinePaymentResultMessage>(s =>
                {
                    s.TransactionOrderPaymentDto = paymentDto;
                });
                ;
                ;

                // reply with orderpaymentresult
                Bus.Reply(response);

                LogMessageAsCompleted();
            }
            catch (System.Exception ex)
            {
                // log error
                LogError("OnlinepaymentCommand Error", ex, NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers).EventReference);
            	
                throw;
            }
        }
    }
}
