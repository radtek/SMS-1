using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Aop.Aspects
{
    using Bec.TargetFramework.Infrastructure.Log;

    using PostSharp.Aspects;
    using PostSharp.Extensibility;

    [Serializable]
    public class TraceMethodAspectAttribute : MethodInterceptionAspect
    {
        private static readonly Func<ILogger> Logger;

        public bool TraceEnabled { get; set; }

        static TraceMethodAspectAttribute()
        {
            if (!PostSharpEnvironment.IsPostSharpRunning)
            {
                Logger = AspectServiceLocator.GetService<ILogger>();
            }
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            if (TraceEnabled)
            {
                var sb = new StringBuilder();

                args.Arguments.ToList().ForEach(
                    it =>
                        { sb.Append(it.GetType().ToString() + ","); });

                Logger().Trace("Method Executed :" + args.Method.Name + " args:" + sb.ToString());
            }

            base.OnInvoke(args);
        }
    }
}
