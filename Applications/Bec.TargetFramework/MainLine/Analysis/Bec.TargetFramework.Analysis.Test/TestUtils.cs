using Bec.TargetFramework.Analysis.Interfaces;
using Bec.TargetFramework.Data.Analysis;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Test.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.XmlDiffPatch;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bec.TargetFramework.Analysis.Test
{
    public static class TestUtils
    {
        public static void DeletePreviousTestMortgageApplications()
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkAnalysisEntities>(UnitOfWorkScopePurpose.Writing, new NullLogger(), true))
            {
                // Get the repos
                var AnalysisInputMortgageApplicationRepos = scope.GetGenericRepository<AnalysisInputMortgageApplication, Guid>();
                var AnalysisInputMortgageApplicationDetailRepos = scope.GetGenericRepository<AnalysisInputMortgageApplicationDetail, Guid>();

                // Find the applications to delete
                var list = AnalysisInputMortgageApplicationDetailRepos.GetAll().ToList();

                list.ForEach(it =>
                {
                    it.IsDeleted = true;
                    it.IsActive = false;
                    AnalysisInputMortgageApplicationDetailRepos.Update(it);
                });

                var list2 = AnalysisInputMortgageApplicationRepos.GetAll().ToList();

                list2.ForEach(it =>
                {
                    it.IsDeleted = true;
                    it.IsActive = false;
                    AnalysisInputMortgageApplicationRepos.Update(it);
                });

                scope.Save();
            }
        }

        public static void DeletePreviousTestMortgageApplications(SearchDetail requestDTO)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkAnalysisEntities>(UnitOfWorkScopePurpose.Writing, new NullLogger(), true))
            {
                // Get the repos
                var AnalysisInputMortgageApplicationRepos = scope.GetGenericRepository<AnalysisInputMortgageApplication, Guid>();
                var AnalysisInputMortgageApplicationDetailRepos = scope.GetGenericRepository<AnalysisInputMortgageApplicationDetail, Guid>();

                // Find the applications to delete
                var list = AnalysisInputMortgageApplicationDetailRepos.FindAll(
                    s => s.Lender.Equals(requestDTO.Lender)
                        && s.Domain.Equals(requestDTO.Domain)
                        && s.MortgageApplicationNumber.Equals(requestDTO.MortgageApplicationNumber))
                        .ToList();

                // Do the deletion
                list.ForEach(it =>
                {
                    it.IsDeleted = true;
                    it.IsActive = false;
                    it.AnalysisInputMortgageApplication.IsDeleted = true;
                    it.AnalysisInputMortgageApplication.IsActive = false;
                    AnalysisInputMortgageApplicationDetailRepos.Update(it);
                    AnalysisInputMortgageApplicationRepos.Update(it.AnalysisInputMortgageApplication);
                });

                scope.Save();
            }
        }

        /// <summary>
        /// Compares two XML files to see if they are the same.
        /// </summary>
        /// <returns>Returns true if two XML files are functionally identical, ignoring comments, white space, and child
        /// order.</returns>
        public static bool XMLfilesIdentical(string originalFile, string finalFile)
        {
            var xmldiff = new XmlDiff();
            var r1 = XmlReader.Create(new StringReader(originalFile));
            var r2 = XmlReader.Create(new StringReader(finalFile));
            var sw = new StringWriter();
            var xw = new XmlTextWriter(sw) { Formatting = Formatting.Indented };

            xmldiff.Options = XmlDiffOptions.IgnorePI |
                XmlDiffOptions.IgnoreChildOrder |
                XmlDiffOptions.IgnoreComments |
                XmlDiffOptions.IgnoreNamespaces |
                XmlDiffOptions.IgnoreXmlDecl |
                XmlDiffOptions.IgnoreWhitespace;
            bool areIdentical = xmldiff.Compare(r1, r2, xw);

            string differences = sw.ToString();

            return areIdentical;
        }   
    }
}

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

namespace Bec.TargetFramework.Infrastructure.Test.Interfaces
{
    public interface IUnitTest
    {
        void TestCleanUp();
        void TestInitialise();
    }
}

