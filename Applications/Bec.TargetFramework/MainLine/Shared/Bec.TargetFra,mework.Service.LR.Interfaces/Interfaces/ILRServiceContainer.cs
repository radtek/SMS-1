using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Service.LR.Interfaces.Interfaces
{
    public interface ILRServiceContainer
    {
        ILRServiceEngine ServiceEngine { get; set; }
    }
}
