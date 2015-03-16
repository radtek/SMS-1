using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bec.TargetFramework.Presentation.Controllers;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Presentation.Models;

namespace Bec.TargetFramework.Presentation.Tests.Controllers
{
    [TestClass]
    public class CompanyControllerTest
    {
        [TestMethod]
        public void GetCompanies()
        {
            // Arrange
            var controller = new CompanyController(new NullLogger());

            // Act
            var result = controller.ViewTemporaryCompanies() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);

            var model = result.Model as GetAllCompaniesVM;
            var verifiedCompanies = model.VerifiedCompanies as List<Company>;
            var unverifiedCompanies = model.UnverifiedCompanies as List<Company>;

            Assert.IsNotNull(verifiedCompanies);
            Assert.IsNotNull(unverifiedCompanies);
            Assert.AreEqual(20, verifiedCompanies.Count + unverifiedCompanies.Count);

            GetCompanies_Aux(verifiedCompanies, true);
            GetCompanies_Aux(unverifiedCompanies, false);
        }

        private static void GetCompanies_Aux(List<Company> companies, bool isVerified)
        {
            for (int i = 0; i < companies.Count; i++)
            {
                Assert.IsFalse(string.IsNullOrEmpty(companies[i].Name));
                Assert.IsFalse(string.IsNullOrEmpty(companies[i].Address1));
                Assert.IsFalse(string.IsNullOrEmpty(companies[i].PostCode));
                Assert.IsFalse(string.IsNullOrEmpty(companies[i].SysAdmin));
                Assert.IsTrue(companies[i].Tel.StartsWith("0208"));
                Assert.AreEqual(11, companies[i].Tel.Length);
                Assert.IsNotNull(companies[i].RecordCreated);
                Assert.IsFalse(companies[i].RecordCreated > DateTime.Now.AddDays(-1));
                Assert.IsFalse(string.IsNullOrEmpty(companies[i].Email));
                Assert.IsFalse(string.IsNullOrEmpty(companies[i].Regulator));
                Assert.AreEqual(isVerified, companies[i].IsVerified);
                if (!companies[i].IsVerified)
                    Assert.IsFalse(companies[i].IsPinCreated);

                if (companies[i].IsPinCreated)
                {
                    Assert.IsFalse(string.IsNullOrEmpty(companies[i].PinCode));
                    Assert.AreEqual(4, companies[i].PinCode.Length);
                    Assert.IsNotNull(companies[i].PinCreated);
                }
                else
                { 
                    Assert.IsTrue(string.IsNullOrEmpty(companies[i].PinCode));
                    Assert.IsNull(companies[i].PinCreated);
                }
            }
        }
    }
}
