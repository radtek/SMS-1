using Bec.TargetFramework.Analysis.Interfaces;
using System;
using System.Collections.Generic;

namespace Bec.TargetFramework.Analysis.Test
{
    public class MockMutator_AddApplicationAlerts : IMutator
    {
        public SearchDetail Mutate(SearchDetail input)
        {
            input.Alert = new SearchAlertDetail();
            var alert = input.Alert;
            alert.PropertySIRAMatchResult = ValueEnum.Item1;
            alert.PropertyHasLinkedTitles = ValueEnum.Item1;

            var propertySellerAuthorityStatusResult = new PartyIndicatorDetail();
            propertySellerAuthorityStatusResult.Party = new PartyDetail();
            propertySellerAuthorityStatusResult.Party.PartyCode = "SELL-001";
            propertySellerAuthorityStatusResult.AuthorityStatus = AuthorityEnum.Item2;
            propertySellerAuthorityStatusResult.AuthorityStatusSpecified = true;
            alert.PropertySellerAuthorityStatusResults = new List<PartyIndicatorDetail>() { propertySellerAuthorityStatusResult };

            var propertyBuyerAuthorityStatusResult = new PartyIndicatorDetail();
            propertyBuyerAuthorityStatusResult.Party = new PartyDetail();
            propertyBuyerAuthorityStatusResult.Party.PartyCode = "BUY-001";
            propertyBuyerAuthorityStatusResult.AuthorityStatus = AuthorityEnum.Item4;
            propertyBuyerAuthorityStatusResult.AuthorityStatusSpecified = true;
            alert.PropertyBuyerAuthorityStatusResults = new List<PartyIndicatorDetail>() { propertyBuyerAuthorityStatusResult };

            var propertySellerPowerOfAttorneyUploadedResult = new PartyIndicatorDetail();
            propertySellerPowerOfAttorneyUploadedResult.Party = new PartyDetail();
            propertySellerPowerOfAttorneyUploadedResult.Party.PartyCode = "SELL-001";
            propertySellerPowerOfAttorneyUploadedResult.Value = ValueEnum.Item1;
            propertySellerPowerOfAttorneyUploadedResult.ValueSpecified = true;
            propertySellerPowerOfAttorneyUploadedResult.Party.PartyCode = "SELL-001";
            alert.PropertySellerPowerOfAttorneyUploadedResults = new List<PartyIndicatorDetail>() { propertySellerPowerOfAttorneyUploadedResult };

            var propertySellerNotARegisteredProprietorResult = new PartyIndicatorDetail();
            propertySellerNotARegisteredProprietorResult.Party = new PartyDetail();
            propertySellerNotARegisteredProprietorResult.Party.PartyCode = "SELL-001";
            propertySellerNotARegisteredProprietorResult.Value = ValueEnum.Item4;
            propertySellerNotARegisteredProprietorResult.ValueSpecified = true;
            alert.PropertySellerNotARegisteredProprietorResults = new List<PartyIndicatorDetail>() { propertySellerNotARegisteredProprietorResult };

            alert.PropertyDateOfPreviousRegisterTransfer = new DateTime(2006, 11, 11);
            alert.PropertyCurrentRegisteredPrice = 243000;

            var propertySellerStatutoryDeclarationResult = new PartyIndicatorDetail();
            propertySellerStatutoryDeclarationResult.Party = new PartyDetail();
            propertySellerStatutoryDeclarationResult.Party.PartyCode = "SELL-001";
            propertySellerStatutoryDeclarationResult.Value = ValueEnum.Item1;
            propertySellerStatutoryDeclarationResult.ValueSpecified = true;
            alert.PropertySellerStatutoryDeclarationResults = new List<PartyIndicatorDetail>() { propertySellerStatutoryDeclarationResult };

            var propertyGradeOfTitleResult = new TitleIndicatorDetail();
            propertyGradeOfTitleResult.TitleNumber = "01234568";
            propertyGradeOfTitleResult.GradeClass = TitleGradeEnum.Item1;
            propertyGradeOfTitleResult.GradeClassSpecified = true;
            alert.PropertyGradeOfTitleResults = new List<TitleIndicatorDetail>() { propertyGradeOfTitleResult };

            alert.PropertyNoOS1OrderedOrNoAP1 = ValueEnum.Item2;
            alert.PropertyNoDaysSinceCompleted = 5;
            alert.PropertyOS1NameOtherThanBuyerExists = ValueEnum.Item0;
            alert.PropertyNoDaysSinceCompletedNoAP1 = 0;
            alert.PropertyNoDaysSinceCompletedNoRegistrationHMLR = 0;
            alert.PropertyNoDaysSinceCompletedNoRegistrationOnCompaniesHouse = 0;

            var propertyTitleProprietorResult = new TitleIndicatorDetail();
            propertyTitleProprietorResult.TitleNumber = "01234568";
            propertyTitleProprietorResult.PartyAlertResults = new List<PartyContainerDetail>() { new PartyContainerDetail() };
            propertyTitleProprietorResult.PartyAlertResults[0].Detail = new PartyDetail();
            propertyTitleProprietorResult.PartyAlertResults[0].Detail.PartyCode = "SELL-001";
            propertyTitleProprietorResult.PartyAlertResults[0].Alert = new PartyAlertDetail();
            propertyTitleProprietorResult.PartyAlertResults[0].Alert.DeathIndicator = ValueEnum.Item1;
            propertyTitleProprietorResult.PartyAlertResults[0].Alert.DeathIndicatorSpecified = true;
            propertyTitleProprietorResult.PartyAlertResults[0].Alert.BankruptcyIndicator = ValueEnum.Item0;
            propertyTitleProprietorResult.PartyAlertResults[0].Alert.BankruptcyIndicatorSpecified = true;
            alert.PropertyTitleProprietorResults = new List<TitleIndicatorDetail>() { propertyTitleProprietorResult };

            alert.PropertyTenureNotMatchHMLR = ValueEnum.Item1;
            alert.PropertyDaysLeftOnLease = 0;

            alert.PropertyIPMatchPartyResults = new List<PartyIndicatorDetail>() { new PartyIndicatorDetail() };
            alert.PropertyIPMatchPartyResults[0].Party = new PartyDetail();
            alert.PropertyIPMatchPartyResults[0].Party.PartyCode = "BUY-001";
            alert.PropertyIPMatchPartyResults[0].IPAddress = "789.423.42.150";
            alert.PropertyIPMatchPartyResults.Add(new PartyIndicatorDetail());
            alert.PropertyIPMatchPartyResults[1].Party = new PartyDetail();
            alert.PropertyIPMatchPartyResults[1].Party.PartyCode = "SELL-001";
            alert.PropertyIPMatchPartyResults[1].IPAddress = "789.423.42.150";

            alert.PropertyBuyerDistanceFromResults = new List<PartyIndicatorDetail>() { new PartyIndicatorDetail() };
            alert.PropertyBuyerDistanceFromResults[0].Party = new PartyDetail();
            alert.PropertyBuyerDistanceFromResults[0].Party.PartyCode = "BUY-001";
            alert.PropertyBuyerDistanceFromResults[0].Distance = 11;
            alert.PropertyBuyerDistanceFromResults[0].DistanceSpecified = true;

            alert.PropertyHasMutipleBuyersWithSameHomeAcrossDifferentSearches = ValueEnum.Item0;

            alert.PropertySellerHasCreditHistoryElsewhereResults = new List<PartyIndicatorDetail>() { new PartyIndicatorDetail() };
            alert.PropertySellerHasCreditHistoryElsewhereResults[0].Party = new PartyDetail();
            alert.PropertySellerHasCreditHistoryElsewhereResults[0].Party.PartyCode = "SELL-001";

            alert.PropertyPriceMatchSIRAApplication = ValueEnum.Item0;
            alert.PropertyPriceMatchSIRAOffer = ValueEnum.Item0;
            alert.PropertyBuyerOrSellerConveyancerHasCancelledSearch = ValueEnum.Item2;

            alert.PropertySourceOfDepositResults = new List<SourceOfDepositDetail>() { new SourceOfDepositDetail() };
            alert.PropertySourceOfDepositResults[0].SourceType = SourceOfDepositEnum.Item1;
            alert.PropertySourceOfDepositResults[0].Amount = 25000;
            alert.PropertySourceOfDepositResults[0].SourceParty = new PartyDetail();
            alert.PropertySourceOfDepositResults[0].SourceParty.Name = new NameDetail();
            alert.PropertySourceOfDepositResults[0].SourceParty.Name.FirstName = "Charles";
            alert.PropertySourceOfDepositResults[0].SourceParty.Name.LastName = "Dickens";
            alert.PropertySourceOfDepositResults[0].BuyerDeclaresHasBeenGifted = ValueEnum.Item1;
            alert.PropertySourceOfDepositResults[0].SourceHasChargeOnProperty = ValueEnum.Item1;

            alert.PropertySourceOfDepositResults.Add(new SourceOfDepositDetail());
            alert.PropertySourceOfDepositResults[1].SourceType = SourceOfDepositEnum.Item2;
            alert.PropertySourceOfDepositResults[1].Amount = 10000;
            alert.PropertySourceOfDepositResults[1].SourceParty = new PartyDetail();
            alert.PropertySourceOfDepositResults[1].SourceParty.Name = new NameDetail();
            alert.PropertySourceOfDepositResults[1].SourceParty.Name.FirstName = "Bob";
            alert.PropertySourceOfDepositResults[1].SourceParty.Name.MiddleName = "The";
            alert.PropertySourceOfDepositResults[1].SourceParty.Name.LastName = "Builder";
            alert.PropertySourceOfDepositResults[1].BuyerDeclaresHasBeenGifted = ValueEnum.Item0;
            alert.PropertySourceOfDepositResults[1].SourceHasChargeOnProperty = ValueEnum.Item2;

            alert.PropertyStatus = StatusEnum.Item2;

            alert.PropertyChargeResults = new List<ChargeDetail>() { new ChargeDetail() };
            alert.PropertyChargeResults[0].Date = new DateTime(2001, 11, 12);
            alert.PropertyChargeResults[0].Description = "this is a charge";
            alert.PropertyChargeResults[0].Type = "type1";
            alert.PropertyChargeResults[0].TitleNumber = "01234567";

            alert.PropertyChargeResults[0].Parties = new List<PartyContainerDetail>() { new PartyContainerDetail() };
            alert.PropertyChargeResults[0].Parties[0].Detail = new PartyDetail();
            alert.PropertyChargeResults[0].Parties[0].Detail.Name = new NameDetail();
            alert.PropertyChargeResults[0].Parties[0].Detail.Name.FirstName = "Bob";
            alert.PropertyChargeResults[0].Parties[0].Detail.Name.LastName = "Monkhouse";
            alert.PropertyChargeResults[0].Parties[0].Organisation = new OrganisationDetail();
            alert.PropertyChargeResults[0].Parties[0].Organisation.Name = "Monkhouse Ltd";
            alert.PropertyChargeResults[0].Parties.Add(new PartyContainerDetail());
            alert.PropertyChargeResults[0].Parties[1].Detail = new PartyDetail();
            alert.PropertyChargeResults[0].Parties[1].Detail.Name = new NameDetail();
            alert.PropertyChargeResults[0].Parties[1].Detail.Name.FirstName = "Elvis";
            alert.PropertyChargeResults[0].Parties[1].Detail.Name.LastName = "Presley";

            alert.PropertyChargeResults.Add(new ChargeDetail());
            alert.PropertyChargeResults[1].Date = new DateTime(1998, 11, 12);
            alert.PropertyChargeResults[1].Description = "another charge";
            alert.PropertyChargeResults[1].Type = "type2";
            alert.PropertyChargeResults[1].TitleNumber = "01234567";
            alert.PropertyChargeResults[1].Parties = new List<PartyContainerDetail>() { new PartyContainerDetail() };
            alert.PropertyChargeResults[1].Parties[0] = new PartyContainerDetail();
            alert.PropertyChargeResults[1].Parties[0].Detail = new PartyDetail();
            alert.PropertyChargeResults[1].Parties[0].Detail.Name = new NameDetail();
            alert.PropertyChargeResults[1].Parties[0].Detail.Name.FirstName = "David";
            alert.PropertyChargeResults[1].Parties[0].Detail.Name.LastName = "Beckham";

            alert.PropertyRestrictionResults = new List<RestrictionDetail>() { new RestrictionDetail() };
            alert.PropertyRestrictionResults[0].TypeName = "Restriction 1";
            alert.PropertyRestrictionResults[0].TitleNumber = "01234567";
            alert.PropertyRestrictionResults[0].Description = "Restriction Descr 1";

            alert.PropertyRestrictionResults.Add(new RestrictionDetail());
            alert.PropertyRestrictionResults[1].TypeName = "Restriction 2";
            alert.PropertyRestrictionResults[1].TitleNumber = "01234567";
            alert.PropertyRestrictionResults[1].Description = "Restriction Descr 2";

            alert.PropertySellerPostRedirectResults = new List<PartyIndicatorDetail>() { new PartyIndicatorDetail() };
            alert.PropertySellerPostRedirectResults[0].Party = new PartyDetail();
            alert.PropertySellerPostRedirectResults[0].Party.PartyCode = "SELL-001";
            alert.PropertySellerPostRedirectResults[0].Value = ValueEnum.Item4;
            alert.PropertySellerPostRedirectResults[0].ValueSpecified = true;

            alert.PropertyTitleUnencumberedResults = new List<TitleIndicatorDetail>() { new TitleIndicatorDetail() };
            alert.PropertyTitleUnencumberedResults[0].TitleNumber = "01234568";
            alert.PropertyTitleUnencumberedResults[0].Value = ValueEnum.Item4;
            alert.PropertyTitleUnencumberedResults[0].ValueSpecified = true;

            alert.PropertyBuyerNotSeenFaceToFaceConveyancerResults = new List<PartyIndicatorDetail>() { new PartyIndicatorDetail() };
            alert.PropertyBuyerNotSeenFaceToFaceConveyancerResults[0].Party = new PartyDetail();
            alert.PropertyBuyerNotSeenFaceToFaceConveyancerResults[0].Party.PartyCode = "BUY-001";
            alert.PropertyBuyerNotSeenFaceToFaceConveyancerResults[0].Value = ValueEnum.Item4;
            alert.PropertyBuyerNotSeenFaceToFaceConveyancerResults[0].ValueSpecified = true;

            alert.PropertyBuyerNotSeenFaceToFaceBrokerResults = new List<PartyIndicatorDetail>() { new PartyIndicatorDetail() };
            alert.PropertyBuyerNotSeenFaceToFaceBrokerResults[0].Party = new PartyDetail();
            alert.PropertyBuyerNotSeenFaceToFaceBrokerResults[0].Party.PartyCode = "BUY-001";
            alert.PropertyBuyerNotSeenFaceToFaceBrokerResults[0].Value = ValueEnum.Item4;
            alert.PropertyBuyerNotSeenFaceToFaceBrokerResults[0].ValueSpecified = true;

            alert.PropertySIRAThirdPartyIntroducerMatch = ValueEnum.Item1;
            alert.PropertyThirdPartyIntroducer = new PartyDetail();
            alert.PropertyThirdPartyIntroducer.PartyCode = "TPI-001";

            alert.PropertyTenureNotMatchSTS = ValueEnum.Item0;

            alert.PropertySellerConveyancingBranchRegulatorHasNoMatchResults = new List<PartyIndicatorDetail>() { new PartyIndicatorDetail() };
            alert.PropertySellerConveyancingBranchRegulatorHasNoMatchResults[0].Party = new PartyDetail();
            alert.PropertySellerConveyancingBranchRegulatorHasNoMatchResults[0].Party.PartyCode = "SCU-001";
            alert.PropertySellerConveyancingBranchRegulatorHasNoMatchResults[0].Value = ValueEnum.Item4;
            alert.PropertySellerConveyancingBranchRegulatorHasNoMatchResults[0].ValueSpecified = true;

            alert.PropertySellerConveyancingBranchComplianceOfficerNotApprovedResults = new List<PartyIndicatorDetail>() { new PartyIndicatorDetail() };
            alert.PropertySellerConveyancingBranchComplianceOfficerNotApprovedResults[0].Party = new PartyDetail();
            alert.PropertySellerConveyancingBranchComplianceOfficerNotApprovedResults[0].Party.PartyCode = "SELL-001";
            alert.PropertySellerConveyancingBranchComplianceOfficerNotApprovedResults[0].Value = ValueEnum.Item4;
            alert.PropertySellerConveyancingBranchComplianceOfficerNotApprovedResults[0].ValueSpecified = true;

            alert.PropertyNewBuildFirstRegistration = ValueEnum.Item0;
            alert.PropertySubSale = ValueEnum.Item0;

            alert.PropertyIncentivesPartyResults = new List<PartyIndicatorDetail>() { new PartyIndicatorDetail() };
            alert.PropertyIncentivesPartyResults[0].Party = new PartyDetail();
            alert.PropertyIncentivesPartyResults[0].Party.Name = new NameDetail();
            alert.PropertyIncentivesPartyResults[0].Party.Name.FirstName = "Joe";
            alert.PropertyIncentivesPartyResults[0].Party.Name.LastName = "Allen";

            alert.PropertyBuyerWillBeResidentResults = new List<PartyIndicatorDetail>() { new PartyIndicatorDetail() };
            alert.PropertyBuyerWillBeResidentResults[0].Party = new PartyDetail();
            alert.PropertyBuyerWillBeResidentResults[0].Party.PartyCode = "BUY-001";
            alert.PropertyBuyerWillBeResidentResults[0].Value = ValueEnum.Item1;
            alert.PropertyBuyerWillBeResidentResults[0].ValueSpecified = true;

            alert.PropertyValuationSurveyPrice = 298000;
            alert.PropertyServiceAddressPotentiallyExists = ValueEnum.Item4;

            alert.PropertyBuyerHasChangedConveyancingBranchAfterExchangeResults = new List<PartyIndicatorDetail>() { new PartyIndicatorDetail() };
            alert.PropertyBuyerHasChangedConveyancingBranchAfterExchangeResults[0].Party = new PartyDetail();
            alert.PropertyBuyerHasChangedConveyancingBranchAfterExchangeResults[0].Party.PartyCode = "BUY-001";
            alert.PropertyBuyerHasChangedConveyancingBranchAfterExchangeResults[0].Value = ValueEnum.Item4;
            alert.PropertyBuyerHasChangedConveyancingBranchAfterExchangeResults[0].ValueSpecified = true;

            alert.PropertyOtherSTSSearchesExistWithSameBuyerAtThisAddressResults = new List<PartyIndicatorDetail>() { new PartyIndicatorDetail() };
            alert.PropertyOtherSTSSearchesExistWithSameBuyerAtThisAddressResults[0].Party = new PartyDetail();
            alert.PropertyOtherSTSSearchesExistWithSameBuyerAtThisAddressResults[0].Party.PartyCode = "BCU-001";
            alert.PropertyOtherSTSSearchesExistWithSameBuyerAtThisAddressResults[0].Value = ValueEnum.Item4;
            alert.PropertyOtherSTSSearchesExistWithSameBuyerAtThisAddressResults[0].ValueSpecified = true;
            alert.PropertyOtherSTSSearchesExistWithSameBuyerAtThisAddressResults.Add(new PartyIndicatorDetail());
            alert.PropertyOtherSTSSearchesExistWithSameBuyerAtThisAddressResults[1].Party = new PartyDetail();
            alert.PropertyOtherSTSSearchesExistWithSameBuyerAtThisAddressResults[1].Party.PartyCode = "BCU-002";
            alert.PropertyOtherSTSSearchesExistWithSameBuyerAtThisAddressResults[1].Value = ValueEnum.Item4;
            alert.PropertyOtherSTSSearchesExistWithSameBuyerAtThisAddressResults[1].ValueSpecified = true;

            alert.PropertyRegisteredProprietorsWhoAreNotSellerOnSTS = ValueEnum.Item0;
            alert.PropertyDeathOnExperianNotOnHMLR = ValueEnum.Item4;
            alert.PropertyDeathOnHMLRNotOnExperian = ValueEnum.Item2;
            alert.PropertyBankruptcyOnExperianNotOnHMLR = ValueEnum.Item0;
            alert.PropertyBankruptcyOnHMLRNotOnExperian = ValueEnum.Item0;
            alert.PropertyIPMatchOnBuyerAndSeller = ValueEnum.Item4;
            alert.PropertyIPMatchOnBuyerConveyancerAndSellerConveyancer = ValueEnum.Item4;

            alert.PropertySellerNotSeenFaceToFaceConveyancerResults = new List<PartyIndicatorDetail>() { new PartyIndicatorDetail() };
            alert.PropertySellerNotSeenFaceToFaceConveyancerResults[0].Party = new PartyDetail();
            alert.PropertySellerNotSeenFaceToFaceConveyancerResults[0].Party.PartyCode = "SELL-001";
            alert.PropertySellerNotSeenFaceToFaceConveyancerResults[0].Value = ValueEnum.Item4;
            alert.PropertySellerNotSeenFaceToFaceConveyancerResults[0].ValueSpecified = true;

            alert.PropertyBuyerNotSeenFaceToFaceByCoveyancerOrBroker = ValueEnum.Item4;
            alert.PropertyHasGiftedDepositWithCharge = ValueEnum.Item4;
            alert.PropertyTitleUnencumberedAndNotNewBuild = ValueEnum.Item4;

            alert.PropertyRegisteredProprietorNotASellerResults = new List<PartyIndicatorDetail>() { new PartyIndicatorDetail() };
            alert.PropertyRegisteredProprietorNotASellerResults[0].Party = new PartyDetail();
            alert.PropertyRegisteredProprietorNotASellerResults[0].Party.Name = new NameDetail();
            alert.PropertyRegisteredProprietorNotASellerResults[0].Party.Name.FirstName = "John";
            alert.PropertyRegisteredProprietorNotASellerResults[0].Party.Name.LastName = "Connor";
            alert.PropertyRegisteredProprietorNotASellerResults[0].Value = ValueEnum.Item4;
            alert.PropertyRegisteredProprietorNotASellerResults[0].ValueSpecified = true;

            return input;
        }
    }
}
