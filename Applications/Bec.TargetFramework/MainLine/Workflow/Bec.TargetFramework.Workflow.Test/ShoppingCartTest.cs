using System.Diagnostics;
using Autofac;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Rules.Validation.Card;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.SB.Messages.Commands;
using Bec.TargetFramework.Workflow.Test.FirstDataTransactionService;
using Bec.TargetFramework.Workflow.Test.Objects;
using BEC.TargetFramework.Workflow.Test.IOC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using EnvDTE;
using Fabrik.Common;
using NServiceBus;
using NServiceBus.Serilog.Tracing;
using Omu.ValueInjecter;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Entities.Enums;
using ServiceStack.Common;
using Bec.TargetFramework.Business.Rules.Validation.Bank;

namespace Bec.TargetFramework.Workflow.Test
{
    public class ShoppingCartTest
    {
        private IContainer m_IocContainer;
        private IShoppingCartLogic m_ShoppingCartLogic;
        private ITransactionOrderLogic m_TransactionLogic;
        private IPaymentLogic m_PaymentLogic;
        private IProductLogic m_ProductLogic;
        private IInvoiceLogic m_InvoiceLogic;

        private static IBus m_Bus;
        private IStartableBus m_StartableBus;

        public ShoppingCartTest()
        {

            ContainerBuilder builder = new ContainerBuilder();

            var registrar = new DependencyRegistrar();

            registrar.Register(builder, null);

            m_IocContainer = builder.Build();

            m_ShoppingCartLogic = m_IocContainer.Resolve<IShoppingCartLogic>();
            m_TransactionLogic = m_IocContainer.Resolve<ITransactionOrderLogic>();
            m_PaymentLogic = m_IocContainer.Resolve<IPaymentLogic>();
            m_ProductLogic = m_IocContainer.Resolve<IProductLogic>();
            m_InvoiceLogic = m_IocContainer.Resolve<IInvoiceLogic>();

            TracingLog.Disable();

            //var startableBus = NServiceBusHelper.CreateDefaultStartableBusUsingaAutofacBuilder(m_IocContainer).PurgeOnStartup(true).CreateBus();

            //SB.Infrastructure.HookMessageMutators.InitialiseMessageMutators();

            ////Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install();

            //m_Bus = startableBus.Start();

            //System.Threading.Thread.Sleep(20000);
            //TestManualPaymentViaBusWithReturn();
        }

        private void CheckCreditNumber()
        {
            var validator = new CreditCardValidator();

            var type1 = validator.GetCardType("4864460762442971");
            var type2 = validator.GetCardType("4659427639983700");
            var type3 = validator.GetCardType("6759649826438453");

            var boo = new BankAccountValidator();

            var result = boo.CheckBankAccount("404620", "21283658");
        }

        private void TestManualPaymentViaBusWithReturn()
        {
            System.Threading.Thread.Sleep(20000);

            Guid productID = Guid.Parse("23a68156-4d76-11e4-b796-ff1a9b2bebdc");
            int versionNumber = 1;
            string countryCode = "UK";

            //// get product
            var productDto = m_ProductLogic.GetProduct(productID, versionNumber);

            var countryDeductions = m_ShoppingCartLogic.GetCountryDeductions(countryCode);

            //Ensure.Argument.NotNull(countryDeductions);

            var orgId = Guid.Parse("a36a7f2e-4e24-11e4-8918-e308a5d07188");

            var dto = new VUserAccountOrganisationDTO
            {
                UserAccountOrganisationID = Guid.Parse("b0f07cda-4ec8-11e4-a653-37388da09721"),
                OrganisationID = Guid.Parse("b0ae6b24-4ec8-11e4-8355-b759dc3e7869"),
                Email = "s.anumalsetty@beconsultancy.co.uk",
                OrganisationBranchID = Guid.Parse("b0dc3248-4ec8-11e4-b3cf-2300166e1201"),
                ID = Guid.Parse("fd21914a-0d76-4568-a4e2-895a0d8c25ea")
            };



            //// create shopping cart
            var cart = m_ShoppingCartLogic.CreateShoppingCart(dto, PaymentCardTypeIDEnum.Visa_Credit, PaymentMethodTypeIDEnum.Credit_Card, countryCode);

            Ensure.Argument.NotNull(cart.ShoppingCartID);

            // set payment method and card
            cart.PaymentCardTypeID = 9000;
            cart.PaymentMethodTypeID = 8000;


            // add product
            var cartWithProduct = m_ShoppingCartLogic.AddProductToShoppingCartFromProductID(cart, productID, versionNumber, 1);

            OrderRequestDTO request = new OrderRequestDTO();
            request.CardNumber = "4012001037141112";
            request.CardExpiryMonth = 12;
            request.CardExpiryYear = 16;
            request.CVVNumber = 112;
            request.PaymentChargeType = PaymentChargeTypeEnum.Sale;

            var message = new OnlinePaymentCommand
            {
                OrderRequestDto = request,
                ShoppingCartDto = cartWithProduct,
                VUserAccountOrganisationDto = dto
            };

            Ensure.Argument.IsNot(cartWithProduct.PriceDTO.CartFinalPrice <= 0);

            m_Bus.SetMessageHeader(message, "Source", "PaymentTest");
            m_Bus.SetMessageHeader(message, "MessageType", message.GetType().FullName + "," + message.GetType().Assembly.FullName);
            m_Bus.SetMessageHeader(message, "ServiceType", "PaymentTest");

            OnlinePaymentResultMessage response = null;

            var synchronousHandle = m_Bus.Send(message)
                            .Register(asyncResult =>
                            {
                                NServiceBus.CompletionResult completionResult = asyncResult.AsyncState as NServiceBus.CompletionResult;
                                if (completionResult != null && completionResult.Messages.Length > 0)
                                {
                                    // Always expecting one IMessage as reply
                                    response = completionResult.Messages[0] as OnlinePaymentResultMessage;
                                }
                            }
                            , null);

            synchronousHandle.AsyncWaitHandle.WaitOne();
            // save cart
            //cartWithProduct = m_ShoppingCartLogic.SaveShoppingCart(cartWithProduct);

            //var invoiceDto = m_InvoiceLogic.CreateAndSaveInvoiceFromShoppingCart(cartWithProduct);

            //var transactionOrder = m_TransactionLogic.CreateAndSaveTransactionOrderFromShoppingCartDTO(dto,
            //    cartWithProduct, invoiceDto, TransactionTypeEnum.Payment);

            //// try fail payment, expiry past
            //var paymentDto = m_PaymentLogic.ProcessPaymentTransaction(dto, transactionOrder, request);
            //// try success payment expiry now
            //request.CardExpiryYear = 64;

            //paymentDto = m_PaymentLogic.ProcessPaymentTransaction(dto, transactionOrder, request);
        }

        private void TestManualPayment()
        {
            System.Threading.Thread.Sleep(15000);

            Guid productID = Guid.Parse("23a68156-4d76-11e4-b796-ff1a9b2bebdc");
            int versionNumber = 1;
            string countryCode = "UK";

            //// get product
            var productDto = m_ProductLogic.GetProduct(productID, versionNumber);

            var countryDeductions = m_ShoppingCartLogic.GetCountryDeductions(countryCode);

            //Ensure.Argument.NotNull(countryDeductions);

            var orgId = Guid.Parse("a36a7f2e-4e24-11e4-8918-e308a5d07188");

            var dto = new VUserAccountOrganisationDTO
            {
                UserAccountOrganisationID = Guid.Parse("b0f07cda-4ec8-11e4-a653-37388da09721"),
                OrganisationID = Guid.Parse("b0ae6b24-4ec8-11e4-8355-b759dc3e7869"),
                Email = "s.anumalsetty@beconsultancy.co.uk",
                OrganisationBranchID = Guid.Parse("b0dc3248-4ec8-11e4-b3cf-2300166e1201"),
                ID = Guid.Parse("fd21914a-0d76-4568-a4e2-895a0d8c25ea")
            };



            //// create shopping cart
            var cart = m_ShoppingCartLogic.CreateShoppingCart(dto, PaymentCardTypeIDEnum.Visa_Credit, PaymentMethodTypeIDEnum.Credit_Card, countryCode);

            Ensure.Argument.NotNull(cart.ShoppingCartID);

            // set payment method and card
            cart.PaymentCardTypeID = 9000;
            cart.PaymentMethodTypeID = 8000;


            // add product
            var cartWithProduct = m_ShoppingCartLogic.AddProductToShoppingCartFromProductID(cart, productID, versionNumber, 1);

            OrderRequestDTO request = new OrderRequestDTO();
            request.CardNumber = "4012001037141112";
            request.CardExpiryMonth = 12;
            request.CardExpiryYear = 16;
            request.CVVNumber = 112;
            request.PaymentChargeType = PaymentChargeTypeEnum.Sale;

            Ensure.Argument.IsNot(cartWithProduct.PriceDTO.CartFinalPrice <= 0);

            // save cart
            cartWithProduct = m_ShoppingCartLogic.SaveShoppingCart(cartWithProduct);

            var invoiceDto = m_InvoiceLogic.CreateAndSaveInvoiceFromShoppingCart(cartWithProduct);

            var transactionOrder = m_TransactionLogic.CreateAndSaveTransactionOrderFromShoppingCartDTO(dto,
                cartWithProduct, invoiceDto, TransactionTypeIDEnum.Payment);

            // try fail payment, expiry past
            var paymentDto = m_PaymentLogic.ProcessPaymentTransaction(dto, transactionOrder, request);
            // try success payment expiry now
            request.CardExpiryYear = 64;

            paymentDto = m_PaymentLogic.ProcessPaymentTransaction(dto, transactionOrder, request);
        }


        private void MakeAPaymentDirect()
        {
            string gatewayID = "AE7819-05";
            string hMAC = "Vcuo8yPVj09ZAzOy3AL3WxBe0yx24dcP";
            string username = "be100";
            string password = "9qvwiw0k";
            string keyId = "129155 ";

            PaymentTransactionRequestDTO request = new PaymentTransactionRequestDTO();
            request.CreditCardCvv2 = "123";
            request.CreditCardExpireMonth = 02;
            request.CreditCardExpireYear = 2016;
            request.CreditCardName = "Boo";
            request.CreditCardNumber = "4111111111111111";
            request.CreditCardType = "VISA";
            request.IsRecurringPayment = false;
            request.OrderTotal = 101;
            request.InitialOrderId = 1000;
            request.OrderGuid = Guid.NewGuid();

            // payment
            var response = ProcessPayment(request, gatewayID, hMAC, password, "00", keyId);

           
            response = ProcessPayment(request, gatewayID, hMAC, password, "01", keyId);

          var merchant = new Merchant(gatewayID, password, hMAC, keyId, true);

           // var response = merchant.Charge(1, "Chris Misson", "4111111111111111", 1000, 10, 2016, 123, "123 Reg Town", "Boston", "1001", "1001");


            
        }

        private void CreateShoppingCartTest()
        {
           // var cart = m_ShoppingCartLogic.CreateShoppingCart(Guid.NewGuid(),"UK");
           // cart = m_ShoppingCartLogic.AddProductToShoppingCartViaID(cart, Guid.Parse("3f7f7a8a-4342-4d55-9fb3-4778fadb9d16"), 1, 1);

           // m_ShoppingCartLogic.InsertShoppingCart(cart);

           // cart.ShoppingCartItems.First().Quantity = 2;

           //// cart = m_ShoppingCartLogic.CalculateShoppingCart(cart);

           // m_ShoppingCartLogic.UpdateShoppingCart(cart);

           // //cart = m_ShoppingCartLogic.RemoveProductFromShoppingCartViaID(cart, cart.ShoppingCartItems.First());

           // //m_ShoppingCartLogic.UpdateShoppingCart(cart);

           // //m_ShoppingCartLogic.DeleteShoppingCart(cart);

           // var order = m_TransactionLogic.CreateTransactionOrderFromShoppingCartDTO(cart);


        }

        public PaymentTransactionResponseDTO ProcessPayment(PaymentTransactionRequestDTO processPaymentRequest, string gateway, string hmac, string password, string transactionType, string keyID)
        {
            bool flag;
            PaymentTransactionResponseDTO processPaymentResult = new PaymentTransactionResponseDTO();
            //Customer customerById = this._customerService.GetCustomerById(processPaymentRequest.CustomerId);
            string creditCardNumber = processPaymentRequest.CreditCardNumber;
            char[] chrArray = new char[] { '|' };
            string str = creditCardNumber.Split(chrArray)[0];
            if (processPaymentRequest.CreditCardNumber.Contains("|"))
            {
                string creditCardNumber1 = processPaymentRequest.CreditCardNumber;
                char[] chrArray1 = new char[] { '|' };
                flag = Convert.ToBoolean(creditCardNumber1.Split(chrArray1)[1]);
            }
            else
            {
                flag = false;
            }
            bool flag1 = flag;
            bool flag2 = processPaymentRequest.CreditCardNumber.StartsWith("T");
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            try
            {
                using (StringWriter stringWriter = new StringWriter(stringBuilder1))
                {
                    using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
                    {
                        xmlTextWriter.Formatting = Formatting.Indented;
                        xmlTextWriter.WriteStartElement("Transaction");
                        xmlTextWriter.WriteElementString("ExactID", gateway);
                        stringBuilder.Append("ExactID, ");
                        xmlTextWriter.WriteElementString("Password", password);
                        stringBuilder.Append("Password, ");
                        xmlTextWriter.WriteElementString("Transaction_Type", transactionType);
                        stringBuilder.Append("Type, ");
                        xmlTextWriter.WriteElementString("DollarAmount", processPaymentRequest.OrderTotal.ToString());
                        stringBuilder.Append("DollarAmount, ");
                        string str1 = processPaymentRequest.CreditCardExpireMonth.ToString("00");
                        int creditCardExpireYear = processPaymentRequest.CreditCardExpireYear;
                        xmlTextWriter.WriteElementString("Expiry_Date", string.Concat(str1, creditCardExpireYear.ToString().Substring(2, 2)));
                        stringBuilder.Append("Expire, ");
                        xmlTextWriter.WriteElementString("CardHoldersName", processPaymentRequest.CreditCardName);
                        stringBuilder.Append("CC Name, ");
                        xmlTextWriter.WriteElementString("Card_Number", str);
                        stringBuilder.Append("CC Number, ");
                        // xmlTextWriter.WriteElementString("VerificationStr1", customerById.BillingAddress.Address1 ?? (string.Concat("|", customerById.BillingAddress.ZipPostalCode) ?? string.Concat("|", (customerById.BillingAddress.StateProvince != null ? customerById.BillingAddress.StateProvince.Name : ""), "|", customerById.BillingAddress.Country.ThreeLetterIsoCode)));
                        stringBuilder.Append("Verification Str 1, ");
                        xmlTextWriter.WriteElementString("VerificationStr2", processPaymentRequest.CreditCardCvv2);
                        stringBuilder.Append("Verification Str 2, ");
                        xmlTextWriter.WriteElementString("CVD_Presence_Ind", "1");
                        xmlTextWriter.WriteElementString("Client_Email", "s.anumalsetty@beconsultancy.co.uk");
                        stringBuilder.Append("Email, ");
                        xmlTextWriter.WriteElementString("Currency", "GBP");
                        stringBuilder.Append("Currency, ");
                        xmlTextWriter.WriteElementString("Customer_Ref", Guid.NewGuid().ToString());
                        stringBuilder.Append("Customer Ref, ");
                        xmlTextWriter.WriteElementString("Reference_No", processPaymentRequest.OrderGuid.ToString());
                        stringBuilder.Append("Reference, ");
                        xmlTextWriter.WriteElementString("Client_IP", "192.168.1.10");
                        stringBuilder.Append("IP, ");
                        xmlTextWriter.WriteElementString("ZipCode", "");
                        stringBuilder.Append("Zip Code, ");
                        xmlTextWriter.WriteEndElement();
                        string str3 = stringBuilder1.ToString();
                 
                            try
                            {
                                PaymentTransactionResponseDTO dto = this.SendFDRequest(str3,keyID,hmac);

                                if (!dto.Transaction_Approved)
                                    dto.AddError(string.Format("Error {0}: {1}", dto.Bank_Resp_Code, dto.Bank_Message));
                                else
                                {
                                    dto.AuthorizationTransactionId = string.Concat(dto.Authorization_Num, "|", dto.Transaction_Tag);
                                    dto.AuthorizationTransactionResult = string.Format("Approved ({0}: {1})", dto.EXact_Resp_Code, dto.EXact_Message);
                                    //dto.NewPaymentStatus = 
                                    // processPaymentResult.NewPaymentStatus = (this._firstDataSettings.TransactionMode == TransactMode.Authorize ? PaymentStatus.Authorized : PaymentStatus.Paid);
                                }
                            }
                            catch (Exception exception1)
                            {
                                Exception exception = exception1;
                                //   processPaymentResult.AddError(this._localizationService.GetResource("BitShift.Plugin.FirstData.TechnicalError"));
                                // LoggingExtensions.Error(this._logger, "Error processing payment", exception, Environment.UserName);
                            }
            
                    }
                }
            }
            catch (Exception exception3)
            {
                Exception exception2 = exception3;
              //  processPaymentResult.AddError(this._localizationService.GetResource("BitShift.Plugin.FirstData.TechnicalError"));
                // LoggingExtensions.Error(this._logger, string.Concat("Error processing payment.  Null Check: ", stringBuilder.ToString()), exception2, Environment.UserName);
            }
            return processPaymentResult;
        }

        private PaymentTransactionResponseDTO SendFDRequest(string transaction, string keyID, string hmac)
        {
            PaymentTransactionResponseDTO dto = new PaymentTransactionResponseDTO();

            string end;
            XmlNode itemOf;
            byte[] bytes = (new UTF8Encoding()).GetBytes(transaction);
            SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
            string str = BitConverter.ToString(sHA1CryptoServiceProvider.ComputeHash(bytes)).Replace("-", "");
            string lower = str.ToLower();
            string str1 = "POST\n";
            string str2 = "application/xml\n";
            string str3 = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string str4 = "/transaction/v12";
            string str5 = keyID;
            string str6 = hmac;
            string[] strArrays = new string[] { str1, str2, lower, "\n", str3, "\n", str4 };
            string str7 = string.Concat(strArrays);
            HMAC hMACSHA1 = new HMACSHA1(Encoding.UTF8.GetBytes(str6));
            byte[] numArray = hMACSHA1.ComputeHash(Encoding.UTF8.GetBytes(str7));
            string base64String = Convert.ToBase64String(numArray);
            HttpWebRequest byteCount = (HttpWebRequest)WebRequest.Create("https://api.demo.globalgatewaye4.firstdata.com/transaction/v12");
            byteCount.Method = "POST";
            byteCount.Accept = "application/xml";
            byteCount.Headers.Add("x-gge4-date", str3);
            byteCount.Headers.Add("x-gge4-content-sha1", lower);
            byteCount.ContentLength = (long)Encoding.UTF8.GetByteCount(transaction);
            byteCount.ContentType = "application/xml";
            byteCount.Headers["Authorization"] = string.Concat("GGE4_API ", str5, ":", base64String);
            StreamWriter streamWriter = null;
            streamWriter = new StreamWriter(byteCount.GetRequestStream());
            streamWriter.Write(transaction);
            streamWriter.Flush();
            streamWriter.Close();
            try
            {
                //using (StreamReader streamReader = new StreamReader(((HttpWebResponse)byteCount.GetResponse()).GetResponseStream()))
                //{
                //    end = streamReader.ReadToEnd();
                //    streamReader.Close();
                //}

                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(TransactionResult));
                var response = (TransactionResult) serializer.Deserialize(((HttpWebResponse)byteCount.GetResponse()).GetResponseStream());
                dto.InjectFrom(response);
            }
            catch (WebException webException)
            {
                using (StreamReader streamReader1 = new StreamReader(webException.Response.GetResponseStream()))
                {
                    end = streamReader1.ReadToEnd();
                    streamReader1.Close();
                    throw new Exception(end);
                }
            }
            return dto;
        }
    }
}
