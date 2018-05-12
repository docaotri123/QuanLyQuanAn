using QuanLyQuanAn.BLL.IService;
using QuanLyQuanAn.DAL.IRepository;
using QuanLyQuanAn.DAL.Model;
using QuanLyQuanAn.DAL.Repository;
using System;
using System.Collections.Generic;

namespace QuanLyQuanAn.BLL.Services
{
    public class FoodService : IFoodService
    {
        private IFoodRepository foodRepository;
        public FoodService()
        {
            this.foodRepository = new FoodRepository(new QuanLyQuanAnEntities());
        }

        public IEnumerable<Food> GetFoodByCategory(int? idCategory)
        {
            return foodRepository.GetFoodByCategory(idCategory);
        }
    }
}
