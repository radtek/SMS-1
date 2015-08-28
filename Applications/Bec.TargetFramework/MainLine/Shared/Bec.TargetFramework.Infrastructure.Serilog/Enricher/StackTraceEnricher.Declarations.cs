using System;
using Serilog.Core;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public partial class StackTraceEnricher : ILogEventEnricher
    {
        public const string UnknownPropertyValue = "?";

        [Flags]
        public enum Properties
        {
            None                = 0,
            AssemblyName        = 1,
            ClassName           = 2,
            MethodName          = 4,
            ILOffset            = 8,
            NativeOffset        = 16,
            FileName            = 32,
            LineNumber          = 64,
            ColumnNumber        = 128,
            StackTrace          = 256,

            Caller = ClassName | MethodName,
            Source = FileName | LineNumber | ColumnNumber,
            CallerAndSource = Caller | Source,

            Default = Caller
        }

        public static class PropertyNames
        {
            public const string StackTraceDepth = "StackTraceDepth";
            public const string AssemblyName = "AssemblyName";
            public const string AssemblyFullName = "AssemblyFullName";
            public const string ClassName = "ClassName";
            public const string MethodName = "MethodName";
            public const string ILOffset = "ILOffset";
            public const string NativeOffset = "NativeOffset";
            public const string FileName = "FileName";
            public const string LineNumber = "LineNumber";
            public const string ColumnNumber = "ColumnNumber";
            public const string StackTrace = "StackTrace";
            public const string StackTraceDetail = "StackTraceDetail";
        }
    }
}