namespace Bec.TargetFramework.Framework.Infrastructure
{
    public interface IStartupTask 
    {
        void Execute();

        int Order { get; }
    }
}
