using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Service.LR.Interfaces.Interfaces;

namespace Bec.TargetFramework.Service.LR.Infrastructure.Base
{
    public class LRServiceInterfaceBase : ILRServiceInterface
    {
        public string ServiceURL { get; set; }
    }
}
