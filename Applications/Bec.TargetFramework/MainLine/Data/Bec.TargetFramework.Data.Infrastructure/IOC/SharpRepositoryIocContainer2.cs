namespace Bec.TargetFramework.Data.Infrastructure.Ioc
{
    public static class SharpRepositoryIocContainer
    {
        static SharpRepositoryIocContainer()
        {
            Current = null;
        }

        public static ISharpRepositoryIocContainer Current { get; private set; }

        public static void SetIocContainer(ISharpRepositoryIocContainer container)
        {
            Current = container;
        }
    }
}