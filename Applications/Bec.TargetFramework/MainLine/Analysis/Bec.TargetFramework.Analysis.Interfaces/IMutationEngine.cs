using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Interfaces
{
    public interface IMutationEngine
    {
        int MutatorCount { get; }
        void Add(IMutator mutator);
        List<SearchDetail> Mutate(List<SearchDetail> inputs);
        void Apply(IMutationScript script);
    }
}
