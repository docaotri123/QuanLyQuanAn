﻿using QuanLyQuanAn.DAL.IRepository;
using QuanLyQuanAn.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DAL.Repository
{
    public class BillRepository : IBillRepository, IDisposable
    {
        private bool disposed;
        private readonly QuanLyQuanAnEntities db;
        public BillRepository(QuanLyQuanAnEntities _db)
        {
            this.db = _db;
        }


        public Bill GetIdBillByTable(int? idTable)
        {
            return db.Bills.FirstOrDefault(m => m.idTable == idTable);
        }

        //trien
        public Bill GetIdBillByTableAndStatusBill(int? idTable, bool status)
        {
            return db.Bills.FirstOrDefault(m => m.idTable == idTable && m.statusBill == status);
        }
        //trien
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

        public void InsertBillIntoTable(int? idTable, DateTime? dateCheckIn, DateTime? DateCheckOut, int Discount, bool status)
        {
            Bill x = new Bill();
            x.dateCheckIn = dateCheckIn;
            x.dateCheckOUt = DateCheckOut;
            x.discount = Discount;
            x.statusBill = status;
            x.idTable = idTable;
            db.Bills.Add(x);
            db.SaveChanges();

        }

        public void SetStatusBill(int? idBill, bool status)
        {
            var result = db.Bills.SingleOrDefault(m => m.idBill == idBill);

            if (result != null)
            {
                result.statusBill = status;
                db.SaveChanges();
            }
        }

        public void SetIdTableBill(int? idBill, int? idTable)
        {
            var result = db.Bills.SingleOrDefault(m => m.idBill == idBill);
            if(result!=null)
            {
                result.idTable = idTable;
                db.SaveChanges();
            }
        }
    }
}
