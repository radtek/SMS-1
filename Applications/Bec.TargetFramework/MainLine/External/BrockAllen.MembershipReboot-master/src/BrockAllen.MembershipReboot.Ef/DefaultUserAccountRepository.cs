/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */


using System;
using System.Collections.Generic;
using System.ServiceModel;
using Autofac;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.IOC;

namespace BrockAllen.MembershipReboot.Ef
{
    public class DefaultUserAccountRepository: IUserAccountRepository
    {
        public UserLogicController UserLogic { get; set; }

        public DefaultUserAccountRepository()
        {

        }

        public List<UserAccount> GetAll()
        {
            return UserLogic.GetAllUserAccount();
        }

        public UserAccount GetByEmail(string email)
        {
            return UserLogic.GetBAUserAccountByEmail(email);
        }

        public UserAccount GetByEmailNotID(string email,Guid id)
        {
            return UserLogic.GetBAUserAccountByEmailAndNotID(email, id);
        }

        public UserAccount GetByUsername(string username)
        {
            return UserLogic.GetBAUserAccountByUsername(username);
        }

        public UserAccount GetByVerificationKey(string key)
        {
            return null;
        }

        public UserAccount Get(System.Guid key)
        {
            return UserLogic.GetUserAccount(key);
        }

        public UserAccount Create()
        {
            return UserLogic.CreateUserAccount();
        }

        public void Add(UserAccount item)
        {
            UserLogic.AddUserAccount(item);
           
        }

        public void Remove(UserAccount item)
        {
            UserLogic.RemoveUserAccount(item);
        }

        public void Update(UserAccount item)
        {
            UserLogic.UpdateUserAccount(item);
        }

        public void Dispose()
        {
             
        }
    }
}
