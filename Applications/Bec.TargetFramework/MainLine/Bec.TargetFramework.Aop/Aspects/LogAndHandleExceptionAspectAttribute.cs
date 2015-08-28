using Bec.TargetFramework.Infrastructure.Log;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;

namespace Bec.TargetFramework.Aop.Aspects
{
    [Serializable]
    public class LogExceptionAspectAttribute : MethodInterceptionAspect
    {
        private static readonly Func<ILogger> Logger;

        static LogExceptionAspectAttribute()
        {
            if (!PostSharpEnvironment.IsPostSharpRunning)
            {
                Logger = AspectServiceLocator.GetService<ILogger>();
            }
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            try
            {
                base.OnInvoke(args);
            }
            catch (Exception ex)
            {
                Logger().Error(ex);

                throw;
            }
        }
    }
}
