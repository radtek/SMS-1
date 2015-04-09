﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Interfaces
{
    public interface IClientBase : IDisposable
    {
        HttpClient HttpClient { get; }
    }


}
