using System.Collections.Generic;


namespace Bec.TargetFramework.Business.Rules.Validation.Bank
{
    public interface IRuleMappingSource
    {
        IEnumerable<IModulusWeightMapping> GetModulusWeightMappings();
    }
}