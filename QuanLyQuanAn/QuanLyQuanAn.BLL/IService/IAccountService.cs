
using QuanLyQuanAn.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.BLL.IService
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        bool Login(string userName, string password);
        Account GetAccountByUserName(string userName);
        bool UpdateAccount(string userName, string newPassword);



    }
}
