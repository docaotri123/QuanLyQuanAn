using QuanLyQuanAn.BLL.IService;
using QuanLyQuanAn.DAL.IRepository;
using QuanLyQuanAn.DAL.Model;
using QuanLyQuanAn.DAL.Repository;
using System;

namespace QuanLyQuanAn.BLL.Services
{
    public class BillService : IBillService
    {
        private IBillRepository billRepository;
        public BillService()
        {
            this.billRepository = new BillRepository(new QuanLyQuanAnEntities());
        }
        public Bill GetIdBillByTable(int? idTable)
        {
            return billRepository.GetIdBillByTable(idTable);
        }
    }
}
