using QuanLyQuanAn.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.BLL.IService
{
    public interface IFoodCategoryService
    {
        IEnumerable<FoodCategory> GetFoodCategories();
        int GetIDCategoryByName(string name);
        string GetNameCategoryById(int? id);
    }
}
