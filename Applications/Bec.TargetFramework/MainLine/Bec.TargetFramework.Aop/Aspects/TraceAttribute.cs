using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Log;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Reflection;
using System.Text;

namespace Bec.TargetFramework.Aop.Aspects
{
    [Serializable]
    public sealed class TraceAttribute : OnMethodBoundaryAspect
    {
        private static readonly Func<ILogger> Logger;

        private static readonly bool TraceEnabled;

        private string methodName; 

        public bool TraceExceptionsOnly { get; set; }

        static TraceAttribute()
        {
            if (!PostSharpEnvironment.IsPostSharpRunning)
            {
                Logger = AspectServiceLocator.GetService<ILogger>();

                TraceEnabled = AspectServiceLocator.TraceEnabled;
            }
        }

        public TraceAttribute()
        {
            TraceExceptionsOnly = false;
        }

        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            this.methodName = method.DeclaringType.FullName + "." + method.Name;
        } 

        // Invoked at runtime before that target method is invoked. 
        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!TraceExceptionsOnly && TraceEnabled)
                Logger().Trace(string.Format("{0}: Enter", this.methodName));
        }

        public override void OnException(MethodExecutionArgs args)
        {
            if (TraceEnabled)
            {
                StringBuilder stringBuilder = new StringBuilder(1024);

                // Write the exit message. 
                stringBuilder.Append(this.methodName);
                stringBuilder.Append('(');

                // Write the current instance object, unless the method 
                // is static. 
                object instance = args.Instance;
                if (instance != null)
                {
                    stringBuilder.Append("this=");
                    stringBuilder.Append(instance);
                    if (args.Arguments.Count > 0)
                        stringBuilder.Append("; ");
                }

                // Write the list of all arguments. 
                for (int i = 0; i < args.Arguments.Count; i++)
                {
                    if (i > 0)
                        stringBuilder.Append(", ");
                    stringBuilder.Append(args.Arguments.GetArgument(i) ?? "null");
                }

                // Write the exception message. 
                stringBuilder.AppendFormat("): Exception ");
                stringBuilder.Append(args.Exception.GetType().Name);
                stringBuilder.Append(": ");
                stringBuilder.Append(args.Exception.FlattenException());

                Logger().Error(stringBuilder.ToString());
            }
        }

        // Invoked at runtime after the target method is invoked (in a finally block). 
        public override void OnExit(MethodExecutionArgs args)
        {
            if (!TraceExceptionsOnly && TraceEnabled)
                Logger().Trace(string.Format("{0}: Exit", this.methodName));
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            if (!TraceExceptionsOnly && TraceEnabled)
                Logger().Trace(string.Format("{0}: Success", this.methodName));
        } 
    }
}
