using System;

namespace Bec.TargetFramework.Entities.Enums
{
	public class PaymentTransactionType
	{
		public const string Purchase = "00";

		public const string PreAuth = "01";

		public const string PreAuthCompletion = "02";

		public const string Refund = "04";

		public const string Void = "13";

		public const string TaggedPreAuthCompletion = "32";

		public const string TaggedVoid = "33";

		public const string TaggedRefund = "34";

        public PaymentTransactionType()
		{
		}
	}

    public enum PaymentChargeTypeEnum : int
    {
        Credit=0,

        /// <remarks/>
        ForceTicket=1,

        /// <remarks/>
        PostAuth=2,

        /// <remarks/>
        PreAuth=3,

        /// <remarks/>
        Return=4,

        /// <remarks/>
        Sale=5,

        /// <remarks/>
        Void=6
    }

       
}