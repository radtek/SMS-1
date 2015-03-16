using Bec.TargetFramework.Analysis.Interfaces;
using System;

namespace Bec.TargetFramework.Analysis.Test
{
    public class MockMutator_ClearUnnecessaryData : IMutator
    {
        public SearchDetail Mutate(SearchDetail input)
        {
            // The interaction 2 schema does not expect any details in the transaction node. So we are clearing it here
            input.Transaction = null;

            return input;
        }
    }
}
