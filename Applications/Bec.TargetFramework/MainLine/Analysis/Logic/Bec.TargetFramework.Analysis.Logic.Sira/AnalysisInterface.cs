using Bec.TargetFramework.Analysis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bec.TargetFramework.Rules.Sira
{
    public class AnalysisInterface : IAnalysisInterface
    {
        public IAnalysisContainer Container
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

        public IAnalysisBatchScheduler BatchScheduler
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

        public IAnalysisBatchReceiver BatchSearcher
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

        public IAnalysisEngine Engine
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

        public IAnalysisBatchProcessor BatchProcessor
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

        public IAnalysisBatchCollator BatchCollator
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

        public IAnalysisBatchSender BatchSender
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
