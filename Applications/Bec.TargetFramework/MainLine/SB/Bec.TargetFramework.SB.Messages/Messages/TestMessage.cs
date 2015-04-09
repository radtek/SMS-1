using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Bec.TargetFramework.SB.Messages.Messages
{
    public class TestMessage : IMessage
    {
        public string Message = "This is a test";
    }
}
