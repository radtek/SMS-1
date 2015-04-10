/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */


using System;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.ServiceModel;
using Autofac;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.IOC;
namespace BrockAllen.MembershipReboot.Ef
{
    public class DefaultUserAccountRepository
           : IUserAccountRepository
    {
        private IUserLogic m_UserLogic;

        public DefaultUserAccountRepository()
        {
            

        }

        private void SetupUserLogicIfInBusinessService()
        {
            if (m_UserLogic == null &&  AppDomain.CurrentDomain.FriendlyName.Contains(".Hosts.BusinessService"))
                m_UserLogic = IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<IUserLogic>();
        }

        public List<UserAccount> GetAll()
        {
            SetupUserLogicIfInBusinessService();

            return m_UserLogic.GetAllUserAccount();
        }

        public UserAccount GetByEmail(string email)
        {
            SetupUserLogicIfInBusinessService();

            return m_UserLogic.GetBAUserAccountByEmail(email);
        }

        public UserAccount GetByEmailNotID(string email,Guid id)
        {
            SetupUserLogicIfInBusinessService();

            return m_UserLogic.GetBAUserAccountByEmailAndNotID(email, id);
        }

        public UserAccount GetByUsername(string username)
        {
            SetupUserLogicIfInBusinessService();

            return m_UserLogic.GetBAUserAccountByUsername(username);
        }

        public UserAccount GetByVerificationKey(string key)
        {
            return m_UserLogic.GetBAUserAccountByVerificationKey(key);
        }

        public UserAccount Get(System.Guid key)
        {
            SetupUserLogicIfInBusinessService();

            return m_UserLogic.GetUserAccount(key);
        }

        public UserAccount Create()
        {
            SetupUserLogicIfInBusinessService();

            return m_UserLogic.CreateUserAccount();
        }

        public void Add(UserAccount item)
        {
            SetupUserLogicIfInBusinessService();

             m_UserLogic.AddUserAccount(item);
           
        }

        public void Remove(UserAccount item)
        {
            SetupUserLogicIfInBusinessService();

            m_UserLogic.RemoveUserAccount(item);
        }

        public void Update(UserAccount item)
        {
            SetupUserLogicIfInBusinessService();

            m_UserLogic.UpdateUserAccount(item);
        }

        public void Dispose()
        {
             
        }
    }
}
