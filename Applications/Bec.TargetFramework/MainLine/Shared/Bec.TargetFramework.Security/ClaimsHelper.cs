using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using BrockAllen.MembershipReboot;
using System.ServiceModel;

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
