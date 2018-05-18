using QuanLyQuanAn.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DAL.IRepository
{
    public interface IFoodRepository
    {
        IEnumerable<Food> GetFoodByCategory(int? idCategory);
        IEnumerable<Food> GetFoods();
        void InsertFood(string nameFood, decimal price,int idCategory);
    }
}
