using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Bec.TargetFramework.SB.Infrastructure
{
    public class HookMessageMutators
    {

        public static void InitialiseMessageMutators()
        {
            // register outgoing mutator
            Configure.Instance.Configurer.ConfigureComponent<IncomingOutgoingMessageMutator>(DependencyLifecycle.InstancePerCall);
        }
    }
}
