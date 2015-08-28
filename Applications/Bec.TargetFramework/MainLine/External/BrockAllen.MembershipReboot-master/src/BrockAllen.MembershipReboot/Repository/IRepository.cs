/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace BrockAllen.MembershipReboot
{
    public interface IRepository<T> : IDisposable
         where T : class
    {

        T GetByEmailNotID(string email, Guid id);

        T GetByVerificationKey(string key);

        List<T> GetAll();
        T Get(Guid key);
        T Create();
        void Add(T item);
        void Remove(T item);
        void Update(T item);

        T GetByUsername(string username);

        T GetByEmail(string email);
    }
}
