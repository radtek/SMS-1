using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.Workflow.Providers
{
    public class ProviderBase
    {
        private ILogger m_Logger;

        public ProviderBase(ILogger logger)
        {
            m_Logger = logger;
        }

        public ILogger Logger
        {
            get { return m_Logger; }
            set { m_Logger = value; }
        }
    }
}
