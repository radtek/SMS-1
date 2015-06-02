
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Messages.Events
{
    public class MutateSearchEvent : IEvent
    {
        public Guid TransferInterfaceProcessLogInputID { get; set; }
    }
}
