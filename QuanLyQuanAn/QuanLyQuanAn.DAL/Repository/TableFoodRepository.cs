using QuanLyQuanAn.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanAn.DAL.Model;

namespace QuanLyQuanAn.DAL.Repository
{
    public class TableFoodRepository : ITableFoodRepository, IDisposable
    {
        private readonly QuanLyQuanAnEntities db;
        private bool disposed;

        public TableFoodRepository(QuanLyQuanAnEntities _db)
        {
            db = _db;
        }

 
        public IEnumerable<TableFood> GetTableFoods()
        {
            return db.TableFoods.ToList();
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
