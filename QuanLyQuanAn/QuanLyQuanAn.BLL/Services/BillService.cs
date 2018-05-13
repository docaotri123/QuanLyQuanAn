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

        public void InsertBillIntoTable(int? idTable, DateTime? dateCheckIn, DateTime? DateCheckOut, int Discount, bool status)
        {
            billRepository.InsertBillIntoTable(idTable, dateCheckIn, DateCheckOut, Discount, status);
        }

        public void SetStatusBill(int? idBill, bool status)
        {
            billRepository.SetStatusBill(idBill, status);
        }
    }
}
