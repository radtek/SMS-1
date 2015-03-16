using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.UI.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Workflow.Interfaces;
using Bec.TargetFramework.Entities.DTO.Payment;
using Ext.Net;
using Ext.Net.MVC;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.SB.Messages.Commands;
using Bec.TargetFramework.SB.Infrastructure;
using Fabrik.Common;
using System.Collections;
using NServiceBus;
using NServiceBus.Serilog.Tracing;
using Bec.TargetFramework.Infrastructure.Log;
using Autofac;
using Bec.TargetFramework.SB.Infrastructure;
using BEC.TargetFramework.UI.Web.IOC;
using Autofac.Integration.Mvc;
using Task = System.Threading.Tasks.Task;
using NServiceBus.Installation.Environments;



namespace Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch.Controllers
{
    [DirectController(AreaName = "SafeTransactionSearch")]
    public class PaymentController : Controller
    {
        private IWorkflowProcessService m_WorkflowProcessLogic;
        private IDataLogic m_DataLogic;
        private IProductLogic m_ProductLogic;
        private IShoppingCartLogic m_ShoppingCartLogic;
        private ILogger logger;
        private IBus m_Bus;
        private IUserLogic m_UserLogic;
  
        public PaymentController(ILogger logger, IWorkflowProcessService logic, IDataLogic dLogic, IProductLogic pLogic, IShoppingCartLogic sLogic, IBus bus, IUserLogic uLogic)
        {
            this.logger = logger;
            m_WorkflowProcessLogic = logic;
            m_DataLogic = dLogic;
            m_ProductLogic = pLogic;
            m_ShoppingCartLogic = sLogic;
            m_Bus = bus;
            m_UserLogic = uLogic;
        }
        // GET: SafeTransactionSearch/Payment
        public ActionResult Index()
        {
            Ext.Net.MessageBus.Default.Publish("TreeStructureReload");
            var payment = new PaymentDTO();
            //Guid productID = Guid.Parse("23a68156-4d76-11e4-b796-ff1a9b2bebdc");
            //int versionNumber = 1;
            //string countryCode = "UK";

            //var productDto = m_ProductLogic.GetProduct(productID, versionNumber);

            //var countryDeductions = m_ShoppingCartLogic.GetCountryDeductions(countryCode);

            //var permanentAccount = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<PermanentAccountDTO>(WorkflowDataEnum.PermanentAccountData.GetStringValue());
            //var uaoDto = m_UserLogic.GetVUserAccountOrganisation(permanentAccount.UserID);
            //WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey(WorkflowDataEnum.UserAccountOrganisationData.GetStringValue(), uaoDto);

            //var cart =  m_ShoppingCartLogic.CreateShoppingCart(uaoDto, PaymentCardTypeEnum.VisaCredit, PaymentMethodTypeEnum.CreditCard, countryCode);

            //Ensure.Argument.NotNull(cart.ShoppingCartID);
            //// add product
            //payment.ShoppingCart = m_ShoppingCartLogic.AddProductToShoppingCartFromProductID(cart, productID, versionNumber, 1);

            //WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey(WorkflowDataEnum.PaymentData.GetStringValue(), payment);

            return View(payment);
        }
        [HttpPost]
        public ActionResult Next(PaymentDTO dto)
        {

            //var Payment = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<PaymentDTO>(WorkflowDataEnum.PaymentData.GetStringValue());
           
            //    //Make Payment
            //    WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<PaymentDTO>(WorkflowDataEnum.PaymentData.GetStringValue(), dto);
            //    // need to restart workflow
            var state = WorkflowSessionHelper.GetWorkflowStateFromSession();

            
            


            //    Guid productID = Guid.Parse("23a68156-4d76-11e4-b796-ff1a9b2bebdc");
            //    int versionNumber = 1;
            //    string countryCode = "UK";


            //    var uaoDto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<VUserAccountOrganisationDTO>(WorkflowDataEnum.UserAccountOrganisationData.GetStringValue());

            //    OrderRequestDTO request = new OrderRequestDTO();
            //    request.CardNumber = dto.OrderRequest.CardNumber;
            //    request.CardExpiryMonth = dto.OrderRequest.CardExpiryMonth;
            //    request.CardExpiryYear = dto.OrderRequest.CardExpiryYear;
            //    request.CVVNumber = dto.OrderRequest.CVVNumber;
            //    request.PaymentChargeType = PaymentChargeTypeEnum.Sale;

            //    var message = new OnlinePaymentCommand
            //    {
            //        OrderRequestDto = dto.OrderRequest,
            //        ShoppingCartDto = Payment.ShoppingCart,
            //        VUserAccountOrganisationDto = uaoDto
            //    };

            //    Ensure.Argument.IsNot(Payment.ShoppingCart.PriceDTO.CartFinalPrice <= 0);

            //    m_Bus.SetMessageHeader(message, "Source", "Payment");
            //    m_Bus.SetMessageHeader(message, "MessageType", message.GetType().FullName + "," + message.GetType().Assembly.FullName);
            //    m_Bus.SetMessageHeader(message, "ServiceType", "Payment");

            //    OnlinePaymentResultMessage response = null;

            //    var synchronousHandle = m_Bus.Send(message)
            //                    .Register(asyncResult =>
            //                    {
            //                        NServiceBus.CompletionResult completionResult = asyncResult.AsyncState as NServiceBus.CompletionResult;
            //                        if (completionResult != null && completionResult.Messages.Length > 0)
            //                        {
            //                            // Always expecting one IMessage as reply
            //                            response = completionResult.Messages[0] as OnlinePaymentResultMessage;

            //                        }
            //                    }
            //                    , null);

            //    synchronousHandle.AsyncWaitHandle.WaitOne();
            //    WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<TransactionOrderPaymentDTO>(WorkflowDataEnum.TransactionOrderResponseData.GetStringValue(), response.TransactionOrderPaymentDto);
            //    if (response.TransactionOrderPaymentDto.IsPaymentSuccessful == false)
            //    {
            //        Session.Add("TransactionResponseState", response.TransactionOrderPaymentDto);
            //        Window window = new Window.Builder()
            //          .ID("PaymentErrorWindow")
            //          .Icon(Icon.Application)
            //          .AutoRender(false)
            //          .Width(620)
            //          .Height(250)
            //          .CloseAction(CloseAction.Destroy)
            //          .BodyPadding(5)
            //          .Modal(true)
            //          .Title("Important Payment Information")
            //          .Loader(Html.X()
            //              .ComponentLoader()
            //              .Url(Url.Action("PaymentError", "Payment", new { area = "SafeTransactionSearch" }))
            //              .Mode(LoadMode.Frame));

            //        window.Render(RenderMode.AddTo, "PaymentForm");

            //        window.Show();
            //        return this.Direct();

            //    }
                object oValue1 = new object();
                var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "true");
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("PayClicked", (key) => "true");
                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(state.InstanceID.Value, state);
                currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("PayClicked", out oValue1);
                currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                WorkflowSessionHelper.AddOrReplaceWorkflowStateToSession(currentState.WorkflowState);
                    return RedirectToAction(
                        currentState.CurrentActionDTO.ActionName,
                        currentState.CurrentActionDTO.ControllerName,
                    new
                    {
                        area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
                    });
                

        }

        [HttpPost]
        public ActionResult Previous(PaymentDTO dto)
        {
            WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<PaymentDTO>(WorkflowDataEnum.PaymentData.GetStringValue(), dto);
            var state = WorkflowSessionHelper.GetWorkflowStateFromSession();

            object oValue1 = new object();
            var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "false");
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("PayClicked", (key) => "true");
            var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(state.InstanceID.Value, state);
            currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("PayClicked", out oValue1);
            currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
            WorkflowSessionHelper.AddOrReplaceWorkflowStateToSession(currentState.WorkflowState);

            if (currentState != null)
                return RedirectToAction(
                    currentState.CurrentActionDTO.ActionName,
                    currentState.CurrentActionDTO.ControllerName,
                new
                {
                    area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
                });

            return View();
        }

        public ActionResult PaymentSuccessful()
        {
            var temporaryAccount = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<TemporaryAccountDTO>(WorkflowDataEnum.TemporaryAccountData.GetStringValue());
            temporaryAccount.IsPaymentSuccessful = true;
            WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey(WorkflowDataEnum.TemporaryAccountData.GetStringValue(), temporaryAccount);
            Ext.Net.MessageBus.Default.Publish("TreeStructureReload");
            return View("PaymentSuccessful");
        }

        //[HttpPost]
        public ActionResult PaymentSuccessfulNext()
        {
            // need to restart workflow
            var state = WorkflowSessionHelper.GetWorkflowStateFromSession();

            object oValue1 = new object();
            var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "true");
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("PaymentSuccessfulClicked", (key) => "true");

            var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(state.InstanceID.Value, state);
            currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("PaymentSuccessfulClicked", out oValue1);
            currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
            WorkflowSessionHelper.AddOrReplaceWorkflowStateToSession(currentState.WorkflowState);
            if (currentState != null)
                return RedirectToAction(
                    currentState.CurrentActionDTO.ActionName,
                    currentState.CurrentActionDTO.ControllerName,
                new
                {
                    area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
                });

            return View("PaymentSuccessful");
        }


        public StoreResult GetOrderSummary()
        {

            PaymentDTO payment = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<PaymentDTO>(WorkflowDataEnum.PaymentData.GetStringValue());
            
            return this.Store(payment.ShoppingCart.ShoppingCartItems);

        }


        public ActionResult ShowProductDescWindow(Guid id)
        {
            Window window = new Window.Builder()
               .ID("ProductDescWindow")
               .Icon(Icon.Application)
               .AutoRender(false)
               .Width(620)
               .Height(250)
               .CloseAction(CloseAction.Destroy)
               .BodyPadding(5)
               .Modal(true)
               .Loader(Html.X()
                   .ComponentLoader()
                   .Url(Url.Action("ShowProductDesc", "Payment", new { area = "SafeTransactionSearch", id = id }))
                   .Mode(LoadMode.Frame));

            window.Render(RenderMode.AddTo, "PaymentForm");

            window.Show();

            return this.Direct();
        }

        public ActionResult ShowProductDesc(Guid id)
        {
            //List<CartItemPriceDTO> itemPriceDetails = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<CartItemPriceDTO>>("CartItem");
            var Payment = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<PaymentDTO>(WorkflowDataEnum.PaymentData.GetStringValue());
            var product = Payment.ShoppingCart.ShoppingCartItems as List<ShoppingCartItemDTO>;
            var item = product.SingleOrDefault(p => p.ProductID == id);
            return View("ProductDescription", item);
        }


        public ActionResult PaymentError()
        {
            var response = Session["TransactionResponseState"] as TransactionOrderPaymentDTO;
            return View(response);
        }
    }
}