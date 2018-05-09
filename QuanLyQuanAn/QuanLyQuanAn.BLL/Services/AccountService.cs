using System;
using System.Collections.Generic;
using QuanLyQuanAn.DAL.IRepository;
using QuanLyQuanAn.DAL.Model;
using QuanLyQuanAn.DAL.Repository;
using QuanLyQuanAn.BLL.IService;

namespace QuanLyQuanAn.BLL
{
    public class AccountService :IAccountService
    {
        private IAccountRepository accountRepository;
        public AccountService()
        {
            this.accountRepository = new AccountRepository(new QuanLyQuanAnEntities());
        }
        public IEnumerable<Account> GetAccounts()
        {
            return accountRepository.GetAccounts();
        }
        public bool Login(string userName, string password)
        {
            return accountRepository.Login(userName,password);
        }

    }

}
