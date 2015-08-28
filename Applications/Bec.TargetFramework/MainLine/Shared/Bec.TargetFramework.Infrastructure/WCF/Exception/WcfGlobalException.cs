
namespace Bec.TargetFramework.Infrastructure.WCF.Exception
{
    public class WcfGlobalException
    {
        /// <summary>
        /// 调用方法的实例
        /// </summary>
        public object Instance { set; get; }
        /// <summary>
        /// 调用的方法名称
        /// </summary>
        public string OperationMethod { set; get; }
        /// <summary>
        /// 异常信息
        /// </summary>
        public string Message { set; get; }
        /// <summary>
        /// 异常trace信息
        /// </summary>
        public string StackTrace { set; get; }

        public WcfGlobalException(string message,string trace,object instance,string operationName)
        {
            this.Instance = instance;
            this.OperationMethod = operationName;
            this.Message = message;
            this.StackTrace = trace;
        }
    }
}
