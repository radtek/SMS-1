using Bec.TargetFramework.Analysis.Infrastructure;
using Bec.TargetFramework.Analysis.Interfaces;
using Bec.TargetFramework.Analysis.Services;
using Bec.TargetFramework.Analysis.Test.Properties;
using Bec.TargetFramework.Data.Analysis;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Test.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Bec.TargetFramework.Analysis.Test
{
    [TestClass]
    public class Interaction1RequestTests : UnitTestBase
    {   
        [TestMethod]
        public void MortgageApplicationLogicService_Sample_Valid()
        {
            var service = new MortgageApplicationLogicService(new NullLogger(), null);            
            var requestDTO = SearchDetailHelper.Deserialize<SearchDetail>(Resources.Interaction1RequestSample);
            var responseDTO = service.ProcessMortgageApplication(requestDTO);

            AssertResponseIsCorrect(responseDTO);
        }

        private void AssertResponseIsCorrect(SearchDetail responseDTO)
        {
            Assert.AreEqual("Paragon", responseDTO.Lender);
            Assert.AreEqual("PARA", responseDTO.Domain);
            Assert.AreEqual("45345345352", responseDTO.MortgageApplicationNumber);
            Assert.IsFalse(responseDTO.HasError);
            Assert.IsNull(responseDTO.Parties);
            Assert.IsNull(responseDTO.Transaction);
            Assert.IsNull(responseDTO.ValidationErrors);
        }

        [TestMethod]
        public void MortgageApplicationLogic_Sample_Valid()
        {
            var requestDTO = SearchDetailHelper.Deserialize<SearchDetail>(Resources.Interaction1RequestSample);

            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                AssertResponseIsCorrect(logic.ProcessMortgageApplication(requestDTO));
        }

        [TestMethod]
        public void MortgageApplicationLogic_Sample_Invalid_NullHeaders()
        {
            var requestDTO = SearchDetailHelper.Deserialize<SearchDetail>(Resources.Interaction1RequestSample);

            // Make the headers invalid
            requestDTO.Lender = null;
            requestDTO.Domain = null;
            requestDTO.MortgageApplicationNumber = null;

            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                AssertResponseIsInvalid_NullHeaders(logic.ProcessMortgageApplication(requestDTO));
        }

        private void AssertResponseIsInvalid_NullHeaders(SearchDetail responseDTO)
        {
            Assert.IsNull(responseDTO.Lender);
            Assert.IsNull(responseDTO.Domain);
            Assert.IsNull(responseDTO.MortgageApplicationNumber);
            Assert.IsTrue(responseDTO.HasError);
            Assert.IsNull(responseDTO.Parties);
            Assert.IsNull(responseDTO.Transaction);
            Assert.IsNull(responseDTO.ValidationErrors);
            Assert.AreEqual(ErrorEnum.ERR001, responseDTO.BusinessErrors[0].Code);
            Assert.AreEqual("Lender not supplied in request", responseDTO.BusinessErrors[0].Message);
            Assert.AreEqual(ErrorEnum.ERR002, responseDTO.BusinessErrors[1].Code);
            Assert.AreEqual("Domain not supplied in request", responseDTO.BusinessErrors[1].Message);
            Assert.AreEqual(ErrorEnum.ERR003, responseDTO.BusinessErrors[2].Code);
            Assert.AreEqual("Mortgage application number not supplied in request", responseDTO.BusinessErrors[2].Message);
        }

        [TestMethod]
        public void MortgageApplicationLogic_Sample_Invalid_UnknownLender()
        {
            var requestDTO = SearchDetailHelper.Deserialize<SearchDetail>(Resources.Interaction1RequestSample);

            // Make the headers invalid
            requestDTO.Lender = "SomeoneElse";

            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                AssertResponseIsInvalid_UnknownLender(logic.ProcessMortgageApplication(requestDTO));
        }

        private void AssertResponseIsInvalid_UnknownLender(SearchDetail responseDTO)
        {
            Assert.AreEqual("SomeoneElse", responseDTO.Lender);
            Assert.AreEqual("PARA", responseDTO.Domain);
            Assert.AreEqual("45345345352", responseDTO.MortgageApplicationNumber);
            Assert.IsTrue(responseDTO.HasError);
            Assert.IsNull(responseDTO.Parties);
            Assert.IsNull(responseDTO.Transaction);
            Assert.IsNull(responseDTO.ValidationErrors);
            Assert.AreEqual(1, responseDTO.BusinessErrors.Count);
            Assert.AreEqual(ErrorEnum.ERR004, responseDTO.BusinessErrors[0].Code);
            Assert.AreEqual("Lender supplied is not recognised", responseDTO.BusinessErrors[0].Message);
        }

        [TestMethod]
        public void MortgageApplicationLogic_Sample_Invalid_UnknownDomain()
        {
            var requestDTO = SearchDetailHelper.Deserialize<SearchDetail>(Resources.Interaction1RequestSample);

            // Make the headers invalid
            requestDTO.Domain = "SomeoneElse";

            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                AssertResponseIsInvalid_UnknownDomain(logic.ProcessMortgageApplication(requestDTO));
        }

        private void AssertResponseIsInvalid_UnknownDomain(SearchDetail responseDTO)
        {
            Assert.AreEqual("Paragon", responseDTO.Lender);
            Assert.AreEqual("SomeoneElse", responseDTO.Domain);
            Assert.AreEqual("45345345352", responseDTO.MortgageApplicationNumber);
            Assert.IsTrue(responseDTO.HasError);
            Assert.IsNull(responseDTO.Parties);
            Assert.IsNull(responseDTO.Transaction);
            Assert.IsNull(responseDTO.ValidationErrors);
            Assert.AreEqual(1, responseDTO.BusinessErrors.Count);
            Assert.AreEqual(ErrorEnum.ERR005, responseDTO.BusinessErrors[0].Code);
            Assert.AreEqual("Domain supplied is not recognised", responseDTO.BusinessErrors[0].Message);
        }

        [TestMethod]
        public void PopulateFromXML_Sample_Valid()
        {
            var dto = SearchDetailHelper.Deserialize<SearchDetail>(Resources.Interaction1RequestSample);

            // Test headers
            Assert.AreEqual("Paragon", dto.Lender);
            Assert.AreEqual("PARA", dto.Domain);
            Assert.AreEqual("45345345352", dto.MortgageApplicationNumber);
            Assert.IsNotNull(dto.Parties);
            Assert.IsNotNull(dto.Transaction);
            Assert.AreEqual(3, dto.Parties.Count);

            // Test party 1
            var party1 = dto.Parties[0];
            Assert.AreEqual("Ken", party1.Detail.Name.FirstName);
            Assert.IsNull(party1.Detail.Name.MiddleName);
            Assert.AreEqual("Barlow", party1.Detail.Name.LastName);
            Assert.AreEqual(new DateTime(1976, 12, 13), party1.Detail.DateOfBirth);
            Assert.AreEqual(PartyTypeEnum.BUY, party1.Detail.PartyType);
            Assert.AreEqual("BUY-001", party1.Detail.PartyCode);
            Assert.AreEqual("k.barlow@msn.com", party1.Detail.EmailAddress);
            Assert.AreEqual(2, party1.Detail.TelephoneNumbers.Count);
            Assert.AreEqual("02078889999", party1.Detail.TelephoneNumbers[0]);
            Assert.AreEqual("07808654539", party1.Detail.TelephoneNumbers[1]);
            Assert.AreEqual("12", party1.Detail.Address.BuildingName);
            Assert.AreEqual("Strange Street", party1.Detail.Address.Line1);
            Assert.AreEqual("", party1.Detail.Address.Line2);
            Assert.AreEqual("Sidcup", party1.Detail.Address.TownCity);
            Assert.AreEqual("DA157TG", party1.Detail.Address.PostCode);
            Assert.AreEqual("Kent", party1.Detail.Address.County);
            Assert.AreEqual("GBR", party1.Detail.Address.CountryCode);
            Assert.AreEqual("Main address", party1.Detail.Address.AdditionalInformation);
            Assert.IsFalse(party1.Detail.Address.IsAnInternationalAddress);

            // Test party 2
            var party2 = dto.Parties[1];
            Assert.AreEqual("Dudley", party2.Detail.Name.FirstName);
            Assert.AreEqual("Scott", party2.Detail.Name.MiddleName);
            Assert.AreEqual("Moore", party2.Detail.Name.LastName);
            Assert.AreEqual(new DateTime(1974, 02, 14), party2.Detail.DateOfBirth);
            Assert.AreEqual(PartyTypeEnum.MBU, party2.Detail.PartyType);
            Assert.AreEqual("MBU-001", party2.Detail.PartyCode);
            Assert.AreEqual("d.s.moore@gmail.com", party2.Detail.EmailAddress);
            Assert.AreEqual(1, party2.Detail.TelephoneNumbers.Count);
            Assert.AreEqual("08458269612", party2.Detail.TelephoneNumbers[0]);
            Assert.IsNull(party2.Detail.Address);
            Assert.AreEqual("Dudley Brokers", party2.Organisation.Name);
            Assert.AreEqual("1234", party2.Organisation.Address.BuildingName);
            Assert.AreEqual("Kings Way", party2.Organisation.Address.Line1);
            Assert.AreEqual("", party2.Organisation.Address.Line2);
            Assert.AreEqual("Westminster", party2.Organisation.Address.TownCity);
            Assert.AreEqual("W16TH", party2.Organisation.Address.PostCode);
            Assert.AreEqual("London", party2.Organisation.Address.County);
            Assert.AreEqual("GBR", party2.Organisation.Address.CountryCode);
            Assert.AreEqual("", party2.Organisation.Address.AdditionalInformation);
            Assert.IsFalse(party2.Organisation.Address.IsAnInternationalAddress);

            // Test party 3
            var party3 = dto.Parties[2];
            Assert.AreEqual("Sylvia", party3.Detail.Name.FirstName);
            Assert.IsNull(party3.Detail.Name.MiddleName);
            Assert.AreEqual("Jupiter", party3.Detail.Name.LastName);
            Assert.AreEqual(new DateTime(1955, 02, 14), party3.Detail.DateOfBirth);
            Assert.AreEqual(PartyTypeEnum.BCU, party3.Detail.PartyType);
            Assert.AreEqual("BCU-001", party3.Detail.PartyCode);
            Assert.AreEqual("sJupiter@dtConveyancers.com", party3.Detail.EmailAddress);
            Assert.AreEqual(1, party3.Detail.TelephoneNumbers.Count);
            Assert.AreEqual("08003524569", party3.Detail.TelephoneNumbers[0]);
            Assert.IsNull(party3.Detail.Address);
            Assert.AreEqual("DT Conveyancers", party3.Organisation.Name);
            Assert.AreEqual("786", party3.Organisation.Address.BuildingName);
            Assert.AreEqual("Mount Drive", party3.Organisation.Address.Line1);
            Assert.AreEqual("", party3.Organisation.Address.Line2);
            Assert.AreEqual("Kingsway", party3.Organisation.Address.TownCity);
            Assert.AreEqual("EC15HH", party3.Organisation.Address.PostCode);
            Assert.AreEqual("London", party3.Organisation.Address.County);
            Assert.AreEqual("GBR", party3.Organisation.Address.CountryCode);
            Assert.AreEqual("", party3.Organisation.Address.AdditionalInformation);
            Assert.IsFalse(party3.Organisation.Address.IsAnInternationalAddress);

            // Test transaction address
            Assert.AreEqual("2", dto.Transaction.Address.BuildingName);
            Assert.AreEqual("Main Road", dto.Transaction.Address.Line1);
            Assert.AreEqual("", dto.Transaction.Address.Line2);
            Assert.AreEqual("London", dto.Transaction.Address.TownCity);
            Assert.AreEqual("SW116TN", dto.Transaction.Address.PostCode);
            Assert.AreEqual("London", dto.Transaction.Address.County);
            Assert.AreEqual("GBR", dto.Transaction.Address.CountryCode);
            Assert.AreEqual("", dto.Transaction.Address.AdditionalInformation);
            Assert.IsFalse(dto.Transaction.Address.IsAnInternationalAddress);

            // Test tranaction price
            Assert.AreEqual(350000, dto.Transaction.Price.MortgageOfferPrice);
            Assert.AreEqual(65000, dto.Transaction.Price.DepositPrice);
            Assert.AreEqual(415000, dto.Transaction.Price.PurchasePrice);
            Assert.AreEqual(415000, dto.Transaction.Price.EstimatedPrice);
            Assert.AreEqual(350000, dto.Transaction.Price.ApprovedOfferPrice);
            Assert.AreEqual(415000, dto.Transaction.Price.MortgageApplicationPurchasePrice);
            Assert.AreEqual(0, dto.Transaction.Price.MortgageOfferPurchasePrice);
        }

        [TestMethod]
        public void MortgageApplicationLogic_Sample_Invalid_NoTransactionAddress()
        {
            var requestDTO = SearchDetailHelper.Deserialize<SearchDetail>(Resources.Interaction1RequestSample);

            // Make it invalid
            requestDTO.Transaction.Address = null;

            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                AssertResponseIsInvalid_NoTransactionAddress(logic.ProcessMortgageApplication(requestDTO));

            // Another method is to have the address dto, but not have any field populated
            requestDTO.Transaction.Address = new AddressDetail();
            requestDTO.Transaction.Address.BuildingName = string.Empty;

            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                AssertResponseIsInvalid_NoTransactionAddress(logic.ProcessMortgageApplication(requestDTO));
        }

        private void AssertResponseIsInvalid_NoTransactionAddress(SearchDetail responseDTO)
        {
            Assert.AreEqual("Paragon", responseDTO.Lender);
            Assert.AreEqual("PARA", responseDTO.Domain);
            Assert.AreEqual("45345345352", responseDTO.MortgageApplicationNumber);
            Assert.IsTrue(responseDTO.HasError);
            Assert.AreEqual(1, responseDTO.BusinessErrors.Count);
            Assert.AreEqual(ErrorEnum.ERR006, responseDTO.BusinessErrors[0].Code);
            Assert.AreEqual("Transaction address not supplied in request", responseDTO.BusinessErrors[0].Message);
        }

        [TestMethod]
        public void MortgageApplicationLogic_Sample_Invalid_NoBuyer()
        {
            var requestDTO = SearchDetailHelper.Deserialize<SearchDetail>(Resources.Interaction1RequestSample);

            // Make it invalid
            requestDTO.Parties.RemoveAll(p => p.Detail.PartyType == PartyTypeEnum.BUY);

            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                AssertResponseIsInvalid_NoBuyer(logic.ProcessMortgageApplication(requestDTO));
        }

        private void AssertResponseIsInvalid_NoBuyer(SearchDetail responseDTO)
        {
            Assert.AreEqual("Paragon", responseDTO.Lender);
            Assert.AreEqual("PARA", responseDTO.Domain);
            Assert.AreEqual("45345345352", responseDTO.MortgageApplicationNumber);
            Assert.IsTrue(responseDTO.HasError);
            Assert.IsNull(responseDTO.Parties);
            Assert.IsNull(responseDTO.Transaction);
            Assert.IsNull(responseDTO.ValidationErrors);
            Assert.AreEqual(1, responseDTO.BusinessErrors.Count);
            Assert.AreEqual(ErrorEnum.ERR007, responseDTO.BusinessErrors[0].Code);
            Assert.AreEqual("Buyer not supplied in request", responseDTO.BusinessErrors[0].Message);
        }

        [TestMethod]
        public void MortgageApplicationLogic_Sample_Invalid_NoBuyerName()
        {
            var requestDTO = SearchDetailHelper.Deserialize<SearchDetail>(Resources.Interaction1RequestSample);

            // Make it invalid
            var buyer = requestDTO.Parties.First(p => p.Detail.PartyType == PartyTypeEnum.BUY);
            buyer.Detail.Name.FirstName = null;
            buyer.Detail.Name.MiddleName = null;
            buyer.Detail.Name.LastName = string.Empty;

            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                AssertResponseIsInvalid_NoBuyerName(logic.ProcessMortgageApplication(requestDTO));

            // Make it invalid another way
            buyer.Detail.Name = null;

            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                AssertResponseIsInvalid_NoBuyerName(logic.ProcessMortgageApplication(requestDTO));
        }

        private void AssertResponseIsInvalid_NoBuyerName(SearchDetail responseDTO)
        {
            Assert.AreEqual("Paragon", responseDTO.Lender);
            Assert.AreEqual("PARA", responseDTO.Domain);
            Assert.AreEqual("45345345352", responseDTO.MortgageApplicationNumber);
            Assert.IsTrue(responseDTO.HasError);
            Assert.IsNull(responseDTO.Parties);
            Assert.IsNull(responseDTO.Transaction);
            Assert.IsNull(responseDTO.ValidationErrors);
            Assert.AreEqual(1, responseDTO.BusinessErrors.Count);
            Assert.AreEqual(ErrorEnum.ERR008, responseDTO.BusinessErrors[0].Code);
            Assert.AreEqual("Buyer name not supplied in request", responseDTO.BusinessErrors[0].Message);
        }

        [TestMethod]
        public void MortgageApplicationLogic_Sample_Invalid_NoBuyerAddress()
        {
            var requestDTO = SearchDetailHelper.Deserialize<SearchDetail>(Resources.Interaction1RequestSample);

            // Make it invalid
            var buyer = requestDTO.Parties.First(p => p.Detail.PartyType == PartyTypeEnum.BUY);
            buyer.Detail.Address.BuildingName = null;
            buyer.Detail.Address.CountryCode = null;
            buyer.Detail.Address.County = string.Empty;
            buyer.Detail.Address.Line1 = string.Empty;
            buyer.Detail.Address.Line2 = string.Empty;
            buyer.Detail.Address.PostCode = string.Empty;
            buyer.Detail.Address.TownCity = string.Empty;

            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                AssertResponseIsInvalid_NoBuyerAddress(logic.ProcessMortgageApplication(requestDTO));

            // Make it invalid another way
            buyer.Detail.Address = null;

            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                AssertResponseIsInvalid_NoBuyerAddress(logic.ProcessMortgageApplication(requestDTO));
        }

        private void AssertResponseIsInvalid_NoBuyerAddress(SearchDetail responseDTO)
        {
            Assert.AreEqual("Paragon", responseDTO.Lender);
            Assert.AreEqual("PARA", responseDTO.Domain);
            Assert.AreEqual("45345345352", responseDTO.MortgageApplicationNumber);
            Assert.IsTrue(responseDTO.HasError);
            Assert.IsNull(responseDTO.Parties);
            Assert.IsNull(responseDTO.Transaction);
            Assert.IsNull(responseDTO.ValidationErrors);
            Assert.AreEqual(1, responseDTO.BusinessErrors.Count);
            Assert.AreEqual(ErrorEnum.ERR009, responseDTO.BusinessErrors[0].Code);
            Assert.AreEqual("Buyer address not supplied in request", responseDTO.BusinessErrors[0].Message);
        }

        [TestMethod]
        public void MortgageApplicationLogic_Sample_Invalid_NoTransaction()
        {
            var requestDTO = SearchDetailHelper.Deserialize<SearchDetail>(Resources.Interaction1RequestSample);

            // Make it invalid
            requestDTO.Transaction = null;

            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                AssertResponseIsInvalid_NoTransaction(logic.ProcessMortgageApplication(requestDTO));
        }

        private void AssertResponseIsInvalid_NoTransaction(SearchDetail responseDTO)
        {
            Assert.AreEqual("Paragon", responseDTO.Lender);
            Assert.AreEqual("PARA", responseDTO.Domain);
            Assert.AreEqual("45345345352", responseDTO.MortgageApplicationNumber);
            Assert.IsTrue(responseDTO.HasError);
            Assert.IsNull(responseDTO.Parties);
            Assert.IsNull(responseDTO.Transaction);
            Assert.IsNull(responseDTO.ValidationErrors);
            Assert.AreEqual(1, responseDTO.BusinessErrors.Count);
            Assert.AreEqual(ErrorEnum.ERR010, responseDTO.BusinessErrors[0].Code);
            Assert.AreEqual("Transaction section not supplied in request", responseDTO.BusinessErrors[0].Message);
        }

        [TestMethod]
        public void MortgageApplicationLogic_Sample_Save()
        {
            var requestDTO = SearchDetailHelper.Deserialize<SearchDetail>(Resources.Interaction1RequestSample);

            // Firstly, mark all current mortgage applications that match this one as deleted.
            TestUtils.DeletePreviousTestMortgageApplications(requestDTO);

            //var mockContext = new Mock<BecTargetFrameworkAnalysisEntities>();

            //var data = new List<AnalysisMortgageApplicationDetail> 
            //{ 
            //    new AnalysisMortgageApplicationDetail { SearchReferenceKey = "BBB", IsActive = true, IsDeleted = false }, 
            //}.AsQueryable();

            //var mockSetDetail = new Mock<DbSet<AnalysisMortgageApplicationDetail>>();
            //mockSetDetail.As<IQueryable<AnalysisMortgageApplicationDetail>>().Setup(m => m.Provider).Returns(data.Provider);
            //mockSetDetail.As<IQueryable<AnalysisMortgageApplicationDetail>>().Setup(m => m.Expression).Returns(data.Expression);
            //mockSetDetail.As<IQueryable<AnalysisMortgageApplicationDetail>>().Setup(m => m.ElementType).Returns(data.ElementType);
            //mockSetDetail.As<IQueryable<AnalysisMortgageApplicationDetail>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            //mockContext.Setup(m => m.AnalysisMortgageApplicationDetails).Returns(mockSetDetail.Object);

            //var mockSetApplication = new Mock<DbSet<AnalysisMortgageApplication>>();
            //mockContext.Setup(m => m.AnalysisMortgageApplications).Returns(mockSetApplication.Object);

            // Trigger the logic
            //using (MortgageApplicationLogic logic = new MortgageApplicationLogic(new NullLogger(), null, mockContext.Object))
            //    logic.ProcessMortgageApplication(requestDTO);

            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                logic.ProcessMortgageApplication(requestDTO);

            //mockSetDetail.Verify(m => m.Add(It.IsAny<AnalysisMortgageApplicationDetail>()), Times.Once());
            //mockSetApplication.Verify(m => m.Add(It.IsAny<AnalysisMortgageApplication>()), Times.Once());
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());

            // Check that the new mortgage application was saved
            //MortgageApplicationLogic_Sample_Save_CheckIt(requestDTO, mockContext.Object);

            MortgageApplicationLogic_Sample_Save_CheckIt(requestDTO);

            // Clean up any data we created.
            TestUtils.DeletePreviousTestMortgageApplications(requestDTO);
        }

        //private void MortgageApplicationLogic_Sample_Save_CheckIt(SearchDetail requestDTO, BecTargetFrameworkAnalysisEntities context)
        private void MortgageApplicationLogic_Sample_Save_CheckIt(SearchDetail requestDTO)
        {
            //using (var scope = new UnitOfWorkScope<BecTargetFrameworkAnalysisEntities>(context, UnitOfWorkScopePurpose.Writing, new NullLogger(), true))
            using (var scope = new UnitOfWorkScope<TargetFrameworkAnalysisEntities>(UnitOfWorkScopePurpose.Writing, new NullLogger(), true))
            {
                // Check the detail table
                var analysisMortgageApplicationDetailDTO =
                    AnalysisMortgageApplicationDetailConverter.ToDto(
                        scope.DbContext.AnalysisMortgageApplicationDetails.Single(
                            s => s.Lender.Equals(requestDTO.Lender)
                                && s.Domain.Equals(requestDTO.Domain)
                                && s.MortgageApplicationNumber.Equals(requestDTO.MortgageApplicationNumber)
                                && s.IsActive
                                && !s.IsDeleted));

                Assert.IsNotNull(analysisMortgageApplicationDetailDTO);
                Assert.AreEqual(requestDTO.Lender, analysisMortgageApplicationDetailDTO.Lender);
                Assert.AreEqual(requestDTO.Domain, analysisMortgageApplicationDetailDTO.Domain);
                Assert.AreEqual(requestDTO.MortgageApplicationNumber, analysisMortgageApplicationDetailDTO.MortgageApplicationNumber);
                Assert.AreEqual(requestDTO.Lender + "|" + requestDTO.Domain + "|" + requestDTO.MortgageApplicationNumber, analysisMortgageApplicationDetailDTO.SearchReferenceKey);
                Assert.AreEqual(true, analysisMortgageApplicationDetailDTO.IsActive);
                Assert.AreEqual(false, analysisMortgageApplicationDetailDTO.IsDeleted);

                // Check the header table
                var analysisMortgageApplicationDTO =
                    AnalysisMortgageApplicationConverter.ToDto(
                        scope.DbContext.AnalysisMortgageApplications.Single(
                            s => s.AnalysisMortgageApplicationID == analysisMortgageApplicationDetailDTO.AnalysisMortgageApplicationID));

                Assert.IsNotNull(analysisMortgageApplicationDTO);
                Assert.AreEqual(JsonHelper.SerializeData(requestDTO), analysisMortgageApplicationDTO.ApplicationData);
                Assert.AreEqual(DateTime.Now.Date, analysisMortgageApplicationDTO.LastUpdated.Date);
                Assert.AreEqual(Guid.Parse("8967ae42-97fa-11e4-9023-e7ad5fae5a2c"), analysisMortgageApplicationDTO.SchemaID);
                Assert.AreEqual(0, analysisMortgageApplicationDTO.SchemaVersionNumber);
                Assert.AreEqual(true, analysisMortgageApplicationDTO.IsActive);
                Assert.AreEqual(false, analysisMortgageApplicationDTO.IsDeleted);
            }
        }

        
        [TestMethod]
        public void MortgageApplicationLogic_NullRequest()
        {
            SearchDetail requestDTO = null;

            // Trigger the logic
            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                AssertResponseIsInvalid_NullRequest(logic.ProcessMortgageApplication(requestDTO));
        }

        private void AssertResponseIsInvalid_NullRequest(SearchDetail responseDTO)
        {
            Assert.IsTrue(responseDTO.HasError);
            Assert.IsNull(responseDTO.Parties);
            Assert.IsNull(responseDTO.Transaction);
            Assert.IsNull(responseDTO.ValidationErrors);
            Assert.AreEqual(1, responseDTO.BusinessErrors.Count);
            Assert.AreEqual(ErrorEnum.ERR011, responseDTO.BusinessErrors[0].Code);
            Assert.AreEqual("Request is a null value", responseDTO.BusinessErrors[0].Message);
        }

        /// <summary>
        /// Test that we can send an update to a mortgage application, and it updates to the same row.
        /// </summary>
        [TestMethod]
        public void MortgageApplicationLogic_Sample_Valid_Update()
        {
            var requestDTO = SearchDetailHelper.Deserialize<SearchDetail>(Resources.Interaction1RequestSample);

            // Firstly, mark all current mortgage applications that match this one as deleted.
            TestUtils.DeletePreviousTestMortgageApplications(requestDTO);

            // Trigger the logic to send the first one.
            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                logic.ProcessMortgageApplication(requestDTO);

            // Make a change
            requestDTO.Transaction.Price.DepositPrice = 60000;

            // Do it again to send the update
            using (var logic = new MortgageApplicationLogic(new NullLogger(), null))
                logic.ProcessMortgageApplication(requestDTO);

            // Check that the entry was updated.
            MortgageApplicationLogic_Sample_Save_CheckIt(requestDTO);
        }
    }
}
