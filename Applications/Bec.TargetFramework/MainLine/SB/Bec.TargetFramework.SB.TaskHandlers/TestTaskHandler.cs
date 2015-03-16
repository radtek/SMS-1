using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Log;
using NServiceBus;

namespace Bec.TargetFramework.SB.TaskHandlers
{
    public class TestTaskHandler : IHandleMessages<TestTaskHandlerMessage>
    {
        public IBus Bus { get; set; }

        private ILogger Logger { get; set; }

        public TestTaskHandler(ILogger logger)
        {
            Logger = logger;
        }

        public void Handle(TestTaskHandlerMessage message)
        {
        }
    }

    public class TestTaskHandlerMessage : IEvent
    {
        
    }
}
