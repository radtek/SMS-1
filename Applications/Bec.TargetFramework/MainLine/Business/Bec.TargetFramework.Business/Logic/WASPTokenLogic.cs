//Bec.TargetFramework.Entities
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.ExperianIDCheck;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Settings;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Helpers;
using ServiceStack.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using Bec.TargetFramework.Business.BWAService;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Security.Tokens;
using Microsoft.Web.Services3.Security;
using Microsoft.Web.Services3.Security.Cryptography;
using System.Text;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class WASPTokenLogic : BinarySecurityToken
    {
   /// <summary>
    /// The default number of minutes before token expiry occurs.
    /// </summary>

    private const int TokenExpiryInMinutes = 90;
    /// <summary>
    /// The WASP token key name.
    /// </summary>

    private const string TokenKeyName = "ExperianWASP";
    // The lifetime of the token is not known. This
    // lifetime allows the software to refresh the token
    // after a period of time defined within the constructor.

    private LifeTime lifeTime = new LifeTime(DateTime.Now.AddMinutes(TokenExpiryInMinutes));
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    public WASPTokenLogic(string token)
        : base(TokenKeyName)
    {
        // Store the token data
        RawData = (new UTF8Encoding()).GetBytes(token);
    }

    /// <summary>
    /// Retrieves the UTF8 encoded version of the WASP token.
    /// </summary>
    public override string ToString()
    {
        return UTF8Encoding.ASCII.GetString(RawData);
    }

    #region "SecurityToken implementation"

    public override bool IsCurrent
    {
        get { return lifeTime.IsCurrent; }
    }
    public override KeyAlgorithm Key
    {
        get { return null; }
    }
    public override bool SupportsDigitalSignature
    {
        get { return false; }
    }
    public override bool SupportsDataEncryption
    {
        get { return false; }
    }
    public override bool Equals(SecurityToken token)
    {
        return (token != null && token is WASPTokenLogic);
    }
    public override int GetHashCode()
    {
        return (RawData != null) ? RawData.GetHashCode() : 0;
    }
    public override bool IsExpired
    {
        get { return lifeTime.IsExpired; }
    }

    #endregion


 
    }
}