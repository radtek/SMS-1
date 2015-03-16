using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Serilog;

namespace Bec.TargetFramework.Workflow.Test
{
    class Program
    {
        static void Main(string[] args)
        {


            //using (
            //    var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
            //        new SerilogLogger(), false))
            //{


            //    var repos = scope.GetGenericRepository<Bec.TargetFramework.Data.UserAccount, Guid>();
            //    var exists =
            //        repos.Exists(
            //            u =>
            //                u.Email.ToLower() == "test@test.test" && u.IsAccountClosed == false &&
            //                u.IsActive == true);


            //}

            //long reposTotal = 0;
            //long directTotal = 0;

            //for (int i = 0; i < 50; i++)
            //{
            //    Task.Factory.StartNew(() =>
            //    {
                    
            //         Stopwatch watch = new Stopwatch();

            //    watch.Start();


            //    bool exists = false;

            //    using (
            //        var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
            //            new SerilogLogger(), false))
            //    {


            //        var repos = scope.GetGenericRepository<Bec.TargetFramework.Data.UserAccount, Guid>();
            //        exists =
            //            repos.Exists(
            //                u =>
            //                    u.Email.ToLower() == "test@test.test" && u.IsAccountClosed == false &&
            //                    u.IsActive == true);
                                

            //    }

            //    watch.Stop();

            //    Console.WriteLine("repos:" +  watch.ElapsedMilliseconds);

            //        reposTotal += watch.ElapsedMilliseconds;

            //    watch = new Stopwatch();       
            //    watch.Start();


            //    exists = false;

            //    using (
            //        var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
            //            new SerilogLogger(), false))
            //    {
            //        exists = scope.DbContext.UserAccounts.Any(u =>
            //            u.Email.ToLower() == "test@test.test" && u.IsAccountClosed == false &&
            //                    u.IsActive == true);
            //    }

            //    watch.Stop();

            //    Console.WriteLine("direct:" + watch.ElapsedMilliseconds);

            //    directTotal += watch.ElapsedMilliseconds;

            //    }).Wait();
            //}

            
            //Console.WriteLine(reposTotal / 50 + ":" + directTotal / 50);

          // ShoppingCartTest test = new ShoppingCartTest();
            ExperianTest test = new ExperianTest();
           // var test = new ExperianTest();
           // VirusScanningTest vs = new VirusScanningTest();
           // NotificationTest test = new NotificationTest();
            Console.WriteLine("All Finished");
            Console.ReadLine();
        }

        
    }

}
