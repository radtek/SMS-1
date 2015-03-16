using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Interfaces
{
    public interface ICollator
    {
        List<SearchDetail> Collate(List<SearchDetail> inputs);
    }
}
