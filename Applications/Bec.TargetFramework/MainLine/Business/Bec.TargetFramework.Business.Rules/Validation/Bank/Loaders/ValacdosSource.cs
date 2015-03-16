
using Bec.TargetFramework.Business.Rules.Properties;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Bec.TargetFramework.Business.Rules.Validation.Bank
{
    public class ValacdosSource : IRuleMappingSource
    {
        private static readonly string[] Rows = Resources.valacdos.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

        public IEnumerable<IModulusWeightMapping> GetModulusWeightMappings()
        {
            return Rows.Where(row => row.Length > 0)
                .Select(row => new ModulusWeightMapping(row));
        } 
    }
}