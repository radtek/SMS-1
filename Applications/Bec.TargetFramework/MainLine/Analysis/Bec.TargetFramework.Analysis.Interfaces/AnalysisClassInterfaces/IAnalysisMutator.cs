using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bec.TargetFramework.Analysis.Interfaces
{
    public interface IAnalysisMutator
    {
        List<IAnalysisInput> Inputs { get; set; }
    }
}
