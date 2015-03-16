using Bec.TargetFramework.Analysis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis
{
    public class Collator : ICollator
    {
        public virtual List<SearchDetail> Collate(List<SearchDetail> inputs)
        {
            // TODO: Filter out any mutated results that should not be sent to the outside system

            // TODO: Store the filtered results

            // return the results
            return inputs;
        }
    }
}
