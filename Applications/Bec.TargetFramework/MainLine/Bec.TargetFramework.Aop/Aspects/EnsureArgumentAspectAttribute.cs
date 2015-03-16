using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;

namespace Bec.TargetFramework.Aop.Aspects
{
    using Bec.TargetFramework.Infrastructure.Log;

    using PostSharp.Aspects;
    using PostSharp.Extensibility;

    [Serializable]
    public class EnsureArgumentAspectAttribute : MethodInterceptionAspect
    {
        static EnsureArgumentAspectAttribute()
        {

        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            if (args != null && args.Arguments.Count > 0)
            {
                args.Arguments.ToList().ForEach(item =>
                {
                    Ensure.That(item).IsNotNull();
                });
            }

            base.OnInvoke(args);
        }
    }
}
