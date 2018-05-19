using QuanLyQuanAn.BLL.IService;
using QuanLyQuanAn.DAL.IRepository;
using QuanLyQuanAn.DAL.Model;
using QuanLyQuanAn.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.BLL.Services
{
    public class FoodCategoryService : IFoodCategoryService
    {
        private IFoodCategoryRepository foodCategory;
        public FoodCategoryService()
        {
            this.foodCategory = new FoodCategoryRepository(new QuanLyQuanAnEntities());
        }
        public IEnumerable<FoodCategory> GetFoodCategories()
        {
            return foodCategory.GetFoodCategories();
        }

        public int GetIDCategoryByName(string name)
        {
            return foodCategory.GetIDCategoryByName(name);
        }

        public string GetNameCategoryById(int? id)
        {
            return foodCategory.GetNameCategoryById(id);
        }
    }
}
