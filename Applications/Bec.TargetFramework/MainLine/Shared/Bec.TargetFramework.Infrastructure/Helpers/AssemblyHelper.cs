using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.Helpers
{
    public class AssemblyHelper
    {
        public static List<Assembly> GetAllValidAssembliesForLoading()
        {
            List<Assembly> assemblies = new List<Assembly>();

            assemblies.AddRange(AppDomain.CurrentDomain.GetAssemblies().Where(p=> !p.FullName.StartsWith("ServiceStack") && !p.FullName.StartsWith("Think") ).ToArray());

            return assemblies;
        }
    }
}
