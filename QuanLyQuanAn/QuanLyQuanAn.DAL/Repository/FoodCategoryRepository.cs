using QuanLyQuanAn.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanAn.DAL.Model;

namespace QuanLyQuanAn.DAL.Repository
{
    public class FoodCategoryRepository : IFoodCategoryRepository, IDisposable
    {
        private readonly QuanLyQuanAnEntities db;
        private bool disposed;

        public FoodCategoryRepository(QuanLyQuanAnEntities _db)
        {
            this.db = _db;
        }

        public IEnumerable<FoodCategory> GetFoodCategories()
        {
            return db.FoodCategories.ToList();
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
