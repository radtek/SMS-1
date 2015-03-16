using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bec.TargetFramework.Analysis.Interfaces
{
    public interface IAnalysisContainer
    {
        IAnalysisLogger Logger { get; set; }

        IAnalysisSetting Settings { get; set; }
    }
}
