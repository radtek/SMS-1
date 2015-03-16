using Bec.TargetFramework.Analysis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Test
{
    public class MockMutationScript : IMutationScript
    {
        public void ApplyTo(IMutationEngine mutationEngine)
        {
            mutationEngine.Add(new MockMutator_GetOriginalApplication());
            mutationEngine.Add(new MockMutator_ClearUnnecessaryData());
            mutationEngine.Add(new MockMutator_AddOtherParties());
            mutationEngine.Add(new MockMutator_AddPartyAlerts());
            mutationEngine.Add(new MockMutator_AddApplicationAlerts());
        }
    }
}
