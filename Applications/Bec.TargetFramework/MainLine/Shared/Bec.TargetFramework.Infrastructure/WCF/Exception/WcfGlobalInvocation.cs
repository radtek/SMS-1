
namespace Bec.TargetFramework.Infrastructure.WCF.Exception
{
    public class WcfGlobalInvocation
    {
        /// <summary>
        /// 调用方法的实例
        /// </summary>
        public object Instance { set; get; }

        /// <summary>
        /// 调用的方法
        /// </summary>
        public string OperationMethod { set; get; }
        /// <summary>
        /// 执行时间
        /// </summary>
        public double ElaposedTime { set; get; }

        public WcfGlobalInvocation(object instance, string operationMethod, double elaposedTime)
        {
            this.Instance = instance;
            this.OperationMethod = operationMethod;
            this.ElaposedTime = elaposedTime;
        }
    }
}
