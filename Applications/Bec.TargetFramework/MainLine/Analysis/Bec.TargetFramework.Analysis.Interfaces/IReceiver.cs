using System;
using System.Collections.Generic;
namespace Bec.TargetFramework.Analysis.Interfaces
{
    public interface IReceiver
    {
        List<SearchDetail> GetApplicationsThatMatchASearch();
    }
}
