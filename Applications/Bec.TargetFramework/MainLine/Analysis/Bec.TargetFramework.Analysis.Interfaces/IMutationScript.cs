using System;
namespace Bec.TargetFramework.Analysis.Interfaces
{
    public interface IMutationScript
    {
        void ApplyTo(IMutationEngine mutationEngine);
    }
}
