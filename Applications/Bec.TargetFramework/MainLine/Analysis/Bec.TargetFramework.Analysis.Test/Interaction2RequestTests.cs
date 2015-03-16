using Bec.TargetFramework.Analysis.Infrastructure;
using Bec.TargetFramework.Analysis.Interfaces;
using Bec.TargetFramework.Analysis.Test.Properties;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Test.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Linq;

namespace Bec.TargetFramework.Analysis.Test
{
    [TestClass]
    public class Interaction2RequestTests : UnitTestBase
    {
        public const string OUTPUTPATH = UnitTestBase.TESTINGPATH + @"\SenderOutput";

        [TestInitialize]
        public override void TestInitialise()
        {
            base.TestInitialise();

            if (!Directory.Exists(OUTPUTPATH))
                Directory.CreateDirectory(OUTPUTPATH);

            // Delete the files in the output folder
            Array.ForEach(Directory.GetFiles(OUTPUTPATH), File.Delete);
        }

        [TestMethod]
        public void ReceiverLogic_NoApplication_NoSMSData()
        {
            TestUtils.DeletePreviousTestMortgageApplications();

            // There is no application data from SIRA, or any data within SMS.
            // Check that any call to the receiver will not return any match results
            var receiver = new MockReceiver();
            Assert.AreEqual(0, receiver.GetApplicationsThatMatchASearch().Count);
        }

        [TestMethod]
        public void ReceiverLogic_HasApplication_NoSMSData_X1()
        {
            TestUtils.DeletePreviousTestMortgageApplications();

            // Add a new mortgage application to the system
            AddNewApplication(1);

            // There is one application from SIRA but no data within SMS.
            // For now, the receiver will always return any SIRA applications we have received
            var receiver = new MockReceiver();
            Assert.AreEqual(1, receiver.GetApplicationsThatMatchASearch().Count);
        }

        [TestMethod]
        public void ReceiverLogic_HasApplication_NoSMSData_X10()
        {
            TestUtils.DeletePreviousTestMortgageApplications();

            // Add x10 new mortgage application to the system
            AddNewApplication(10);

            // There should now be 10 new applications from SIRA but no data within SMS.
            // For now, the receiver will always return any SIRA applications we have received
            var receiver = new MockReceiver();
            Assert.AreEqual(10, receiver.GetApplicationsThatMatchASearch().Count);
        }

        public static void AddNewApplication(int number)
        {
            // Create a sample application request object
            var requestDTO = SearchDetailHelper.Deserialize<SearchDetail>(Resources.Interaction1RequestSample);

            // Save the original mortgage application number as we need it to be the prefix later on
            var originalMortgageApplicationNumber = requestDTO.MortgageApplicationNumber;

            for (int i = 1; i <= number; i++)
            {
                if (number > 1)
                    // Change the mortgage application number so we don't get key conflicts
                    requestDTO.MortgageApplicationNumber = originalMortgageApplicationNumber + "_" + i;

                // Create the application
                using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                    logic.ProcessMortgageApplication(requestDTO);
            }
        }

        [TestMethod]
        public void MutatorLogic_GetOriginalApplication_NoMatches()
        {
            // Delete any existing applications
            TestUtils.DeletePreviousTestMortgageApplications();

            // Create the receiver
            var receiver = new MockReceiver();

            // Get the matching searches
            var matches = receiver.GetApplicationsThatMatchASearch();

            // Pass this to the mutation logic
            var mutator = new MockMutator_GetOriginalApplication();
            var mutationResults = new List<SearchDetail>();
            matches.ForEach(a => mutationResults.Add(mutator.Mutate(a)));

            Assert.AreEqual(0, mutationResults.Count);
        }

        [TestMethod]
        public void MutatorLogic_GetOriginalApplication_OneMatch()
        {
            TestUtils.DeletePreviousTestMortgageApplications();

            // Add a new mortgage application to the system
            AddNewApplication(1);

            // There is one application from SIRA but no data within SMS.
            // For now, the receiver will always return any SIRA applications we have received
            var receiver = new MockReceiver();

            // Get the matching searches
            var matches = receiver.GetApplicationsThatMatchASearch();

            // Pass this to the mutation logic
            var mutator = new MockMutator_GetOriginalApplication();
            var mutationResults = new List<SearchDetail>();
            matches.ForEach(a => mutationResults.Add(mutator.Mutate(a)));

            // Check we have one mutation result
            Assert.AreEqual(1, mutationResults.Count);

            // Check the mutation result details
            var mutationResult = mutationResults[0];
            Assert.AreEqual(3, mutationResult.Parties.Count);
            Assert_GetOriginalApplication(mutationResult);
        }

        [TestMethod]
        public void MutatorLogic_ClearUnnecessaryData_OneMatch()
        {
            TestUtils.DeletePreviousTestMortgageApplications();

            // Add a new mortgage application to the system
            AddNewApplication(1);

            // There is one application from SIRA but no data within SMS.
            // For now, the receiver will always return any SIRA applications we have received
            var receiver = new MockReceiver();

            // Get the matching searches
            var matches = receiver.GetApplicationsThatMatchASearch();

            // Pass this to the mutation logic
            var mutatorGetOriginalApplication = new MockMutator_GetOriginalApplication();
            var mutatorClearUnnecessaryData = new MockMutator_ClearUnnecessaryData();
            var mutationResults = new List<SearchDetail>();
            matches.ForEach(a => mutationResults.Add(mutatorGetOriginalApplication.Mutate(a)));
            mutationResults.ForEach(a => mutatorClearUnnecessaryData.Mutate(a));

            // Check we have one mutation result
            Assert.AreEqual(1, mutationResults.Count);

            // Check the mutation result details
            var mutationResult = mutationResults[0];
            Assert_GetOriginalApplication(mutationResult);
            Assert_ClearUnnecessaryData(mutationResult);
        }

        private void Assert_ClearUnnecessaryData(SearchDetail mutationResult)
        {
            Assert.IsNull(mutationResult.Transaction);
        }

        private void Assert_GetOriginalApplication(SearchDetail mutationResult)
        {
            var buyer = mutationResult.Parties[0];
            var broker = mutationResult.Parties[1];
            var conveyancer = mutationResult.Parties[2];
            Assert.AreEqual(PartyTypeEnum.BUY, buyer.Detail.PartyType);
            Assert.AreEqual(PartyTypeEnum.MBU, broker.Detail.PartyType);
            Assert.AreEqual(PartyTypeEnum.BCU, conveyancer.Detail.PartyType);
        }

        [TestMethod]
        public void MutatorLogic_AddOtherParties_OneMatch()
        {
            TestUtils.DeletePreviousTestMortgageApplications();

            // Add a new mortgage application to the system
            AddNewApplication(1);

            // There is one application from SIRA but no data within SMS.
            // For now, the receiver will always return any SIRA applications we have received
            var receiver = new MockReceiver();

            // Get the matching searches
            var matches = receiver.GetApplicationsThatMatchASearch();

            // Pass this to the mutation logic
            var mutatorGetOriginalApplication = new MockMutator_GetOriginalApplication();
            var mutatorClearUnnecessaryData = new MockMutator_ClearUnnecessaryData();
            var mutatorAddOtherParties = new MockMutator_AddOtherParties();
            var mutationResults = new List<SearchDetail>();
            matches.ForEach(a => mutationResults.Add(mutatorGetOriginalApplication.Mutate(a)));
            mutationResults.ForEach(a => mutatorClearUnnecessaryData.Mutate(a));
            mutationResults.ForEach(a => mutatorAddOtherParties.Mutate(a));

            // Check we have one mutation result
            Assert.AreEqual(1, mutationResults.Count);

            // Check the mutation result details
            var mutationResult = mutationResults[0];
            Assert_GetOriginalApplication(mutationResult);
            Assert_ClearUnnecessaryData(mutationResult);
            Assert.AreEqual(6, mutationResult.Parties.Count);
            Assert_AddOtherParties(mutationResult);
            Assert_LastUpdated(mutationResult);
        }

        private void Assert_LastUpdated(SearchDetail mutationResult)
        {
            Assert.AreEqual(new DateTime(2015, 2, 4), mutationResult.LastUpdated);
            foreach (var party in mutationResult.Parties)
                Assert.AreEqual(new DateTime(2015, 2, 4), party.LastUpdated);
        }

        private void Assert_AddOtherParties(SearchDetail mutationResult)
        {
            var seller = mutationResult.Parties[3];

            Assert.AreEqual(PartyTypeEnum.SELL, seller.Detail.PartyType);
            Assert.AreEqual("SELL-001", seller.Detail.PartyCode);
            Assert.IsFalse(string.IsNullOrWhiteSpace(seller.Detail.Name.FirstName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(seller.Detail.Name.LastName));
            Assert.IsNotNull(seller.Detail.DateOfBirth);
            Assert.IsNotNull(seller.Detail.Address);
            Assert.IsFalse(string.IsNullOrWhiteSpace(seller.Detail.Address.BuildingName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(seller.Detail.Address.Line1));
            Assert.IsFalse(string.IsNullOrWhiteSpace(seller.Detail.Address.TownCity));
            Assert.IsFalse(string.IsNullOrWhiteSpace(seller.Detail.Address.PostCode));
            Assert.IsFalse(string.IsNullOrWhiteSpace(seller.Detail.Address.County));
            Assert.IsFalse(string.IsNullOrWhiteSpace(seller.Detail.Address.CountryCode));
            Assert.IsFalse(seller.Detail.Address.IsAnInternationalAddress);
            Assert.IsFalse(string.IsNullOrWhiteSpace(seller.Detail.SMSActorCode));
            Assert.IsFalse(string.IsNullOrWhiteSpace(seller.Detail.EmailAddress));
            Assert.IsFalse(string.IsNullOrWhiteSpace(seller.Detail.TelephoneNumbers[0]));

            var sellerConveyancer = mutationResult.Parties[4];
            Assert.AreEqual(PartyTypeEnum.SCU, sellerConveyancer.Detail.PartyType);
            Assert.AreEqual("SCU-001", sellerConveyancer.Detail.PartyCode);
            Assert.IsFalse(string.IsNullOrWhiteSpace(sellerConveyancer.Detail.Name.FirstName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(sellerConveyancer.Detail.Name.LastName));
            Assert.IsNotNull(sellerConveyancer.Detail.DateOfBirth);
            Assert.IsNull(sellerConveyancer.Detail.Address);
            Assert.IsFalse(string.IsNullOrWhiteSpace(sellerConveyancer.Detail.SMSActorCode));
            Assert.IsFalse(string.IsNullOrWhiteSpace(sellerConveyancer.Detail.EmailAddress));
            Assert.IsFalse(string.IsNullOrWhiteSpace(sellerConveyancer.Detail.TelephoneNumbers[0]));
            Assert.IsNotNull(sellerConveyancer.Organisation);
            Assert.IsFalse(string.IsNullOrWhiteSpace(sellerConveyancer.Organisation.Name));
            Assert.IsNotNull(sellerConveyancer.Organisation.Address);
            Assert.IsFalse(string.IsNullOrWhiteSpace(sellerConveyancer.Organisation.Address.BuildingName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(sellerConveyancer.Organisation.Address.Line1));
            Assert.IsFalse(string.IsNullOrWhiteSpace(sellerConveyancer.Organisation.Address.TownCity));
            Assert.IsFalse(string.IsNullOrWhiteSpace(sellerConveyancer.Organisation.Address.PostCode));
            Assert.IsFalse(string.IsNullOrWhiteSpace(sellerConveyancer.Organisation.Address.County));
            Assert.IsFalse(string.IsNullOrWhiteSpace(sellerConveyancer.Organisation.Address.CountryCode));
            Assert.IsFalse(sellerConveyancer.Organisation.Address.IsAnInternationalAddress);

            var estateAgentUser = mutationResult.Parties[5];
            Assert.AreEqual(PartyTypeEnum.EAU, estateAgentUser.Detail.PartyType);
            Assert.AreEqual("EAU-001", estateAgentUser.Detail.PartyCode);
            Assert.IsFalse(string.IsNullOrWhiteSpace(estateAgentUser.Detail.Name.FirstName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(estateAgentUser.Detail.Name.LastName));
            Assert.IsNotNull(estateAgentUser.Detail.DateOfBirth);
            Assert.IsNull(estateAgentUser.Detail.Address);
            Assert.IsFalse(string.IsNullOrWhiteSpace(estateAgentUser.Detail.SMSActorCode));
            Assert.IsFalse(string.IsNullOrWhiteSpace(estateAgentUser.Detail.EmailAddress));
            Assert.IsFalse(string.IsNullOrWhiteSpace(estateAgentUser.Detail.TelephoneNumbers[0]));
            Assert.IsNotNull(estateAgentUser.Organisation);
            Assert.IsFalse(string.IsNullOrWhiteSpace(estateAgentUser.Organisation.Name));
            Assert.IsNotNull(estateAgentUser.Organisation.Address);
            Assert.IsFalse(string.IsNullOrWhiteSpace(estateAgentUser.Organisation.Address.BuildingName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(estateAgentUser.Organisation.Address.Line1));
            Assert.IsFalse(string.IsNullOrWhiteSpace(estateAgentUser.Organisation.Address.TownCity));
            Assert.IsFalse(string.IsNullOrWhiteSpace(estateAgentUser.Organisation.Address.PostCode));
            Assert.IsFalse(string.IsNullOrWhiteSpace(estateAgentUser.Organisation.Address.County));
            Assert.IsFalse(string.IsNullOrWhiteSpace(estateAgentUser.Organisation.Address.CountryCode));
            Assert.IsFalse(estateAgentUser.Organisation.Address.IsAnInternationalAddress);
        }

        [TestMethod]
        public void MutatorLogic_AddPartyAlerts_OneMatch()
        {
            TestUtils.DeletePreviousTestMortgageApplications();

            // Add a new mortgage application to the system
            AddNewApplication(1);

            // There is one application from SIRA but no data within SMS.
            // For now, the receiver will always return any SIRA applications we have received
            var receiver = new MockReceiver();

            // Get the matching searches
            var matches = receiver.GetApplicationsThatMatchASearch();

            // Pass this to the mutation logic
            var mutatorGetOriginalApplication = new MockMutator_GetOriginalApplication();
            var mutatorClearUnnecessaryData = new MockMutator_ClearUnnecessaryData();
            var mutatorAddOtherParties = new MockMutator_AddOtherParties();
            var mutatorAddPartyAlerts = new MockMutator_AddPartyAlerts();
            var mutationResults = new List<SearchDetail>();
            matches.ForEach(a => mutationResults.Add(mutatorGetOriginalApplication.Mutate(a)));
            mutationResults.ForEach(a => mutatorClearUnnecessaryData.Mutate(a));
            mutationResults.ForEach(a => mutatorAddOtherParties.Mutate(a));
            mutationResults.ForEach(a => mutatorAddPartyAlerts.Mutate(a));

            // Check we have one mutation result
            Assert.AreEqual(1, mutationResults.Count);

            // Check the mutation result details
            var mutationResult = mutationResults[0];
            Assert_GetOriginalApplication(mutationResult);
            Assert_ClearUnnecessaryData(mutationResult);
            Assert_AddOtherParties(mutationResult);
            Assert_AddPartyAlerts(mutationResult);
        }

        private void Assert_AddPartyAlerts(SearchDetail mutationResult)
        {
            var buyerAlert = mutationResult.Parties[0].Alert;
            Assert.IsNotNull(buyerAlert.AMLExecutionDate);
            Assert.AreEqual(ValueEnum.Item1, buyerAlert.AMLResult);
            Assert.IsNotNull(buyerAlert.CardPaymentAVSResults[0].Date);
            Assert.IsFalse(string.IsNullOrWhiteSpace(buyerAlert.CardPaymentAVSResults[0].AVSCode));
            Assert.AreEqual(ValueEnum.Item1, buyerAlert.CardPaymentAVSResults[0].Value);
            Assert.AreEqual(ValueEnum.Item1, buyerAlert.BankAccountResult);
            Assert.AreEqual(ValueEnum.Item2, buyerAlert.DeathIndicator);
            Assert.AreEqual(ValueEnum.Item2, buyerAlert.BankruptcyIndicator);
            Assert.AreEqual(ValueEnum.Item1, buyerAlert.PartyDataMatchIndicator);
            Assert.AreEqual(ValueEnum.Item0, buyerAlert.GenuineIDDocumentsSeenByConveyancer);
            Assert.AreEqual(ValueEnum.Item0, buyerAlert.CertifiedCopyIDDocumentsSeenByConveyancer);

            var brokerAlert = mutationResult.Parties[1].Alert;
            Assert.IsNotNull(brokerAlert.AMLExecutionDate);
            Assert.AreEqual(ValueEnum.Item1, brokerAlert.AMLResult);
            Assert.IsNull(brokerAlert.CardPaymentAVSResults);
            Assert.AreEqual(ValueEnum.Item1, brokerAlert.BankAccountResult);
            Assert.AreEqual(ValueEnum.Item1, brokerAlert.FCAIndividualUserIDNumber);
            Assert.AreEqual(FCAUserStatusEnum.Item1, brokerAlert.FCAIndividualStatus);
            Assert.IsNull(brokerAlert.FCAIndividualDisciplinaryHistory);
            Assert.AreEqual(BrokerEnum.Item1, brokerAlert.FCABrokerType);
            Assert.AreEqual(ValueEnum.Item1, brokerAlert.FCAValidatedWithNetwork);
            Assert.AreEqual(ValueEnum.Item2, brokerAlert.DeathIndicator);
            Assert.AreEqual(ValueEnum.Item2, brokerAlert.BankruptcyIndicator);
            Assert.AreEqual(ValueEnum.Item1, brokerAlert.PartyDataMatchIndicator);

            var buyerConveyancerAlert = mutationResult.Parties[2].Alert;
            Assert.IsNotNull(buyerConveyancerAlert.AMLExecutionDate);
            Assert.AreEqual(ValueEnum.Item1, buyerConveyancerAlert.AMLResult);
            Assert.IsNull(buyerConveyancerAlert.CardPaymentAVSResults);
            Assert.AreEqual(ValueEnum.Item1, buyerConveyancerAlert.BankAccountResult);
            Assert.AreEqual(ValueEnum.Item2, buyerConveyancerAlert.DeathIndicator);
            Assert.AreEqual(ValueEnum.Item2, buyerConveyancerAlert.BankruptcyIndicator);
            Assert.AreEqual(ValueEnum.Item1, buyerConveyancerAlert.PartyDataMatchIndicator);

            var sellerAlert = mutationResult.Parties[3].Alert;
            Assert.IsNotNull(sellerAlert.AMLExecutionDate);
            Assert.AreEqual(ValueEnum.Item1, sellerAlert.AMLResult);
            Assert.IsNotNull(sellerAlert.CardPaymentAVSResults[0].Date);
            Assert.IsFalse(string.IsNullOrWhiteSpace(sellerAlert.CardPaymentAVSResults[0].AVSCode));
            Assert.AreEqual(ValueEnum.Item1, sellerAlert.CardPaymentAVSResults[0].Value);
            Assert.AreEqual(ValueEnum.Item1, sellerAlert.BankAccountResult);
            Assert.AreEqual(ValueEnum.Item2, sellerAlert.DeathIndicator);
            Assert.AreEqual(ValueEnum.Item2, sellerAlert.BankruptcyIndicator);
            Assert.AreEqual(ValueEnum.Item0, sellerAlert.PartyDataMatchIndicator);

            var sellerConveyancerAlert = mutationResult.Parties[4].Alert;
            Assert.IsNotNull(sellerConveyancerAlert.AMLExecutionDate);
            Assert.AreEqual(ValueEnum.Item1, sellerConveyancerAlert.AMLResult);
            Assert.IsNull(sellerConveyancerAlert.CardPaymentAVSResults);
            Assert.AreEqual(ValueEnum.Item1, sellerConveyancerAlert.BankAccountResult);
            Assert.AreEqual(ValueEnum.Item2, sellerConveyancerAlert.DeathIndicator);
            Assert.AreEqual(ValueEnum.Item2, sellerConveyancerAlert.BankruptcyIndicator);
            Assert.AreEqual(ValueEnum.Item0, sellerConveyancerAlert.PartyDataMatchIndicator);

            var estateAgentAlert = mutationResult.Parties[5].Alert;
            Assert.IsNotNull(estateAgentAlert.AMLExecutionDate);
            Assert.AreEqual(ValueEnum.Item1, estateAgentAlert.AMLResult);
            Assert.IsNull(estateAgentAlert.CardPaymentAVSResults);
            Assert.AreEqual(ValueEnum.Item1, estateAgentAlert.BankAccountResult);
            Assert.AreEqual(ValueEnum.Item2, estateAgentAlert.DeathIndicator);
            Assert.AreEqual(ValueEnum.Item2, estateAgentAlert.BankruptcyIndicator);
            Assert.AreEqual(ValueEnum.Item0, estateAgentAlert.PartyDataMatchIndicator);
        }

        [TestMethod]
        public void MutatorLogic_AddApplicationAlerts_OneMatch()
        {
            TestUtils.DeletePreviousTestMortgageApplications();

            // Add a new mortgage application to the system
            AddNewApplication(1);

            // There is one application from SIRA but no data within SMS.
            // For now, the receiver will always return any SIRA applications we have received
            var receiver = new MockReceiver();

            // Get the matching searches
            var matches = receiver.GetApplicationsThatMatchASearch();

            // Pass this to the mutation logic
            var mutatorGetOriginalApplication = new MockMutator_GetOriginalApplication();
            var mutatorClearUnnecessaryData = new MockMutator_ClearUnnecessaryData();
            var mutatorAddOtherParties = new MockMutator_AddOtherParties();
            var mutatorAddPartyAlerts = new MockMutator_AddPartyAlerts();
            var mutatorAddApplicationAlerts = new MockMutator_AddApplicationAlerts();
            var mutationResults = new List<SearchDetail>();
            matches.ForEach(a => mutationResults.Add(mutatorGetOriginalApplication.Mutate(a)));
            mutationResults.ForEach(a => mutatorClearUnnecessaryData.Mutate(a));
            mutationResults.ForEach(a => mutatorAddOtherParties.Mutate(a));
            mutationResults.ForEach(a => mutatorAddPartyAlerts.Mutate(a));
            mutationResults.ForEach(a => mutatorAddApplicationAlerts.Mutate(a));

            // Check we have one mutation result
            Assert.AreEqual(1, mutationResults.Count);

            // Check the mutation result details
            var mutationResult = mutationResults[0];
            Assert_GetOriginalApplication(mutationResult);
            Assert_ClearUnnecessaryData(mutationResult);
            Assert_AddOtherParties(mutationResult);
            Assert_AddPartyAlerts(mutationResult);
            Assert_AddApplicationAlerts(mutationResult);
        }

        private void Assert_AddApplicationAlerts(SearchDetail mutationResult)
        {
            var alert = mutationResult.Alert;
            Assert.IsNotNull(alert);
            Assert.AreEqual(ValueEnum.Item1, alert.PropertySIRAMatchResult);
            Assert.AreEqual(ValueEnum.Item1, alert.PropertyHasLinkedTitles);

            Assert.IsNotNull(alert.PropertySellerAuthorityStatusResults);
            Assert.AreEqual("SELL-001", alert.PropertySellerAuthorityStatusResults[0].Party.PartyCode);
            Assert.AreEqual(AuthorityEnum.Item2, alert.PropertySellerAuthorityStatusResults[0].AuthorityStatus);

            Assert.IsNotNull(alert.PropertyBuyerAuthorityStatusResults);
            Assert.AreEqual("BUY-001", alert.PropertyBuyerAuthorityStatusResults[0].Party.PartyCode);
            Assert.AreEqual(AuthorityEnum.Item4, alert.PropertyBuyerAuthorityStatusResults[0].AuthorityStatus);

            Assert.IsNotNull(alert.PropertySellerPowerOfAttorneyUploadedResults);
            Assert.AreEqual("SELL-001", alert.PropertySellerPowerOfAttorneyUploadedResults[0].Party.PartyCode);
            Assert.AreEqual(ValueEnum.Item1, alert.PropertySellerPowerOfAttorneyUploadedResults[0].Value);

            Assert.IsNull(alert.PropertyBuyerPowerOfAttorneyUploadedResults);

            Assert.IsNotNull(alert.PropertySellerNotARegisteredProprietorResults);
            Assert.AreEqual("SELL-001", alert.PropertySellerNotARegisteredProprietorResults[0].Party.PartyCode);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertySellerNotARegisteredProprietorResults[0].Value);

            Assert.AreEqual(new DateTime(2006, 11, 11), alert.PropertyDateOfPreviousRegisterTransfer);
            Assert.AreEqual(243000, alert.PropertyCurrentRegisteredPrice);
            Assert.IsNull(alert.PropertyBuyerStatutoryDeclarationResults);

            Assert.IsNotNull(alert.PropertySellerStatutoryDeclarationResults);
            Assert.AreEqual("SELL-001", alert.PropertySellerStatutoryDeclarationResults[0].Party.PartyCode);
            Assert.AreEqual(ValueEnum.Item1, alert.PropertySellerStatutoryDeclarationResults[0].Value);

            Assert.IsNotNull(alert.PropertyGradeOfTitleResults);
            Assert.AreEqual("01234568", alert.PropertyGradeOfTitleResults[0].TitleNumber);
            Assert.AreEqual(TitleGradeEnum.Item1, alert.PropertyGradeOfTitleResults[0].GradeClass);

            Assert.AreEqual(ValueEnum.Item2, alert.PropertyNoOS1OrderedOrNoAP1);
            Assert.AreEqual(5, alert.PropertyNoDaysSinceCompleted);
            Assert.AreEqual(ValueEnum.Item0, alert.PropertyOS1NameOtherThanBuyerExists);
            Assert.AreEqual(0, alert.PropertyNoDaysSinceCompletedNoAP1);
            Assert.AreEqual(0, alert.PropertyNoDaysSinceCompletedNoRegistrationHMLR);
            Assert.AreEqual(0, alert.PropertyNoDaysSinceCompletedNoRegistrationOnCompaniesHouse);

            Assert.IsNotNull(alert.PropertyTitleProprietorResults);
            Assert.AreEqual("01234568", alert.PropertyTitleProprietorResults[0].TitleNumber);
            Assert.AreEqual("SELL-001", alert.PropertyTitleProprietorResults[0].PartyAlertResults[0].Detail.PartyCode);
            Assert.AreEqual(ValueEnum.Item1, alert.PropertyTitleProprietorResults[0].PartyAlertResults[0].Alert.DeathIndicator);
            Assert.AreEqual(ValueEnum.Item0, alert.PropertyTitleProprietorResults[0].PartyAlertResults[0].Alert.BankruptcyIndicator);

            Assert.AreEqual(ValueEnum.Item1, alert.PropertyTenureNotMatchHMLR);
            Assert.AreEqual(0, alert.PropertyDaysLeftOnLease);

            Assert.IsNotNull(alert.PropertyIPMatchPartyResults);
            Assert.AreEqual("BUY-001", alert.PropertyIPMatchPartyResults[0].Party.PartyCode);
            Assert.AreEqual("789.423.42.150", alert.PropertyIPMatchPartyResults[0].IPAddress);
            Assert.AreEqual("SELL-001", alert.PropertyIPMatchPartyResults[1].Party.PartyCode);
            Assert.AreEqual("789.423.42.150", alert.PropertyIPMatchPartyResults[1].IPAddress);

            Assert.IsNotNull(alert.PropertyBuyerDistanceFromResults);
            Assert.AreEqual("BUY-001", alert.PropertyBuyerDistanceFromResults[0].Party.PartyCode);
            Assert.AreEqual(11, alert.PropertyBuyerDistanceFromResults[0].Distance);

            Assert.AreEqual(ValueEnum.Item0, alert.PropertyHasMutipleBuyersWithSameHomeAcrossDifferentSearches);

            Assert.IsNotNull(alert.PropertySellerHasCreditHistoryElsewhereResults);
            Assert.AreEqual("SELL-001", alert.PropertySellerHasCreditHistoryElsewhereResults[0].Party.PartyCode);

            Assert.AreEqual(ValueEnum.Item0, alert.PropertyPriceMatchSIRAApplication);
            Assert.AreEqual(ValueEnum.Item0, alert.PropertyPriceMatchSIRAOffer);
            Assert.AreEqual(ValueEnum.Item2, alert.PropertyBuyerOrSellerConveyancerHasCancelledSearch);

            Assert.IsNotNull(alert.PropertySourceOfDepositResults);
            Assert.AreEqual(SourceOfDepositEnum.Item1, alert.PropertySourceOfDepositResults[0].SourceType);
            Assert.AreEqual(25000, alert.PropertySourceOfDepositResults[0].Amount);
            Assert.AreEqual("Charles", alert.PropertySourceOfDepositResults[0].SourceParty.Name.FirstName);
            Assert.AreEqual("Dickens", alert.PropertySourceOfDepositResults[0].SourceParty.Name.LastName);
            Assert.AreEqual(ValueEnum.Item1, alert.PropertySourceOfDepositResults[0].BuyerDeclaresHasBeenGifted);
            Assert.AreEqual(ValueEnum.Item1, alert.PropertySourceOfDepositResults[0].SourceHasChargeOnProperty);

            Assert.AreEqual(SourceOfDepositEnum.Item2, alert.PropertySourceOfDepositResults[1].SourceType);
            Assert.AreEqual(10000, alert.PropertySourceOfDepositResults[1].Amount);
            Assert.AreEqual("Bob", alert.PropertySourceOfDepositResults[1].SourceParty.Name.FirstName);
            Assert.AreEqual("The", alert.PropertySourceOfDepositResults[1].SourceParty.Name.MiddleName);
            Assert.AreEqual("Builder", alert.PropertySourceOfDepositResults[1].SourceParty.Name.LastName);
            Assert.AreEqual(ValueEnum.Item0, alert.PropertySourceOfDepositResults[1].BuyerDeclaresHasBeenGifted);
            Assert.AreEqual(ValueEnum.Item2, alert.PropertySourceOfDepositResults[1].SourceHasChargeOnProperty);

            Assert.AreEqual(StatusEnum.Item2, alert.PropertyStatus);

            Assert.IsNotNull(alert.PropertyChargeResults);
            Assert.AreEqual(new DateTime(2001, 11, 12), alert.PropertyChargeResults[0].Date);
            Assert.AreEqual("this is a charge", alert.PropertyChargeResults[0].Description);
            Assert.AreEqual("type1", alert.PropertyChargeResults[0].Type);
            Assert.AreEqual("01234567", alert.PropertyChargeResults[0].TitleNumber);
            Assert.AreEqual("Bob", alert.PropertyChargeResults[0].Parties[0].Detail.Name.FirstName);
            Assert.AreEqual("Monkhouse", alert.PropertyChargeResults[0].Parties[0].Detail.Name.LastName);
            Assert.AreEqual("Monkhouse Ltd", alert.PropertyChargeResults[0].Parties[0].Organisation.Name);
            Assert.AreEqual("Elvis", alert.PropertyChargeResults[0].Parties[1].Detail.Name.FirstName);
            Assert.AreEqual("Presley", alert.PropertyChargeResults[0].Parties[1].Detail.Name.LastName);

            Assert.AreEqual(new DateTime(1998, 11, 12), alert.PropertyChargeResults[1].Date);
            Assert.AreEqual("another charge", alert.PropertyChargeResults[1].Description);
            Assert.AreEqual("type2", alert.PropertyChargeResults[1].Type);
            Assert.AreEqual("01234567", alert.PropertyChargeResults[1].TitleNumber);
            Assert.AreEqual("David", alert.PropertyChargeResults[1].Parties[0].Detail.Name.FirstName);
            Assert.AreEqual("Beckham", alert.PropertyChargeResults[1].Parties[0].Detail.Name.LastName);

            Assert.IsNotNull(alert.PropertyRestrictionResults);
            Assert.AreEqual("Restriction 1", alert.PropertyRestrictionResults[0].TypeName);
            Assert.AreEqual("01234567", alert.PropertyRestrictionResults[0].TitleNumber);
            Assert.AreEqual("Restriction Descr 1", alert.PropertyRestrictionResults[0].Description);

            Assert.AreEqual("Restriction 2", alert.PropertyRestrictionResults[1].TypeName);
            Assert.AreEqual("01234567", alert.PropertyRestrictionResults[1].TitleNumber);
            Assert.AreEqual("Restriction Descr 2", alert.PropertyRestrictionResults[1].Description);

            Assert.IsNotNull(alert.PropertySellerPostRedirectResults);
            Assert.AreEqual("SELL-001", alert.PropertySellerPostRedirectResults[0].Party.PartyCode);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertySellerPostRedirectResults[0].Value);

            Assert.IsNotNull(alert.PropertyTitleUnencumberedResults);
            Assert.AreEqual("01234568", alert.PropertyTitleUnencumberedResults[0].TitleNumber);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertyTitleUnencumberedResults[0].Value);

            Assert.IsNotNull(alert.PropertyBuyerNotSeenFaceToFaceConveyancerResults);
            Assert.AreEqual("BUY-001", alert.PropertyBuyerNotSeenFaceToFaceConveyancerResults[0].Party.PartyCode);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertyBuyerNotSeenFaceToFaceConveyancerResults[0].Value);

            Assert.IsNotNull(alert.PropertyBuyerNotSeenFaceToFaceBrokerResults);
            Assert.AreEqual("BUY-001", alert.PropertyBuyerNotSeenFaceToFaceBrokerResults[0].Party.PartyCode);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertyBuyerNotSeenFaceToFaceBrokerResults[0].Value);

            Assert.AreEqual(ValueEnum.Item1, alert.PropertySIRAThirdPartyIntroducerMatch);

            Assert.IsNotNull(alert.PropertyThirdPartyIntroducer);
            Assert.AreEqual("TPI-001", alert.PropertyThirdPartyIntroducer.PartyCode);

            Assert.AreEqual(ValueEnum.Item0, alert.PropertyTenureNotMatchSTS);

            Assert.IsNotNull(alert.PropertySellerConveyancingBranchRegulatorHasNoMatchResults);
            Assert.AreEqual("SCU-001", alert.PropertySellerConveyancingBranchRegulatorHasNoMatchResults[0].Party.PartyCode);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertySellerConveyancingBranchRegulatorHasNoMatchResults[0].Value);

            Assert.IsNotNull(alert.PropertySellerConveyancingBranchComplianceOfficerNotApprovedResults);
            Assert.AreEqual("SELL-001", alert.PropertySellerConveyancingBranchComplianceOfficerNotApprovedResults[0].Party.PartyCode);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertySellerConveyancingBranchComplianceOfficerNotApprovedResults[0].Value);

            Assert.AreEqual(ValueEnum.Item0, alert.PropertyNewBuildFirstRegistration);
            Assert.AreEqual(ValueEnum.Item0, alert.PropertySubSale);

            Assert.IsNotNull(alert.PropertyIncentivesPartyResults);
            Assert.AreEqual("Joe", alert.PropertyIncentivesPartyResults[0].Party.Name.FirstName);
            Assert.AreEqual("Allen", alert.PropertyIncentivesPartyResults[0].Party.Name.LastName);

            Assert.IsNotNull(alert.PropertyBuyerWillBeResidentResults);
            Assert.AreEqual("BUY-001", alert.PropertyBuyerWillBeResidentResults[0].Party.PartyCode);
            Assert.AreEqual(ValueEnum.Item1, alert.PropertyBuyerWillBeResidentResults[0].Value);

            Assert.IsNull(alert.PropertySellerToRemainResidentAsTenantResults);
            Assert.AreEqual(298000, alert.PropertyValuationSurveyPrice);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertyServiceAddressPotentiallyExists);

            Assert.IsNotNull(alert.PropertyBuyerHasChangedConveyancingBranchAfterExchangeResults);
            Assert.AreEqual("BUY-001", alert.PropertyBuyerHasChangedConveyancingBranchAfterExchangeResults[0].Party.PartyCode);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertyBuyerHasChangedConveyancingBranchAfterExchangeResults[0].Value);

            Assert.IsNull(alert.PropertySellerHasChangedConveyancingBranchAfterExchangeResults);

            Assert.IsNotNull(alert.PropertyOtherSTSSearchesExistWithSameBuyerAtThisAddressResults);
            Assert.AreEqual("BCU-001", alert.PropertyOtherSTSSearchesExistWithSameBuyerAtThisAddressResults[0].Party.PartyCode);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertyOtherSTSSearchesExistWithSameBuyerAtThisAddressResults[0].Value);
            Assert.AreEqual("BCU-002", alert.PropertyOtherSTSSearchesExistWithSameBuyerAtThisAddressResults[1].Party.PartyCode);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertyOtherSTSSearchesExistWithSameBuyerAtThisAddressResults[1].Value);

            Assert.IsNull(alert.PropertyOtherSTSSearchesExistWithSameSellerAtThisAddressResults);
            Assert.AreEqual(ValueEnum.Item0, alert.PropertyRegisteredProprietorsWhoAreNotSellerOnSTS);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertyDeathOnExperianNotOnHMLR);
            Assert.AreEqual(ValueEnum.Item2, alert.PropertyDeathOnHMLRNotOnExperian);
            Assert.AreEqual(ValueEnum.Item0, alert.PropertyBankruptcyOnExperianNotOnHMLR);
            Assert.AreEqual(ValueEnum.Item0, alert.PropertyBankruptcyOnHMLRNotOnExperian);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertyIPMatchOnBuyerAndSeller);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertyIPMatchOnBuyerConveyancerAndSellerConveyancer);

            Assert.IsNotNull(alert.PropertySellerNotSeenFaceToFaceConveyancerResults);
            Assert.AreEqual("SELL-001", alert.PropertySellerNotSeenFaceToFaceConveyancerResults[0].Party.PartyCode);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertySellerNotSeenFaceToFaceConveyancerResults[0].Value);

            Assert.AreEqual(ValueEnum.Item4, alert.PropertyBuyerNotSeenFaceToFaceByCoveyancerOrBroker);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertyHasGiftedDepositWithCharge);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertyTitleUnencumberedAndNotNewBuild);

            Assert.IsNotNull(alert.PropertyRegisteredProprietorNotASellerResults);
            Assert.AreEqual("John", alert.PropertyRegisteredProprietorNotASellerResults[0].Party.Name.FirstName);
            Assert.AreEqual("Connor", alert.PropertyRegisteredProprietorNotASellerResults[0].Party.Name.LastName);
            Assert.AreEqual(ValueEnum.Item4, alert.PropertyRegisteredProprietorNotASellerResults[0].Value);
        }

        [TestMethod]
        public void MutationEngine_Basic()
        {
            TestUtils.DeletePreviousTestMortgageApplications();

            AddNewApplication(10);
            var receiver = new MockReceiver();

            // Get the matching searches
            var matches = receiver.GetApplicationsThatMatchASearch();

            // Create the processor to deal with the logic
            var mutationEngine = new MockMutationEngine();
            mutationEngine.Apply(new MockMutationScript());

            Assert.AreEqual(5, mutationEngine.MutatorCount);

            var mutationResults = mutationEngine.Mutate(matches);

            // Check we have the mutation results
            Assert.AreEqual(10, mutationResults.Count);

            // Check the mutation result details
            var mutationResult = mutationResults[0];
            Assert_GetOriginalApplication(mutationResult);
            Assert_ClearUnnecessaryData(mutationResult);
            Assert_AddOtherParties(mutationResult);
            Assert_AddPartyAlerts(mutationResult);
            Assert_AddApplicationAlerts(mutationResult);
        }

        [TestMethod]
        public void CollatorLogic_Basic()
        {
            // Set up the test data
            TestUtils.DeletePreviousTestMortgageApplications();
            AddNewApplication(10);
            var receiver = new MockReceiver();
            var matches = receiver.GetApplicationsThatMatchASearch();
            IMutationEngine mutationEngine = new MockMutationEngine();
            mutationEngine.Add(new MockMutator_GetOriginalApplication());
            mutationEngine.Add(new MockMutator_ClearUnnecessaryData());
            mutationEngine.Add(new MockMutator_AddOtherParties());
            mutationEngine.Add(new MockMutator_AddPartyAlerts());
            mutationEngine.Add(new MockMutator_AddApplicationAlerts());
            var mutationResults = mutationEngine.Mutate(matches);

            // Trigger the code to test
            var collator = new MockCollator();
            var collatorResults = collator.Collate(mutationResults);

            // Validate the results.
            Assert.AreEqual(mutationResults.Count, collatorResults.Count);
        }

        [TestMethod]
        public void SenderLogic_Basic_x1()
        {
            // Set up the test data
            SenderLogic_Basic_SetUp(1, 0);

            // Check it
            Assert_OutputFileIsExpected_x1();
        }

        private void Assert_OutputFileIsExpected_x1()
        {
            var files = Directory.GetFiles(OUTPUTPATH);
            Assert.AreEqual(1, files.Length);

            // Check it
            AssertXMLFileIdentical(files[0], Resources.PARA_SMOV_INT2_20150204_162758592);
        }

        [TestMethod]
        public void Serialize()
        {
            // Create a sample application request object
            var requestDTO = SearchDetailHelper.Deserialize<SearchDetail>(Resources.Interaction1RequestSample);

            // Try to serial it
            var xml = SearchDetailHelper.Serialize<SearchDetail>(requestDTO);

            // Check it
            Assert.IsTrue(TestUtils.XMLfilesIdentical(Resources.Serialize_Output, xml));            
        }

        [TestMethod]
        public void SenderLogic_Basic_x10()
        {
            // Set up the test data
            SenderLogic_Basic_SetUp(10, 0);
            
            // Validate the results.
            Assert_OutputFileIsExpected_x10();
        }

        private void Assert_OutputFileIsExpected_x10()
        {
            var files = Directory.GetFiles(OUTPUTPATH);
            Assert.AreEqual(1, files.Length);

            // Check it
            AssertXMLFileIdentical(files[0], Resources.PARA_SMOV_INT2_20150204_162758592_x10);
        }

        [TestMethod]
        public void SenderLogic_Basic_x10_BatchSizeGreater()
        {
            // Set up the test data
            SenderLogic_Basic_SetUp(10, 11);

            // Validate the results.
            Assert_OutputFileIsExpected_x10();
        }

        [TestMethod]
        public void SenderLogic_Basic_x10_BatchSizeNegative()
        {
            // Set up the test data
            SenderLogic_Basic_SetUp(10, -1);

            // Validate the results.
            Assert_OutputFileIsExpected_x10();
        }

        [TestMethod]
        public void SenderLogic_Basic_x10_BatchSize3()
        {
            // Set up the test data
            SenderLogic_Basic_SetUp(10, 3);

            // Validate the results.
            Assert_OutputFileIsExpected_x10_BatchSize3();
        }

        private void Assert_OutputFileIsExpected_x10_BatchSize3()
        {
            var files = Directory.GetFiles(OUTPUTPATH);
            Assert.AreEqual(4, files.Length);

            // Check it
            AssertXMLFileIdentical(files[0], Resources.SenderLogic_Basic_x10_BatchSize3_1of4);
            AssertXMLFileIdentical(files[1], Resources.SenderLogic_Basic_x10_BatchSize3_2of4);
            AssertXMLFileIdentical(files[2], Resources.SenderLogic_Basic_x10_BatchSize3_3of4);
            AssertXMLFileIdentical(files[3], Resources.SenderLogic_Basic_x10_BatchSize3_4of4);
        }

        private static void AssertXMLFileIdentical(string file, string expectedXml)
        {
            var xDocument = XDocument.Load(file);
            string xml = xDocument.ToString();
            Assert.IsTrue(TestUtils.XMLfilesIdentical(expectedXml, xml));

            AssertXMLFileValidAgainstSchema(xml);
        }

        private static void AssertXMLFileValidAgainstSchema(string xml)
        {
            var schemas = new string[] { Resources.Schema };
            var errors = string.Empty;
            Assert.IsTrue(xml.IsValidAgainstXMLSchema(schemas, out errors));
            Assert.AreEqual(string.Empty, errors);
        }

        private void SenderLogic_Basic_SetUp(int applicationsCount, int batchSize)
        {
            // Set up the test data
            TestUtils.DeletePreviousTestMortgageApplications();
            AddNewApplication(applicationsCount);

            var receiver = new MockReceiver();
            var matches = receiver.GetApplicationsThatMatchASearch();

            var mutationEngine = new MockMutationEngine();            
            mutationEngine.Apply(new MockMutationScript());
            
            var mutationResults = mutationEngine.Mutate(matches);

            var collator = new MockCollator();
            var collatorResults = collator.Collate(mutationResults);

            // Trigger the code to test
            var sender = new MockSender();
            sender.OutputPath = OUTPUTPATH;
            sender.Domain = "PARA";
            sender.Lender = "Paragon";
            if (batchSize > 0)
                sender.BatchSize = batchSize; // Test the batch size logic works

            var senderResult = sender.Send(collatorResults);

            // Validate the results.
            Assert.IsTrue(senderResult);
        }

        [TestMethod]
        [Ignore] // Not yet ready to be used
        public void SenderLogic_Basic_x1000_BatchSize100()
        {
            // This test generates large example batch files
            SenderLogic_Basic_SetUp(1000, 100);
        }

        [TestMethod]
        public void Processor()
        {
            // Create the mock processor
            var processor = new MockProcessor();
            processor.MockApplicationsCount = 1;
            processor.Process();

            // Check it
            Assert_OutputFileIsExpected_x1();
        }

        [TestMethod]
        public void Scheduler_NextTriggerDate()
        {
            using (var scheduler = new MockBatchScheduler())
            {
                // Trigger the scheduler
                scheduler.Start();

                // Account for the weekend
                DateTime date;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                    date = DateTime.Now.AddDays(3);
                else
                    date = DateTime.Now.AddDays(1);

                // Check the next scheduled time is as expected.
                Assert.AreEqual(new DateTime(date.Year, date.Month, date.Day, 0, 0, 0), scheduler.GetNextTriggerDate());
            }
        }

        [TestMethod]
        public void Scheduler_CheckJobCalled_JobsCounted()
        {
            // Create a mock trigger to activate almost immediately
            var trigger = TriggerBuilder.Create()
              .WithIdentity("myTrigger", BatchScheduler.GROUP)
              .StartAt(DateTime.Now.AddSeconds(2))
              .Build();

            using (var scheduler = new MockBatchScheduler(null, trigger))
            {
                // Start the scheduler
                scheduler.Start();

                // Wait a bit
                Thread.Sleep(3000);

                // Ensure the job was triggered
                Assert.AreEqual(1, scheduler.JobsCounted);
            }
        }

        [TestMethod]
        public void Scheduler_CheckJobCalled_JobsCounted_Repeats_x3()
        {
            // Create a mock trigger to activate almost immediately
            var trigger = TriggerBuilder.Create()
              .WithIdentity("myTrigger", BatchScheduler.GROUP)
              .StartAt(DateTime.Now.AddSeconds(2))
              .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(1)
                .WithRepeatCount(2))     
              .Build();

            using (var scheduler = new MockBatchScheduler(null, trigger))
            {
                // Start the scheduler
                scheduler.Start();

                // Wait a bit
                Thread.Sleep(5000);

                // Ensure the job was triggered the right number of times
                Assert.AreEqual(3, scheduler.JobsCounted);
            }
        }

        [TestMethod]
        public void Scheduler_CheckJobCalled_MockBatchJob()
        {
            // Create a mock trigger to activate almost immediately
            var trigger = TriggerBuilder.Create()
              .WithIdentity("myTrigger", BatchScheduler.GROUP)
              .StartAt(DateTime.Now.AddSeconds(2))
              .Build();

            // Create a mock job to be triggered
            var job = JobBuilder.Create<MockBatchJob>()
                .WithIdentity(BatchScheduler.JOB, BatchScheduler.GROUP)
                .Build();

            using (var scheduler = new MockBatchScheduler(job, trigger))
            {
                // Start the scheduler
                scheduler.Start();

                // Wait for the processor to complete
                while (scheduler.JobsCounted <= 0)
                {
                    Thread.Sleep(1000);                    
                }

                // Check it worked
                Assert_OutputFileIsExpected_x1();                
            }
        }
    }
}