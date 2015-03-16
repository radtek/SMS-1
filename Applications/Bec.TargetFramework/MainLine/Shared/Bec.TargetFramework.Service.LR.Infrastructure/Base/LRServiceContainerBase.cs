using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Service.LR.Interfaces.Interfaces;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;

namespace Bec.TargetFramework.Service.LR.Infrastructure.Base
{
    public class LRServiceContainerBase : ILRServiceContainer
    {
        protected LRServiceEngineBase m_ServiceEngineBase;
        protected LRSettings m_LRSettings;
        protected ILogger m_Logger;
        protected IDataLogic m_DataLogic;
        protected ConcurrentDictionary<string, object> m_ObjectDictionary;
        protected bool m_HasErrors = false;

        public ILRServiceEngine ServiceEngine { get; set; }

        public LRServiceContainerBase(ILogger logger, LRSettings settings,IDataLogic dLogic)
        {
            m_Logger = logger;
            m_LRSettings = settings;
            m_DataLogic = dLogic;
        }
    }
}
