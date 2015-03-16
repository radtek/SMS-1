using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bec.TargetFramework.Analysis.Interfaces
{
    public interface IAnalysisInterface
    {
        IAnalysisContainer Container { get; set; }
            
        IAnalysisBatchScheduler BatchScheduler { get; set; }
        
        IAnalysisBatchReceiver BatchSearcher { get; set; }
        
        IAnalysisEngine Engine { get; set; }
        
        IAnalysisBatchProcessor BatchProcessor { get; set; }
        
        IAnalysisBatchCollator BatchCollator { get; set; }
        
        IAnalysisBatchSender BatchSender { get; set; }
    }
}
