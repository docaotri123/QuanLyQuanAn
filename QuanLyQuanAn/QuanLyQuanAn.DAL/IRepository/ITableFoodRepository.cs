using QuanLyQuanAn.DAL.Model;
using QuanLyQuanAn.DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DAL.IRepository
{
    public interface ITableFoodRepository
    {
        IEnumerable<TableFood> GetTableFoods();
        IEnumerable<TableFoodDetails_Result> TableFoodDetails(int? idTable);
    }
}
