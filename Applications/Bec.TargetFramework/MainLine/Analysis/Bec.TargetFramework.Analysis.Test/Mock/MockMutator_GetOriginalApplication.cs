using Bec.TargetFramework.Analysis.Interfaces;
using System;

namespace Bec.TargetFramework.Analysis.Test
{
    public class MockMutator_GetOriginalApplication : IMutator
    {
        public SearchDetail Mutate(SearchDetail input)
        {
            input.LastUpdated = new DateTime(2015, 2, 4);
            input.LastUpdatedSpecified = true;
            return input;
        }
    }
}
