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
namespace BrockAllen.MembershipReboot.Ef
{
    public class DefaultUserAccountRepository
           : IUserAccountRepository
    {
        private ChannelFactory<IUserLogic> m_UserLogicChannel;
        private IUserLogic m_UserLogic;

        public DefaultUserAccountRepository()
        {
            

            m_UserLogicChannel = new ChannelFactory<IUserLogic>(Bec.TargetFramework.Infrastructure.WCF.NetTcpBindingConfiguration.GetDefaultNetTcpBinding(), System.Configuration.ConfigurationManager.AppSettings["BusinessServiceBaseURL"] + "UserLogicService");
        }

        private void SetupUserLogicIfInBusinessService()
        {
            if (m_UserLogic == null &&  AppDomain.CurrentDomain.FriendlyName.Contains(".Hosts.BusinessService"))
                m_UserLogic = IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<IUserLogic>();
        }

        public List<UserAccount> GetAll()
        {
            var proxy = m_UserLogicChannel.CreateChannel();

            var result = proxy.GetAllUserAccount();

            ((ICommunicationObject)proxy).Close();

            return result;
        }

        public UserAccount GetByEmail(string email)
        {
            var proxy = m_UserLogicChannel.CreateChannel();

            var result = proxy.GetBAUserAccountByEmail(email);

            ((ICommunicationObject)proxy).Close();

            return result;
        }

        public UserAccount GetByEmailNotID(string email,Guid id)
        {
            var proxy = m_UserLogicChannel.CreateChannel();

            var result = proxy.GetBAUserAccountByEmailAndNotID(email,id);

            ((ICommunicationObject)proxy).Close();

            return result;
        }

        public UserAccount GetByUsername(string username)
        {
            SetupUserLogicIfInBusinessService();

            if(m_UserLogic == null)
            { 
                var proxy = m_UserLogicChannel.CreateChannel();

                var result = proxy.GetBAUserAccountByUsername(username);

                ((ICommunicationObject)proxy).Close();

                return result;
            }
            else
                return m_UserLogic.GetBAUserAccountByUsername(username);
        }

        public UserAccount GetByVerificationKey(string key)
        {
            var proxy = m_UserLogicChannel.CreateChannel();

            var result = proxy.GetBAUserAccountByVerificationKey(key);

            ((ICommunicationObject)proxy).Close();

            return result;
        }

        public UserAccount Get(System.Guid key)
        {
            var proxy = m_UserLogicChannel.CreateChannel();

            var result = proxy.GetUserAccount(key);

            ((ICommunicationObject)proxy).Close();

            return result;
        }

        public UserAccount Create()
        {
            var proxy = m_UserLogicChannel.CreateChannel();

            var result = proxy.CreateUserAccount();

            ((ICommunicationObject)proxy).Close();

            return result;
        }

        public void Add(UserAccount item)
        {
            var proxy = m_UserLogicChannel.CreateChannel();

            proxy.AddUserAccount(item);

            ((ICommunicationObject)proxy).Close();
        }

        public void Remove(UserAccount item)
        {
            var proxy = m_UserLogicChannel.CreateChannel();

            proxy.RemoveUserAccount(item);

            ((ICommunicationObject)proxy).Close();
        }

        public void Update(UserAccount item)
        {
            SetupUserLogicIfInBusinessService();

            if(m_UserLogic == null)
            { 
                var proxy = m_UserLogicChannel.CreateChannel();

               proxy.UpdateUserAccount(item);

               ((ICommunicationObject)proxy).Close();
            }
            else
                m_UserLogic.UpdateUserAccount(item);
        }

        public void Dispose()
        {
            if (m_UserLogicChannel != null)
                m_UserLogicChannel.TryDispose();
        }
    }
}
