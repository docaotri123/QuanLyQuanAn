using QuanLyQuanAn.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanAn.DAL.Model;
using QuanLyQuanAn.DAL.ViewModel;

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

        public IEnumerable<TableFoodDetails_Result> TableFoodDetails(int? idTable)
        {
            return db.TableFoodDetails(idTable).ToList();
        }

        public void SetStatusTable(int? idTable, string status)
        {
            var result = db.TableFoods.SingleOrDefault(m => m.idTable == idTable);
            if (result != null)
            {
                result.statusTable = status;
                db.SaveChanges();
            }
        }
    }
}
