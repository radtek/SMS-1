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

namespace Bec.TargetFramework.Security
{
    public class ClaimsHelper
    {
        public static List<Claim> GenerateUserClaims(Guid userId)
        {
            var claims = new List<Claim>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading))
            {
                var userClaims = scope.DbContext.up_GetUserClaims(userId).ToList();

                // add claims to user profile
                claims.ForEach(item =>
                {
                    string claim = string.Empty;

                    if (item.Type.StartsWith("R_"))
                        claim = ClaimsAuthorization.ResourceType + item.Type.Replace("R_", "");
                    else if (item.Type.StartsWith("S_"))
                        claim = ClaimsAuthorization.StateType + item.Type.Replace("S_", "");
                    claims.Add(new Claim(claim,item.Value));
                });
            }

            return claims;
        }

        public static bool UserHasClaim(string operation, string resource)
        {
            return
                ClaimsPrincipal.Current.Claims.Any(item => item.Type.Equals(ClaimsAuthorization.ResourceType + resource)
                                                           && item.Value.Equals(operation));
        }

        //public static bool UserHasState(string stateN)
        //{
        //    return
        //        ClaimsPrincipal.Current.Claims.Any(item => item.Type.Equals(ClaimsAuthorization.ResourceType + resource)
        //                                                   && item.Value.Equals(operation));
        //}
    }
}
