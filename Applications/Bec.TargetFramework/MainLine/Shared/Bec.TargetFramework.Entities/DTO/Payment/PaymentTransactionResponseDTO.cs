using Bec.TargetFramework.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public partial class PaymentTransactionResponseDTO : PaymentTransactionDTO 
    {
        //[DataMember]
        //private PaymentStatusEnum _newPaymentStatus = PaymentStatus.Pending;

        [DataMember]
        public IList<string> Errors { get; set; }

        public PaymentTransactionResponseDTO()
        {
            this.Errors = new List<string>();
        }

        [DataMember]
        /// <summary>
        /// Gets or sets the authorization transaction identifier
        /// </summary>
        public string AuthorizationTransactionId { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets the authorization transaction code
        /// </summary>
        public string AuthorizationTransactionCode { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets the authorization transaction result
        /// </summary>
        public string AuthorizationTransactionResult { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets the capture transaction identifier
        /// </summary>
        public string CaptureTransactionId { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets the capture transaction result
        /// </summary>
        public string CaptureTransactionResult { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets the subscription transaction identifier
        /// </summary>
        public string SubscriptionTransactionId { get; set; }

        //[DataMember]
        ///// <summary>
        ///// Gets or sets a payment status after processing
        ///// </summary>
        //public PaymentStatus NewPaymentStatus
        //{
        //    get
        //    {
        //        return _newPaymentStatus;
        //    }
        //    set
        //    {
        //        _newPaymentStatus = value;
        //    }
        //}


        public bool Success
        {
            get { return (this.Errors.Count == 0); }
        }

        public void AddError(string error)
        {
            this.Errors.Add(error);
        }

        [DataMember]
        public bool Transaction_Error {get;set;}

        [DataMember]
        public string Error_Number { get; set; }

        [DataMember]
        public string Error_Description { get; set; }

        //[DataMember]
        //public PaymentApiErrorCode ApiError { get; set; }

        [DataMember]
       
        public bool Transaction_Approved {get;set;}
        [DataMember]
       
        public string EXact_Resp_Code {get;set;}
        [DataMember]

        //public PaymentEcommerceErrorCode EcommerceError {get;set;}
        //[DataMember]
        public string EXact_Message {get;set;}
        [DataMember]
       
        public string Bank_Resp_Code {get;set;}
        [DataMember]

        //public PaymentBankErrorCode BankError {get;set;}
        //[DataMember]
        public string Bank_Message {get;set;}
        [DataMember]
       
        public string Bank_Resp_Code_2 {get;set;}
        [DataMember]
       
        public string SequenceNo {get;set;}
        [DataMember]
       
        public string AVS {get;set;}
        [DataMember]
       
        public string CVV2 {get;set;}
        [DataMember]
       
        public string Retrieval_Ref_No {get;set;}
        [DataMember]
       
        public string CAVV_Response {get;set;}
        [DataMember]
       
        public string AmountRequested {get;set;}
        [DataMember]
       
        public string MerchantName {get;set;}
        [DataMember]
       
        public string MerchantAddress {get;set;}
        [DataMember]
       
        public string MerchantCity {get;set;}
        [DataMember]
       
        public string MerchantProvince {get;set;}
        [DataMember]
       
        public string MerchantCountry {get;set;}
        [DataMember]
       
        public string MerchantPostal {get;set;}
        [DataMember]
       
        public string MerchantURL {get;set;}
        [DataMember]
       
        public string CurrentBalance {get;set;}
        [DataMember]
       
        public string PreviousBalance {get;set;}
        [DataMember]
       
        public string CTR {get;set;}
       
    }
    [DataContract]
      public partial class PaymentTransactionDTO
    {
        
        public string ExactID {get;set;}
        [DataMember]
       
        public string Password {get;set;}
        [DataMember]
       
        public string Transaction_Type {get;set;}
        [DataMember]
       
        public string DollarAmount {get;set;}
        [DataMember]
       
        public string SurchargeAmount {get;set;}
        [DataMember]
       
        public string Card_Number {get;set;}
        [DataMember]
       
        public string Transaction_Tag {get;set;}
        [DataMember]
       
        public string Track1 {get;set;}
        [DataMember]
       
        public string Track2 {get;set;}
        [DataMember]
       
        public string PAN {get;set;}
        [DataMember]
       
        public string Authorization_Num {get;set;}
        [DataMember]
       
        public string Expiry_Date {get;set;}
        [DataMember]
       
        public string CardHoldersName {get;set;}
        [DataMember]
       
        public string VerificationStr1 {get;set;}
        [DataMember]
       
        public string VerificationStr2 {get;set;}
        [DataMember]
       
        public string CVD_Presence_Ind {get;set;}
        [DataMember]
       
        public string ZipCode {get;set;}
        [DataMember]
       
        public string Tax1Amount {get;set;}
        [DataMember]
       
        public string Tax1Number {get;set;}
        [DataMember]
       
        public string Tax2Amount {get;set;}
        [DataMember]
       
        public string Tax2Number {get;set;}
        [DataMember]
       
        public string Secure_AuthRequired {get;set;}
        [DataMember]
       
        public string Secure_AuthResult {get;set;}
        [DataMember]
       
        public string Ecommerce_Flag {get;set;}
        [DataMember]
       
        public string XID {get;set;}
        [DataMember]
       
        public string CAVV {get;set;}
        [DataMember]
       
        public string CAVV_Algorithm {get;set;}
        [DataMember]
       
        public string Reference_No {get;set;}
        [DataMember]
       
        public string Customer_Ref {get;set;}
        [DataMember]
       
        public string Reference_3 {get;set;}
        [DataMember]
       
        public string Language {get;set;}
        [DataMember]
       
        public string Client_IP {get;set;}
        [DataMember]
       
        public string Client_Email {get;set;}
        [DataMember]
       
        public string User_Name {get;set;}
        [DataMember]
       
        public string Currency {get;set;}
        [DataMember]
       
        public bool PartialRedemption {get;set;}
        [DataMember]
       
        public bool PartialRedemptionSpecified {get;set;}
        [DataMember]
       
        public string TransarmorToken {get;set;}
        [DataMember]
       
        public string CardType {get;set;}
        [DataMember]
       
        public string EAN {get;set;}
        [DataMember]
       
        public bool VirtualCard {get;set;}
        [DataMember]
       
        public bool VirtualCardSpecified {get;set;}
        [DataMember]
       
        public string CardCost {get;set;}
        [DataMember]
       
        public string FraudSuspected {get;set;}
    }
}
