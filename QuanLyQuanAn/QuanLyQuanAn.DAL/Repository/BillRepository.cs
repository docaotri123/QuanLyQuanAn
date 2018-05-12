using QuanLyQuanAn.DAL.IRepository;
using QuanLyQuanAn.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DAL.Repository
{
    public class BillRepository : IBillRepository, IDisposable
    {
        private bool disposed;
        private readonly QuanLyQuanAnEntities db;
        public BillRepository(QuanLyQuanAnEntities _db)
        {
            this.db = _db;
        }


        public Bill GetIdBillByTable(int? idTable)
        {
            return db.Bills.FirstOrDefault(m => m.idTable == idTable);
        }
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
    }
}
