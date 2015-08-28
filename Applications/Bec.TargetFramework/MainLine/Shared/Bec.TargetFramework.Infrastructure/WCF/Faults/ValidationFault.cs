using Bec.TargetFramework.Infrastructure.WCF.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.WCF.Faults
{
    [DataContract]
    public class ValidationFault : Fault
    {
        public ValidationFault(string reasonText)
            : base(reasonText)
        {

        }
    }
}
