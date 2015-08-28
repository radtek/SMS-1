using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.Test.Interfaces
{
    public interface IUnitTest
    {
        void TestCleanUp();
        void TestInitialise();
    }
}
