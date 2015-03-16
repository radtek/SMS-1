using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Interfaces
{
    public interface ISender
    {
        bool Send(List<SearchDetail> inputs);
        string OutputPath { get; set; }
    }
}
