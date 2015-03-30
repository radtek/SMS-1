using System;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using Autofac;
using Autofac.Integration.Wcf;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Services;
using Bec.TargetFramework.Entities.Experian;
using Bec.TargetFramework.Infrastructure.Serilog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bec.TargetFramework.Entities;
using System.ComponentModel.DataAnnotations;
using BrockAllen.MembershipReboot;
using System.Threading;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.Business.Tests.Logic
{
    [TestClass]
    public class UserLogicTests
    {
        public static IContainer m_IocContainer;
        public static ServiceHost m_UserLogicService;
        const string TESTUSER_GUID = "c04500f5-702a-4d07-bf3a-526b0f3dc560";
        const string TESTUSER = "testuser1";
        const string TESTUSER_EMAIL = "b@gmail.com";
        const string TESTADMIN = "TestAdmin";
        const string TESTADMIN1 = "TestAdmin1";
        const string TESTADMIN_PASSWORD = "Registeration#";
        private Guid Test_Guid = new Guid(TESTUSER_GUID);
        const int ALLOWED_NUMBER_OF_ATTEMPTS = 6;


        [ClassInitialize()]
        public static void SetupTestClass(TestContext context)
        {
            try
            {
                InitialiseIOC();
                System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var serviceModel = ServiceModelSectionGroup.GetSectionGroup(config);

                m_UserLogicService = new ServiceHost(typeof(UserLogicService));
                m_UserLogicService.AddDependencyInjectionBehavior(typeof(IUserLogic), m_IocContainer);
                m_UserLogicService.Open();
            }
            catch (Exception ex)
            {
                if (Serilog.Log.Logger == null)
                    new SerilogLogger(true, false, "BusinessService").Error(ex);
                else
                    Serilog.Log.Logger.Error(ex, ex.Message, null);
            }
        }

        private static void InitialiseIOC()
        {
            ContainerBuilder builder = new ContainerBuilder();

            var registrar = new Bec.TargetFramework.Hosts.BusinessService.IOC.DependencyRegistrar();

            registrar.Register(builder, null);

            m_IocContainer = builder.Build();
        }

        [TestMethod()]
        public void Authenticate_CheckFailedMessage_UserSupplied_PasswordSupplied()
        {
            Test_Fail_UserName_Password("b", "b");
        }

        [TestMethod()]
        public void Authenticate_CheckFailedMessage_UserSupplied_PasswordBlank()
        {
            Test_Fail_UserName_Password("b", "");
        }

        [TestMethod()]
        public void Authenticate_CheckFailedMessage_UserBlank_PasswordSupplied()
        {
            Test_Fail_UserName_Password("", "b");
        }

        [TestMethod()]
        public void Authenticate_CheckFailedMessage_UserBlank_PasswordBlank()
        {
            Test_Fail_UserName_Password("", "");
        }

        [TestMethod()]
        public void Authenticate_CheckFailedMessage_UserNull_PasswordNull()
        {
            Test_Fail_UserName_Password(null, null);
        }

        [TestMethod()]
        public void Authenticate_CheckFailedMessage_UserBlank_PasswordNull()
        {
            Test_Fail_UserName_Password("", null);
        }

        [TestMethod()]
        public void Authenticate_CheckFailedMessage_UserNull_PasswordBlank()
        {
            Test_Fail_UserName_Password(null, "");
        }

        private void Test_Fail_UserName_Password(string username, string password)
        {
            var serviceInstance = m_IocContainer.Resolve<IUserLogic>();

            var result = serviceInstance.AuthenticateUser(username, password);

            Assert.IsFalse(result.valid);
            Assert.AreEqual("Invalid Username or Password", result.validationMessage);
        }

        [TestMethod()]
        public void Authenticate_CreateAccount_CheckPassword_Length()
        {
            var serviceInstance = m_IocContainer.Resolve<IUserLogic>();

            const string SHORT_PASSWORD = "password";
            bool errorThrown = false;
            try
            {
                serviceInstance.CreateAccount(TESTUSER, SHORT_PASSWORD, TESTUSER_EMAIL, true, Test_Guid);
            }
            catch (ValidationException ex)
            {
                errorThrown = true;
                Assert.AreEqual("Password must be at least 10 characters long.", ex.Message);
            }
            Assert.IsTrue(errorThrown);
        }

        [TestMethod()]
        public void Authenticate_CreateAccount_CheckPassword_Invalid()
        {
            var serviceInstance = m_IocContainer.Resolve<IUserLogic>();

            const string INVALID_PASSWORD = "password123";
            bool errorThrown = false;
            try
            {
                serviceInstance.CreateAccount(TESTUSER, INVALID_PASSWORD, TESTUSER_EMAIL, true, Test_Guid);
            }
            catch (ValidationException ex)
            {
                errorThrown = true;
                Assert.AreEqual("Password must contain at least 3 of the following characters: one upper, one lower, one digit and one other.", ex.Message);
            }

            Assert.IsTrue(errorThrown);
        }

        [TestMethod()]
        public void Authenticate_CreateTemporaryAccount()
        {
            //var serviceInstance = m_IocContainer.Resolve<IUserLogic>();

            //// Delete the test user account in case it is still there from a previous test
            //if (serviceInstance.DoesUserExist(Test_Guid, true))
            //    serviceInstance.DeleteAccount(Test_Guid);
            
            //// Create the temporary user
            //const string VALID_PASSWORD = "Password123";
            //serviceInstance.CreateTemporaryAccount(TESTUSER_EMAIL, VALID_PASSWORD, true, Test_Guid);

            //// Validate it was created
            //Assert.IsTrue(serviceInstance.DoesUserExist(Test_Guid, true));

            //// Get the user, check it exists
            //var userAccount = serviceInstance.GetUserAccount(Test_Guid);
            //Assert.IsNotNull(userAccount);

            //// Test authenticate logic
            //var result = serviceInstance.AuthenticateUser(userAccount.Username, VALID_PASSWORD);
            //Assert.IsTrue(result.Result.valid);
            //Assert.AreEqual("Authentication success", result.validationMessage);

            //// Clean up the temporary user
            //serviceInstance.DeleteAccount(Test_Guid);
        }

        [TestMethod()]
        public void Authenticate_Check_TestAdmin_Account()
        {
            //var serviceInstance = m_IocContainer.Resolve<IUserLogic>();

            //// Get the user account
            //var account = serviceInstance.GetUserAccountByUsername(TESTADMIN);
            //Assert.IsNotNull(account);
            //Assert.AreEqual("Applications@beconsultancy.co.uk", account.Email);

            //// Check the exists function
            //Assert.IsTrue(serviceInstance.DoesUserExist(account.ID, false));
            
            //// Test authenticate logic
            //var result = serviceInstance.AuthenticateUser(TESTADMIN, "");
            //Assert.IsFalse(result.valid);
            //result = serviceInstance.AuthenticateUser(TESTADMIN, "boo");
            //Assert.IsFalse(result.valid);
            //result = serviceInstance.AuthenticateUser(TESTADMIN, TESTADMIN_PASSWORD);
            //Assert.IsTrue(result.valid);
        }

        [TestMethod()]
        public void Authenticate_CheckFailed_MultipleAttempts()
        {
            var serviceInstance = m_IocContainer.Resolve<IUserLogic>();

            // Get the user account
            var account = serviceInstance.GetUserAccountByUsername(TESTADMIN);
            
            // Make sure the number of unsuccessful attempts is at zero
            serviceInstance.LockOrUnlockUser(account.ID, false);

            // Try 5 times
            //UserLoginValidation result = null;
            //for (int i = 1; i < ALLOWED_NUMBER_OF_ATTEMPTS; i++)
            //{
            //    result = serviceInstance.AuthenticateUser(TESTADMIN, "dsd");
            //    Assert.IsFalse(result.valid);
            //    Assert.AreEqual("Invalid Username or Password", result.validationMessage);
            //}

            //// Do it one more time, this should trigger the lock out.
            //result = serviceInstance.AuthenticateUser(TESTADMIN, "dsd");
            //Assert.IsFalse(result.valid);
            //Assert.AreEqual("Your account has been locked for 30 minutes due to too many failed login attempts", result.validationMessage);

            // Check the account is locked
            account = serviceInstance.GetUserAccountByUsername(TESTADMIN);
            Assert.AreEqual(ALLOWED_NUMBER_OF_ATTEMPTS, account.FailedLoginCount);

            // Unlock the account
            serviceInstance.LockOrUnlockUser(account.ID, false);

            // Check the account is unlocked
            account = serviceInstance.GetUserAccountByUsername(TESTADMIN);
            Assert.AreEqual(0, account.FailedLoginCount);
        }

        [TestMethod()]
        public void Authenticate_CheckFailed_AccountLockoutDuration()
        {
            // Check the default lock out duration is correct.
            var settings = SecuritySettings.FromConfiguration();
            Assert.AreEqual(TimeSpan.FromMinutes(30), settings.AccountLockoutDuration);            
        }

        [TestMethod()]
        public void Authenticate_CheckFailed_MultipleAttempts_DifferentUsers()
        {
            //var serviceInstance = m_IocContainer.Resolve<IUserLogic>();

            //// Get the user accounts
            //var account = serviceInstance.GetUserAccountByUsername(TESTADMIN);
            //var account1 = serviceInstance.GetUserAccountByUsername(TESTADMIN1);

            //// Make sure the number of unsuccessful attempts is at zero
            //serviceInstance.LockOrUnlockUser(account.ID, false);
            //serviceInstance.LockOrUnlockUser(account1.ID, false);

            //// Lock the first account
            //for (int i = 1; i <= ALLOWED_NUMBER_OF_ATTEMPTS; i++)
            //{
            //    serviceInstance.AuthenticateUser(TESTADMIN, "dsd");
            //}

            //// Try to login to the other account with correct password
            //var result = serviceInstance.AuthenticateUser(TESTADMIN1, TESTADMIN_PASSWORD);
            //Assert.IsTrue(result.valid);
            
            //// Try the first account again, with correct credentials, this should still fail
            //result = serviceInstance.AuthenticateUser(TESTADMIN, TESTADMIN_PASSWORD);
            //Assert.IsFalse(result.valid);
            //Assert.AreEqual("Your account has been locked for 30 minutes due to too many failed login attempts", result.validationMessage);

            //// Unlock the account
            //serviceInstance.LockOrUnlockUser(account.ID, false);
            //serviceInstance.LockOrUnlockUser(account1.ID, false);
        }

        [TestMethod()]
        public void Authenticate_CheckFailed_MultipleAttempts_BugAfterTimeout()
        {
            var serviceInstance = m_IocContainer.Resolve<IUserLogic>();

            // Get the user accounts
            var account = serviceInstance.GetUserAccountByUsername(TESTADMIN);

            // Make sure the number of unsuccessful attempts is at zero
            serviceInstance.LockOrUnlockUser(account.ID, false);

            // Lock the account
            for (int i = 1; i <= ALLOWED_NUMBER_OF_ATTEMPTS; i++)
            {
                serviceInstance.AuthenticateUser(TESTADMIN, "dsd");
            }

            // Mimic that we waited for 30 mins so we can try the log in again
            AlterLastFailedLoginDate(account.ID);

            UserLoginValidation result;

            // Try the login again, with incorrect password. This should let you do six attempts again
            //for (int i = 1; i < ALLOWED_NUMBER_OF_ATTEMPTS; i++)
            //{
            //    result = serviceInstance.AuthenticateUser(TESTADMIN, "dsd");
            //    Assert.IsFalse(result.valid);
            //    Assert.AreEqual("Invalid Username or Password", result.validationMessage);
            //}

            //// One more time should lock the account again
            //result = serviceInstance.AuthenticateUser(TESTADMIN, "dsd");
            //Assert.IsFalse(result.valid);
            //Assert.AreEqual("Your account has been locked for 30 minutes due to too many failed login attempts", result.validationMessage);

            //// Unlock the account to tidy up
            //serviceInstance.LockOrUnlockUser(account.ID, false);
        }

        private void AlterLastFailedLoginDate(Guid userID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, new NullLogger(), true))
            {                
                var repos = scope.GetGenericRepository<Bec.TargetFramework.Data.UserAccount, Guid>();
                var userAccount = new Bec.TargetFramework.Data.UserAccount();
                userAccount = repos.Get(userID);
                userAccount.LastFailedLogin = DateTime.Now.AddHours(-1);

                repos.Update(userAccount);
                scope.Save();
            }
        }
    }
}
