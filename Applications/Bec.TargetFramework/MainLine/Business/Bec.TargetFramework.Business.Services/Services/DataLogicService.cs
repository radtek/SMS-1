﻿using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Framework.Configuration;
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

    [WcfGlobalExceptionOperationBehaviorAttribute(typeof(WcfGlobalErrorHandler))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DataLogicService : DataLogic, IDataLogic, IBusinessLogicService
    {
        public DataLogicService(ILogger logger, ICacheProvider cacheProvider, CommonSettings settings)
            : base(logger, cacheProvider, settings)
        {
        }
    }
}
