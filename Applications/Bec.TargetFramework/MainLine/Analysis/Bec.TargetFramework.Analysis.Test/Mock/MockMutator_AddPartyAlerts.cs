using Bec.TargetFramework.Analysis.Interfaces;
using System;
using System.Collections.Generic;

namespace Bec.TargetFramework.Analysis.Test
{
    public class MockMutator_AddPartyAlerts : IMutator
    {
        public SearchDetail Mutate(SearchDetail input)
        {
            // buyer alert, for now mock this data
            input.Parties[0].Alert = new PartyAlertDetail();
            var alert = input.Parties[0].Alert;
            alert.AMLExecutionDate = new DateTime(2014, 11, 3);
            alert.AMLExecutionDateSpecified = true;
            alert.AMLResult = ValueEnum.Item1;
            alert.AMLResultSpecified = true;
            var cardPaymentAVSResult = new CardPaymentAVSDetail();
            cardPaymentAVSResult.Date = new DateTime(2014, 08, 09);
            cardPaymentAVSResult.AVSCode = "AVS code";
            cardPaymentAVSResult.Value = ValueEnum.Item1;
            alert.CardPaymentAVSResults = new List<CardPaymentAVSDetail>();
            alert.CardPaymentAVSResults.Add(cardPaymentAVSResult);
            alert.BankAccountResult = ValueEnum.Item1;
            alert.BankAccountResultSpecified = true;
            alert.DeathIndicator = ValueEnum.Item2;
            alert.DeathIndicatorSpecified = true;
            alert.BankruptcyIndicator = ValueEnum.Item2;
            alert.BankruptcyIndicatorSpecified = true;
            alert.PartyDataMatchIndicator = ValueEnum.Item1;
            alert.PartyDataMatchIndicatorSpecified = true;
            alert.GenuineIDDocumentsSeenByConveyancer = ValueEnum.Item0;
            alert.GenuineIDDocumentsSeenByConveyancerSpecified = true;
            alert.CertifiedCopyIDDocumentsSeenByConveyancer = ValueEnum.Item0;
            alert.CertifiedCopyIDDocumentsSeenByConveyancerSpecified = true;

            // broker alert, for now mock this data
            input.Parties[1].Alert = new PartyAlertDetail();
            alert = input.Parties[1].Alert;
            alert.AMLExecutionDate = new DateTime(2011, 2, 3);
            alert.AMLExecutionDateSpecified = true;
            alert.AMLResult = ValueEnum.Item1;
            alert.AMLResultSpecified = true;
            alert.BankAccountResult = ValueEnum.Item1;
            alert.BankAccountResultSpecified = true;
            alert.FCAIndividualUserIDNumber = ValueEnum.Item1;
            alert.FCAIndividualUserIDNumberSpecified = true;
            alert.FCAIndividualStatus = FCAUserStatusEnum.Item1;
            alert.FCAIndividualStatusSpecified = true;
            alert.FCABrokerType = BrokerEnum.Item1;
            alert.FCABrokerTypeSpecified = true;
            alert.FCAValidatedWithNetwork = ValueEnum.Item1;
            alert.FCAValidatedWithNetworkSpecified = true;
            alert.DeathIndicator = ValueEnum.Item2;
            alert.DeathIndicatorSpecified = true;
            alert.BankruptcyIndicator = ValueEnum.Item2;
            alert.BankruptcyIndicatorSpecified = true;
            alert.PartyDataMatchIndicator = ValueEnum.Item1;
            alert.PartyDataMatchIndicatorSpecified = true;

            // buyer conveyancer alert, for now mock this data
            input.Parties[2].Alert = new PartyAlertDetail();
            alert = input.Parties[2].Alert;
            alert.AMLExecutionDate = new DateTime(2012, 9, 1);
            alert.AMLExecutionDateSpecified = true;
            alert.AMLResult = ValueEnum.Item1;
            alert.AMLResultSpecified = true;
            alert.BankAccountResult = ValueEnum.Item1;
            alert.BankAccountResultSpecified = true;
            alert.DeathIndicator = ValueEnum.Item2;
            alert.DeathIndicatorSpecified = true;
            alert.BankruptcyIndicator = ValueEnum.Item2;
            alert.BankruptcyIndicatorSpecified = true;
            alert.PartyDataMatchIndicator = ValueEnum.Item1;
            alert.PartyDataMatchIndicatorSpecified = true;

            // seller alert, for now mock this data
            input.Parties[3].Alert = new PartyAlertDetail();
            alert = input.Parties[3].Alert;
            alert.AMLExecutionDate = new DateTime(2014, 11, 3);
            alert.AMLExecutionDateSpecified = true;
            alert.AMLResult = ValueEnum.Item1;
            alert.AMLResultSpecified = true;
            cardPaymentAVSResult = new CardPaymentAVSDetail();
            cardPaymentAVSResult.Date = new DateTime(2014, 08, 10);
            cardPaymentAVSResult.AVSCode = "AVS code";
            cardPaymentAVSResult.Value = ValueEnum.Item1;
            alert.CardPaymentAVSResults = new List<CardPaymentAVSDetail>();
            alert.CardPaymentAVSResults.Add(cardPaymentAVSResult);
            alert.BankAccountResult = ValueEnum.Item1;
            alert.BankAccountResultSpecified = true;
            alert.DeathIndicator = ValueEnum.Item2;
            alert.DeathIndicatorSpecified = true;
            alert.BankruptcyIndicator = ValueEnum.Item2;
            alert.BankruptcyIndicatorSpecified = true;
            alert.PartyDataMatchIndicator = ValueEnum.Item0;
            alert.PartyDataMatchIndicatorSpecified = true;

            // seller conveyancer alert, for now mock this data
            input.Parties[4].Alert = new PartyAlertDetail();
            alert = input.Parties[4].Alert;
            alert.AMLExecutionDate = new DateTime(2011, 2, 3);
            alert.AMLExecutionDateSpecified = true;
            alert.AMLResult = ValueEnum.Item1;
            alert.AMLResultSpecified = true;
            alert.BankAccountResult = ValueEnum.Item1;
            alert.BankAccountResultSpecified = true;
            alert.DeathIndicator = ValueEnum.Item2;
            alert.DeathIndicatorSpecified = true;
            alert.BankruptcyIndicator = ValueEnum.Item2;
            alert.BankruptcyIndicatorSpecified = true;
            alert.PartyDataMatchIndicator = ValueEnum.Item0;
            alert.PartyDataMatchIndicatorSpecified = true;

            // estate agent alert, for now mock this data
            input.Parties[5].Alert = new PartyAlertDetail();
            alert = input.Parties[5].Alert;
            alert.AMLExecutionDate = new DateTime(2012, 9, 1);
            alert.AMLExecutionDateSpecified = true;
            alert.AMLResult = ValueEnum.Item1;
            alert.AMLResultSpecified = true;
            alert.BankAccountResult = ValueEnum.Item1;
            alert.BankAccountResultSpecified = true;
            alert.DeathIndicator = ValueEnum.Item2;
            alert.DeathIndicatorSpecified = true;
            alert.BankruptcyIndicator = ValueEnum.Item2;
            alert.BankruptcyIndicatorSpecified = true;
            alert.PartyDataMatchIndicator = ValueEnum.Item0;
            alert.PartyDataMatchIndicatorSpecified = true;

            return input;
        }
    }
}
