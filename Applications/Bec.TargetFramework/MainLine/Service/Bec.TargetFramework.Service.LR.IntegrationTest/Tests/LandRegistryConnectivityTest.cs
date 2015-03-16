using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Test.Base;
using Bec.TargetFramework.Infrastructure.Test.Interfaces;
using Bec.TargetFramework.Service.LR.Entities.Engine;
using Bec.TargetFramework.Service.LR.Entities.EnquiryByPropertyDescription20;
using Bec.TargetFramework.Service.LR.Entities.Objects;
using Bec.TargetFramework.Service.LR.Entities.OfficialCopyTitleKnown21;
using Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21;
using Bec.TargetFramework.Service.LR.Infrastructure.Base;
using Ionic.Zip;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bec.TargetFramework.Service.LR.Entities;
using AmountType = Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21.AmountType;
using IndicatorType = Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21.IndicatorType;
using ProductResponseCodeContentType = Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21.ProductResponseCodeContentType;
using Q1AddressType = Bec.TargetFramework.Service.LR.Entities.EnquiryByPropertyDescription20.Q1AddressType;
using Q1CustomerReferenceType = Bec.TargetFramework.Service.LR.Entities.EnquiryByPropertyDescription20.Q1CustomerReferenceType;
using Q1ExpectedPriceType = Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21.Q1ExpectedPriceType;
using Q1ExternalReferenceType = Bec.TargetFramework.Service.LR.Entities.EnquiryByPropertyDescription20.Q1ExternalReferenceType;
using Q1IdentifierType = Bec.TargetFramework.Service.LR.Entities.EnquiryByPropertyDescription20.Q1IdentifierType;
using Q1ProductType = Bec.TargetFramework.Service.LR.Entities.EnquiryByPropertyDescription20.Q1ProductType;
using Q1SubjectPropertyType = Bec.TargetFramework.Service.LR.Entities.EnquiryByPropertyDescription20.Q1SubjectPropertyType;
using Q1TextType = Bec.TargetFramework.Service.LR.Entities.EnquiryByPropertyDescription20.Q1TextType;
using Q1TitleKnownOfficialCopyType = Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21.Q1TitleKnownOfficialCopyType;
using Q2TextType = Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21.Q2TextType;
using Bec.TargetFramework.Service.LR.Infrastructure;

namespace Bec.TargetFramework.Service.LR.IntegrationTest.Tests
{
    [TestClass]
    public class LandRegistryConnectivityTest : UnitTestBase
    {
        private static Random m_RandomNumberGenerator;

        [ClassInitialize]
        public static void ClassInitialise(TestContext tc)
        {
            m_RandomNumberGenerator = new Random(1000000);
        }


        #region Tests

        private X509Certificate2Collection CreateCertificateCrendential()
        {
            X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySerialNumber, "47 ce 29 1d", false);

            return col;
        }

        /// <summary>
        /// Copy of Title and associated documents using document type
        /// </summary>
        [TestMethod]
        public void OfficialCopyTitleKnownConnectivityTest()
        {
            var binding = new BasicHttpBinding("TestCertificationPortBinding");
            var endPointAddress =
                new EndpointAddress(
                    new Uri(
                        "https://bgtest.landregistry.gov.uk/b2b/ECBG_StubService/OfficialCopyTitleKnownV2_1WebService?wsdl"));

            using (
                var client =
                    new OC1TitleKnownV2_1ServiceClient(binding, endPointAddress))
            {
                client.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.Root,
                    X509FindType.FindBySerialNumber, "47 ce 29 1d");

                client.ChannelFactory.Endpoint.Behaviors.Add(new LREndpointBehavior("BGUser001", "landreg001"));

                var request = new RequestTitleKnownOfficialCopyV2_1Type();

                try
                {
                    request.ID = new Entities.OfficialCopyTitleKnown21.Q1IdentifierType();
                    request.ID.MessageID = new Entities.OfficialCopyTitleKnown21.Q1TextType();
                    request.ID.MessageID.Value = Guid.NewGuid().ToString();

                    request.Product = new Entities.OfficialCopyTitleKnown21.Q1ProductType();
                    request.Product.ExternalReference = new Entities.OfficialCopyTitleKnown21.Q1ExternalReferenceType();
                    request.Product.ExternalReference.Reference = "boooo";
                    request.Product.CustomerReference = new Entities.OfficialCopyTitleKnown21.Q1CustomerReferenceType();
                    request.Product.CustomerReference.Reference = "boooo";

                    request.Product.SubjectProperty = new Entities.OfficialCopyTitleKnown21.Q1SubjectPropertyType();
                    request.Product.SubjectProperty.TitleNumber = new Entities.OfficialCopyTitleKnown21.Q2TextType();
                    //request.Product.SubjectProperty.TitleNumber.Value = "ST500681";
                    request.Product.SubjectProperty.TitleNumber.Value = "DN100";
                    request.Product.ExpectedPrice = new Entities.OfficialCopyTitleKnown21.Q1ExpectedPriceType();
                    request.Product.ExpectedPrice.GrossPriceAmount = new Entities.OfficialCopyTitleKnown21.AmountType();
                    request.Product.ExpectedPrice.GrossPriceAmount.Value = 10;

                    request.Product.DocumentDetails = new Q1DocumentDetailsType[1];

                    request.Product.Contact = new Q1ContactType[1];

                    var contact = new Q1ContactType();

                    contact.Communication = new Q1CommunicationType();
                    contact.Communication.Telephone =
                        new Bec.TargetFramework.Service.LR.Entities.OfficialCopyTitleKnown21.Q3TextType();
                    contact.Communication.Telephone.Value = "02088517935";

                    contact.Name = new Bec.TargetFramework.Service.LR.Entities.OfficialCopyTitleKnown21.Q3TextType();
                    contact.Name.Value = "Chris Misson";

                    request.Product.Contact[0] = contact;

                    request.Product.TitleKnownOfficialCopy = new Entities.OfficialCopyTitleKnown21.Q1TitleKnownOfficialCopyType();
                    request.Product.TitleKnownOfficialCopy.RequestedOfficialCopyCode = new RequestedOfficialCopyCodeType();
                    request.Product.TitleKnownOfficialCopy.PropertyDescription = "A Nice House";
                    request.Product.TitleKnownOfficialCopy.OfficialCopyTypeCode = new OfficialCopyCodeType();
                    request.Product.TitleKnownOfficialCopy.OfficialCopyTypeCode.Value = OfficialCopyCodeContentType.Item10;
                    request.Product.TitleKnownOfficialCopy.ContinueIfTitleIsClosedAndContinuedIndicator =new Entities.OfficialCopyTitleKnown21.IndicatorType();
                    request.Product.TitleKnownOfficialCopy.ContinueIfTitleIsClosedAndContinuedIndicator.Value = true;
                    request.Product.TitleKnownOfficialCopy.ContinueIfActualFeeExceedsExpectedFeeIndicator = new Entities.OfficialCopyTitleKnown21.IndicatorType();
                    request.Product.TitleKnownOfficialCopy.ContinueIfActualFeeExceedsExpectedFeeIndicator.Value = true;
                    request.Product.TitleKnownOfficialCopy.NotifyIfPendingApplicationIndicator =new Entities.OfficialCopyTitleKnown21.IndicatorType();
                    request.Product.TitleKnownOfficialCopy.NotifyIfPendingApplicationIndicator.Value = true;
                    request.Product.TitleKnownOfficialCopy.NotifyIfPendingFirstRegistrationIndicator = new Entities.OfficialCopyTitleKnown21.IndicatorType();
                    request.Product.TitleKnownOfficialCopy.NotifyIfPendingFirstRegistrationIndicator.Value = true;
                    request.Product.TitleKnownOfficialCopy.SendBackDatedIndicator = new Entities.OfficialCopyTitleKnown21.IndicatorType();
                    request.Product.TitleKnownOfficialCopy.SendBackDatedIndicator.Value = true;

                    // request 2xdeed documents
                    request.Product.DocumentDetails = new Q1DocumentDetailsType[2];

                    var documentDetails = new Q1DocumentDetailsType();

                    documentDetails.AdditionalInformation = new Bec.TargetFramework.Service.LR.Entities.OfficialCopyTitleKnown21.Q3TextType();
                    documentDetails.AdditionalInformation.Value = "1";
                    
                    documentDetails.TypeOfDocumentCode = new TypeOfDocumentCodeType();
                    //documentDetails.TypeOfDocumentCode.Value = TypeOfDocumentCodeContentType.Item180;
                    documentDetails.TypeOfDocumentCode.Value = TypeOfDocumentCodeContentType.Item70;
                    documentDetails.DateOfDocumentDate = new Bec.TargetFramework.Service.LR.Entities.OfficialCopyTitleKnown21.DateType();
                    documentDetails.DateOfDocumentDate.Value = DateTime.Now;

                    var documentDetails2 = new Q1DocumentDetailsType();

                    documentDetails2.AdditionalInformation = new Bec.TargetFramework.Service.LR.Entities.OfficialCopyTitleKnown21.Q3TextType();
                    documentDetails2.AdditionalInformation.Value = "1";

                    documentDetails2.TypeOfDocumentCode = new TypeOfDocumentCodeType();
                    //documentDetails.TypeOfDocumentCode.Value = TypeOfDocumentCodeContentType.Item180;
                    documentDetails2.TypeOfDocumentCode.Value = TypeOfDocumentCodeContentType.Item70;
                    documentDetails2.DateOfDocumentDate = new Bec.TargetFramework.Service.LR.Entities.OfficialCopyTitleKnown21.DateType();
                    documentDetails2.DateOfDocumentDate.Value = DateTime.Now;

                    request.Product.DocumentDetails[0] = documentDetails;
                    request.Product.DocumentDetails[1] = documentDetails2;

                    var response = client.performTitleKnownSearch(request);

                    // expect one attachment
                    Assert.IsNotNull(response.GatewayResponse.Results.Attachment);

                    // expect a zip file in attachments, could also be a PDF
                    Assert.IsTrue(response.GatewayResponse.Results.Attachment.EmbeddedFileBinaryObject.format.Equals("ZIP"));

                    using (
                        var ms =
                            new MemoryStream(response.GatewayResponse.Results.Attachment.EmbeddedFileBinaryObject.Value)
                        )
                    {
                        using (var zip = ZipFile.Read(ms))
                        {
                            zip.Entries.ToList()
                                .ForEach(ze =>
                                {
                                    MemoryStream extractStream = new MemoryStream();

                                    // extract to stream
                                    ze.Extract(extractStream);

                                    var name = ze.FileName;
                                });
                        }
                    }

                    
                }
                catch (FaultException ex)
                {

                    MessageFault msgFault = ex.CreateMessageFault();

                    if (msgFault.HasDetail)
                    {
                        var content = msgFault.GetReaderAtDetailContents().ReadOuterXml();
                    }


                    throw;
                }



                client.Close();
            }
        }

        /// <summary>
        /// Register Extract - Provides Title and Register and XML based content from title
        /// </summary>
        [TestMethod]
        public void OfficialCopyWithSummaryConnectivityTest()
        {
            var binding = new BasicHttpBinding("TestCertificationPortBinding");
            var endPointAddress =
                new EndpointAddress(
                    new Uri(
                        "https://bgtest.landregistry.gov.uk/b2b/BGStubService/OfficialCopyWithSummaryV2_1WebService?wsdl"));

            using (
                var client =
                    new OCWithSummaryV2_1ServiceClient(binding,endPointAddress))
            {
                client.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.Root,
                    X509FindType.FindBySerialNumber, "47 ce 29 1d");


                client.ChannelFactory.Endpoint.Behaviors.Add(new LREndpointBehavior("BGUser001", "landreg001"));

                try
                {
                    var request = new RequestOCWithSummaryV2_0Type();

                    request.ID = new Entities.OfficialCopyWithSummary21.Q1IdentifierType();
                    request.ID.MessageID = new Entities.OfficialCopyWithSummary21.Q1TextType();
                    request.ID.MessageID.Value = "170100";

                    request.Product = new Entities.OfficialCopyWithSummary21.Q1ProductType();
                    request.Product.CustomerReference = new Entities.OfficialCopyWithSummary21.Q1CustomerReferenceType();
                    request.Product.CustomerReference.Reference = "Bguser1";
                    request.Product.ExternalReference = new Entities.OfficialCopyWithSummary21.Q1ExternalReferenceType();
                    request.Product.ExternalReference.Reference = "Ext_ref";

                    request.Product.ExpectedPrice = new Q1ExpectedPriceType();
                    request.Product.ExpectedPrice.GrossPriceAmount = new AmountType();
                    request.Product.ExpectedPrice.GrossPriceAmount.Value = 8;
                    request.Product.SubjectProperty = new Entities.OfficialCopyWithSummary21.Q1SubjectPropertyType();
                    request.Product.SubjectProperty.TitleNumber = new Q2TextType();
                    request.Product.SubjectProperty.TitleNumber.Value = "GR506405";

                    request.Product.TitleKnownOfficialCopy = new Q1TitleKnownOfficialCopyType();
                    request.Product.TitleKnownOfficialCopy.IncludeTitlePlanIndicator = new IndicatorType();
                    request.Product.TitleKnownOfficialCopy.IncludeTitlePlanIndicator.Value = true;
                    request.Product.TitleKnownOfficialCopy.ContinueIfActualFeeExceedsExpectedFeeIndicator = new IndicatorType();
                    request.Product.TitleKnownOfficialCopy.ContinueIfActualFeeExceedsExpectedFeeIndicator.Value = true;
                    request.Product.TitleKnownOfficialCopy.ContinueIfTitleIsClosedAndContinuedIndicator = new IndicatorType();
                    request.Product.TitleKnownOfficialCopy.ContinueIfTitleIsClosedAndContinuedIndicator.Value = true;
                    request.Product.TitleKnownOfficialCopy.NotifyIfPendingApplicationIndicator = new IndicatorType();
                    request.Product.TitleKnownOfficialCopy.NotifyIfPendingApplicationIndicator.Value = true;
                    request.Product.TitleKnownOfficialCopy.NotifyIfPendingFirstRegistrationIndicator = new IndicatorType();
                    request.Product.TitleKnownOfficialCopy.NotifyIfPendingFirstRegistrationIndicator.Value = true;
                    request.Product.TitleKnownOfficialCopy.SendBackDatedIndicator = new IndicatorType();
                    request.Product.TitleKnownOfficialCopy.SendBackDatedIndicator.Value = true;

                    var response = client.performOCWithSummary(request);

                    Assert.IsTrue(response.GatewayResponse.Results.Attachment != null);
                    Assert.IsTrue(response.GatewayResponse.Results.Attachment.EmbeddedFileBinaryObject.Value != null);
                    Assert.IsTrue(response.GatewayResponse.Results.Attachment.EmbeddedFileBinaryObject.format.Equals("ZIP"));

                    // 2 documents title plan and register
                    Assert.IsTrue(response.GatewayResponse.Results.OCSummaryData.DocumentDetails.Length > 0);

                    // zip contents
                    using (
                        var ms =
                            new MemoryStream(response.GatewayResponse.Results.Attachment.EmbeddedFileBinaryObject.Value)
                        )
                    {
                        using (var zip = ZipFile.Read(ms))
                        {
                            zip.Entries.ToList()
                                .ForEach(ze =>
                                {
                                    MemoryStream extractStream = new MemoryStream();

                                    // extract to stream
                                    ze.Extract(extractStream);

                                    Assert.IsTrue(extractStream.Length > 0);
                                });
                        }
                    }

                    

                    
                }
                catch (FaultException ex)
                {

                    MessageFault msgFault = ex.CreateMessageFault();

                    if (msgFault.HasDetail)
                    {
                        var content = msgFault.GetReaderAtDetailContents().ReadOuterXml();
                    }


                    throw;
                }


                client.Close();
            }
        }


        private LRSettings CreateSettings()
        {
            return new LRSettings
            {
                LRBindingConfigurationName = "TestCertificationPortBinding",
                LRPassword = "landreg001",
                LRUserName = "BGUser001",
                LRCertificatSerialNumber = "47 ce 29 1d"
            };
        }

        /// <summary>
        /// Enquiry to get Title Number
        /// </summary>
        [TestMethod]
        public void EnquiryByPropertyDescriptionConnectivityTest()
        {
            var serviceInterface = new LRServiceInterfaceBase
            {
                ServiceURL =
                    "https://bgtest.landregistry.gov.uk/b2b/ECBG_StubService/EnquiryByPropertyDescriptionV2_0WebService?wsdl"
            };

            var serviceDefinition = new EnquiryByPropertyDescriptionServiceDefinition20();

            //var serviceContainer = new LRServiceContainer("", null,null,null);

            //serviceContainer.ServiceEngine = new EnquiryByPropertyDescriptionEngine20(null);
            //serviceContainer.ServiceEngine.ServiceInterface = serviceInterface;
            //serviceContainer.ServiceEngine.ServiceDefinition = serviceDefinition;

            //serviceContainer.InitialiseContainer(new ConcurrentDictionary<string, object>());
            //serviceContainer.ExecuteService();
            

            //var binding = new BasicHttpBinding("TestCertificationPortBinding");
            //var endPointAddress = 
            //new EndpointAddress(
            //    new Uri(""
            //        ));

            //using (
            //    var client =
            //            new PropertyDescriptionEnquiryV2_0ServiceClient(binding,endPointAddress))
            //{
            //    client.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.Root, X509FindType.FindBySerialNumber, "47 ce 29 1d");


            //    client.ChannelFactory.Endpoint.Behaviors.Add(new LREndpointBehavior("BGUser001","landreg001"));

            //    var request = new RequestSearchByPropertyDescriptionV2_0Type();
            //    request.Product = new Q1ProductType();

            //    request.Product.SubjectProperty = new Q1SubjectPropertyType();

            //    try
            //    {
            //        request.Product.SubjectProperty.Address = new Q1AddressType();
            //        request.Product.SubjectProperty.Address.PostcodeZone = "BR1 2FE";
            //        request.Product.SubjectProperty.Address.BuildingNumber = "1";

            //        request.ID = new Q1IdentifierType();
            //        request.ID.MessageID = new Q1TextType();
            //        request.ID.MessageID.Value = Guid.NewGuid().ToString();
            //        request.Product.CustomerReference = new Q1CustomerReferenceType();
            //        request.Product.ExternalReference = new Q1ExternalReferenceType();
            //        request.Product.CustomerReference.Reference = "Test";
            //        request.Product.ExternalReference.Reference = "Test";

            //        var response = client.searchProperties(request);

            //        // title exists
            //        Assert.IsTrue(response.GatewayResponse.Results.Title.Length > 0);

            //        // title address postcode is correct
            //        Assert.AreEqual(response.GatewayResponse.Results.Title[0].TitleNumber.Value, "DN100");
            //    }
            //    catch (FaultException ex )
            //    {

            //        MessageFault msgFault =  ex.CreateMessageFault();

            //        if (msgFault.HasDetail)
            //        {
            //            var content = msgFault.GetReaderAtDetailContents().ReadOuterXml();
            //        }


            //        throw;
            //    }

                
                
            //    client.Close();
            //}
        }

        #endregion
    }
}
