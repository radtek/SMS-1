using Bec.TargetFramework.Infrastructure.Log;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Linq;
using System.Text;

namespace Bec.TargetFramework.Aop.Aspects
{
    [Serializable]
    public class RetryOnExceptionAttribute : MethodInterceptionAspect
    {
        private static readonly Func<ILogger> Logger;

        public int MaxRetries { get; set; }

        static RetryOnExceptionAttribute()
        {
            if (!PostSharpEnvironment.IsPostSharpRunning)
            {
                Logger = AspectServiceLocator.GetService<ILogger>();
            }
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            int retriesCounter = 0;

            while (true)
            {
                try
                {
                    base.OnInvoke(args);
                    return;
                }
                catch (Exception ex)
                {
                    retriesCounter++;
                    if (retriesCounter > this.MaxRetries) throw;

                    var sb = new StringBuilder();

                    args.Arguments.ToList().ForEach(
                        it =>
                        { sb.Append(it.GetType().ToString() + ","); });

                    Logger().Trace("Method Executed :" + args.Method.Name + " retries:" + retriesCounter +  " args:" + sb.ToString());

                    // log the error
                    Logger().Error(ex);
                }
            }
        }
    }
}
