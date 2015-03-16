using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;

namespace Bec.TargetFramework.Entities.Injections
{
    public class IgnoreProps : ConventionInjection
    {
        private readonly string[] _ignores;

        public IgnoreProps()
        {
        }

        public IgnoreProps(params string[] ignores)
        {
            _ignores = ignores;
        }

        protected override bool Match(ConventionInfo c)
        {
            return (_ignores == null || !_ignores.Contains(c.SourceProp.Name)) &&
                   c.SourceProp.Name == c.TargetProp.Name
                   && c.SourceProp.Type == c.TargetProp.Type;
        }
    }
}
