using Bec.TargetFramework.Analysis.Interfaces;
using System.Collections.Generic;

namespace Bec.TargetFramework.Analysis.Test
{
    public class MockCollator : Collator
    {
        public override List<SearchDetail> Collate(List<SearchDetail> inputs)
        {
            // For now, we just return the inputs for mock testing purposes
            return inputs;
        }
    }
}
