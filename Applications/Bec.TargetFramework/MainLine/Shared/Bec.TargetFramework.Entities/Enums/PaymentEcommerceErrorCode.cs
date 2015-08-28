using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum PaymentEcommerceErrorCode
    {
        TransactionNormal = 0,
        CVV2CIDCVC2Datanotverified = 8,
        InvalidCreditCardNumber = 22,
        InvalidExpiryDate = 25,
        InvalidAmount = 26,
        InvalidCardHolder = 27,
        InvalidAuthorizationNo = 28,
        InvalidVerificationString = 31,
        InvalidTransactionCode = 32,
        InvalidReferenceNo = 57,
        InvalidAVSStringThelengthoftheAVSStringhasexceededthemax40characters = 58,
        InvalidCustomerReferenceNumber = 60,
        InvalidDuplicate = 63,
        InvalidRefund = 64,
        RestrictedCardNumber = 68,
        Datawithinthetransactionisincorrect = 72,
        Invalidauthorizationnumberenteredonapreauthcompletion = 93,
        InvalidSequenceNo = 11,
        MessageTimedoutatHost = 12,
        BCEFunctionError = 21,
        InvalidResponsefromFirstData = 23,
        InvalidDateFromHost = 30,
        InvalidTransactionDescription = 10,
        InvalidGatewayID = 14,
        InvalidTransactionNumber = 15,
        ConnectionInactive = 16,
        UnmatchedTransaction = 17,
        InvalidReversalResponse = 18,
        UnabletoSendSocketTransaction = 19,
        UnabletoWriteTransactiontoFile = 20,
        UnabletoVoidTransaction = 24,
        PaymentTypeNotSupportedByMerchant = 37,
        UnabletoConnect = 40,
        UnabletoSendLogon = 41,
        UnabletoSendTrans = 42,
        InvalidLogon = 43,
        TerminalnotActivated = 52,
        TerminalGatewayMismatch = 53,
        InvalidProcessingCenter = 54,
        NoProcessorsAvailable = 55,
        DatabaseUnavailable = 56,
        SocketError = 61,
        HostnotReady = 62,
        AddressnotVerified = 44,
        TransactionPlacedinQueue = 70,
        TransactionReceivedfromBank = 73,
        ReversalPending = 76,
        ReversalComplete = 77,
        ReversalSenttoBank = 79,
    }
}
