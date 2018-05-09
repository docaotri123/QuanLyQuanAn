using QuanLyQuanAn.DAL.Model;
using System;
using System.Collections.Generic;

namespace QuanLyQuanAn.DAL.IRepository
{
    public interface IAccountRepository: IDisposable
    {
        IEnumerable<Account> GetAccounts();
        bool Login(string userName, string password);
    }
}
