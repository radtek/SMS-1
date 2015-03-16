using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Framework.Configuration;
using System;
using System.Runtime.CompilerServices;

namespace Bec.TargetFramework.Entities.Settings
{
	public class PaymentSettings : ISettings
	{
		public decimal AdditionalFee
		{
			get;
			set;
		}

		public bool AdditionalFeePercentage
		{
			get;
			set;
		}

		public bool EnableCardSaving
		{
			get;
			set;
		}

		public bool EnableRecurringPayments
		{
			get;
			set;
		}

        public string PaymentURL
        {
            get;
            set;
        }

		public string GatewayID
		{
			get;
			set;
		}

		public string HMAC
		{
			get;
			set;
		}

		public string KeyID
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

        //public PaymentTransactionMode TransactionMode
        //{
        //    get;
        //    set;
        //}

        public string KeySerialNumber
        {
            get;
            set;
        }

		public bool UseSandbox
		{
			get;
			set;
		}
	}
}