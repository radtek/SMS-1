using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.WCF.Exception
{
    [DataContract]
    public abstract class Fault
    {
        internal FaultReason Reason { get; private set; }

        protected Fault(string reasonText)
        {
            Reason = new FaultReason(new FaultReasonText(reasonText, CultureInfo.CurrentUICulture));
        }

        public override string ToString()
        {
            return Reason.ToString();
        }

        public static void Throw<TFault>(TFault fault) where TFault : Fault
        {
            throw new FaultException<TFault>(fault, fault.Reason);
        }
    }
}
