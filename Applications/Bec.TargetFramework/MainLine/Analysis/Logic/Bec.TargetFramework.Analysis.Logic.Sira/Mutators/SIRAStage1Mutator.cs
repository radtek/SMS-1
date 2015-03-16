using Bec.TargetFramework.Analysis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Logic.Sira
{
    public class SIRAStage1Mutator : IAnalysisMutator
    {
        public IAnalysisInterface Mutate(IAnalysisInterface context)
        {
            return context;
        }

        public List<IAnalysisInput> Inputs
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
