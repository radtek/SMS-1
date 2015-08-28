using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.Enums
{
    public class PaymentFraudErrorCode
    {
        public const string AddresscheckfailedFraudsuspected="F1";
        public const string CardCheckNumbercheckfailedFraudsuspected="F2";
        public const string CountryCheckFailedFraudSuspected	="F3";
        public const string CustomerReferenceCheckFailedFraudSuspected="	F4";
        public const string EmailAddresscheckfailedFraudsuspected="F5";
        public const string IPAddresscheckfailedFraudsuspected = "	F6";

    }
}
