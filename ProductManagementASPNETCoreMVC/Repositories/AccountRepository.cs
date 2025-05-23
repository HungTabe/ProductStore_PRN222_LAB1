using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDAO _accountDAO;

        public AccountRepository(AccountDAO accountDAO)
        {
            _accountDAO = accountDAO;
        }

        public bool VerifyPassword(string email, string password) => _accountDAO.VerifyPassword(email, password);
        public AccountMember GetAccountById(string email) => _accountDAO.GetAccountById(email);
        public void AddAccount(AccountMember account) => _accountDAO.AddAccount(account);
        public void UpdateAccount(AccountMember account) => _accountDAO.UpdateAccount(account);
        public void DeleteAccount(string email) => _accountDAO.DeleteAccount(email);
    }
}
