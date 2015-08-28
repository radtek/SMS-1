using System.Linq;
using System.Security.Claims;

namespace Bec.TargetFramework.Security
{
    public class ClaimsHelper
    {
        public static bool UserHasClaim(string operation, string resource)
        {
            return ClaimsPrincipal.Current.Claims.Any(item => item.Type.Equals(resource) && item.Value.Equals(operation));
        }
    }
}
