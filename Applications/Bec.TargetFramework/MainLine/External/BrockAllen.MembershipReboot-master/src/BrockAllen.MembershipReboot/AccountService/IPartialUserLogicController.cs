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
        Task<List<UserAccount>> GetAllUserAccountAsync();
        Task<UserAccount> GetBAUserAccountByUsernameAsync(string username);
        Task<UserAccount> GetBAUserAccountByEmailAsync(string email);
        Task<UserAccount> GetUserAccountAsync(Guid key);
        Task<UserAccount> GetBAUserAccountByEmailAndNotIDAsync(string email, Guid id);
        Task AddUserAccountAsync(UserAccount user);
        Task RemoveUserAccountAsync(UserAccount user);
    }
}
