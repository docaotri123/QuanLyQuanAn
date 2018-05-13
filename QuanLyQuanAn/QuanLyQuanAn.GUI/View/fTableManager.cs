
using QuanLyQuanAn.BLL.Services;
using QuanLyQuanAn.DAL.Model;
using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyQuanAn
{
    public partial class fTableManager : Form
    {
        TableFoodService tableFood = new TableFoodService();
        FoodCategoryService foodCategory = new FoodCategoryService();
        FoodService food = new FoodService();
        BillService bill = new BillService();
        BillInfoService billInfo = new BillInfoService();
        
        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
        }
        
        private void LoadTable()
        {
            var listTable = tableFood.GetTableFoods();
            int x = 50;
            int y = 50;
            foreach(var item in listTable)
            {
                Button btn = new Button() { Width = x, Height = y };
                btn.Text = item.nameTable+Environment.NewLine+item.statusTable;
                btn.Click += btn_Click;
                btn.Tag = item;

                if (item.statusTable == "Trống")
                {
                    btn.BackColor = Color.Green;
                }
                else
                    btn.BackColor = Color.White;
                flpTable.Controls.Add(btn);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            int idTable = ((sender as Button).Tag as TableFood).idTable;
            lsvBill.Tag = (sender as Button).Tag;
            DisplayBill(idTable);
            LoadFoodCategories();
        }

        private void DisplayBill(int id)
        {
            lsvBill.Items.Clear();
            var listDetail = tableFood.TableFoodDetails(id);
            int Total = 0;
            CultureInfo culture = new CultureInfo("vi-VN");
            foreach (var item in listDetail)
            {
                ListViewItem lsvItem = new ListViewItem(item.nameFood);
                int Price =(int) item.price;
                lsvItem.SubItems.Add(Price.ToString());
                lsvItem.SubItems.Add(item.count.ToString());
                int TotalPrice =(int) (item.count * item.price);
                lsvItem.SubItems.Add(TotalPrice.ToString());
                Total += TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            //CultureInfo culture = new CultureInfo("en-US");
            //Thread.CurrentThread.CurrentCulture = culture;
           
            if (Total > 0)
                txbTotalPrice.Text = Total.ToString("c",culture);
            else
                txbTotalPrice.Text = "";

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile profile = new fAccountProfile();
            profile.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin admin = new fAdmin();
            admin.ShowDialog();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            FoodCategory selected = cb.SelectedItem as FoodCategory;
            id = selected.idFoodCategory;

            LoadFoodbyCategory(id);
        }

        private void LoadFoodCategories()
        {
            var listCategory = foodCategory.GetFoodCategories();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "nameFoodCategory";
        }

        private void LoadFoodbyCategory(int? id)
        {
            var listFood = food.GetFoodByCategory(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "nameFood";
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            //TableFood table = lsvBill.Tag as TableFood;
            //int idTable = (lsvBill.Tag as TableFood).idTable;
            int idTable = (lsvBill.Tag as TableFood).idTable;
            string status = (lsvBill.Tag as TableFood).statusTable;
            int? idFood = (cbFood.SelectedItem as Food).idFood;
            int? countFood = (int)(numFoodCount.Value);
            if(countFood<=0)
            {
                countFood = 1;
            }
            if (status!="Trống")
            {
                //Bàn đả đặt =>Them BillInfo
                //   int? idBill = bill.GetIdBillByTable(idTable).idBill;
                //trien
                int? idBill = bill.GetIdBillByTableAndStatusBill(idTable,false).idBill;
                //trien
                for (int i = 0; i < countFood; i++)
                {
                    billInfo.InsertFoodIntoBillInfo(idBill, idFood);
                }
                lsvBill.Items.Clear();
                flpTable.Controls.Clear();
                DisplayBill(idTable);
                LoadTable();
            }
            else
            {
                //Bàn trống=>Tạo moi Bill =>Them BillInfo
                tableFood.SetStatusTable(idTable, "Đã Đặt");
                DateTime? datetime = DateTime.Now;
                DateTime? datetimeOut = null;
                bill.InsertBillIntoTable(idTable, datetime, datetimeOut, 11000, false);
                //int? idBill = bill.GetIdBillByTable(idTable).idBill;
                //trien
                int? idBill = bill.GetIdBillByTableAndStatusBill(idTable,false).idBill;
                //trien
                for (int i = 0; i < countFood; i++)
                {
                    billInfo.InsertFoodIntoBillInfo(idBill, idFood);
                }
                lsvBill.Items.Clear();
                flpTable.Controls.Clear();
                DisplayBill(idTable);
                LoadTable();
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            int idTable = (lsvBill.Tag as TableFood).idTable;
            string status = (lsvBill.Tag as TableFood).statusTable;
            if (status != "Trống")
            {
                //Bàn đả đặt => Cap nhat trang thai ban, Bill
                //int? idBill = bill.GetIdBillByTable(idTable).idBill;
                //trien
                int? idBill = bill.GetIdBillByTableAndStatusBill(idTable,false).idBill;
                //trien
                bill.SetStatusBill(idBill, true);
                tableFood.SetStatusTable(idTable, "Trống");
                lsvBill.Items.Clear();
                flpTable.Controls.Clear();
                DisplayBill(idTable);
                LoadTable();

            }
            else
            {
                //ban trong => xuat thong bao ban trong
                MessageBox.Show("Ban trong khong thanh toan");
            }
        }

        //private void flpTable_Paint(object sender, PaintEventArgs e)
        //{

        //}
    }
}
