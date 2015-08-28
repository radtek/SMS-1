using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Test.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Bec.TargetFramework.Infrastructure.Test.Base
{
    public class UnitTestBase : IUnitTest
    {
        public const string TESTINGPATH = @"C:\Testing";

        [TestCleanup] 
        public virtual void TestCleanUp()
        {
        }

        [TestInitialize]
        public virtual void TestInitialise()
        {
            if (!Directory.Exists(TESTINGPATH))
                Directory.CreateDirectory(TESTINGPATH);
        }
    }
}
