using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BCrypt.Net;

namespace DataAccessObjects
{
    public class AccountDAO
    {
        private readonly MyStoreContext _context;

        public AccountDAO(MyStoreContext context)
        {
            _context = context;
        }

        public AccountMember GetAccountById(string email)
        {
            return _context.AccountMembers.FirstOrDefault(a => a.EmailAddress == email);
        }

        public void AddAccount(AccountMember account)
        {
            account.MemberPassword = BCrypt.Net.BCrypt.HashPassword(account.MemberPassword);
            _context.AccountMembers.Add(account);
            _context.SaveChanges();
        }

        public void UpdateAccount(AccountMember account)
        {
            if (!string.IsNullOrEmpty(account.MemberPassword))
            {
                account.MemberPassword = BCrypt.Net.BCrypt.HashPassword(account.MemberPassword);
            }
            _context.Entry(account).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteAccount(string email)
        {
            var account = _context.AccountMembers.Find(email);
            if (account != null)
            {
                _context.AccountMembers.Remove(account);
                _context.SaveChanges();
            }
        }

        public bool VerifyPassword(string email, string password)
        {
            var account = GetAccountById(email);
            return account != null && BCrypt.Net.BCrypt.Verify(password, account.MemberPassword);
        }
    }
}
