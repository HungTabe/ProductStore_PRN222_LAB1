using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IAccountRepository
    {
        AccountMember GetAccountById(string email);
        void AddAccount(AccountMember account);
        void UpdateAccount(AccountMember account);
        void DeleteAccount(string email);
        bool VerifyPassword(string email, string password);

    }
}
