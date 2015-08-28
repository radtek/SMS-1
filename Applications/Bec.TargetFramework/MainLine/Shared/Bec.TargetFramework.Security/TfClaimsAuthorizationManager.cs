using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Security
{
    public class TfClaimsAuthorizationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            Trace.WriteLine("\n\nClaimsAuthorizationManager\n_______________________\n");

            Trace.WriteLine("\nAction:");
            Trace.WriteLine("  " + context.Action.First().Value);

            Trace.WriteLine("\nResources:");
            foreach (var resource in context.Resource)
            {
                Trace.WriteLine("  " + resource.Value);
            }

            Trace.WriteLine("\nClaims:");
            foreach (var claim in context.Principal.Claims)
            {
                Trace.WriteLine("  " + claim.Value);
            }

            // check for operation/resource combo
            var exists = context.Principal.Claims.Any(item => item.Type.Equals(context.Resource.First().Value) && item.Value.Equals(context.Action.First().Value));

            return exists;
        }
    }
}
