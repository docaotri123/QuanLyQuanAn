using QuanLyQuanAn.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanAn.DAL.Model;

namespace QuanLyQuanAn.DAL.Repository
{
    public class FoodRepository : IFoodRepository, IDisposable
    {
        private bool disposed;
        private readonly QuanLyQuanAnEntities db;
        public FoodRepository(QuanLyQuanAnEntities _db)
        {
            this.db = _db;
        }

        public IEnumerable<Food> GetFoodByCategory(int? idCategory)
        {
            return db.Foods.Where(m=>m.idFoodCategory==idCategory).ToList();
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

        public IEnumerable<Food> GetFoods()
        {
            return db.Foods.ToList();
        }

        public void InsertFood(string nameFood, decimal price, int idCategory)
        {
            Food f = new Food();
            f.nameFood = nameFood;
            f.price = price;
            f.idFoodCategory = idCategory;

            db.Foods.Add(f);
            db.SaveChanges();
        }
    }
}
