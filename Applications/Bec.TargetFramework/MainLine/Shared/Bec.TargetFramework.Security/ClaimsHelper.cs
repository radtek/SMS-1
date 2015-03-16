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
using Bec.TargetFramework.Business.Infrastructure.Interfaces;

namespace Bec.TargetFramework.Security
{
    public class ClaimsHelper
    {
        public static List<Claim> GenerateUserClaims(Guid userId,Guid organisationID)
        {
            var claims = new List<Claim>();

            var channel = new ChannelFactory<IUserLogic>(Bec.TargetFramework.Infrastructure.WCF.NetTcpBindingConfiguration.GetDefaultNetTcpBinding(), System.Configuration.ConfigurationManager.AppSettings["BusinessServiceBaseURL"] + "UserLogicService");
                var proxy = channel.CreateChannel();

                var userClaims = proxy.GetUserClaims(userId, organisationID);

                // add claims to user profile
                userClaims.ForEach(item =>
                {
                    string claim = string.Empty;

                    if (item.Type.StartsWith("R_"))
                        claim = ClaimsAuthorization.ResourceType + item.Type.Replace("R_", "");
                    else if (item.Type.StartsWith("S_"))
                        claim = ClaimsAuthorization.StateType + item.Type.Replace("S_", "");
                    claims.Add(new Claim(claim,item.Value));
                });

                ((ICommunicationObject)proxy).Close();

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
