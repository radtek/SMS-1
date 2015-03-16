using Bec.TargetFramework.Analysis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Test
{
    public class MockMutationEngine : IMutationEngine, IDisposable
    {
        private List<IMutator> m_Mutators;

        public MockMutationEngine()
        {
            m_Mutators = new List<IMutator>();
        }

        public int MutatorCount
        {
            get { return m_Mutators.Count; }
        }

        public void Add(IMutator mutator)
        {
            m_Mutators.Add(mutator);
        }

        public void Dispose()
        {
            m_Mutators = null;
        }

        public List<SearchDetail> Mutate(List<SearchDetail> inputs)
        {
            var results = new List<SearchDetail>();
            inputs.ForEach(a => results.Add(a));
            foreach (var mutator in m_Mutators)
            {
                inputs.ForEach(a => mutator.Mutate(a));
            }
            return results;
        }

        public void Apply(IMutationScript script)
        {
            script.ApplyTo(this);
        }
    }
}
