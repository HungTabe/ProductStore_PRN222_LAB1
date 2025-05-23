using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool VerifyPassword(string email, string password) => _accountRepository.VerifyPassword(email, password);
        public AccountMember GetAccountById(string email) => _accountRepository.GetAccountById(email);
        public void AddAccount(AccountMember account) => _accountRepository.AddAccount(account);
        public void UpdateAccount(AccountMember account) => _accountRepository.UpdateAccount(account);
        public void DeleteAccount(string email) => _accountRepository.DeleteAccount(email);
    }
}
