
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using BrockAllen.MembershipReboot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bec.TargetFramework.Business.Services
{
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Infrastructure.WCF.Exception;

     public class AddressLogicController : AddressLogic, IAddressLogic, IBusinessLogicService
    {
         public AddressLogicController(ILogger logger, ICacheProvider cacheProvider) 
            : base(logger, cacheProvider)
        {
        }

    }
}
