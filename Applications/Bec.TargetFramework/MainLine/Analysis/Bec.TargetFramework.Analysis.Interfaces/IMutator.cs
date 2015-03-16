using System;
namespace Bec.TargetFramework.Analysis.Interfaces
{
    public interface IMutator
    {
        SearchDetail Mutate(SearchDetail input);
    }
}
