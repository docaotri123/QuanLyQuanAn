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

        public void DeleteFood(int? idFood)
        {
            foodRepository.DeleteFood(idFood);
        }

        public IEnumerable<Food> GetFoodByCategory(int? idCategory)
        {
            return foodRepository.GetFoodByCategory(idCategory);
        }

        public IEnumerable<Food> GetFoods()
        {
            return foodRepository.GetFoods();
        }

        public void InsertFood(string nameFood, decimal price, int idCategory)
        {
            foodRepository.InsertFood(nameFood, price, idCategory);
        }

        public void UpdateFood(int? idFood, string nameFood, decimal price, int idCategory)
        {
            foodRepository.UpdateFood(idFood, nameFood, price, idCategory);
        }
    }
}
