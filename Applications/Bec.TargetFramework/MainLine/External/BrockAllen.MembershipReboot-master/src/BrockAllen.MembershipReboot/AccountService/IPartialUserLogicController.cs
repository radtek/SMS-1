using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrockAllen.MembershipReboot.AccountService
{
    public interface IPartialUserLogicController
    {
        Task UpdateUserAccountAsync(UserAccount user);
        List<UserAccount> GetAllUserAccount();
        UserAccount GetBAUserAccountByUsername(string username);
        UserAccount GetBAUserAccountByEmail(string email);
        UserAccount GetUserAccount(Guid key);
        UserAccount GetBAUserAccountByEmailAndNotID(string email, Guid id);
        Task AddUserAccountAsync(UserAccount user);
        UserAccount CreateUserAccount();
        Task RemoveUserAccountAsync(UserAccount user);
    }
}
