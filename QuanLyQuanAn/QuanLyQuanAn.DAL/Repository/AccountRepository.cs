﻿using QuanLyQuanAn.DAL.IRepository;
using QuanLyQuanAn.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyQuanAn.DAL.Repository
{
    public class AccountRepository : IAccountRepository, IDisposable
    {
        private readonly QuanLyQuanAnEntities db;
        public AccountRepository(QuanLyQuanAnEntities _db)
        {
            this.db = _db;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return db.Accounts.ToList();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool Login(string userName, string password)
        {
            if (db.Accounts.FirstOrDefault(m => m.userName.Equals(userName) && m.passWordUser.Equals(password))!=null)
                return true;
            return false;
        }

    }
}