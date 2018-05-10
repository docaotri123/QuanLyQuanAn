using QuanLyQuanAn.DAL.Model;
using QuanLyQuanAn.DAL.Repository;
using QuanLyQuanAn.BLL.IService;
using System.Collections.Generic;
using QuanLyQuanAn.DAL.IRepository;

namespace QuanLyQuanAn.BLL.Services
{
    public class TableFoodService : ITableFoodService
    {
        private ITableFoodRepository tableRepository;
        public TableFoodService()
        {
            this.tableRepository = new TableFoodRepository(new QuanLyQuanAnEntities());
        }
   

        public IEnumerable<TableFood> GetTableFoods()
        {
            return tableRepository.GetTableFoods();
        }
    }
}
