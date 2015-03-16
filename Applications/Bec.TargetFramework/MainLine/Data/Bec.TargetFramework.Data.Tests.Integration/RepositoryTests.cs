using System;
using Bec.TargetFramework.Infrastructure.NLog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Data.Infrastructure.EfRepository;
using Bec.TargetFramework.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Bec.TargetFramework.Data.Repositories;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.Data.Tests.Integration
{
    [TestClass]
    public class RepositoryTests
    {
        private TestContext m_TestContextInstance;
        //private static Container m_Container;

        public TestContext TestContext
        {
            get
            {
                return m_TestContextInstance;
            }
            set
            {
                m_TestContextInstance = value;
            }
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // register EF log interceptor
            System.Data.Entity.Infrastructure.Interception.DbInterception.Add(new LoggerCommandInterceptor(new LogLogger(),true));

            ////m_Container = new Container();
            //m_Container.Register<ILogger>(() => new NLogLogger(), Lifestyle.Transient); 
        }

        [TestMethod]
        public void UnitOfWorkTests()
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing))
            {
                // check db context
                Assert.IsNotNull(scope.DbContext);

                // create user account repository
                var userAccountRepos = scope.GetGenericRepository<UserAccount,Guid>();

                // test dbcontext not null
                Assert.IsFalse(userAccountRepos.Exists(Guid.NewGuid()));

                // create custom repository
                var userAccountLoginSessionRepository = scope.GetCustomRepository<UserAccountLoginSessionRepository>();

                // check repos is not null
                Assert.IsNotNull(userAccountRepos);

                // test dbcontext
                Assert.IsFalse(userAccountLoginSessionRepository.Exists(Guid.NewGuid(),string.Empty));


                // create new item with no guid
                UserAccountLoginSession uas = new UserAccountLoginSession();
                
                userAccountLoginSessionRepository.Add(uas);

                // save - expect errors
                bool result = scope.Save();

            };
        }

        [ClassCleanup]
        public static void Clearup()
        {
        }
    }
}
